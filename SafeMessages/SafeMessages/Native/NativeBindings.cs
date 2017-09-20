#if __MOBILE__

using System;
using System.Runtime.InteropServices;
using CommonUtils;
using SafeMessages.Native;
using Xamarin.Forms;

[assembly: Dependency(typeof(NativeBindings))]

namespace SafeMessages.Native {
  public class NativeBindings : INativeBindings {
    #region FreeAppNative

    public void FreeApp(IntPtr appPtr) {
      FreeAppNative(appPtr);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "app_free")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "app_free")]
#endif
    public static extern void FreeAppNative(IntPtr appPtr);

    #endregion

    #region EncodeAuthReqNative

    public void EncodeAuthReq(IntPtr authReq, IntPtr userDataPtr, EncodeAuthReqCb callback) {
      EncodeAuthReqNative(authReq, userDataPtr, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "encode_auth_req")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "encode_auth_req")]
#endif
    public static extern void EncodeAuthReqNative(IntPtr authReq, IntPtr userDataPtr, EncodeAuthReqCb callback);

    #endregion

    #region AppOutputLogPathNative

    public void AppOutputLogPath(string fileName, IntPtr userDataPtr, AppOutputLogPathCallback callback) {
      AppOutputLogPathNative(fileName, userDataPtr, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "app_output_log_path")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "app_output_log_path")]
#endif
    public static extern void AppOutputLogPathNative(string fileName, IntPtr userDataPtr, AppOutputLogPathCallback callback);

    #endregion

    #region AppInitLoggingNative

    public void AppInitLogging(string fileName, IntPtr userDataPtr, InitLoggingCb callback) {
      AppInitLoggingNative(fileName, userDataPtr, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "app_init_logging")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "app_init_logging")]
#endif
    public static extern void AppInitLoggingNative(string fileName, IntPtr userDataPtr, InitLoggingCb callback);

    #endregion

    #region AppRegistered

    public void AppRegistered(
      string appId,
      IntPtr ffiAuthGrantedPtr,
      IntPtr networkUserData,
      IntPtr userData,
      NetObsCallback netObsCb,
      AppRegisteredCallback appRegCb) {
      AppRegisteredNative(appId, ffiAuthGrantedPtr, networkUserData, userData, netObsCb, appRegCb);
    }
#if __IOS__
    [DllImport("__Internal", EntryPoint = "app_registered")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "app_registered")]
#endif
    public static extern void AppRegisteredNative(
      string appId,
      IntPtr ffiAuthGrantedPtr,
      IntPtr networkUserData,
      IntPtr userData,
      NetObsCallback netObsCb,
      AppRegisteredCallback appRegCb);

    #endregion

    #region DecodeIpcMessage

    public void DecodeIpcMessage(
      string encodedReq,
      IntPtr self,
      DecodeAuthCb cb1,
      DecodeUnregCb cb2,
      DecodeContCb cb3,
      DecodeShareMDataCb cb4,
      DecodeRevokedCb cb5,
      DecodeErrorCb cb6) {
      DecodeIpcMessageNative(encodedReq, self, cb1, cb2, cb3, cb4, cb5, cb6);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "decode_ipc_msg")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "decode_ipc_msg")]
#endif
    public static extern void DecodeIpcMessageNative(
      string encodedReq,
      IntPtr self,
      DecodeAuthCb cb1,
      DecodeUnregCb cb2,
      DecodeContCb cb3,
      DecodeShareMDataCb cb4,
      DecodeRevokedCb cb5,
      DecodeErrorCb cb6);

    #endregion

    #region AccessContainerGetContainerMDataInfo

    public void AccessContainerGetContainerMDataInfo(
      IntPtr appPtr,
      string name,
      IntPtr self,
      AccessContainerGetContainerMDataInfoCb callback) {
      AccessContainerGetContainerMDataInfoNative(appPtr, name, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "access_container_get_container_mdata_info")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "access_container_get_container_mdata_info")]
#endif
    public static extern void AccessContainerGetContainerMDataInfoNative(
      IntPtr appPtr,
      string name,
      IntPtr self,
      AccessContainerGetContainerMDataInfoCb callback);

    #endregion

    #region AppPubSignKey

    public void AppPubSignKey(IntPtr appPtr, IntPtr self, AppPubSignKeyCb callback) {
      AppPubSignKeyNative(appPtr, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "app_pub_sign_key")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "app_pub_sign_key")]
