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
using System.Windows.Shapes;

namespace ViewingSystem
{
    /// <summary>
    /// Interaction logic for NavBar.xaml
    /// </summary>
    public partial class NavBar : Window
    {
        public NavBar()
        {
            InitializeComponent();

            //this is to set default page on application startup such as dashboard...etc..
            frame.Navigate(new Uri("UserDetails.xaml", UriKind.RelativeOrAbsolute));
        }

        private void SideMenuControl_SelectionChanged(object sender, EventArgs e)
        {
            switch (MenuList.SelectedIndex)
            {
                case 0:
                    frame.Navigate(new Uri("Details.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case 1:
                    frame.Navigate(new Uri("UserDetails.xaml", UriKind.RelativeOrAbsolute));
                    break;
                case 2:
                    bool isWindowOpen = false;
                    foreach (Window w in Application.Current.Windows)
                    {
                        if (w is MainWindow)
                        {
                            isWindowOpen = true;
                            w.Activate();
                        }
                    }

                    if (!isWindowOpen)
                    {
                        MainWindow newwindow = new MainWindow();
                        newwindow.Show();
                       
                    }
                    CloseAllWindows();
                    break;
            }
        }

        /// <summary>
        /// Close all opened window when signout
        /// </summary>
        private void CloseAllWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter > 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }
    }
}
