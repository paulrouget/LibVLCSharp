﻿using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace VideoLAN.LibVLC
{
    //TODO: v3
    public class Dialog : IDisposable
    {
        IntPtr _id;
        
        struct Native
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_dialog_post_login")]
            internal static extern int LibVLCDialogPostLogin(IntPtr dialogId, [MarshalAs(UnmanagedType.LPStr)] string username, 
                [MarshalAs(UnmanagedType.LPStr)] string password, bool store);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_dialog_post_action")]
            internal static extern int LibVLCDialogPostAction(IntPtr dialogId, int actionIndex);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_dialog_dismiss")]
            internal static extern int LibVLCDialogDismiss(IntPtr dialogId);
        }

        Dialog(IntPtr id)
        {
            if(id == IntPtr.Zero)
                throw new ArgumentNullException(nameof(id));
            _id = id;
        }

        public Dialog(DialogId id) : this(id.NativeReference)
        {
        }

        public void Dispose()
        {
            if(_id != IntPtr.Zero)
                Marshal.FreeHGlobal(_id);
        }

        ~Dialog()
        {
            Dismiss();
        }

        /// <summary>
        /// Post a login answer.
        /// After this call, the instance won't be valid anymore
        /// </summary>
        /// <param name="username">valid non-empty string</param>
        /// <param name="password">valid string</param>
        /// <param name="store">if true stores the credentials</param>
        /// <returns></returns>
        public bool PostLogin(string username, string password, bool store)
        {
            if(_id == IntPtr.Zero)
                throw new VLCException("Calling method on dismissed Dialog instance");

            var result = Native.LibVLCDialogPostLogin(_id, username ?? string.Empty, password ?? string.Empty, store) == 0;
            _id = IntPtr.Zero;

            return result;
        }
        
        /// <summary>
        /// Post a question answer.
        /// After this call, this instance won't be valid anymore
        /// QuestionCb
        /// </summary>
        /// <param name="actionIndex">1 for action1, 2 for action2</param>
        /// <returns>return true on success, false otherwise</returns>
        public bool PostAction(int actionIndex)
        {
            if (_id == IntPtr.Zero)
                throw new VLCException("Calling method on dismissed Dialog instance");
            if(actionIndex != 1 && actionIndex != 2)
                throw new IndexOutOfRangeException($"{nameof(actionIndex)} should be 1 or 2 but is {actionIndex}");

            var result = Native.LibVLCDialogPostAction(_id, actionIndex) == 0;
            _id = IntPtr.Zero;

            return result;
        }

        /// <summary>
        /// Dismiss a dialog.
        /// After this call, this instance won't be valid anymore
        /// </summary>
        /// <returns></returns>
        public bool Dismiss()
        {
            if (_id == IntPtr.Zero)
                throw new VLCException("Calling method on dismissed Dialog instance");

            var result = Native.LibVLCDialogDismiss(_id) == 0;
            _id = IntPtr.Zero;

            return result;
        }
    }

    public struct DialogId
    {
        public IntPtr NativeReference { get; set; }
    }

    public enum DialogQuestionType
    {
        Normal = 0,
        Warning = 1,
        Critical = 2
    }

    public delegate Task DisplayError(string title, string text);

    public delegate Task DisplayLogin(Dialog dialog, string title, string text, string defaultUsername, bool askStore, CancellationToken token);

    public delegate Task DisplayQuestion(Dialog dialog, string title, string text, DialogQuestionType type, string cancelText,
        string firstActionText, string secondActionText, CancellationToken token);

    public delegate Task DisplayProgress(Dialog dialog, string title, string text, bool indeterminate, float position, string cancelText, CancellationToken token);

    public delegate Task UpdateProgress(Dialog dialog, float position, string text);

    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DisplayErrorCallback(IntPtr data, string title, string text);

    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DisplayLoginCallback(IntPtr data, IntPtr dialogId, string title, string text,
        string defaultUsername, bool askStore);

    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DisplayQuestionCallback(IntPtr data, IntPtr dialogId, string title, string text,
        DialogQuestionType type, string cancelText, string firstActionText, string secondActionText);

    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DisplayProgressCallback(IntPtr data, IntPtr dialogId, string title, string text,
        bool indeterminate, float position, string cancelText);

    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CancelCallback(IntPtr data, IntPtr dialogId);

    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void UpdateProgressCallback(IntPtr data, IntPtr dialogId, float position, string text);

    /// <summary>Dialog callbacks to be implemented</summary>
    public struct DialogCallbacks
    {
        public DisplayErrorCallback DisplayError;

        public DisplayLoginCallback DisplayLogin;

        public DisplayQuestionCallback DisplayQuestion;

        public DisplayProgressCallback DisplayProgress;

        public CancelCallback Cancel;

        public UpdateProgressCallback UpdateProgress;
    }
}