#endif
    public static extern void AppPubSignKeyNative(IntPtr appPtr, IntPtr self, AppPubSignKeyCb callback);

    #endregion

    #region CipherOptFree

    public void CipherOptFree(IntPtr appPtr, ulong cipherOptHandle, IntPtr self, CipherOptFreeCb callback) {
      CipherOptFreeNative(appPtr, cipherOptHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "cipher_opt_free")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "cipher_opt_free")]
#endif
    public static extern void CipherOptFreeNative(IntPtr appPtr, ulong cipherOptHandle, IntPtr self, CipherOptFreeCb callback);

    #endregion

    #region CipherOptNewPlaintext

    public void CipherOptNewPlaintext(IntPtr appPtr, IntPtr self, CipherOptNewPlaintextCb callback) {
      CipherOptNewPlaintextNative(appPtr, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "cipher_opt_new_plaintext")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "cipher_opt_new_plaintext")]
#endif
    public static extern void CipherOptNewPlaintextNative(IntPtr appPtr, IntPtr self, CipherOptNewPlaintextCb callback);

    #endregion

    #region DecryptSealedBox

    public void DecryptSealedBox(
      IntPtr appPtr,
      IntPtr data,
      IntPtr len,
      ulong pkHandle,
      ulong skHandle,
      IntPtr self,
      DecryptSealedBoxCb callback) {
      DecryptSealedBoxNative(appPtr, data, len, pkHandle, skHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "decrypt_sealed_box")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "decrypt_sealed_box")]
#endif
    public static extern void DecryptSealedBoxNative(
      IntPtr appPtr,
      IntPtr data,
      IntPtr len,
      ulong pkHandle,
      ulong skHandle,
      IntPtr self,
      DecryptSealedBoxCb callback);

    #endregion

    #region EncGenerateKeyPair

    public void EncGenerateKeyPair(IntPtr appPtr, IntPtr self, EncGenerateKeyPairCb callback) {
      EncGenerateKeyPairNative(appPtr, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "enc_generate_key_pair")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "enc_generate_key_pair")]
#endif
    public static extern void EncGenerateKeyPairNative(IntPtr appPtr, IntPtr self, EncGenerateKeyPairCb callback);

    #endregion

    #region EncPubKeyFree

    public void EncPubKeyFree(IntPtr appPtr, ulong encryptPubKeyHandle, IntPtr self, EncPubKeyFreeCb callback) {
      EncPubKeyFreeNative(appPtr, encryptPubKeyHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "enc_pub_key_free")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "enc_pub_key_free")]
#endif
    public static extern void EncPubKeyFreeNative(IntPtr appPtr, ulong encryptPubKeyHandle, IntPtr self, EncPubKeyFreeCb callback);

    #endregion

    #region EncPubKeyGet

    public void EncPubKeyGet(IntPtr appPtr, ulong encryptPubKeyHandle, IntPtr self, EncPubKeyGetCb callback) {
      EncPubKeyGetNative(appPtr, encryptPubKeyHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "enc_pub_key_get")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "enc_pub_key_get")]
#endif
    public static extern void EncPubKeyGetNative(IntPtr appPtr, ulong encryptPubKeyHandle, IntPtr self, EncPubKeyGetCb callback);

    #endregion

    #region EncPubKeyNew

    public void EncPubKeyNew(IntPtr appPtr, IntPtr asymPublicKey, IntPtr self, EncPubKeyNewCb callback) {
      EncPubKeyNewNative(appPtr, asymPublicKey, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "enc_pub_key_new")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "enc_pub_key_new")]
#endif
    public static extern void EncPubKeyNewNative(IntPtr appPtr, IntPtr asymPublicKey, IntPtr self, EncPubKeyNewCb callback);

    #endregion

    #region EncryptSealedBox

    public void EncryptSealedBox(IntPtr appPtr, IntPtr data, IntPtr len, ulong pkHandle, IntPtr self, EncryptSealedBoxCb callback) {
      EncryptSealedBoxNative(appPtr, data, len, pkHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "encrypt_sealed_box")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "encrypt_sealed_box")]
