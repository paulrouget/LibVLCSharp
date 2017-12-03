using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using VideoLAN.LibVLC;
using VideoLAN.LibVLC.Manual;
using MediaList = VideoLAN.LibVLC.Manual.MediaList;

namespace Bindings.Tests
{
    [TestFixture]
    public class MediaListPlayerTests
    {
        [Test]
        public async Task Create()
        {
            //TODO: Fix me
            var instance = new Instance();
            var mediaListPlayer = new MediaListPlayer(instance);
            var media = new Media(instance, "http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4", Media.FromType.FromLocation);         
            Assert.AreEqual(VLCState.NothingSpecial, mediaListPlayer.State);          
            mediaListPlayer.MediaList = new MediaList(media);
            mediaListPlayer.PlayItem(media);
            await Task.Delay(5000);
            Assert.True(mediaListPlayer.IsPlaying);
            Assert.AreEqual(VLCState.Playing, mediaListPlayer.State);
        }
    }
}