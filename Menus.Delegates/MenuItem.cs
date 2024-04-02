using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.delegates
{
    public class MenuItem
    {
        private static readonly int sr_RootMenu = -1;
        private string m_Title;
        private int m_Index;
        public event Action<MenuItem> i_Selected;
        private List<MenuItem> r_delegateList;
        public MenuItem(string i_Title, int i_Index)
        {
            m_Title = i_Title;
            m_Index = i_Index;
            r_delegateList = new List<MenuItem>();
        }
        public MenuItem(string i_Title) : this(i_Title, sr_RootMenu)
        {
        }
        public void AddItem(MenuItem item, Action<MenuItem> MouseEventHandler)
        {
            r_delegateList.Add(item);
            item.SetIndex(r_delegateList.Count);
            item.i_Selected += MouseEventHandler;
        }
        public void AddItem(MenuItem item)
        {
            AddItem(item, (i_item) => item.Show());
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
        public void Show()
        {
            ShowMenuList();
            string i_choice = Console.ReadLine();
            while (i_choice != "0")
            {
                int i_menuIndex = int.Parse(i_choice);
                r_delegateList[i_menuIndex - 1].NotifySelected();
                ShowMenuList();
                i_choice = Console.ReadLine();
            }
        }
        private void ShowMenuList()
        {
            Console.WriteLine("**{0}**", m_Title);
            Console.WriteLine("-----------------------");
            foreach (MenuItem item in r_delegateList)
            {
                item.Draw();
            }
            if (m_Index == sr_RootMenu)
            {
                Console.WriteLine("0 -> Exit");
            }
            else
            {
                Console.WriteLine("0 -> Back");
            }
        }
        public void NotifySelected()
        {
            Console.Clear();
            OnSelected();
        }
        private void OnSelected()
        {
            i_Selected?.Invoke(this);
        }
    }
}
