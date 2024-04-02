using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.delegates
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
        public MenuItem AddSubMenu(string i_Title, Action<MenuItem> MouseEventHandler)
        {
            MenuItem menuItem = new MenuItem(i_Title);
            m_MenuItem.AddItem(menuItem, MouseEventHandler);
            return menuItem;
        }
        public MenuItem AddSubMenu(string i_Title, MenuItem i_parent)
        {
            MenuItem menuItem = new MenuItem(i_Title);
            i_parent.AddItem(menuItem);
            return menuItem;
        }
        public MenuItem AddSubMenu(string i_Title, MenuItem i_parent, Action<MenuItem> MouseEventHandler)
        {
            MenuItem i_menuItem = new MenuItem(i_Title);
            i_parent.AddItem(i_menuItem, MouseEventHandler);
            return i_menuItem;
        }
        public void Show()
        {
            m_MenuItem.Show();
        }
    }
}
