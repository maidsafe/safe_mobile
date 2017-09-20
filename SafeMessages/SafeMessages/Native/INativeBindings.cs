using System;
using CommonUtils;

namespace SafeMessages.Native {
  #region Native Delegates

  public delegate void InitLoggingCb(IntPtr a, FfiResult result);

  public delegate void AppExeFileStemCb(IntPtr self, FfiResult result, string exeFileStem);

  public delegate void AppSetAdditionalSearchPathCb(IntPtr self, FfiResult result);

  public delegate void AppOutputLogPathCallback(IntPtr a, FfiResult result, string path);

  public delegate void MDataInfoDecryptCb(IntPtr a, FfiResult result, IntPtr plainText, IntPtr len);

  public delegate void NetworkObserverCb(IntPtr a, int b, int c);

  public delegate void EncodeAuthReqCb(IntPtr a, FfiResult result, uint requestId, string encodedReq);

  public delegate void AccessContainerGetContainerMDataInfoCb(IntPtr self, FfiResult result, ulong mDataInfoHandle);

  public delegate void AppPubSignKeyCb(IntPtr self, FfiResult result, ulong signKeyHandle);

  public delegate void CipherOptFreeCb(IntPtr self, FfiResult result);

  public delegate void CipherOptNewPlaintextCb(IntPtr self, FfiResult result, ulong cipherOptHandle);

  public delegate void DecryptSealedBoxCb(IntPtr self, FfiResult result, IntPtr data, IntPtr dataLen);

  public delegate void EncGenerateKeyPairCb(IntPtr self, FfiResult result, ulong encryptPubKeyHandle, ulong encryptSecKeyHandle);

  public delegate void EncPubKeyFreeCb(IntPtr self, FfiResult result);

  public delegate void EncPubKeyGetCb(IntPtr self, FfiResult result, IntPtr asymPublicKey);

  public delegate void EncPubKeyNewCb(IntPtr self, FfiResult result, ulong encryptPubKeyHandle);

  public delegate void EncryptSealedBoxCb(IntPtr self, FfiResult result, IntPtr data, IntPtr dataLen);

  public delegate void EncSecretKeyFreeCb(IntPtr self, FfiResult result);

  public delegate void EncSecretKeyGetCb(IntPtr self, FfiResult result, IntPtr asymSecretKey);

  public delegate void EncSecretKeyNewCb(IntPtr self, FfiResult result, ulong encryptSecKeyHandle);

  public delegate void IDataCloseSelfEncryptorCb(IntPtr self, FfiResult result, IntPtr xorNameArr);

  public delegate void IDataFetchSelfEncryptorCb(IntPtr self, FfiResult result, ulong sEReaderHandle);

  public delegate void IDataNewSelfEncryptorCb(IntPtr self, FfiResult result, ulong sEWriterHandle);

  public delegate void IDataReadFromSelfEncryptorCb(IntPtr self, FfiResult result, IntPtr data, IntPtr dataLen);

  public delegate void IDataSelfEncryptorReaderFreeCb(IntPtr self, FfiResult result);

  public delegate void IDataSelfEncryptorWriterFreeCb(IntPtr self, FfiResult result);

  public delegate void IDataSizeCb(IntPtr self, FfiResult result, ulong len);

  public delegate void IDataWriteToSelfEncryptorCb(IntPtr self, FfiResult result);

  public delegate void MDataEntriesForEachCb(
    IntPtr self,
    IntPtr entryKey,
    IntPtr entryKeyLen,
    IntPtr entryVal,
    IntPtr entryValLen,
    ulong entryVersion);

  public delegate void MDataEntriesForEachResCb(IntPtr self, FfiResult result);

  public delegate void MDataEntriesFreeCb(IntPtr self, FfiResult result);

  public delegate void MDataEntriesInsertCb(IntPtr self, FfiResult result);

  public delegate void MDataEntriesLenCb(IntPtr self, ulong len);

  public delegate void MDataEntriesNewCb(IntPtr self, FfiResult result, ulong mDataEntriesHandle);

  public delegate void MDataEntryActionsFreeCb(IntPtr self, FfiResult result);

  public delegate void MDataEntryActionsInsertCb(IntPtr self, FfiResult result);

  public delegate void MDataEntryActionsNewCb(IntPtr self, FfiResult result, ulong mDataEntryActionsHandle);

