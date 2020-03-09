# SAFE Email App
The SAFE email app is an example app which showcases how to use the [MaidSafe.SafeApp](https://www.nuget.org/packages/MaidSafe.SafeApp) NuGet to build a simple email application.

Demonstrates the usage of:
 - Private MutableData
 - Public MutableData
 - App's own container
 - `_publicNames` and services containers

|Build Status |
|------------ |
|[![Build Status](https://dev.azure.com/maidsafe/Safe%20Email%20App/_apis/build/status/Safe%20Email%20App-CI)](https://dev.azure.com/maidsafe/Safe%20Email%20App/_build/latest?definitionId=8)|

## Features
- First step would be to Authorize the SAFE email app by authenticating it using the [SAFE Authenticator mobile](https://github.com/maidsafe/safe-authenticator-mobile).
- Create a Public ID which would act as a unique identifier on the SAFE email app. Option to create multiple Public ID's that could be used to create different communication channels. For instance different accounts for personal & official use.
- Compose an email and send it to another user by addressing it to their Public ID.
- Receive & reply to an email from another user.

### Application Data Model
The following diagram depicts how the emails are stored in the SAFE network, as well as how the email app stores email accounts information.

![Email App Data Model](/design/EmailApp-DataModel.png)

## Building

### Pre-requisites
Requires [SAFE Authenticator mobile](https://github.com/maidsafe/safe-authenticator-mobile) to authenticate itself into the SAFE network.

If building on Visual Studio 2017, you will need the following SDKs and workloads installed:

### Workloads required:
- Xamarin

### Required SDK/Tools
- Android 9.0 SDK
- Latest Xcode

### Supported Platforms
- Android 4.2+ (armeabi-v7a, x86_64)
- iOS 8+ (ARM64, x64)

## Further Help
Get your developer related questions clarified on [SAFE Dev Forum](https://forum.safedev.org/). If your looking to share any other ideas or thoughts on the SAFENetwork you can reach out on [SAFE Network Forum](https://safenetforum.org/)

## License
This SAFE Network library is dual-licensed under the Modified BSD ([LICENSE-BSD](LICENSE-BSD) https://opensource.org/licenses/BSD-3-Clause) or the MIT license ([LICENSE-MIT](LICENSE-MIT) https://opensource.org/licenses/MIT) at your option.

## Contributing

Want to contribute? Great :tada:

There are many ways to give back to the project, whether it be writing new code, fixing bugs, or just reporting errors. All forms of contributions are encouraged!

For instructions on how to contribute, see our [Guide to contributing](https://github.com/maidsafe/QA/blob/master/CONTRIBUTING.md).
