namespace TaskVision.Resources.Controls
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Media.Imaging;

    public class MessageDialog
    {
        public static MessageBoxResult Show(
            string messageBoxText,
            string caption,
            MessageBoxButton button,
            MessageDialogImage icon,
            MessageBoxResult defaultResult)
        {
            return ShowCore(messageBoxText, caption, button, icon, defaultResult);
        }

        public static MessageBoxResult Show(
            string messageBoxText,
            string caption,
            MessageBoxButton button,
            MessageDialogImage icon)
        {
            return ShowCore(messageBoxText, caption, button, icon, 0);
        }

        public static MessageBoxResult Show(
            string messageBoxText,
            string caption,
            MessageBoxButton button)
        {
            return ShowCore(messageBoxText, caption, button, MessageDialogImage.None, 0);
        }

        public static MessageBoxResult Show(string messageBoxText, string caption)
        {
            return ShowCore(messageBoxText, caption, MessageBoxButton.OK, MessageDialogImage.None, 0);
        }

        public static MessageBoxResult Show(string messageBoxText)
        {
            return ShowCore(messageBoxText, string.Empty, MessageBoxButton.OK, MessageDialogImage.None, 0);
        }

        private static MessageBoxResult ShowCore(
            string messageBoxText,
            string caption,
            MessageBoxButton button,
            MessageDialogImage icon,
            MessageBoxResult defaultResult)
        {
            if (!IsValidMessageBoxButton(button))
            {
                throw new InvalidEnumArgumentException("button", (int)button, typeof(MessageBoxButton));
            }

            if (!IsValidMessageDialogImage(icon))
            {
                throw new InvalidEnumArgumentException("icon", (int)icon, typeof(MessageBoxImage));
            }

            if (!IsValidMessageBoxResult(defaultResult))
            {
                throw new InvalidEnumArgumentException("defaultResult", (int)defaultResult, typeof(MessageBoxResult));
            }

            var dialog = new Dialog(messageBoxText, caption, button, icon, defaultResult);
            var flag = dialog.ShowDialog();
            return flag == true ? MessageBoxResult.No : MessageBoxResult.None;
        }

        private static bool IsValidMessageBoxButton(MessageBoxButton value)
        {
            return value == MessageBoxButton.OK
                || value == MessageBoxButton.OKCancel
                || value == MessageBoxButton.YesNo
                || value == MessageBoxButton.YesNoCancel;
        }

        private static bool IsValidMessageDialogImage(MessageDialogImage value)
        {
            return value == MessageDialogImage.Error
                || value == MessageDialogImage.Information
                || value == MessageDialogImage.None
                || value == MessageDialogImage.Warning;
        }

        private static bool IsValidMessageBoxResult(MessageBoxResult value)
        {
            return value == MessageBoxResult.Cancel
                || value == MessageBoxResult.No
                || value == MessageBoxResult.None
                || value == MessageBoxResult.OK
                || value == MessageBoxResult.Yes;
        }
    }
 }
