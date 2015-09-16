// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockItem.cs" company="mm-software">
//   mm-software
// </copyright>
// <summary>
//   The stock item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfStudy.Model
{
    using WpfStudy.Infrastructure;

    /// <summary>
    /// The stock item.
    /// </summary>
    public class StockItem : ObservableObject
    {
        private string name;

        private double value;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.SetProperty(ref this.name, value, () => this.Name);
            }
        }

        public double Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.SetProperty(ref this.value, value, () => this.Value);
            }
        }
    }
}