#endif
    public static extern void EncryptSealedBoxNative(
      IntPtr appPtr,
      IntPtr data,
      IntPtr len,
      ulong pkHandle,
      IntPtr self,
      EncryptSealedBoxCb callback);

    #endregion

    #region EncSecretKeyFree

    public void EncSecretKeyFree(IntPtr appPtr, ulong encryptSecKeyHandle, IntPtr self, EncSecretKeyFreeCb callback) {
      EncSecretKeyFreeNative(appPtr, encryptSecKeyHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "enc_secret_key_free")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "enc_secret_key_free")]
#endif
    public static extern void EncSecretKeyFreeNative(IntPtr appPtr, ulong encryptSecKeyHandle, IntPtr self, EncSecretKeyFreeCb callback);

    #endregion

    #region EncSecretKeyGet

    public void EncSecretKeyGet(IntPtr appPtr, ulong encryptSecKeyHandle, IntPtr self, EncSecretKeyGetCb callback) {
      EncSecretKeyGetNative(appPtr, encryptSecKeyHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "enc_secret_key_get")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "enc_secret_key_get")]
#endif
    public static extern void EncSecretKeyGetNative(IntPtr appPtr, ulong encryptSecKeyHandle, IntPtr self, EncSecretKeyGetCb callback);

    #endregion

    #region EncSecretKeyNew

    public void EncSecretKeyNew(IntPtr appPtr, IntPtr asymSecretKey, IntPtr self, EncSecretKeyNewCb callback) {
      EncSecretKeyNewNative(appPtr, asymSecretKey, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "enc_secret_key_new")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "enc_secret_key_new")]
#endif
    public static extern void EncSecretKeyNewNative(IntPtr appPtr, IntPtr asymSecretKey, IntPtr self, EncSecretKeyNewCb callback);

    #endregion

    #region IDataCloseSelfEncryptor

    public void IDataCloseSelfEncryptor(
      IntPtr appPtr,
      ulong seHandle,
      ulong cipherOptHandle,
      IntPtr self,
      IDataCloseSelfEncryptorCb callback) {
      IDataCloseSelfEncryptorNative(appPtr, seHandle, cipherOptHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "idata_close_self_encryptor")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "idata_close_self_encryptor")]
#endif
    public static extern void IDataCloseSelfEncryptorNative(
      IntPtr appPtr,
      ulong seHandle,
      ulong cipherOptHandle,
      IntPtr self,
      IDataCloseSelfEncryptorCb callback);

    #endregion

    #region IDataFetchSelfEncryptor

    public void IDataFetchSelfEncryptor(IntPtr appPtr, IntPtr xorNameArr, IntPtr self, IDataFetchSelfEncryptorCb callback) {
      IDataFetchSelfEncryptorNative(appPtr, xorNameArr, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "idata_fetch_self_encryptor")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "idata_fetch_self_encryptor")]
#endif
    public static extern void IDataFetchSelfEncryptorNative(
      IntPtr appPtr,
      IntPtr xorNameArr,
      IntPtr self,
      IDataFetchSelfEncryptorCb callback);

    #endregion

    #region IDataNewSelfEncryptor

    public void IDataNewSelfEncryptor(IntPtr appPtr, IntPtr self, IDataNewSelfEncryptorCb callback) {
      IDataNewSelfEncryptorNative(appPtr, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "idata_new_self_encryptor")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "idata_new_self_encryptor")]
#endif
    public static extern void IDataNewSelfEncryptorNative(IntPtr appPtr, IntPtr self, IDataNewSelfEncryptorCb callback);

    #endregion

    #region IDataReadFromSelfEncryptor

    public void IDataReadFromSelfEncryptor(
      IntPtr appPtr,
      ulong seHandle,
      ulong fromPos,
      ulong len,
      IntPtr self,
      IDataReadFromSelfEncryptorCb callback) {
      IDataReadFromSelfEncryptorNative(appPtr, seHandle, fromPos, len, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "idata_read_from_self_encryptor")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "idata_read_from_self_encryptor")]
