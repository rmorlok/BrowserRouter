﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using SteelUnderpants.BrowserRouter.Core;

namespace SteelUnderpants.BrowserRouter.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<UrlMap> _RoutedUrls = new ObservableCollection<UrlMap>();

        public MainWindow()
        {
            var routingConfiguration = new RoutingConfiguration();
            foreach (var urlMap in routingConfiguration.UrlMaps)
            {
                _RoutedUrls.Add(urlMap);
            }

            InitializeComponent();
        }

        public ObservableCollection<UrlMap> RoutedUrls 
        { 
            get 
            { 
                return _RoutedUrls; 
            } 
        }
    }
}
