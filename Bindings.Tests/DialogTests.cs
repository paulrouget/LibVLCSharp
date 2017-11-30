using System.Diagnostics;
using System.Threading.Tasks;
using NUnit.Framework;
using VideoLAN.LibVLC.Manual;

namespace Bindings.Tests
{
    [TestFixture]
    public class DialogTests
    {
        [Test]
        public void PostLogin()
        {
            var instance = new Instance();
            bool called = false;
            //instance.SetDialogHandlers(
            //    (title, text) => {},
            //    (id, title, text, username, store) =>
            //    {
            //        new Dialog()
            //        called = true;
            //        Debug.WriteLine("Login");
            //    },
            //    (data, id, title, text, type, cancelText, actionText, secondActionText) => {},
            //    (data, id, title, text, indeterminate, position, cancelText) => {},
            //    (data, id) => {},
            //    (data, id, position, text) => {});

            instance.SetDialogHandlers2((title, text) => Task.CompletedTask,
                (title, text, username, store, token) => Task.CompletedTask,
                (title, text, type, cancelText, actionText, secondActionText, token) => Task.CompletedTask,
                (title, text, indeterminate, position, cancelText, token) => Task.CompletedTask,
                (position, text) => Task.CompletedTask);
            
            
            //dialog.PostLogin("t", "t", false);
            Assert.True(called);
        }
    }
}
