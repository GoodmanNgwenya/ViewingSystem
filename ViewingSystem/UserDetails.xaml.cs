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
using ViewingSystem.Models;
using ViewingSystem.Services;

namespace ViewingSystem
{
    /// <summary>
    /// Interaction logic for UserDetails.xaml
    /// </summary>
    public partial class UserDetails : Page
    {
        DataService _dataService;
        public int UserId;
        public UserDetails()
        {
            InitializeComponent();
            UserId = MainWindow.UserID;
            GetCallsPerUser(UserId);
        }
        /// <summary>
        /// Get all calls for the specific user
        /// </summary>
        /// <param name="userid"></param>
        private void GetCallsPerUser(int userid)
        {
            _dataService = new DataService();
            try
            {
                dataGridCalls.ItemsSource = _dataService.GetCallsByIdAsync(userid).Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