#endif
    public static extern void IDataReadFromSelfEncryptorNative(
      IntPtr appPtr,
      ulong seHandle,
      ulong fromPos,
      ulong len,
      IntPtr self,
      IDataReadFromSelfEncryptorCb callback);

    #endregion

    #region IDataSelfEncryptorReaderFree

    public void IDataSelfEncryptorReaderFree(IntPtr appPtr, ulong sEReaderHandle, IntPtr self, IDataSelfEncryptorReaderFreeCb callback) {
      IDataSelfEncryptorReaderFreeNative(appPtr, sEReaderHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "idata_self_encryptor_reader_free")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "idata_self_encryptor_reader_free")]
#endif
    public static extern void IDataSelfEncryptorReaderFreeNative(
      IntPtr appPtr,
      ulong sEReaderHandle,
      IntPtr self,
      IDataSelfEncryptorReaderFreeCb callback);

    #endregion

    #region IDataSelfEncryptorWriterFree

    public void IDataSelfEncryptorWriterFree(IntPtr appPtr, ulong sEWriterHandle, IntPtr self, IDataSelfEncryptorWriterFreeCb callback) {
      IDataSelfEncryptorWriterFreeNative(appPtr, sEWriterHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "idata_self_encryptor_writer_free")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "idata_self_encryptor_writer_free")]
#endif
    public static extern void IDataSelfEncryptorWriterFreeNative(
      IntPtr appPtr,
      ulong sEWriterHandle,
      IntPtr self,
      IDataSelfEncryptorWriterFreeCb callback);

    #endregion

    #region IDataSize

    public void IDataSize(IntPtr appPtr, ulong seHandle, IntPtr self, IDataSizeCb callback) {
      IDataSizeNative(appPtr, seHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "idata_size")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "idata_size")]
#endif
    public static extern void IDataSizeNative(IntPtr appPtr, ulong seHandle, IntPtr self, IDataSizeCb callback);

    #endregion

    #region IDataWriteToSelfEncryptor

    public void IDataWriteToSelfEncryptor(
      IntPtr appPtr,
      ulong seHandle,
      IntPtr data,
      IntPtr size,
      IntPtr self,
      IDataWriteToSelfEncryptorCb callback) {
      IDataWriteToSelfEncryptorNative(appPtr, seHandle, data, size, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "idata_write_to_self_encryptor")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "idata_write_to_self_encryptor")]
#endif
    public static extern void IDataWriteToSelfEncryptorNative(
      IntPtr appPtr,
      ulong seHandle,
      IntPtr data,
      IntPtr size,
      IntPtr self,
      IDataWriteToSelfEncryptorCb callback);

    #endregion

    #region MDataEntriesForEach

    public void MDataEntriesForEach(
      IntPtr appPtr,
      ulong entriesHandle,
      MDataEntriesForEachCb forEachCallback,
      IntPtr self,
      MDataEntriesForEachResCb resultCallback) {
      MDataEntriesForEachNative(appPtr, entriesHandle, forEachCallback, self, resultCallback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_entries_for_each")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_entries_for_each")]
#endif
    public static extern void MDataEntriesForEachNative(
      IntPtr appPtr,
      ulong entriesHandle,
      MDataEntriesForEachCb forEachCallback,
      IntPtr self,
      MDataEntriesForEachResCb resultCallback);

    #endregion

    #region MDataEntriesFree

    public void MDataEntriesFree(IntPtr appPtr, ulong entriesHandle, IntPtr self, MDataEntriesFreeCb callback) {
      MDataEntriesFreeNative(appPtr, entriesHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_entries_free")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_entries_free")]
#endif
    public static extern void MDataEntriesFreeNative(IntPtr appPtr, ulong entriesHandle, IntPtr self, MDataEntriesFreeCb callback);

    #endregion

    #region MDataEntriesInsert

    public void MDataEntriesInsert(
      IntPtr appPtr,
      ulong entriesHandle,
      IntPtr keyPtr,
      IntPtr keyLen,
      IntPtr valuePtr,
      IntPtr valueLen,
      IntPtr self,
      MDataEntriesInsertCb callback) {
      MDataEntriesInsertNative(appPtr, entriesHandle, keyPtr, keyLen, valuePtr, valueLen, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_entries_insert")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_entries_insert")]
