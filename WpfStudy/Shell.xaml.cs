// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Shell.xaml.cs" company="mm-software">
//   mm-software
// </copyright>
// <summary>
//   Interaction logic for MainWindow.xaml.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfStudy
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;

    using WpfStudy.Resources.Controls;
    using WpfStudy.Resources.Extensions;

    /// <summary>
    /// Interaction logic for MainWindow.
    /// </summary>
    public partial class Shell : INotifyPropertyChanged
    {
        /// <summary>
        /// The filtered file name.
        /// </summary>
        private readonly ICollection<string> filteredFileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="Shell"/> class.
        /// </summary>
        public Shell()
        {
            this.InitializeComponent();

            this.filteredFileName = new List<string> { "App", "Shell" };

            // this.TestList = new List<string> { "Window1", "Test2" };
            this.TestList = new List<FileInfo>();
            this.GetAllWindowName(this.TestList);
            this.NotifyPropertyChanged("TestList");

            var view = CollectionViewSource.GetDefaultView(ProjectFilesItemsControl.DataContext);
            view.GroupDescriptions.Clear();
            view.GroupDescriptions.Add(new PropertyGroupDescription("Directory.Name"));
        }

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the test list.
        /// </summary>
        /// <value>
        /// The test list.
        /// </value>
        public ICollection<FileInfo> TestList { get; set; }

        /// <summary>
        /// The notify property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// The get all window name.
        /// </summary>
        /// <param name="windowsNameCollection">
        /// The windows name collection.
        /// </param>
        private void GetAllWindowName(ICollection<FileInfo> windowsNameCollection)
        {
            var currentDirectory = Directory.CreateDirectory(Environment.CurrentDirectory);
            if (currentDirectory.Parent == null || currentDirectory.Parent.Parent == null)
            {
                return;
            }

            var workDirectory = currentDirectory.Parent.CreateSubdirectory("WpfStudy"); // .Parent;
            foreach (var file in this.GetAllFiles(workDirectory))
            {
                var fileName = file.Name;
                if (!fileName.EndsWith(".xaml.cs"))
                {
                    continue;
                }
                fileName = file.Name.Split(".".ToCharArray())[0];

                if (!this.filteredFileName.Contains(fileName) && !windowsNameCollection.Contains(file))
                {
                    windowsNameCollection.Add(file);
                }
            }
        }

        /// <summary>
        /// The get all files.
        /// </summary>
        /// <param name="rootDirectory">
        /// The root directory.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{FileInfo}"/> All the file include files in the sub directory.
        /// </returns>
        private IEnumerable<FileInfo> GetAllFiles(DirectoryInfo rootDirectory)
        {
            foreach (var file in rootDirectory.GetFiles())
            {
                yield return file;
            }

            /*foreach (var subDirectory in rootDirectory.GetDirectories())
            {
                foreach (var file in this.GetAllFiles(subDirectory))
                {
                    yield return file;
                }
            }*/

            foreach (var file in rootDirectory.GetDirectories().SelectMany(this.GetAllFiles))
            {
                yield return file;
            }
        }

        /// <summary>
        /// The button base_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e routed event args.
        /// </param>
        /*private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var button = e.Source as Button;
            if (button != null)
            {
                string typeName = button.Content.ToString().Split(".".ToCharArray())[0];
                try
                {
                    var type = Type.GetType(this.GetType().Namespace + ".Views." + typeName, true, true);
                    var temp = Activator.CreateInstance(type) as Window;
                    if (temp != null)
                    {
                        temp.Owner = this;
                        temp.Show();
                        this.Hide();
                    }
                }
                catch (TypeLoadException)
                {
                    MessageBox.Show(string.Format(CultureInfo.InvariantCulture, "{0} is not exists!", typeName));
                }
            }
        }*/

        private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            var hyperlink = e.Source as Hyperlink;
            if (hyperlink != null)
            {
                var typeName = hyperlink.NavigateUri.ToString().Split(".".ToCharArray())[0];
                var directoryName = hyperlink.Tag.ToString();
                try
                {
                    var type = Type.GetType(this.GetType().Namespace + "." + directoryName + "." + typeName, true, true);
                    var temp = Activator.CreateInstance(type) as Window;
                    if (temp != null)
                    {
                        temp.Owner = this;
                        if (!(temp is View))
                        {
                            temp.Closed += (obj, arg) => { temp.Owner.Show(); };
                        }
                        temp.Show();
                        this.Hide();
                    }
                }
                catch (TypeLoadException)
                {
                    MessageBox.Show(string.Format(CultureInfo.InvariantCulture, "{0} is not exists!", typeName));
                }
            }
        }

        private void FindApp(object sender, RoutedEventArgs e)
        {
        }
    }
}