  public delegate void MDataGetValueCb(IntPtr self, FfiResult result, IntPtr data, IntPtr dataLen, ulong entryVersion);

  public delegate void MDataInfoDeserialiseCb(IntPtr self, FfiResult result, ulong mDataInfoHandle);

  public delegate void MDataInfoFreeCb(IntPtr self, FfiResult result);

  public delegate void MDataInfoNewPublicCb(IntPtr self, FfiResult result, ulong mDataInfoHandle);

  public delegate void MDataInfoRandomPrivateCb(IntPtr self, FfiResult result, ulong mDataInfoHandle);

  public delegate void MDataInfoRandomPublicCb(IntPtr self, FfiResult result, ulong mDataInfoHandle);

  public delegate void MDataInfoSerialiseCb(IntPtr self, FfiResult result, IntPtr data, IntPtr dataLen);

  public delegate void MDataListEntriesCb(IntPtr self, FfiResult result, ulong mDataEntriesHandle);

  public delegate void MDataMutateEntriesCb(IntPtr self, FfiResult result);

  public delegate void MDataPermissionSetNewCb(IntPtr self, FfiResult result, ulong mDataPermissionSetHandle);

  public delegate void MDataPermissionsFreeCb(IntPtr self, FfiResult result);

  public delegate void MDataPermissionsInsertCb(IntPtr self, FfiResult result);

  public delegate void MDataPermissionsNewCb(IntPtr self, FfiResult result, ulong mDataPermissionsHandle);

  public delegate void MDataPermissionsSetAllowCb(IntPtr self, FfiResult result);

  public delegate void MDataPermissionsSetFreeCb(IntPtr self, FfiResult result);

  public delegate void MDataPutCb(IntPtr self, FfiResult result);

  public delegate void Sha3HashCb(IntPtr self, FfiResult result, IntPtr digest, IntPtr len);

  public delegate void MDataListKeysCb(IntPtr self, FfiResult result, ulong keysHandle);

  public delegate void MDataKeysLenCb(IntPtr self, FfiResult result, IntPtr keysLen);

  public delegate void MDataKeysForEachCb(IntPtr self, IntPtr bytePtr, IntPtr byteLen);

  public delegate void MDataKeysForEachResCb(IntPtr self, FfiResult result);

  public delegate void MDataKeysFreeCb(IntPtr self, FfiResult result);

  public delegate void DecodeAuthCb(IntPtr self, uint reqId, IntPtr authGrantedFfiPtr);

  public delegate void DecodeUnregCb(IntPtr self, uint reqId, IntPtr bsConfig, IntPtr bsSize);

  public delegate void DecodeContCb(IntPtr self, uint reqId);

  public delegate void DecodeShareMDataCb(IntPtr self, uint reqId);

  public delegate void DecodeRevokedCb(IntPtr self);

  public delegate void DecodeErrorCb(IntPtr self, FfiResult result);

  public delegate void NetObsCallback(IntPtr self, FfiResult result, int eventType);

  public delegate void AppRegisteredCallback(IntPtr self, FfiResult result, IntPtr appPtr);

  public delegate void MDataInfoEncryptEntryKeyCb(IntPtr self, FfiResult result, IntPtr dataPtr, IntPtr dataLen);

  public delegate void MDataInfoEncryptEntryValueCb(IntPtr self, FfiResult result, IntPtr dataPtr, IntPtr dataLen);

  #endregion

  public interface INativeBindings {
    void AccessContainerGetContainerMDataInfo(IntPtr appPtr, string name, IntPtr self, AccessContainerGetContainerMDataInfoCb callback);
    void AppExeFileStem(IntPtr self, AppExeFileStemCb callback);
    void AppInitLogging(string fileName, IntPtr userDataPtr, InitLoggingCb callback);
    void AppOutputLogPath(string fileName, IntPtr userDataPtr, AppOutputLogPathCallback callback);
    void AppPubSignKey(IntPtr appPtr, IntPtr self, AppPubSignKeyCb callback);

    void AppRegistered(
      string appId,
      IntPtr authGrantedFfiPtr,
      IntPtr networkUserData,
      IntPtr userData,
      NetObsCallback netObsCb,
      AppRegisteredCallback appRegCb);