#endif
    public static extern void MDataEntriesInsertNative(
      IntPtr appPtr,
      ulong entriesHandle,
      IntPtr keyPtr,
      IntPtr keyLen,
      IntPtr valuePtr,
      IntPtr valueLen,
      IntPtr self,
      MDataEntriesInsertCb callback);

    #endregion

    #region MDataEntriesLen

    public void MDataEntriesLen(IntPtr appPtr, ulong entriesHandle, IntPtr self, MDataEntriesLenCb callback) {
      MDataEntriesLenNative(appPtr, entriesHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_entries_len")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_entries_len")]
#endif
    public static extern void MDataEntriesLenNative(IntPtr appPtr, ulong entriesHandle, IntPtr self, MDataEntriesLenCb callback);

    #endregion

    #region MDataEntriesNew

    public void MDataEntriesNew(IntPtr appPtr, IntPtr self, MDataEntriesNewCb callback) {
      MDataEntriesNewNative(appPtr, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_entries_new")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_entries_new")]
#endif
    public static extern void MDataEntriesNewNative(IntPtr appPtr, IntPtr self, MDataEntriesNewCb callback);

    #endregion

    #region MDataEntryActionsFree

    public void MDataEntryActionsFree(IntPtr appPtr, ulong actionsHandle, IntPtr self, MDataEntryActionsFreeCb callback) {
      MDataEntryActionsFreeNative(appPtr, actionsHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_entry_actions_free")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_entry_actions_free")]
#endif
    public static extern void MDataEntryActionsFreeNative(
      IntPtr appPtr,
      ulong actionsHandle,
      IntPtr self,
      MDataEntryActionsFreeCb callback);

    #endregion

    #region MDataEntryActionsInsert

    public void MDataEntryActionsInsert(
      IntPtr appPtr,
      ulong actionsHandle,
      IntPtr keyPtr,
      IntPtr keyLen,
      IntPtr valuePtr,
      IntPtr valueLen,
      IntPtr self,
      MDataEntryActionsInsertCb callback) {
      MDataEntryActionsInsertNative(appPtr, actionsHandle, keyPtr, keyLen, valuePtr, valueLen, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_entry_actions_insert")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_entry_actions_insert")]
#endif
    public static extern void MDataEntryActionsInsertNative(
      IntPtr appPtr,
      ulong actionsHandle,
      IntPtr keyPtr,
      IntPtr keyLen,
      IntPtr valuePtr,
      IntPtr valueLen,
      IntPtr self,
      MDataEntryActionsInsertCb callback);

    #endregion

    #region MDataEntryActionsNew

    public void MDataEntryActionsNew(IntPtr appPtr, IntPtr self, MDataEntryActionsNewCb callback) {
      MDataEntryActionsNewNative(appPtr, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_entry_actions_new")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_entry_actions_new")]
#endif
    public static extern void MDataEntryActionsNewNative(IntPtr appPtr, IntPtr self, MDataEntryActionsNewCb callback);

    #endregion

    #region MDataInfoEncryptEntryKey

    public void MDataInfoEncryptEntryKey(
      IntPtr appPtr,
      ulong infoH,
      IntPtr inputPtr,
      IntPtr inputLen,
      IntPtr self,
      MDataInfoEncryptEntryKeyCb callback) {
      MDataInfoEncryptEntryKeyNative(appPtr, infoH, inputPtr, inputLen, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_info_encrypt_entry_key")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_info_encrypt_entry_key")]
#endif
    public static extern void MDataInfoEncryptEntryKeyNative(
      IntPtr appPtr,
      ulong infoH,
      IntPtr inputPtr,
      IntPtr inputLen,
      IntPtr self,
      MDataInfoEncryptEntryKeyCb callback);

    #endregion

    #region MDataInfoEncryptEntryValue

    public void MDataInfoEncryptEntryValue(
      IntPtr appPtr,
      ulong infoH,
      IntPtr inputPtr,
      IntPtr inputLen,
      IntPtr self,
      MDataInfoEncryptEntryValueCb callback) {
      MDataInfoEncryptEntryValueNative(appPtr, infoH, inputPtr, inputLen, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_info_encrypt_entry_value")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_info_encrypt_entry_value")]
