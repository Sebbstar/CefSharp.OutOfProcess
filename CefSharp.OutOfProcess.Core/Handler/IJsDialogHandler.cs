namespace CefSharp.OutOfProcess.Handler
{
    using CefSharp.OutOfProcess.Interface.Callbacks;
    
    public interface IJsDialogHandler
    {

        bool OnJSDialog(IChromiumWebBrowser chromiumWebBrowser, string originUrl, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage);

        bool OnBeforeUnloadDialog(IChromiumWebBrowser chromiumWebBrowser, string messageText, bool isReload, IJsDialogCallback callback);

        void OnResetDialogState(IChromiumWebBrowser chromiumWebBrowser);

        void OnDialogClosed(IChromiumWebBrowser chromiumWebBrowser);
    }
}