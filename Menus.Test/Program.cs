using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainMenuDelegate = Ex04.Menus.delegates.MainMenu;
using MenuItemDelegate = Ex04.Menus.delegates.MenuItem;
using Ex04.Menus.interfaces;

namespace Ex04.Menus.Test
{
    internal partial class Program
    {
        Ex04.Menus.interfaces.MainMenu m_MenuInterfaces;
        MainMenuDelegate m_MenuDelegates;
        private void BuildInterfaceMenu()
        {
            m_MenuInterfaces = new Ex04.Menus.interfaces.MainMenu("Interfaces Main Menu");
            Ex04.Menus.interfaces.MenuItem menuDateTime = m_MenuInterfaces.AddSubMenu("Show Date/Time");
            m_MenuInterfaces.AddSubMenu("Show Date", menuDateTime, new MenuDateSelected());
            m_MenuInterfaces.AddSubMenu("Show Time", menuDateTime, new MenuTimeSelected());
            Ex04.Menus.interfaces.MenuItem mnuVersionCapitals = m_MenuInterfaces.AddSubMenu("Show Version and Capitals");
            m_MenuInterfaces.AddSubMenu("Count Capitals", mnuVersionCapitals, new MenuCountCapitalsSelected());
            m_MenuInterfaces.AddSubMenu("Show Version", mnuVersionCapitals, new MenuVersionSelected());
        }
        private void BuildDelegateMenu()
        {
            m_MenuDelegates = new MainMenuDelegate("Delegates Main Menu");
            MenuItemDelegate menuDateTime = m_MenuDelegates.AddSubMenu("Show Date/Time");
            m_MenuDelegates.AddSubMenu("Show Date", menuDateTime, this.MenuDate_OnClick);
            m_MenuDelegates.AddSubMenu("Show Time", menuDateTime, this.MenuTime_OnClick);
            MenuItemDelegate menuVersionAndCapitals = m_MenuDelegates.AddSubMenu("Version and Capitals");
            m_MenuDelegates.AddSubMenu("Count Capitals", menuVersionAndCapitals, this.menuCountCapitals_OnClick);
            m_MenuDelegates.AddSubMenu("Show Version", menuVersionAndCapitals, this.MenuVersion_OnClick);
        }
        public Program()
        {
            BuildInterfaceMenu();
            BuildDelegateMenu();
        }
        static void Main(string[] args)
        {
            Program testApp = new Program();
            Console.WriteLine("Select menu type:");
            Console.WriteLine("1 -> Interfaces\n2 -> Delegates\n0 -> exit");
            string choice = Console.ReadLine();
            while (choice != "0")
            {
                if (choice == "1")
                {
                    testApp.m_MenuInterfaces.Show();
                }
                else if (choice == "2")
                {
                    testApp.m_MenuDelegates.Show();
                }
                Console.Clear();
                Console.WriteLine("1 -> Interfaces\n2 -> Delegates\n0 -> Exit");
                choice = Console.ReadLine();
            }
        }
    }
}
