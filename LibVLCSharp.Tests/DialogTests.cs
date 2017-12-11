using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using VideoLAN.LibVLC;

namespace Bindings.Tests
{
    [TestFixture]
    public class DialogTests
    {
        const string UrlRequireAuth = "http://httpbin.org/basic-auth/user/passwd";

        [Test]
        public async Task PostLogin()
        {
            var instance = new Instance();
            var tcs = new TaskCompletionSource<bool>();

            instance.SetDialogHandlers((title, text) => Task.CompletedTask,
                (dialog, title, text, username, store, token) =>
                {
                    // show UI dialog
                    // On "OK" call PostLogin
                    dialog.PostLogin(username, null, false);
                    tcs.SetResult(true);
                    return Task.CompletedTask;
                },
                (dialog, title, text, type, cancelText, actionText, secondActionText, token) => Task.CompletedTask,
                (dialog, title, text, indeterminate, position, cancelText, token) => Task.CompletedTask,
                (dialog, position, text) => Task.CompletedTask);

            var mp = new MediaPlayer(instance)
            {
                Media = new Media(instance, UrlRequireAuth, Media.FromType.FromLocation)
            };

            mp.Play();

            await tcs.Task;
            Assert.True(tcs.Task.Result);
        }

        [Test]
        public async Task ShouldThrowIfReusingSameDialogAfterLoginCall()
        {
            var instance = new Instance();
            var tcs = new TaskCompletionSource<bool>();

            instance.SetDialogHandlers((title, text) => Task.CompletedTask,
                (dialog, title, text, username, store, token) =>
                {
                    dialog.PostLogin(username, null, false);
                    Assert.Throws<VLCException>(() => dialog.PostLogin(null, null, false), "Calling method on dismissed Dialog instance");
                    tcs.SetResult(true);
                    return Task.CompletedTask;
                },
                (dialog, title, text, type, cancelText, actionText, secondActionText, token) => Task.CompletedTask,
                (dialog, title, text, indeterminate, position, cancelText, token) => Task.CompletedTask,
                (dialog, position, text) => Task.CompletedTask);

            var mp = new MediaPlayer(instance)
            {
                Media = new Media(instance, UrlRequireAuth, Media.FromType.FromLocation)
            };

            mp.Play();

            await tcs.Task;
            Assert.True(tcs.Task.Result);
        }
    }
}
