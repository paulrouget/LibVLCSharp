using System.Threading.Tasks;
using NUnit.Framework;
using VideoLAN.LibVLC;

namespace LibVLCSharp.Tests
{
    [TestFixture]
    public class DialogTests
    {
        const string UrlRequireAuth = "http://httpbin.org/basic-auth/user/passwd";

        [Test]
        public async Task PostLoginOk()
        {
            var instance = new Instance();
            var called = false;

            instance.SetDialogHandlers((title, text) => Task.CompletedTask,
                (dialog, title, text, username, store, token) =>
                {
                    // show UI dialog
                    // On "OK" call PostLogin
                    dialog.PostLogin(username, null, false);
                    called = true;
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
            await Task.Delay(1000);
            Assert.True(called);
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
                    Assert.Throws<VLCException>(() => dialog.PostLogin(username, null, false), "Calling method on dismissed Dialog instance");
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
        public async Task PostLoginCancel()
        {
            var instance = new Instance();
            var called = false;

            instance.SetDialogHandlers((title, text) => Task.CompletedTask,
                (dialog, title, text, username, store, token) =>
                {
                    // show UI dialog
                    // On "Cancel", cancel token which 
                    // TODO FIXME: How to trigger cancel cb?
                    token.Register(() =>
                    {
                        dialog.Dismiss();
                        called = true;
                    });
                    
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
            await Task.Delay(1000);
            Assert.True(called);
        }
    }
}