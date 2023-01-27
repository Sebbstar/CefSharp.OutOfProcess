using System;
using System.Collections.Generic;
using System.Text;

namespace CefSharp.OutOfProcess.Interface.Callbacks
{
    public interface IJsDialogCallback : IDisposable
    {
        bool IsDisposed { get; }
        void Continue(bool success);
        void Continue(bool success, string userInput);
    }
}
