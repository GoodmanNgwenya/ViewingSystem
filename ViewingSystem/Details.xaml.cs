using System;
using System.Collections.Generic;
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
using ViewingSystem.Services;

namespace ViewingSystem
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Page
    {
        DataService _dataService;
        public Details()
        {
            InitializeComponent();
            GetAllCalls();
        }

        /// <summary>
        /// Get all calls
        /// </summary>
        private void GetAllCalls()
        {
            _dataService = new DataService();
            try
            {
                dataGridCalls.ItemsSource = _dataService.GetAllCallsAsync().Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
