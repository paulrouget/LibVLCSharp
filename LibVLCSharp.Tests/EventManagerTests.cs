﻿using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using VideoLAN.LibVLC;
using Media = VideoLAN.LibVLC.Media;

namespace LibVLCSharp.Tests
{
    [TestFixture]
    public class EventManagerTests
    {
        [Test]
        public void MetaChangedEventSubscribe()
        {
            var media = new Media(new Instance(), Path.GetTempFileName(), Media.FromType.FromPath);
            var eventManager = media.EventManager;
            var eventHandlerCalled = false;
            const Media.MetadataType description = Media.MetadataType.Description;
            eventManager.MetaChanged += (sender, args) =>
            {
                Assert.AreEqual(description, args.MetadataType);
                eventHandlerCalled = true;
            };
            media.SetMeta(Media.MetadataType.Description, "test");
            Assert.True(eventHandlerCalled);
        }

        [Test]
        public void SubItemAdded()
        {
            // FIXME
            var instance = new Instance();
            var media = new Media(instance, RealMediaPath, Media.FromType.FromPath);
            var subItem = new Media(instance, Path.GetTempFileName(), Media.FromType.FromPath);

            var eventManager = media.EventManager;
            var eventHandlerCalled = false;
            eventManager.SubItemAdded += (sender, args) =>
            {
                Assert.AreEqual(subItem, args.SubItem);
                eventHandlerCalled = true;
            };
            media.SubItems.Lock();
            Assert.True(media.SubItems.AddMedia(subItem));
            media.SubItems.Unlock();
            Assert.True(eventHandlerCalled);
        }

        string RealMediaPath
        {
            get
            {
                var dir = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                //var binDir = Path.Combine(dir, "..\\..\\..\\");
                var files = Directory.GetFiles(dir);
                return files.First(f => f.Contains("Klang"));
            }
        }

        [Test]
        public void DurationChanged()
        {
            var media = new Media(new Instance(), RealMediaPath, Media.FromType.FromPath);
            var called = false;
            long duration = 0;

            media.EventManager.DurationChanged += (sender, args) =>
            {
                called = true;
                duration = args.Duration;
            };

            media.Parse();

            Assert.True(called);
            Assert.NotZero(duration);
        }

        [Test]
        public void FreedMedia()
        {
            var media = new Media(new Instance(), RealMediaPath, Media.FromType.FromPath);
            var eventCalled = false;
            media.EventManager.MediaFreed += (sender, args) =>
            {
                eventCalled = true;
            };

            media.Dispose();

            Assert.True(eventCalled);
        }

        [Test]
        public async Task StateChanged()
        {
            var media = new Media(new Instance(), RealMediaPath, Media.FromType.FromPath);
            var tcs = new TaskCompletionSource<bool>();
            var openingCalled = false;
            media.EventManager.StateChanged += (sender, args) =>
            {
                if (media.State == VLCState.Opening)
                {
                    openingCalled = true;
                    return;
                }
                Assert.AreEqual(VLCState.Playing, media.State);
                tcs.SetResult(true);
            };

            var mp = new MediaPlayer(media);
            mp.Play();
            await tcs.Task;
            Assert.True(tcs.Task.Result);
            Assert.True(openingCalled);
        }


        [Test]
        public void SubItemTreeAdded()
        {
            var media = new Media(new Instance(), RealMediaPath, Media.FromType.FromPath);
            //TODO: Implement MediaList.cs
            Assert.Fail();
        }
    }
}