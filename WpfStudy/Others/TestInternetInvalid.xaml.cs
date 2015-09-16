// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestInternetInvalid.xaml.cs" company="mm-software">
//   mm-software
// </copyright>
// <summary>
//   Interaction logic for TestInternetInvalid.xaml.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfStudy.Others
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net.NetworkInformation;
    using System.Windows;

    /// <summary>
    /// Interaction logic for TestInternetInvalid.xaml.
    /// </summary>
    public partial class TestInternetInvalid
    {
        /// <summary>
        /// The network interface collection.
        /// </summary>
        private readonly List<NetworkInterface> networkInterfaceCollection;

        /// <summary>
        /// The internet state.
        /// </summary>
        private string internetState;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestInternetInvalid"/> class.
        /// </summary>
        public TestInternetInvalid()
        {
            this.InitializeComponent();

            this.networkInterfaceCollection = new List<NetworkInterface>();
            foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                this.networkInterfaceCollection.Add(networkInterface);
            }

            this.NetworkInterfaceCollection = new ObservableCollection<NetworkInterface>(
                this.networkInterfaceCollection);

            this.NotifyPropretyChanged(() => this.NetworkInterfaceCollection);

            this.Loaded += this.TestInternetInvalidLoaded;
        }

        /// <summary>
        /// Gets or sets the internet state.
        /// </summary>
        /// <value>
        /// The internet state.
        /// </value>
        public string InternetState
        {
            get
            {
                return this.internetState;
            }

            set
            {
                this.SetProperty(ref this.internetState, value, () => this.InternetState);
            }
        }

        /// <summary>
        /// Gets or sets the network interface collection.
        /// </summary>
        /// <value>
        /// The network interface collection.
        /// </value>
        public ObservableCollection<NetworkInterface> NetworkInterfaceCollection { get; set; }

        /// <summary>
        /// The test internet invalid loaded.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TestInternetInvalidLoaded(object sender, RoutedEventArgs e)
        {
            this.SetupNetworkChanged();
        }

        /// <summary>
        /// The setup network changed.
        /// </summary>
        private void SetupNetworkChanged()
        {
            this.InternetState = NetworkInterface.GetIsNetworkAvailable() ? "Online" : "Offline";

            NetworkChange.NetworkAvailabilityChanged +=
                (sender, e) => { this.InternetState = NetworkInterface.GetIsNetworkAvailable() ? "Online" : "Offline"; };
        }

        /// <summary>
        /// The view internet state.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ViewInternetState(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("dddd","Caption", MessageBoxButton.YesNoCancel,MessageBoxImage.Information);
            MessageBox.Show("ddddWindowWindowWindowWindowWindowWindowWindowWindowWindow", "Caption", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);

            MessageBox.Show("dd", "ca", MessageBoxButton.OKCancel, MessageBoxImage.None);

            foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                this.networkInterfaceCollection.Add(networkInterface);
            }
        }
    }
}