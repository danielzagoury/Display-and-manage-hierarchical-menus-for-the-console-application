using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.interfaces;
using Ex04.Menus.delegates;
namespace Ex04.Menus.Test
{
    internal partial class Program
    {
        class MenuDateSelected : ISelected
        {
            public void OnClick(Ex04.Menus.interfaces.MenuItem i_Invoker)
            {
                DateTime i_DateTime = DateTime.Now;
                DateTime i_DateOnly = i_DateTime.Date;
                Console.WriteLine("The Date is: " + i_DateOnly.ToShortDateString());
            }
        }
        class MenuTimeSelected : ISelected
        {
            public void OnClick(Ex04.Menus.interfaces.MenuItem i_Invoker)
            {
                DateTime i_dateTime = DateTime.Now;
                TimeSpan i_timeOnly = i_dateTime.TimeOfDay;
                Console.WriteLine("The Hour is: " + i_timeOnly.ToString(@"hh\:mm\:ss"));
            }
        }
        class MenuVersionSelected : ISelected
        {
            public void OnClick(Ex04.Menus.interfaces.MenuItem i_Invoker)
            {
                Console.WriteLine("Version: 24.1.4.9633");
            }
        }
        class MenuCountCapitalsSelected : ISelected
        {
            public void OnClick(Ex04.Menus.interfaces.MenuItem i_Invoker)
            {
                Console.WriteLine("Enter a sentence");
                string sentence = Console.ReadLine();
                int count = 0;
                foreach (char i_Char in sentence)
                {
                    if (i_Char >= 'A' && i_Char <= 'Z')
                    {
                        count++;
                    }
                }
                Console.WriteLine("Found {0} capital letters", count);
            }
        }
        public void MenuDate_OnClick(Ex04.Menus.delegates.MenuItem i_Invoker)
        {
            DateTime i_DateTime = DateTime.Now;
            DateTime i_DateOnly = i_DateTime.Date;
            Console.WriteLine("The Date is: " + i_DateOnly.ToShortDateString());
        }
        public void MenuTime_OnClick(Ex04.Menus.delegates.MenuItem i_Invoker)
        {
            DateTime i_dateTime = DateTime.Now;
            TimeSpan i_timeOnly = i_dateTime.TimeOfDay;
            Console.WriteLine("The Hour is: " + i_timeOnly.ToString(@"hh\:mm\:ss"));
        }
        public void MenuVersion_OnClick(Ex04.Menus.delegates.MenuItem i_Invoker)
        {
            Console.WriteLine("Version: 24.1.4.9633");
        }
        public void menuCountCapitals_OnClick(Ex04.Menus.delegates.MenuItem i_Invoker)
        {
            Console.WriteLine("Please enter your sentence:");
            string i_userAnswer = Console.ReadLine();
            int i_capitalCount = 0;
            foreach (char i_Char in i_userAnswer)
            {
                if (char.IsUpper(i_Char))
                {
                    i_capitalCount++;
                }
            }
            Console.WriteLine($"There are {i_capitalCount} capitals in your sentence.");
        }
    }
}
