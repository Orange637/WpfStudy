namespace WpfStudy.Resources.Commands
{
    using System.Windows.Input;

    public static class CustomCommands
    {
        static CustomCommands()
        {
            ResetCommand = new RoutedUICommand(
                "Reset",
                "Reset",
                typeof(CustomCommands),
                new InputGestureCollection(new[] { new KeyGesture(Key.R, ModifierKeys.Alt) }));

            FitCommand = new RoutedCommand(
                "Fit",
                typeof(CustomCommands),
                new InputGestureCollection(new[] { new KeyGesture(Key.F, ModifierKeys.Alt) }));

            RotateLeftCommand = new RoutedCommand(
                "RotateLeft",
                typeof(CustomCommands),
                new InputGestureCollection(new[] { new KeyGesture(Key.Left, ModifierKeys.Alt) }));

            RotateRightCommand = new RoutedCommand(
                "RotateRight",
                typeof(CustomCommands),
                new InputGestureCollection(new[] { new KeyGesture(Key.Right, ModifierKeys.Alt) }));
        }

        public static RoutedUICommand ResetCommand { get; private set; }

        public static RoutedCommand FitCommand { get; private set; }

        public static RoutedCommand RotateLeftCommand { get; private set; }

        public static RoutedCommand RotateRightCommand { get; private set; }
    }
}
