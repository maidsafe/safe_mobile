#load "AndroidTest.cake"
#load "IOSTest.cake"
#load "Utility.cake"
#addin Cake.Curl
using System.Linq;

var target = Argument ("target", "Default");
var configuration = Argument ("configuration", "Release");
var ANDROID_X86 = "android-x86";
var ANDROID_ARMEABI_V7A = "android-armeabiv7a";
var LibTypes = new string[] {
  "-mock",
  ""
};

var ANDROID_ARCHITECTURES = new string[] {
  ANDROID_X86,
  ANDROID_ARMEABI_V7A
};
var IOS_ARCHITECTURES = new string[] {
  "ios"
};
var All_ARCHITECTURES = new string[][] {
  ANDROID_ARCHITECTURES,
  IOS_ARCHITECTURES
};
enum Environment {
  Android,
  iOS
}

// --------------------------------------------------------------------------------
// Native lib directory
// --------------------------------------------------------------------------------

var TAG = "6be5558";
var nativeLibDirectory = Directory (string.Concat (System.IO.Path.GetTempPath (), "nativeauthlibs"));
var androidLibDirectory = Directory ("../SafeAuthenticator.Android/lib/");
var iosLibDirectory = Directory ("../SafeAuthenticator.iOS/Native References/");
var androidTestLibDirectory = Directory ("../Tests/SafeAuth.Tests.Android/lib/");
var iosTestLibDirectory = Directory ("../Tests/SafeAuth.Tests.IOS/Native References/");
var AndroidDir = new ConvertableDirectoryPath[] {
  androidTestLibDirectory,
  androidLibDirectory
};
var IOSDir = new ConvertableDirectoryPath[] {
  iosTestLibDirectory,
  iosLibDirectory
};
var DirList = new ConvertableDirectoryPath[][] {
  AndroidDir,
  IOSDir
};
// --------------------------------------------------------------------------------
// Download Libs
// --------------------------------------------------------------------------------

Task ("Download-Libs")
  .Does (() => {
    foreach (var item in Enum.GetValues (typeof (Environment))) {
      string[] targets = null;
      Information (string.Format ("\n{0} ", item));
      switch (item) {
        case Environment.Android:
          targets = ANDROID_ARCHITECTURES;
          break;
        case Environment.iOS:
          targets = IOS_ARCHITECTURES;
          break;
      }

      foreach (var type in LibTypes) {
        foreach (var target in targets) {
          var targetDirectory = string.Format ("{0}/{1}/{2}", nativeLibDirectory.Path, item, target);
          var zipFilename = string.Format ("safe_authenticator{0}-{1}-{2}.zip", type, TAG, target);
          var zipDownloadUrl = string.Format ("https://s3.eu-west-2.amazonaws.com/safe-client-libs/{0}", zipFilename);
          var zipSavePath = string.Format ("{0}/{1}/{2}/{3}", nativeLibDirectory.Path, item, target, zipFilename);

          Information ("Downloading : {0}", zipFilename);

          if (!DirectoryExists (targetDirectory))
            CreateDirectory (targetDirectory);

          if (!FileExists (zipSavePath)) {
            CurlDownloadFiles (
              new [] {
                new Uri (zipDownloadUrl)
              },
              new CurlDownloadSettings {
                OutputPaths = new FilePath[] {
                  zipSavePath
                }
              });
          } else {
            Information ("File already exists");
          }
        }
      }
    }

  })
  .ReportError (exception => {
    Information (exception.Message);
  });

Task ("UnZip-Libs")
  .IsDependentOn ("Download-Libs")
  .Does (() => {
    foreach (var item in Enum.GetValues (typeof (Environment))) {

      ConvertableDirectoryPath[] Dir = null;
      string[] targets = null;
      var outputDirectory = string.Empty;
      Information (string.Format ("\n {0} ", item));
      switch (item) {
        case Environment.Android:
          targets = ANDROID_ARCHITECTURES;
          Dir = DirList.Single (x => x.Equals (AndroidDir));
          break;
        case Environment.iOS:
          targets = IOS_ARCHITECTURES;
          Dir = DirList.Single (x => x.Equals (IOSDir));
          break;
      }
      foreach (var type in Dir.Zip (LibTypes, Tuple.Create)) {
        outputDirectory = type.Item1;
        CleanDirectories (outputDirectory);
        foreach (var target in targets) {

          var zipFilename = string.Format ("safe_authenticator{0}-{1}-{2}.zip", type.Item2, TAG, target);
          var zipSavePath = string.Format ("{0}/{1}/{2}/{3}", nativeLibDirectory.Path, item, target, zipFilename);
          var zipFiles = GetFiles (string.Format (zipSavePath));

          foreach (var zip in zipFiles) {
            var filename = zip.GetFilename ();
            Information (" Unzipping : " + filename);
            var platformOutputDirectory = new StringBuilder ();
            platformOutputDirectory.Append (outputDirectory);

            if (target.Equals (ANDROID_X86))
              platformOutputDirectory.Append ("/x86");
            else if (target.Equals (ANDROID_ARMEABI_V7A))
              platformOutputDirectory.Append ("/armeabi-v7a");

            Unzip (zip, platformOutputDirectory.ToString ());
            if (target.Equals (ANDROID_X86) || target.Equals (ANDROID_ARMEABI_V7A)) {
              var aFilePath = platformOutputDirectory.ToString () + "/libsafe_authenticator.a";
              DeleteFile (aFilePath);
            }
          }
        }
      }
    }

  })
  .ReportError (exception => {
    Information (exception.Message);
  });

Task ("Analyse-Result-File")
  .Does (() => {
      AnalyseResultFile (ANDROID_TEST_RESULTS_PATH);
      AnalyseResultFile (IOS_TEST_RESULTS_PATH);
      Information("All Tests Have Passed");
  });

Task ("Default")
  .IsDependentOn ("UnZip-Libs")
  .IsDependentOn("Restore-NuGet-Packages")
  .IsDependentOn ("Test-Android-Emu")
  .IsDependentOn ("Test-IOS-Emu")
  .IsDependentOn ("Analyse-Result-File")

  .Does (() => {
  });

RunTarget (target);