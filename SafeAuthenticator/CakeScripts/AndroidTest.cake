#load "Utility.cake"

#addin nuget:?package=Cake.Android.Adb&version=3.0.0
#addin nuget:?package=Cake.Android.AvdManager&version=1.0.3
#addin nuget:?package=Cake.FileHelpers

var ANDROID_PROJ = "../Tests/SafeAuth.Tests.Android/SafeAuth.Tests.Android.csproj";
var ANDROID_APK_PATH = "../Tests/SafeAuth.Tests.Android/bin/Debug/com.safe.auth.tests-Signed.apk";
var ANDROID_TEST_RESULTS_PATH = "../Tests/SafeAuth.Tests.Android/AndroidTestResult.xml";
var ANDROID_AVD = "SafeEmulator";
var ANDROID_PKG_NAME = "com.safe.auth.tests";
var ANDROID_EMU_TARGET = EnvironmentVariable("ANDROID_EMU_TARGET") ?? "system-images;android-26;google_apis;x86";
var ANDROID_EMU_DEVICE = EnvironmentVariable("ANDROID_EMU_DEVICE") ?? "Nexus 6P";

var ANDROID_TCP_LISTEN_HOST = System.Net.IPAddress.Any;
var ANDROID_TCP_LISTEN_PORT = 10500;
var ANDROID_HOME = EnvironmentVariable("ANDROID_HOME");


Task ("Build-Android")
    .Does (() =>
{
    // Nuget restore
    MSBuild (ANDROID_PROJ, c => {
        c.Configuration = "Debug";
        c.Targets.Clear();
        c.Targets.Add("Restore");
        c.SetVerbosity(Verbosity.Minimal);
    });

    // Build the app in debug mode
    // needs to be debug so unit tests get discovered
    MSBuild (ANDROID_PROJ, c => {
        c.Configuration = "Debug";
        c.Targets.Clear();
        c.Targets.Add("Rebuild");
        c.SetVerbosity(Verbosity.Minimal);
    });
});


Task ("Test-Android-Emu")
    .IsDependentOn ("Build-Android")
    .Does (() =>
{        
    if (EnvironmentVariable("ANDROID_SKIP_AVD_CREATE") == null) {
        var avdSettings = new AndroidAvdManagerToolSettings  { SdkRoot = ANDROID_HOME };

        Information("after if ");

        // Create the AVD if necessary
        Information ("Creating AVD if necessary: {0}...", ANDROID_AVD);     
        if (!AndroidAvdListAvds (avdSettings).Any (a => a.Name == ANDROID_AVD))
            AndroidAvdCreate (ANDROID_AVD, ANDROID_EMU_TARGET, ANDROID_EMU_DEVICE, force: true, settings: avdSettings);
    }
    // We need to find `emulator` and the best way is to try within a specified ANDROID_HOME
    var emulatorExt = IsRunningOnWindows() ? ".exe" : "";
    string emulatorPath = "emulator" + emulatorExt;
            
    if (ANDROID_HOME != null) {
        var andHome = new DirectoryPath(ANDROID_HOME);
        if (DirectoryExists(andHome)) {
            emulatorPath = MakeAbsolute(andHome.Combine("tools").CombineWithFilePath("emulator" + emulatorExt)).FullPath;
            if (!FileExists(emulatorPath))
                emulatorPath = MakeAbsolute(andHome.Combine("emulator").CombineWithFilePath("emulator" + emulatorExt)).FullPath;
            if (!FileExists(emulatorPath))
                emulatorPath = "emulator" + emulatorExt;
        }
    }
         
    // Start up the emulator by name
    var emu = StartAndReturnProcess (emulatorPath, new ProcessSettings { 
        Arguments = $"-avd {ANDROID_AVD}" });
        var adbSettings = new AdbToolSettings { SdkRoot = ANDROID_HOME };
        
        
        // Keep checking adb for an emulator with an AVD name matching the one we just started
        var emuSerial = string.Empty;
        for (int i = 0; i < 100; i++) {
        foreach (var device in AdbDevices(adbSettings).Where(d => d.Serial.StartsWith("emulator-"))) {
            if (AdbGetAvdName(device.Serial).Equals(ANDROID_AVD, StringComparison.OrdinalIgnoreCase)) {
                emuSerial = device.Serial;
                break;
            }
        }

        if (!string.IsNullOrEmpty(emuSerial))
            break;
        else
            System.Threading.Thread.Sleep(1000);
    }

    Information ("Matched ADB Serial: {0}", emuSerial);
    adbSettings = new AdbToolSettings { SdkRoot = ANDROID_HOME, Serial = emuSerial };

    // Wait for the emulator to enter a 'booted' state
    AdbWaitForEmulatorToBoot(TimeSpan.FromSeconds(100), adbSettings);
    Information ("Emulator finished booting.");

    // Try uninstalling the existing package (if installed)
    try { 
        AdbUninstall (ANDROID_PKG_NAME, false, adbSettings);
        Information ("Uninstalled old: {0}", ANDROID_PKG_NAME);
    } catch { }

    // Use the Install target to push the app onto emulator
    MSBuild (ANDROID_PROJ, c => {
        c.Configuration = "Debug";
        c.Properties["AdbTarget"] = new List<string> { "-s " + emuSerial };
        c.Targets.Clear();
        c.Targets.Add("Install");
        c.SetVerbosity(Verbosity.Minimal);
    });

    //start the TCP Test results listener
    Information("Started TCP Test Results Listener on port: {0}", ANDROID_TCP_LISTEN_PORT);
    var tcpListenerTask = DownloadTcpTextAsync(ANDROID_TCP_LISTEN_HOST,ANDROID_TCP_LISTEN_PORT,ANDROID_TEST_RESULTS_PATH);

    // Launch the app on the emulator
    AdbShell ($"am start -n {ANDROID_PKG_NAME}/{ANDROID_PKG_NAME}.MainActivity", adbSettings);    
        
    // // Wait for the test results to come back
    Information("Waiting for tests...");
    tcpListenerTask.Wait ();

    // Close emulator    
    emu.Kill();

})
.ReportError(exception =>
{  
    Information(exception.Message);
});