#endif
    public static extern void MDataInfoEncryptEntryValueNative(
      IntPtr appPtr,
      ulong infoH,
      IntPtr inputPtr,
      IntPtr inputLen,
      IntPtr self,
      MDataInfoEncryptEntryValueCb callback);

    #endregion

    #region MDataGetValue

    public void MDataGetValue(IntPtr appPtr, ulong infoHandle, IntPtr keyPtr, IntPtr keyLen, IntPtr self, MDataGetValueCb callback) {
      MDataGetValueNative(appPtr, infoHandle, keyPtr, keyLen, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_get_value")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_get_value")]
#endif
    public static extern void MDataGetValueNative(
      IntPtr appPtr,
      ulong infoHandle,
      IntPtr keyPtr,
      IntPtr keyLen,
      IntPtr self,
      MDataGetValueCb callback);

    #endregion

    #region MDataInfoDeserialise

    public void MDataInfoDeserialise(IntPtr appPtr, IntPtr ptr, IntPtr len, IntPtr self, MDataInfoDeserialiseCb callback) {
      MDataInfoDeserialiseNative(appPtr, ptr, len, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_info_deserialise")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_info_deserialise")]
#endif
    public static extern void MDataInfoDeserialiseNative(
      IntPtr appPtr,
      IntPtr ptr,
      IntPtr len,
      IntPtr self,
      MDataInfoDeserialiseCb callback);

    #endregion

    #region MDataInfoFree

    public void MDataInfoFree(IntPtr appPtr, ulong infoHandle, IntPtr self, MDataInfoFreeCb callback) {
      MDataInfoFreeNative(appPtr, infoHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_info_free")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_info_free")]
#endif
    public static extern void MDataInfoFreeNative(IntPtr appPtr, ulong infoHandle, IntPtr self, MDataInfoFreeCb callback);

    #endregion

    #region MDataInfoNewPublic

    public void MDataInfoNewPublic(IntPtr appPtr, IntPtr xorNameArr, ulong typeTag, IntPtr self, MDataInfoNewPublicCb callback) {
      MDataInfoNewPublicNative(appPtr, xorNameArr, typeTag, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_info_new_public")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_info_new_public")]
#endif
    public static extern void MDataInfoNewPublicNative(
      IntPtr appPtr,
      IntPtr xorNameArr,
      ulong typeTag,
      IntPtr self,
      MDataInfoNewPublicCb callback);

    #endregion

    #region MDataInfoRandomPrivate

    public void MDataInfoRandomPrivate(IntPtr appPtr, ulong typeTag, IntPtr self, MDataInfoRandomPrivateCb callback) {
      MDataInfoRandomPrivateNative(appPtr, typeTag, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_info_random_private")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_info_random_private")]
#endif
    public static extern void MDataInfoRandomPrivateNative(IntPtr appPtr, ulong typeTag, IntPtr self, MDataInfoRandomPrivateCb callback);

    #endregion

    #region MDataInfoRandomPublic

    public void MDataInfoRandomPublic(IntPtr appPtr, ulong typeTag, IntPtr self, MDataInfoRandomPublicCb callback) {
      MDataInfoRandomPublicNative(appPtr, typeTag, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_info_random_public")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_info_random_public")]
#endif
    public static extern void MDataInfoRandomPublicNative(IntPtr appPtr, ulong typeTag, IntPtr self, MDataInfoRandomPublicCb callback);

    #endregion

    #region MDataInfoSerialise

    public void MDataInfoSerialise(IntPtr appPtr, ulong infoHandle, IntPtr self, MDataInfoSerialiseCb callback) {
      MDataInfoSerialiseNative(appPtr, infoHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_info_serialise")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_info_serialise")]
#endif
    public static extern void MDataInfoSerialiseNative(IntPtr appPtr, ulong infoHandle, IntPtr self, MDataInfoSerialiseCb callback);

    #endregion

    #region MDataListEntries

    public void MDataListEntries(IntPtr appPtr, ulong infoHandle, IntPtr self, MDataListEntriesCb callback) {
      MDataListEntriesNative(appPtr, infoHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_list_entries")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_list_entries")]
