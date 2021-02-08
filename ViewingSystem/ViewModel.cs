using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ViewingSystem
{
    class ViewModel
    {
        //To call resource dictionary in our codebehind
        ResourceDictionary dict = Application.LoadComponent(new Uri("/ViewingSystem;component/IconDictionary.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;

        //Source list for our Menu Items Listbox
        public List<MenuItemsData> ItemsList
        {
            get
            {
                return new List<MenuItemsData> {
                new MenuItemsData(){ PathData= (PathGeometry)dict["HomeIcon"], MenuText="Home" },
                new MenuItemsData(){ PathData = (PathGeometry)dict["PeopleIcon"], MenuText="User" },
                 new MenuItemsData(){PathData=(PathGeometry)dict["icon_logout"], MenuText="Logout"}
                };
            }
        }
    }

    public class MenuItemsData
    {
        public PathGeometry PathData { get; set; }
        public bool IsItemSelected { get; set; }
        public string MenuText { get; set; }
    }
}
