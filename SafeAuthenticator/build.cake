// #addin Cake.Curl
#addin nuget:?package=Cake.Android.SdkManager
#addin nuget:?package=Cake.Android.Adb&version=3.0.0

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var ANDROID_HOME = EnvironmentVariable ("ANDROID_HOME") ?? Argument ("android_home", "");

var ANDROID_AVD = "SafeEmulator";
var ANDROID_EMU_TARGET = EnvironmentVariable("ANDROID_EMU_TARGET") ?? "system-images;android-26;google_apis;x86";
var ANDROID_EMU_DEVICE = EnvironmentVariable("ANDROID_EMU_DEVICE") ?? "Nexus 6P";

var ANDROID_TCP_LISTEN_HOST = System.Net.IPAddress.Any;
var ANDROID_TCP_LISTEN_PORT = 10500;

Task ("test-android-emu")
    .Does (async() =>
{        
  	var androidSdkSettings = new AndroidSdkManagerToolSettings { 
		SdkRoot = ANDROID_HOME,
		SkipVersionCheck = true
	};

	try { AcceptLicenses (androidSdkSettings); } catch { }

	AndroidSdkManagerInstall (new [] {
			"platforms;android-26"
		}, androidSdkSettings);

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

    // // Try uninstalling the existing package (if installed)
    // try { 
    //     AdbUninstall (ANDROID_PKG_NAME, false, adbSettings);
    //     Information ("Uninstalled old: {0}", ANDROID_PKG_NAME);
    // } catch { }

    // // Use the Install target to push the app onto emulator
    // MSBuild (ANDROID_PROJ, c => {
    //     c.Configuration = "Debug";
    //     c.Properties["AdbTarget"] = new List<string> { "-s " + emuSerial };
    //     c.Targets.Clear();
    //     c.Targets.Add("Install");
    // });

    // //start the TCP Test results listener
    // Information("Started TCP Test Results Listener on port: {0}", ANDROID_TCP_LISTEN_PORT);
    // var tcpListenerTask = DownloadTcpTextAsync(ANDROID_TCP_LISTEN_HOST,ANDROID_TCP_LISTEN_PORT,ANDROID_TEST_RESULTS_PATH);

    // // Launch the app on the emulator
    // AdbShell ($"am start -n {ANDROID_PKG_NAME}/{ANDROID_PKG_NAME}.MainActivity", adbSettings);    
        
    // // // Wait for the test results to come back
    // Information("Waiting for tests...");
    // tcpListenerTask.Wait ();

    // Close emulator    
    emu.Kill();

})
.ReportError(exception =>
{  
    Information(exception.Message);
});

Task("Default")
  .IsDependentOn("AndroidSDK")
  .Does(() => {
  });




RunTarget(target);


// var ANDROID_X86 = "android-x86";
// var ANDROID_ARMEABI_V7A = "android-armeabiv7a";
// var ANDROID_ARCHITECTURES = new string[] {
//   ANDROID_X86,
//   ANDROID_ARMEABI_V7A
// };
// var IOS_ARCHITECTURES = new string[] {
//   "ios"
// };
// var All_ARCHITECTURES = new string[][] {
//   ANDROID_ARCHITECTURES,
//   IOS_ARCHITECTURES
// };
// enum Environment {
//   Android,
//   iOS
// }

// // --------------------------------------------------------------------------------
// // Native lib directory
// // --------------------------------------------------------------------------------

// var TAG = "6be5558";
// var androidLibDirectory = Directory("SafeAuthenticator.Android/lib/");
// var iosLibDirectory = Directory("SafeAuthenticator.iOS/Native References/");
// var nativeLibDirectory = Directory(string.Concat(System.IO.Path.GetTempPath(), "nativeauthlibs"));

// --------------------------------------------------------------------------------
// Download Libs
// --------------------------------------------------------------------------------

// Task("Download-Libs")
//   .Does(() => {
//     foreach(var item in Enum.GetValues(typeof(Environment))) {
//       string[] targets = null;
//       Information(string.Format("\n{0} ", item));
//       switch (item) 
//       {
//       case Environment.Android:
//         targets = ANDROID_ARCHITECTURES;
//         break;
//       case Environment.iOS:
//         targets = IOS_ARCHITECTURES;
//         break;
//       }

//       foreach(var target in targets) {
//         var targetDirectory = string.Format("{0}/{1}/{2}", nativeLibDirectory.Path, item, target);
//         var zipFilename = string.Format("safe_authenticator-{0}-{1}.zip", TAG, target);
//         var zipDownloadUrl = string.Format("https://s3.eu-west-2.amazonaws.com/safe-client-libs/{0}", zipFilename);
//         var zipSavePath = string.Format("{0}/{1}/{2}/{3}", nativeLibDirectory.Path, item, target, zipFilename);

//         Information("Downloading : {0}", zipFilename);

//         if(!DirectoryExists(targetDirectory))
//           CreateDirectory(targetDirectory);

//         if(!FileExists(zipSavePath)) 
//         {
//           CurlDownloadFiles(
//             new [] {
//               new Uri(zipDownloadUrl)
//             },
//             new CurlDownloadSettings {
//               OutputPaths = new FilePath[] {
//                 zipSavePath
//               }
//             });
//         }
//         else
//         {
//           Information("File already exists");
//         }
//       }
//     }
//   })
//   .ReportError(exception => {
//     Information(exception.Message);
//   });

// Task("UnZip-Libs")
//   .IsDependentOn("Download-Libs")
//   .Does(() => {
//     foreach(var item in Enum.GetValues(typeof(Environment))) {
//       string[] targets = null;
//       var outputDirectory = string.Empty;
//       Information(string.Format("\n {0} ", item));
//       switch (item)
//       {
//       case Environment.Android:
//         targets = ANDROID_ARCHITECTURES;
//         outputDirectory = androidLibDirectory.Path.FullPath.ToString();
//         break;
//       case Environment.iOS:
//         targets = IOS_ARCHITECTURES;
//         outputDirectory = iosLibDirectory.Path.FullPath.ToString();
//         break;
//       }

//       CleanDirectories(outputDirectory);

//       foreach(var target in targets) {
//         var zipDirectorySource = Directory(string.Format("{0}/{1}/{2}", nativeLibDirectory.Path, item, target));
//         var zipFiles = GetFiles(string.Format("{0}/*.*", zipDirectorySource));
//         foreach(var zip in zipFiles) {
//           var filename = zip.GetFilename();
//           Information(" Unzipping : " + filename);
//           var platformOutputDirectory = new StringBuilder();
//           platformOutputDirectory.Append(outputDirectory);

//           if(target.Equals(ANDROID_X86))
//             platformOutputDirectory.Append("/x86");
//           else if(target.Equals(ANDROID_ARMEABI_V7A))
//             platformOutputDirectory.Append("/armeabi-v7a");

//           Unzip(zip, platformOutputDirectory.ToString());
          
//           if(target.Equals(ANDROID_X86) || target.Equals(ANDROID_ARMEABI_V7A))
//           {
//             var aFilePath = platformOutputDirectory.ToString() + "/libsafe_authenticator.a";
//             DeleteFile(aFilePath);
//           } 
//         }
//       }
//     }
//   })
//   .ReportError(exception => {
//     Information(exception.Message);
//   });

// Task("Default")
//   .IsDependentOn("UnZip-Libs")
//   .Does(() => {

//   });