#endif
    public static extern void MDataListEntriesNative(IntPtr appPtr, ulong infoHandle, IntPtr self, MDataListEntriesCb callback);

    #endregion

    #region MDataMutateEntries

    public void MDataMutateEntries(IntPtr appPtr, ulong infoHandle, ulong actionsHandle, IntPtr self, MDataMutateEntriesCb callback) {
      MDataMutateEntriesNative(appPtr, infoHandle, actionsHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_mutate_entries")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_mutate_entries")]
#endif
    public static extern void MDataMutateEntriesNative(
      IntPtr appPtr,
      ulong infoHandle,
      ulong actionsHandle,
      IntPtr self,
      MDataMutateEntriesCb callback);

    #endregion

    #region MDataPermissionSetNew

    public void MDataPermissionSetNew(IntPtr appPtr, IntPtr self, MDataPermissionSetNewCb callback) {
      MDataPermissionSetNewNative(appPtr, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_permission_set_new")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_permission_set_new")]
#endif
    public static extern void MDataPermissionSetNewNative(IntPtr appPtr, IntPtr self, MDataPermissionSetNewCb callback);

    #endregion

    #region MDataPermissionsFree

    public void MDataPermissionsFree(IntPtr appPtr, ulong permissionsHandle, IntPtr self, MDataPermissionsFreeCb callback) {
      MDataPermissionsFreeNative(appPtr, permissionsHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_permissions_free")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_permissions_free")]
#endif
    public static extern void MDataPermissionsFreeNative(
      IntPtr appPtr,
      ulong permissionsHandle,
      IntPtr self,
      MDataPermissionsFreeCb callback);

    #endregion

    #region MDataPermissionsInsert

    public void MDataPermissionsInsert(
      IntPtr appPtr,
      ulong permissionsHandle,
      ulong userHandle,
      ulong permissionSetHandle,
      IntPtr self,
      MDataPermissionsInsertCb callback) {
      MDataPermissionsInsertNative(appPtr, permissionsHandle, userHandle, permissionSetHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_permissions_insert")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_permissions_insert")]
#endif
    public static extern void MDataPermissionsInsertNative(
      IntPtr appPtr,
      ulong permissionsHandle,
      ulong userHandle,
      ulong permissionSetHandle,
      IntPtr self,
      MDataPermissionsInsertCb callback);

    #endregion

    #region MDataPermissionsNew

    public void MDataPermissionsNew(IntPtr appPtr, IntPtr self, MDataPermissionsNewCb callback) {
      MDataPermissionsNewNative(appPtr, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_permissions_new")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_permissions_new")]
#endif
    public static extern void MDataPermissionsNewNative(IntPtr appPtr, IntPtr self, MDataPermissionsNewCb callback);

    #endregion

    #region MDataPermissionsSetAllow

    public void MDataPermissionsSetAllow(
      IntPtr appPtr,
      ulong setHandle,
      MDataAction action,
      IntPtr self,
      MDataPermissionsSetAllowCb callback) {
      MDataPermissionsSetAllowNative(appPtr, setHandle, action, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_permissions_set_allow")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_permissions_set_allow")]
#endif
    public static extern void MDataPermissionsSetAllowNative(
      IntPtr appPtr,
      ulong setHandle,
      MDataAction action,
      IntPtr self,
      MDataPermissionsSetAllowCb callback);

    #endregion

    #region MDataPermissionsSetFree

    public void MDataPermissionsSetFree(IntPtr appPtr, ulong setHandle, IntPtr self, MDataPermissionsSetFreeCb callback) {
      MDataPermissionsSetFreeNative(appPtr, setHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_permissions_set_free")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_permissions_set_free")]
#endif
    public static extern void MDataPermissionsSetFreeNative(
      IntPtr appPtr,
      ulong setHandle,
      IntPtr self,
      MDataPermissionsSetFreeCb callback);

    #endregion

    #region MDataPut

    public void MDataPut(IntPtr appPtr, ulong infoHandle, ulong permissionsHandle, ulong entriesHandle, IntPtr self, MDataPutCb callback) {
      MDataPutNative(appPtr, infoHandle, permissionsHandle, entriesHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_put")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_put")]
