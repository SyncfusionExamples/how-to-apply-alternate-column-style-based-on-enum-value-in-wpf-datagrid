#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SfDataGridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void syncgrid_AutoGeneratingColumn(object sender, Syncfusion.UI.Xaml.Grid.AutoGeneratingColumnArgs e)
        {
            //apply cell style at runtime
            e.Column.CellStyle = Application.Current.MainWindow.FindResource("cellStyle") as Style;           
        }

        private void btnExpand_Click(object sender, RoutedEventArgs e)
        {
            //Expand all the groups at programmatically at runtime
            syncgrid.ExpandAllGroup();
        }
    }
}
