using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.interfaces
{
    public class MenuItem
    {
        private static readonly int ROOT_MENU = -1;
        private string m_Title;
        private int m_Index;
        public ISelected Selected;
        private List<MenuItem> delegateList;
        public MenuItem(string i_Title, int i_Index)
        {
            m_Title = i_Title;
            m_Index = i_Index;
            delegateList = new List<MenuItem>();
        }
        public MenuItem(string i_Title) : this(i_Title, ROOT_MENU)
        {
        }
        public void AddItem(MenuItem i_item, ISelected i_Handler)
        {
            delegateList.Add(i_item);
            i_item.SetIndex(delegateList.Count);
            i_item.Selected = i_Handler;
        }
        public void AddItem(MenuItem i_item)
        {
            AddItem(i_item, new MenuList(i_item));
        }
        public int GetIndex() { return m_Index; }
        public void SetIndex(int i_Index)
        {
            m_Index = i_Index;
        }
        public void Draw()
        {
            Console.WriteLine("{0} -> {1}", m_Index, m_Title);
        }
        public void NotifySelected()
        {
            Console.Clear();
            OnSelected(this);
        }
        private void OnSelected(MenuItem i_Invoker)
        {
            Selected?.OnClick(i_Invoker);
        }
        public void Show()
        {
            ShowMenuList();
            string i_choice = Console.ReadLine();
            while (i_choice != "0")
            {
                int menuIndex = int.Parse(i_choice);
                delegateList[menuIndex - 1].NotifySelected();
                ShowMenuList();
                i_choice = Console.ReadLine();
            }
        }
        private void ShowMenuList()
        {
            Console.WriteLine("**{0}**", m_Title);
            Console.WriteLine("-----------------------");
            foreach (MenuItem item in delegateList)
            {
                item.Draw();
            }
            if (m_Index == ROOT_MENU)
            {
                Console.WriteLine("0 -> Exit");
            }
            else
            {
                Console.WriteLine("0 -> Back");
            }
        }
        private class MenuList : ISelected
        {
            MenuItem m_MenuItem;
            public MenuList(MenuItem i_MenuItem)
            {
                m_MenuItem = i_MenuItem;
            }
            public void OnClick(MenuItem i_Invoker)
            {
                m_MenuItem.Show();
            }
        }
    }
}