#endif
    public static extern void MDataPutNative(
      IntPtr appPtr,
      ulong infoHandle,
      ulong permissionsHandle,
      ulong entriesHandle,
      IntPtr self,
      MDataPutCb callback);

    #endregion

    #region Sha3Hash

    public void Sha3Hash(IntPtr data, IntPtr len, IntPtr self, Sha3HashCb callback) {
      Sha3HashNative(data, len, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "sha3_hash")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "sha3_hash")]
#endif
    public static extern void Sha3HashNative(IntPtr data, IntPtr len, IntPtr self, Sha3HashCb callback);

    #endregion

    #region MDataListKeys

    public void MDataListKeys(IntPtr appPtr, ulong infoHandle, IntPtr self, MDataListKeysCb callback) {
      MDataListKeysNative(appPtr, infoHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_list_keys")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_list_keys")]
#endif
    public static extern void MDataListKeysNative(IntPtr appPtr, ulong infoHandle, IntPtr self, MDataListKeysCb callback);

    #endregion

    #region MDataKeysLen

    public void MDataKeysLen(IntPtr appPtr, ulong keysHandle, IntPtr self, MDataKeysLenCb callback) {
      MDataKeysLenNative(appPtr, keysHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_keys_len")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_keys_len")]
#endif
    public static extern void MDataKeysLenNative(IntPtr appPtr, ulong keysHandle, IntPtr self, MDataKeysLenCb callback);

    #endregion

    #region MDataKeysForEach

    public void MDataKeysForEach(IntPtr appPtr, ulong keysHandle, MDataKeysForEachCb forEachCb, IntPtr self, MDataKeysForEachResCb resCb) {
      MDataKeysForEachNative(appPtr, keysHandle, forEachCb, self, resCb);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_keys_for_each")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_keys_for_each")]
#endif
    public static extern void MDataKeysForEachNative(
      IntPtr appPtr,
      ulong keysHandle,
      MDataKeysForEachCb forEachCb,
      IntPtr self,
      MDataKeysForEachResCb resCb);

    #endregion

    #region MDataKeysFree

    public void MDataKeysFree(IntPtr appPtr, ulong keysHandle, IntPtr self, MDataKeysFreeCb callback) {
      MDataKeysFreeNative(appPtr, keysHandle, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_keys_free")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_keys_free")]
#endif
    public static extern void MDataKeysFreeNative(IntPtr appPtr, ulong keysHandle, IntPtr self, MDataKeysFreeCb callback);

    #endregion

    #region MDataInfoDecrypt

    public void MDataInfoDecrypt(
      IntPtr appPtr,
      ulong mDataInfoH,
      IntPtr cipherText,
      IntPtr cipherLen,
      IntPtr self,
      MDataInfoDecryptCb callback) {
      MDataInfoDecryptNative(appPtr, mDataInfoH, cipherText, cipherLen, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "mdata_info_decrypt")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "mdata_info_decrypt")]
#endif
    public static extern void MDataInfoDecryptNative(
      IntPtr appPtr,
      ulong mDataInfoH,
      IntPtr cipherText,
      IntPtr cipherLen,
      IntPtr self,
      MDataInfoDecryptCb callback);

    #endregion

    #region AppExeFileStem

    public void AppExeFileStem(IntPtr self, AppExeFileStemCb callback) {
      AppExeFileStemNative(self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "app_exe_file_stem")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "app_exe_file_stem")]
#endif
    public static extern void AppExeFileStemNative(IntPtr self, AppExeFileStemCb callback);

    #endregion

    #region AppSetAdditionalSearchPath

    public void AppSetAdditionalSearchPath(string path, IntPtr self, AppSetAdditionalSearchPathCb callback) {
      AppSetAdditionalSearchPathNative(path, self, callback);
    }

#if __IOS__
    [DllImport("__Internal", EntryPoint = "app_set_additional_search_path")]
#elif __ANDROID__
    [DllImport("safe_app", EntryPoint = "app_set_additional_search_path")]
#endif
    public static extern void AppSetAdditionalSearchPathNative(string path, IntPtr self, AppSetAdditionalSearchPathCb callback);

    #endregion
  }
}

#endif
