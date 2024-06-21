namespace CefSharp.OutOfProcess.Interface.Callbacks
{
    /// <summary>
    /// Supported JavaScript dialog types.
    /// </summary>
    public enum CefJsDialogType
    {
        /// <summary>
        /// Alert Dialog
        /// </summary>
        Alert = 0,
        /// <summary>
        /// Confirm Dialog
        /// </summary>
        Confirm,
        /// <summary>
        /// Prompt Dialog
        /// </summary>
        Prompt
    }
}