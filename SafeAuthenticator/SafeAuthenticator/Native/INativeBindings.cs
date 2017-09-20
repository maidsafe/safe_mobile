using System;
using CommonUtils;

namespace SafeAuthenticator.Native {
  #region Native Delegates

  public delegate void AuthExeFileStemCb(IntPtr self, FfiResult result, string exeFileStem);

  public delegate void AuthSetAdditionalSearchPathCb(IntPtr self, FfiResult result);

  public delegate void EncodeAuthRspCb(IntPtr a, FfiResult result, string encodedRsp);

  public delegate void NetObsCb(IntPtr a, int errorCode, int eventType);

  public delegate void CreateAccountCb(IntPtr a, FfiResult result, IntPtr authPtr);

  public delegate void AppAuthReqCb(IntPtr a, uint reqId, IntPtr authReq);

  public delegate void AppContReqCb(IntPtr a, uint reqId, IntPtr ffiContainersReq);

  public delegate void AppUnregAppReqCb(IntPtr a, uint reqId);

  public delegate void AppShareMDataReqCb(IntPtr a, uint reqId, IntPtr ffiShareMDataReq, IntPtr ffiUserMetaData);

  public delegate void AppReqOnErrorCb(IntPtr a, FfiResult result, string encodedString);

  public delegate void AuthLogPathCb(IntPtr a, FfiResult result, string path);

  public delegate void InitLoggingCb(IntPtr a, FfiResult result);

  public delegate void LoginCb(IntPtr a, FfiResult result, IntPtr authPtr);

  public delegate void AuthRegisteredAppsCb(IntPtr a, FfiResult result, IntPtr registeredAppFfiPtr, IntPtr len);

  public delegate void AuthAccountInfoCb(IntPtr a, FfiResult result, IntPtr accountInfoPtr);

  #endregion

  public interface INativeBindings {
    void AuthAccountInfo(IntPtr authPtr, IntPtr self, AuthAccountInfoCb callback);

    void AuthDecodeIpcMsg(
      IntPtr authPtr,
      string encodedString,
      IntPtr self,
      AppAuthReqCb appAuthCb,
      AppContReqCb appContCb,
      AppUnregAppReqCb appUnregCb,
      AppShareMDataReqCb appShareMDataCb,
      AppReqOnErrorCb appReqOnErrorCb);

    void AuthExeFileStem(IntPtr self, AuthExeFileStemCb callback);
    void AuthInitLogging(string fileName, IntPtr userDataPtr, InitLoggingCb callback);
    void AuthOutputLogPath(string fileName, IntPtr userDataPtr, AuthLogPathCb callback);

    void AuthRegisteredApps(IntPtr authPtr, IntPtr self, AuthRegisteredAppsCb callback);
    void AuthSetAdditionalSearchPath(string path, IntPtr self, AuthSetAdditionalSearchPathCb callback);

    void CreateAccount(
      string location,
      string password,
      string invitation,
      IntPtr netCbPtr,
      IntPtr userDataPtr,
      NetObsCb netobs,
      CreateAccountCb createAcctCb);

    void EncodeAuthRsp(IntPtr authPtr, IntPtr authReq, uint reqId, bool isGranted, IntPtr self, EncodeAuthRspCb callback);

    void FreeAuth(IntPtr authPtr);

    void Login(string location, string password, IntPtr netCbPtr, IntPtr userDataPtr, NetObsCb netobs, LoginCb loginAcctCb);
  }
}