    void AppSetAdditionalSearchPath(string path, IntPtr self, AppSetAdditionalSearchPathCb callback);
    void CipherOptFree(IntPtr appPtr, ulong cipherOptHandle, IntPtr self, CipherOptFreeCb callback);
    void CipherOptNewPlaintext(IntPtr appPtr, IntPtr self, CipherOptNewPlaintextCb callback);

    void DecodeIpcMessage(
      string encodedReq,
      IntPtr self,
      DecodeAuthCb cb1,
      DecodeUnregCb cb2,
      DecodeContCb cb3,
      DecodeShareMDataCb cb4,
      DecodeRevokedCb cb5,
      DecodeErrorCb cb6);

    void DecryptSealedBox(IntPtr appPtr, IntPtr data, IntPtr len, ulong pkHandle, ulong skHandle, IntPtr self, DecryptSealedBoxCb callback);
    void EncGenerateKeyPair(IntPtr appPtr, IntPtr self, EncGenerateKeyPairCb callback);
    void EncodeAuthReq(IntPtr authReq, IntPtr userDataPtr, EncodeAuthReqCb callback);
    void EncPubKeyFree(IntPtr appPtr, ulong encryptPubKeyHandle, IntPtr self, EncPubKeyFreeCb callback);
    void EncPubKeyGet(IntPtr appPtr, ulong encryptPubKeyHandle, IntPtr self, EncPubKeyGetCb callback);
    void EncPubKeyNew(IntPtr appPtr, IntPtr asymPublicKey, IntPtr self, EncPubKeyNewCb callback);
    void EncryptSealedBox(IntPtr appPtr, IntPtr data, IntPtr len, ulong pkHandle, IntPtr self, EncryptSealedBoxCb callback);
    void EncSecretKeyFree(IntPtr appPtr, ulong encryptSecKeyHandle, IntPtr self, EncSecretKeyFreeCb callback);
    void EncSecretKeyGet(IntPtr appPtr, ulong encryptSecKeyHandle, IntPtr self, EncSecretKeyGetCb callback);
    void EncSecretKeyNew(IntPtr appPtr, IntPtr asymSecretKey, IntPtr self, EncSecretKeyNewCb callback);
    void FreeApp(IntPtr appPtr);

    void IDataCloseSelfEncryptor(IntPtr appPtr, ulong seH, ulong cipherOptH, IntPtr self, IDataCloseSelfEncryptorCb callback);
    void IDataFetchSelfEncryptor(IntPtr appPtr, IntPtr xorNameArr, IntPtr self, IDataFetchSelfEncryptorCb callback);
    void IDataNewSelfEncryptor(IntPtr appPtr, IntPtr self, IDataNewSelfEncryptorCb callback);

    void IDataReadFromSelfEncryptor(
      IntPtr appPtr,
      ulong seHandle,
      ulong fromPos,
      ulong len,
      IntPtr self,
      IDataReadFromSelfEncryptorCb callback);

    void IDataSelfEncryptorReaderFree(IntPtr appPtr, ulong sEReaderHandle, IntPtr self, IDataSelfEncryptorReaderFreeCb callback);
    void IDataSelfEncryptorWriterFree(IntPtr appPtr, ulong sEWriterHandle, IntPtr self, IDataSelfEncryptorWriterFreeCb callback);
    void IDataSize(IntPtr appPtr, ulong seHandle, IntPtr self, IDataSizeCb callback);

    void IDataWriteToSelfEncryptor(
      IntPtr appPtr,
      ulong seHandle,
      IntPtr data,
      IntPtr size,
      IntPtr self,
      IDataWriteToSelfEncryptorCb callback);

    void MDataEntriesForEach(
      IntPtr appPtr,
      ulong entriesHandle,
      MDataEntriesForEachCb forEachCallback,
      IntPtr self,
      MDataEntriesForEachResCb resultCallback);

    void MDataEntriesFree(IntPtr appPtr, ulong entriesHandle, IntPtr self, MDataEntriesFreeCb callback);

    void MDataEntriesInsert(
      IntPtr appPtr,
      ulong entriesHandle,
      IntPtr keyPtr,
      IntPtr keyLen,
      IntPtr valuePtr,
      IntPtr valueLen,
      IntPtr self,
      MDataEntriesInsertCb callback);

    void MDataEntriesLen(IntPtr appPtr, ulong entriesHandle, IntPtr self, MDataEntriesLenCb callback);
    void MDataEntriesNew(IntPtr appPtr, IntPtr self, MDataEntriesNewCb callback);
    void MDataEntryActionsFree(IntPtr appPtr, ulong actionsHandle, IntPtr self, MDataEntryActionsFreeCb callback);

