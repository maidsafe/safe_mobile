#if __MOBILE__

using System;
using System.Runtime.InteropServices;
using SafeAuthenticator.Native;
using Xamarin.Forms;

[assembly: Dependency(typeof(NativeBindings))]

namespace SafeAuthenticator.Native {
  public class NativeBindings : INativeBindings {
    #region FreeAuthNative

    public void FreeAuth(IntPtr authPtr) {
      FreeAuthNative(authPtr);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "auth_free")]
#elif __ANDROID__
    [DllImport("safe_authenticator", EntryPoint = "auth_free")]
#endif
    public static extern void FreeAuthNative(IntPtr authPtr);

    #endregion

    #region Login

    public void Login(string location, string password, IntPtr netCbPtr, IntPtr userDataPtr, NetObsCb netobs, LoginCb loginAcctCb) {
      LoginNative(location, password, netCbPtr, userDataPtr, netobs, loginAcctCb);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "login")]
#elif __ANDROID__
    [DllImport("safe_authenticator", EntryPoint = "login")]
#endif
    public static extern void LoginNative(
      string location,
      string password,
      IntPtr netCbPtr,
      IntPtr userDataPtr,
      NetObsCb netobs,
      LoginCb loginAcctCb);

    #endregion

    #region EncodeAuthRsp

    public void EncodeAuthRsp(IntPtr authPtr, IntPtr authReq, uint reqId, bool isGranted, IntPtr self, EncodeAuthRspCb callback) {
      EncodeAuthRspCallbackNative(authPtr, authReq, reqId, isGranted, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "encode_auth_resp")]
#elif __ANDROID__
    [DllImport("safe_authenticator", EntryPoint = "encode_auth_resp")]
#endif
    public static extern void EncodeAuthRspCallbackNative(
      IntPtr authPtr,
      IntPtr authReq,
      uint reqId,
      [MarshalAs(UnmanagedType.U1)] bool isGranted,
      IntPtr self,
      EncodeAuthRspCb callback);

    #endregion

    #region Create Account

    public void CreateAccount(
      string location,
      string password,
      string invitation,
      IntPtr netCbPtr,
      IntPtr userDataPtr,
      NetObsCb netobs,
      CreateAccountCb createAcctCb) {
      CreateAccountNative(location, password, invitation, netCbPtr, userDataPtr, netobs, createAcctCb);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "create_acc")]
#elif __ANDROID__
    [DllImport("safe_authenticator", EntryPoint = "create_acc")]
#endif
    public static extern void CreateAccountNative(
      string location,
      string password,
      string invitation,
      IntPtr netCbPtr,
      IntPtr userDataPtr,
      NetObsCb netobs,
      CreateAccountCb createAcctCb);

    #endregion

    #region AuthRegisteredApps

    public void AuthRegisteredApps(IntPtr authPtr, IntPtr self, AuthRegisteredAppsCb callback) {
      AuthRegisteredAppsNative(authPtr, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "auth_registered_apps")]
#elif __ANDROID__
    [DllImport("safe_authenticator", EntryPoint = "auth_registered_apps")]
#endif
    public static extern void AuthRegisteredAppsNative(IntPtr authPtr, IntPtr self, AuthRegisteredAppsCb callback);

    #endregion

    #region AuthInitLogging

    public void AuthInitLogging(string fileName, IntPtr userDataPtr, InitLoggingCb callback) {
      AuthInitLoggingNative(fileName, userDataPtr, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "auth_init_logging")]
#elif __ANDROID__
    [DllImport("safe_authenticator", EntryPoint = "auth_init_logging")]
#endif
    public static extern void AuthInitLoggingNative(string fileName, IntPtr userDataPtr, InitLoggingCb callback);

    #endregion

    #region AuthOutputLogPath

    public void AuthOutputLogPath(string fileName, IntPtr userDataPtr, AuthLogPathCb callback) {
      AuthOutputLogPathNative(fileName, userDataPtr, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "auth_output_log_path")]
#elif __ANDROID__
    [DllImport("safe_authenticator", EntryPoint = "auth_output_log_path")]
#endif
    public static extern void AuthOutputLogPathNative(string fileName, IntPtr userDataPtr, AuthLogPathCb callback);

    #endregion

    #region AppPubSignKey

    public void AuthDecodeIpcMsg(
      IntPtr authPtr,
      string encodedString,
      IntPtr self,
      AppAuthReqCb appAuthCb,
      AppContReqCb appContCb,
      AppUnregAppReqCb appUnregCb,
      AppShareMDataReqCb appShareMDataCb,
      AppReqOnErrorCb appReqOnErrorCb) {
      AuthDecodeIpcMsgNative(authPtr, encodedString, self, appAuthCb, appContCb, appUnregCb, appShareMDataCb, appReqOnErrorCb);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "auth_decode_ipc_msg")]
#elif __ANDROID__
    [DllImport("safe_authenticator", EntryPoint = "auth_decode_ipc_msg")]
#endif
    public static extern void AuthDecodeIpcMsgNative(
      IntPtr authPtr,
      string encodedString,
      IntPtr self,
      AppAuthReqCb appAuthCb,
      AppContReqCb appContCb,
      AppUnregAppReqCb appUnregCb,
      AppShareMDataReqCb appShareMDataCb,
      AppReqOnErrorCb appReqOnErrorCb);

    #endregion

    #region AuthAccountInfo

    public void AuthAccountInfo(IntPtr authPtr, IntPtr self, AuthAccountInfoCb callback) {
      AuthAccountInfoNative(authPtr, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "auth_account_info")]
#elif __ANDROID__
    [DllImport("safe_authenticator", EntryPoint = "auth_account_info")]
#endif
    public static extern void AuthAccountInfoNative(IntPtr authPtr, IntPtr self, AuthAccountInfoCb callback);

    #endregion

    #region AuthExeFileStem

    public void AuthExeFileStem(IntPtr self, AuthExeFileStemCb callback) {
      AuthExeFileStemNative(self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "auth_exe_file_stem")]
#elif __ANDROID__
    [DllImport("safe_authenticator", EntryPoint = "auth_exe_file_stem")]
#endif
    public static extern void AuthExeFileStemNative(IntPtr self, AuthExeFileStemCb callback);

    #endregion

    #region AuthSetAdditionalSearchPath

    public void AuthSetAdditionalSearchPath(string path, IntPtr self, AuthSetAdditionalSearchPathCb callback) {
      AuthSetAdditionalSearchPathNative(path, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "auth_set_additional_search_path")]
#elif __ANDROID__
    [DllImport("safe_authenticator", EntryPoint = "auth_set_additional_search_path")]
#endif
    public static extern void AuthSetAdditionalSearchPathNative(string path, IntPtr self, AuthSetAdditionalSearchPathCb callback);

    #endregion
  }
}
#endif
