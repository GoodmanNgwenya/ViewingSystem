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
using ViewingSystem.Models;
using ViewingSystem.Services;

namespace ViewingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataService _dataService;
        User user = new User();

        /// <summary>
        /// Get and Set values for a global variables
        /// </summary>
        private static int userId;
        public static int UserID
        {
            get { return userId; }
            set { userId = value; }
        }
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            _dataService = new DataService();
            try
            {
                if (txtUsername.Text == null || txtUsername.Text == "")
                {
                    txtMessage.Text = "Provide username";
                    return;
                }
                if (txtPassword.Password == null || txtPassword.Password == "")
                {
                    txtMessage.Text = "Provide password";
                    return;
                }


                var user = _dataService.LoginAsync(txtUsername.Text, txtPassword.Password.ToString());
                if (user.Result.Id != 0)
                {
                    UserID = user.Result.Id;
                    bool isWindowOpen = false;

                    foreach (Window w in Application.Current.Windows)
                    {
                        if (w is NavBar)
                        {
                            isWindowOpen = true;
                            w.Activate();
                        }
                    }

                    if (!isWindowOpen)
                    {
                        NavBar newwindow = new NavBar();
                        newwindow.Show();
                    }

                    //Clear the input value after it passed successful
                    txtUsername.Clear();
                    txtPassword.Clear();

                }
                else
                {
                    txtMessage.Text = "User with the provided information not found";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
