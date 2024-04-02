using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.interfaces
{
    public class MainMenu
    {
        private MenuItem m_MenuItem;
        public MainMenu(string i_Title)
        {
            m_MenuItem = new MenuItem(i_Title);
        }
        public MenuItem AddSubMenu(string i_Title)
        {
            MenuItem menuItem = new MenuItem(i_Title);
            m_MenuItem.AddItem(menuItem);
            return menuItem;
        }
        public MenuItem AddSubMenu(string i_Title, ISelected i_handler)
        {
            MenuItem menuItem = new MenuItem(i_Title);
            m_MenuItem.AddItem(menuItem, i_handler);
            return menuItem;
        }
        public MenuItem AddSubMenu(string i_Title, MenuItem i_parent)
        {
            MenuItem menuItem = new MenuItem(i_Title);
            i_parent.AddItem(menuItem);
            return menuItem;
        }
        public MenuItem AddSubMenu(string i_Title, MenuItem i_parent, ISelected i_handler)
        {
            MenuItem menuItem = new MenuItem(i_Title);
            i_parent.AddItem(menuItem, i_handler);
            return menuItem;
        }
        public void Show()
        {
            m_MenuItem.Show();
        }
    }
}