    void MDataEntryActionsInsert(
      IntPtr appPtr,
      ulong actionsHandle,
      IntPtr keyPtr,
      IntPtr keyLen,
      IntPtr valuePtr,
      IntPtr valueLen,
      IntPtr self,
      MDataEntryActionsInsertCb callback);

    void MDataEntryActionsNew(IntPtr appPtr, IntPtr self, MDataEntryActionsNewCb callback);
    void MDataGetValue(IntPtr appPtr, ulong infoHandle, IntPtr keyPtr, IntPtr keyLen, IntPtr self, MDataGetValueCb callback);
    void MDataInfoDecrypt(IntPtr appPtr, ulong mDataInfoH, IntPtr cipherText, IntPtr cipherLen, IntPtr self, MDataInfoDecryptCb callback);
    void MDataInfoDeserialise(IntPtr appPtr, IntPtr ptr, IntPtr len, IntPtr self, MDataInfoDeserialiseCb callback);

    void MDataInfoEncryptEntryKey(
      IntPtr appPtr,
      ulong infoH,
      IntPtr inputPtr,
      IntPtr inputLen,
      IntPtr self,
      MDataInfoEncryptEntryKeyCb callback);

    void MDataInfoEncryptEntryValue(
      IntPtr appPtr,
      ulong infoH,
      IntPtr inputPtr,
      IntPtr inputLen,
      IntPtr self,
      MDataInfoEncryptEntryValueCb callback);

    void MDataInfoFree(IntPtr appPtr, ulong infoHandle, IntPtr self, MDataInfoFreeCb callback);
    void MDataInfoNewPublic(IntPtr appPtr, IntPtr xorNameArr, ulong typeTag, IntPtr self, MDataInfoNewPublicCb callback);
    void MDataInfoRandomPrivate(IntPtr appPtr, ulong typeTag, IntPtr self, MDataInfoRandomPrivateCb callback);
    void MDataInfoRandomPublic(IntPtr appPtr, ulong typeTag, IntPtr self, MDataInfoRandomPublicCb callback);
    void MDataInfoSerialise(IntPtr appPtr, ulong infoHandle, IntPtr self, MDataInfoSerialiseCb callback);
    void MDataKeysForEach(IntPtr appPtr, ulong keysHandle, MDataKeysForEachCb forEachCb, IntPtr self, MDataKeysForEachResCb resCb);

    void MDataKeysFree(IntPtr appPtr, ulong keysHandle, IntPtr self, MDataKeysFreeCb callback);

    void MDataKeysLen(IntPtr appPtr, ulong keysHandle, IntPtr self, MDataKeysLenCb callback);
    void MDataListEntries(IntPtr appPtr, ulong infoHandle, IntPtr self, MDataListEntriesCb callback);
    void MDataListKeys(IntPtr appPtr, ulong infoHandle, IntPtr self, MDataListKeysCb callback);
    void MDataMutateEntries(IntPtr appPtr, ulong infoHandle, ulong actionsHandle, IntPtr self, MDataMutateEntriesCb callback);
    void MDataPermissionSetNew(IntPtr appPtr, IntPtr self, MDataPermissionSetNewCb callback);
    void MDataPermissionsFree(IntPtr appPtr, ulong permissionsHandle, IntPtr self, MDataPermissionsFreeCb callback);

    void MDataPermissionsInsert(
      IntPtr appPtr,
      ulong permissionsHandle,
      ulong userHandle,
      ulong permissionSetHandle,
      IntPtr self,
      MDataPermissionsInsertCb callback);

    void MDataPermissionsNew(IntPtr appPtr, IntPtr self, MDataPermissionsNewCb callback);
    void MDataPermissionsSetAllow(IntPtr appPtr, ulong setHandle, MDataAction action, IntPtr self, MDataPermissionsSetAllowCb callback);
    void MDataPermissionsSetFree(IntPtr appPtr, ulong setHandle, IntPtr self, MDataPermissionsSetFreeCb callback);
    void MDataPut(IntPtr appPtr, ulong infoHandle, ulong permissionsHandle, ulong entriesHandle, IntPtr self, MDataPutCb callback);
    void Sha3Hash(IntPtr data, IntPtr len, IntPtr self, Sha3HashCb callback);
  }
}
