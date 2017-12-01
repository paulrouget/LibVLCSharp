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
           
            instance.SetDialogHandlers((title, text) => Task.CompletedTask,
                (dialog, title, text, username, store, token) =>
                {
                    dialog.PostLogin(username, "YOLO", false);
                    called = true;
                    return Task.CompletedTask;
                },
                (dialog, title, text, type, cancelText, actionText, secondActionText, token) => Task.CompletedTask,
                (dialog, title, text, indeterminate, position, cancelText, token) => Task.CompletedTask,
                (dialog, position, text) => Task.CompletedTask);
            
            
            
            Assert.True(called);
        }
    }
}
