// ----------------------------------------------------------------------------
// <auto-generated>
// This is autogenerated code by CppSharp.
// Do not edit this file or all your changes will be lost after re-generation.
// </auto-generated>
// ----------------------------------------------------------------------------
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace VideoLAN.LibVLC
{
    /// <summary>
    /// <para>@{</para>
    /// <para></para>
    /// <para>LibVLC dialog external API</para>
    /// </summary>
    public enum DialogQuestionType
    {
        Normal = 0,
        Warning = 1,
        Critical = 2
    }

    public unsafe partial class DialogId
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::VideoLAN.LibVLC.DialogId> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::VideoLAN.LibVLC.DialogId>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::VideoLAN.LibVLC.DialogId __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::VideoLAN.LibVLC.DialogId(native.ToPointer(), skipVTables);
        }

        internal static global::VideoLAN.LibVLC.DialogId __CreateInstance(global::VideoLAN.LibVLC.DialogId.__Internal native, bool skipVTables = false)
        {
            return new global::VideoLAN.LibVLC.DialogId(native, skipVTables);
        }

        private static void* __CopyValue(global::VideoLAN.LibVLC.DialogId.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::VideoLAN.LibVLC.DialogId.__Internal));
            *(global::VideoLAN.LibVLC.DialogId.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private DialogId(global::VideoLAN.LibVLC.DialogId.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected DialogId(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    /// <summary>Dialog callbacks to be implemented</summary>
    public unsafe partial class DialogCallback : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 48)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr pf_display_error;

            [FieldOffset(8)]
            internal global::System.IntPtr pf_display_login;

            [FieldOffset(16)]
            internal global::System.IntPtr pf_display_question;

            [FieldOffset(24)]
            internal global::System.IntPtr pf_display_progress;

            [FieldOffset(32)]
            internal global::System.IntPtr pf_cancel;

            [FieldOffset(40)]
            internal global::System.IntPtr pf_update_progress;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0libvlc_dialog_cbs@@QEAA@AEBU0@@Z")]
            internal static extern global::System.IntPtr cctor(global::System.IntPtr instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::VideoLAN.LibVLC.DialogCallback> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::VideoLAN.LibVLC.DialogCallback>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::VideoLAN.LibVLC.DialogCallback __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::VideoLAN.LibVLC.DialogCallback(native.ToPointer(), skipVTables);
        }

        internal static global::VideoLAN.LibVLC.DialogCallback __CreateInstance(global::VideoLAN.LibVLC.DialogCallback.__Internal native, bool skipVTables = false)
        {
            return new global::VideoLAN.LibVLC.DialogCallback(native, skipVTables);
        }

        private static void* __CopyValue(global::VideoLAN.LibVLC.DialogCallback.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::VideoLAN.LibVLC.DialogCallback.__Internal));
            *(global::VideoLAN.LibVLC.DialogCallback.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private DialogCallback(global::VideoLAN.LibVLC.DialogCallback.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected DialogCallback(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public DialogCallback()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::VideoLAN.LibVLC.DialogCallback.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public DialogCallback(global::VideoLAN.LibVLC.DialogCallback _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::VideoLAN.LibVLC.DialogCallback.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::VideoLAN.LibVLC.DialogCallback.__Internal*) __Instance) = *((global::VideoLAN.LibVLC.DialogCallback.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::VideoLAN.LibVLC.DialogCallback __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }
    }

    public unsafe partial class libvlc_dialog
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="libvlc_dialog_set_callbacks")]
            internal static extern void LibvlcDialogSetCallbacks(global::System.IntPtr p_instance, global::System.IntPtr p_cbs, global::System.IntPtr p_data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="libvlc_dialog_set_context")]
            internal static extern void LibvlcDialogSetContext(global::System.IntPtr p_id, global::System.IntPtr p_context);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="libvlc_dialog_get_context")]
            internal static extern global::System.IntPtr LibvlcDialogGetContext(global::System.IntPtr p_id);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="libvlc_dialog_post_login")]
            internal static extern int LibvlcDialogPostLogin(global::System.IntPtr p_id, [MarshalAs(UnmanagedType.LPStr)] string psz_username, [MarshalAs(UnmanagedType.LPStr)] string psz_password, bool b_store);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="libvlc_dialog_post_action")]
            internal static extern int LibvlcDialogPostAction(global::System.IntPtr p_id, int i_action);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="libvlc_dialog_dismiss")]
            internal static extern int LibvlcDialogDismiss(global::System.IntPtr p_id);
        }

        /// <summary>Register callbacks in order to handle VLC dialogs</summary>
        /// <param name="p_cbs">a pointer to callbacks, or NULL to unregister callbacks.</param>
        /// <param name="p_data">opaque pointer for the callback</param>
        /// <remarks>LibVLC 3.0.0 and later.</remarks>
        public static void LibvlcDialogSetCallbacks(global::VideoLAN.LibVLC.Instance p_instance, global::VideoLAN.LibVLC.DialogCallback p_cbs, global::System.IntPtr p_data)
        {
            var __arg0 = ReferenceEquals(p_instance, null) ? global::System.IntPtr.Zero : p_instance.NativeReference;
            var __arg1 = ReferenceEquals(p_cbs, null) ? global::System.IntPtr.Zero : p_cbs.__Instance;
            __Internal.LibvlcDialogSetCallbacks(__arg0, __arg1, p_data);
        }

        /// <summary>Associate an opaque pointer with the dialog id</summary>
        /// <remarks>LibVLC 3.0.0 and later.</remarks>
        public static void LibvlcDialogSetContext(global::VideoLAN.LibVLC.DialogId p_id, global::System.IntPtr p_context)
        {
            var __arg0 = ReferenceEquals(p_id, null) ? global::System.IntPtr.Zero : p_id.__Instance;
            __Internal.LibvlcDialogSetContext(__arg0, p_context);
        }

        /// <summary>Return the opaque pointer associated with the dialog id</summary>
        /// <remarks>LibVLC 3.0.0 and later.</remarks>
        public static global::System.IntPtr LibvlcDialogGetContext(global::VideoLAN.LibVLC.DialogId p_id)
        {
            var __arg0 = ReferenceEquals(p_id, null) ? global::System.IntPtr.Zero : p_id.__Instance;
            var __ret = __Internal.LibvlcDialogGetContext(__arg0);
            return __ret;
        }

        /// <summary>Post a login answer</summary>
        /// <param name="p_id">id of the dialog</param>
        /// <param name="psz_username">valid and non empty string</param>
        /// <param name="psz_password">valid string (can be empty)</param>
        /// <param name="b_store">if true, store the credentials</param>
        /// <returns>0 on success, or -1 on error</returns>
        /// <remarks>
        /// <para>After this call, p_id won't be valid anymore</para>
        /// <para>libvlc_dialog_cbs.pf_display_login</para>
        /// <para>LibVLC 3.0.0 and later.</para>
        /// </remarks>
        public static int LibvlcDialogPostLogin(global::VideoLAN.LibVLC.DialogId p_id, string psz_username, string psz_password, bool b_store)
        {
            var __arg0 = ReferenceEquals(p_id, null) ? global::System.IntPtr.Zero : p_id.__Instance;
            var __ret = __Internal.LibvlcDialogPostLogin(__arg0, psz_username, psz_password, b_store);
            return __ret;
        }

        /// <summary>Post a question answer</summary>
        /// <param name="p_id">id of the dialog</param>
        /// <param name="i_action">1 for action1, 2 for action2</param>
        /// <returns>0 on success, or -1 on error</returns>
        /// <remarks>
        /// <para>After this call, p_id won't be valid anymore</para>
        /// <para>libvlc_dialog_cbs.pf_display_question</para>
        /// <para>LibVLC 3.0.0 and later.</para>
        /// </remarks>
        public static int LibvlcDialogPostAction(global::VideoLAN.LibVLC.DialogId p_id, int i_action)
        {
            var __arg0 = ReferenceEquals(p_id, null) ? global::System.IntPtr.Zero : p_id.__Instance;
            var __ret = __Internal.LibvlcDialogPostAction(__arg0, i_action);
            return __ret;
        }

        /// <summary>Dismiss a dialog</summary>
        /// <param name="p_id">id of the dialog</param>
        /// <returns>0 on success, or -1 on error</returns>
        /// <remarks>
        /// <para>After this call, p_id won't be valid anymore</para>
        /// <para>libvlc_dialog_cbs.pf_cancel</para>
        /// <para>LibVLC 3.0.0 and later.</para>
        /// </remarks>
        public static int LibvlcDialogDismiss(global::VideoLAN.LibVLC.DialogId p_id)
        {
            var __arg0 = ReferenceEquals(p_id, null) ? global::System.IntPtr.Zero : p_id.__Instance;
            var __ret = __Internal.LibvlcDialogDismiss(__arg0);
            return __ret;
        }
    }
}
