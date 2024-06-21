using CefSharp.OutOfProcess.Interface;
using CefSharp.OutOfProcess.Interface.Callbacks;
using System;

namespace CefSharp.OutOfProcess.BrowserProcess.CallbackProxies
{
    internal sealed class JsDialogHandlerProxy : CallbackProxyBase<object>, IJsDialogHandler
    {
        public JsDialogHandlerProxy(IOutOfProcessHostRpc host)
            : base(host)
        {

        }

        public void Callback(JsDialogCallbackDetails details)
        {
            var cb = (CefSharp.OutOfProcess.Interface.Callbacks.IJsDialogCallback)GetCallback(details.CallbackId);

            if (details.UserInput != string.Empty)
            {
                cb.Continue(details.Success, details.UserInput);
            }
            else
            {
                cb.Continue(details.Success);
            }
        }

        public bool OnBeforeUnloadDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, string messageText, bool isReload, IJsDialogCallback callback)
        {
            var result = host.OnBeforeUnloadDialog(((OutOfProcessChromiumWebBrowser)chromiumWebBrowser).Id, messageText, isReload, CreateCallback(callback));
            return result;
        }

        public void OnDialogClosed(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            host.OnDialogClosed(((OutOfProcessChromiumWebBrowser)chromiumWebBrowser).Id);
        }

        public bool OnJSDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage)
        {
            var result = host.OnJSDialog(((OutOfProcessChromiumWebBrowser)chromiumWebBrowser).Id, originUrl, ParseEnum<Interface.Callbacks.CefJsDialogType>(Enum.GetName(typeof(CefJsDialogType), dialogType)), messageText, defaultPromptText, CreateCallback(callback), ref suppressMessage);
            return result;
        }

        public void OnResetDialogState(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            host.OnResetDialogState(((OutOfProcessChromiumWebBrowser)chromiumWebBrowser).Id);
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}