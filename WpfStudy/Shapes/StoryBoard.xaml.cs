using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfStudy.Shapes
{
    /// <summary>
    /// Interaction logic for StoryBoard.xaml
    /// </summary>
    public partial class StoryBoard : Window
    {
        public StoryBoard()
        {
            InitializeComponent();
        }

        private void RunByCode(object sender, RoutedEventArgs e)
        {
            var storyBoard = new Storyboard();
            var animation1 = new DoubleAnimation
                {
                    To = 400, From = 0,
                    Duration = TimeSpan.FromSeconds(1),
                    FillBehavior = FillBehavior.HoldEnd
                };
            var animation2 = new DoubleAnimation
                {
                    To = 400, From = 0,
                    Duration = TimeSpan.FromSeconds(1),
                    FillBehavior = FillBehavior.HoldEnd
                };
            var animation3 = new DoubleAnimation
                {
                    To = 400, From = 0,
                    Duration = TimeSpan.FromSeconds(1),
                    FillBehavior = FillBehavior.HoldEnd
                };

            Storyboard.SetTargetName(animation1, "WhiteAthlete");
            Storyboard.SetTargetProperty(animation1, new PropertyPath(TranslateTransform.XProperty));
            Storyboard.SetTargetName(animation2, "BlackAthlete");
            Storyboard.SetTargetProperty(animation2, new PropertyPath(TranslateTransform.XProperty));
            Storyboard.SetTargetName(animation3, "BrownAthlete");
            Storyboard.SetTargetProperty(animation3, new PropertyPath(TranslateTransform.XProperty));

            storyBoard.Duration = TimeSpan.FromSeconds(1);
            storyBoard.Children.Add(animation1);
            storyBoard.Children.Add(animation2);
            storyBoard.Children.Add(animation3);
            storyBoard.Begin(this);
        }
    }
}
