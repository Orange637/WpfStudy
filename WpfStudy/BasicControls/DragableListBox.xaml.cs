using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfStudy.BasicControls
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class DragableListBox
    {
        private ListBoxItem selectedItem;
        public DragableListBox()
        {
            InitializeComponent();
            List<String> data = new List<string>();

            data.Add("Maryland");
            data.Add("Virginia");
            data.Add("West Virginia");
            data.Add("Ohio");
            data.Add("California");
            data.Add("Washington");
            data.Add("Nevada");

            foreach (string str in data)
                sourceList.Items.Add(str);
        }

        private void HandlerPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectedItem = sender as ListBoxItem;
        }
        private void HandlerPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(selectedItem, selectedItem.Content,
                   DragDropEffects.Copy);
            }
        }
        private void sourceList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }
        private void destList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }
        private void sourceList_Drop(object sender, DragEventArgs e)
        {
            sourceList.Items.Add(e.Data.GetData(DataFormats.Text));
        }
        private void destList_Drop(object sender, DragEventArgs e)
        {
            destList.Items.Add(e.Data.GetData(DataFormats.Text));
        }
    }
}