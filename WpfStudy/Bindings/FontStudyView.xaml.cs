namespace WpfStudy.Bindings
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for FontStudyView.xaml.
    /// </summary>
    public partial class FontStudyView
    {
        private double customFontSize;

        private FontWeight customFontWeight;

        private FontStyle customFontStyle;


        public FontStudyView()
        {
            this.InitializeComponent();
        }


        public double CustomFontSize
        {
            get
            {
                return this.customFontSize;
            }

            set
            {
                this.SetProperty(ref this.customFontSize, value, () => this.CustomFontSize);
            }
        }

        public FontWeight CustomFontWeight
        {
            get
            {
                return this.customFontWeight;
            }

            set
            {
                this.SetProperty(ref this.customFontWeight, value, () => this.CustomFontWeight);
            }
        }

        public FontStyle CustomFontStyle
        {
            get
            {
                return this.customFontStyle;
            }

            set
            {
                this.SetProperty(ref this.customFontStyle, value, () => this.CustomFontStyle);
            }
        }

        private void MakeFontBold(object sender, RoutedEventArgs e)
        {
            this.CustomFontWeight = this.customFontWeight.Equals(FontWeights.Bold)
                                        ? FontWeights.Normal
                                        : FontWeights.Bold;
        }

        private void MakeFontItalic(object sender, RoutedEventArgs e)
        {
            this.CustomFontStyle = this.customFontStyle.Equals(FontStyles.Italic)
                                       ? FontStyles.Normal
                                       : FontStyles.Italic;
        }

        private void MakeSelectionChanged(object sender, RoutedEventArgs e)
        {
            this.RichTextBoxOne.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Oblique);
            this.RichTextBoxOne.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
        }
    }
}
