using System;
using System.Runtime.InteropServices;
using System.Security;

namespace VideoLAN.LibVLC.Manual
{
    public class MediaListPlayer : Internal
    {
        MediaListEventManager _eventManager;

        struct Native
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_media_list_player_new")]
            internal static extern IntPtr LibVLCMediaListPlayerNew(IntPtr instance);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_media_list_player_release")]
            internal static extern void LibVLCMediaListPlayerRelease(IntPtr mediaListPlayer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_media_list_player_event_manager")]
            internal static extern IntPtr LibVLCMediaListPlayerEventManager(IntPtr mediaListPlayer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_media_list_player_set_media_player")]
            internal static extern void LibVLCMediaListPlayerSetMediaPlayer(IntPtr mediaListPlayer, IntPtr mediaPlayer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_media_list_player_set_media_list")]
            internal static extern void LibVLCMediaListPlayerSetMediaList(IntPtr mediaListPlayer, IntPtr mediaList);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_media_list_player_play")]
            internal static extern void LibVLCMediaListPlayerPlay(IntPtr mediaListPlayer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_media_list_player_pause")]
            internal static extern void LibVLCMediaListPlayerPause(IntPtr mediaListPlayer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_media_list_player_is_playing")]
            internal static extern int LibVLCMediaListPlayerIsPlaying(IntPtr mediaListPlayer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_media_list_player_get_state")]
            internal static extern VLCState LibVLCMediaListPlayerGetState(IntPtr mediaListPlayer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_media_list_player_play_item_at_index")]
            internal static extern int LibVLCMediaListPlayerPlayItemAtIndex(IntPtr mediaListPlayer, int index);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_media_list_player_play_item")]
            internal static extern int LibVLCMediaListPlayerPlayItem(IntPtr mediaListPlayer, IntPtr media);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_media_list_player_stop")]
            internal static extern void LibVLCMediaListPlayerStop(IntPtr mediaListPlayer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_media_list_player_next")]
            internal static extern int LibVLCMediaListPlayerNext(IntPtr mediaListPlayer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_media_list_player_previous")]
            internal static extern int LibVLCMediaListPlayerPrevious(IntPtr mediaListPlayer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_media_list_player_set_playback_mode")]
            internal static extern void LibVLCMediaListPlayerSetPlaybackMode(IntPtr mediaListPlayer, PlaybackMode mode);

        }

        public MediaListPlayer(Instance instance)
            : base(() => Native.LibVLCMediaListPlayerNew(instance.NativeReference), Native.LibVLCMediaListPlayerRelease)
        {
        }

        /// <summary>Return the event manager of this media_list_player.</summary>
        /// <returns>the event manager</returns>
        public MediaListEventManager EventManager
        {
            get
            {
                if (_eventManager == null)
                {
                    var ptr = Native.LibVLCMediaListPlayerEventManager(NativeReference);
                    _eventManager = new MediaListEventManager(ptr);
                }
                return _eventManager;
            }
        }

        /// <summary>Replace media player in media_list_player with this instance.</summary>
        public MediaPlayer MediaPlayer
        {
            set => Native.LibVLCMediaListPlayerSetMediaPlayer(NativeReference, value.NativeReference);
        }

        /// <summary>Set the media list associated with the player</summary>
        public MediaList MediaList
        {
            set => Native.LibVLCMediaListPlayerSetMediaList(NativeReference, value.NativeReference);
        }

        /// <summary>Play media list</summary>
        public void Play()
        {
            Native.LibVLCMediaListPlayerPlay(NativeReference);
        }

        /// <summary>Toggle pause (or resume) media list</summary>
        public void Pause()
        {
            Native.LibVLCMediaListPlayerPause(NativeReference);
        }

        /// <summary>Is media list playing?</summary>
        public bool IsPlaying => Native.LibVLCMediaListPlayerIsPlaying(NativeReference) != 0;

        /// <summary>
        /// Get current libvlc_state of media list player
        /// </summary>
        public VLCState State => Native.LibVLCMediaListPlayerGetState(NativeReference);

        /// <summary>
        /// Play media list item at position index
        /// </summary>
        /// <param name="index">index in media list to play</param>
        public bool PlayItemAtIndex(int index) =>
            Native.LibVLCMediaListPlayerPlayItemAtIndex(NativeReference, index) == 0;

        /// <summary>
        /// Play the given media item
        /// </summary>
        /// <param name="media">the media instance</param>
        public bool PlayItem(Media media) =>
            Native.LibVLCMediaListPlayerPlayItem(NativeReference, media.NativeReference) == 0;

        /// <summary>
        /// Stop playing media list
        /// </summary>
        public void Stop() => Native.LibVLCMediaListPlayerStop(NativeReference);

        /// <summary>
        /// Play next item from media list
        /// </summary>
        public bool Next() => Native.LibVLCMediaListPlayerNext(NativeReference) == 0;

        /// <summary>
        /// Play previous item from media list
        /// </summary>
        public bool Previous() => Native.LibVLCMediaListPlayerPrevious(NativeReference) == 0;

        /// <summary>
        /// Sets the playback mode for the playlist
        /// </summary>
        public PlaybackMode PlaybackMode
        {
            set => Native.LibVLCMediaListPlayerSetPlaybackMode(NativeReference, value);
        }
    }

    /// <summary>Defines playback modes for playlist.</summary>
    public enum PlaybackMode
    {
        Default = 0,
        Loop = 1,
        Repeat = 2
    }
}