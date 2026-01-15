using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Menus04.Ex
{
    public class MainMenu
    {
        private MenuItem m_RootItem;
        private MenuItem m_CurrentItem;
        public MainMenu()
        {
            m_RootItem = new MenuItem(string.Empty);
            m_CurrentItem = m_RootItem;
        }

        public void Show()
        {
            bool isPressedExit = false;

            while (!isPressedExit)
            {
                displayMenu();
                int userChoice = getUserChoice();

                if (userChoice == 0)
                {
                    if (m_CurrentItem == m_RootItem)
                    {
                        isPressedExit = true;
                    }
                    else
                    {
                        m_CurrentItem = m_CurrentItem.ParentItem;
                    }
                }
                else if (userChoice > 0)
                {
                    MenuItem selectedItem = m_CurrentItem.SubItems[userChoice - 1];

                    if (m_CurrentItem.SubItems.Count > 0)
                    {
                        m_CurrentItem = selectedItem;
                    }
                    else
                    {
                        selectedItem.OnSelected();  // Invoke the action associated with the menu item 
                    }
                }
            }
        }

        private void displayMenu()
        {
            Console.Clear();
            string menuTitle = m_CurrentItem.MenuTitle;
            string exitOrBack = m_CurrentItem == m_RootItem ? "Exit" : "Back";
            string numberOfItems = m_CurrentItem.SubItems.Count.ToString();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(String.Format("** {0} **",menuTitle));
            Console.ResetColor();
            Console.WriteLine("------------------------");

            for (int i = 1; i <= m_CurrentItem.SubItems.Count; i++)
            {
                Console.WriteLine(String.Format("{0}. {1}   ", i, m_CurrentItem.SubItems[i-1].MenuTitle));
            }

            Console.WriteLine(String.Format("0. {0}", exitOrBack));
            Console.WriteLine(String.Format("Please enter your choice (1-{0} or 0 to {1}): ", numberOfItems, exitOrBack));
            Console.WriteLine(">> ");

        }

        private int getUserChoice()
        {
            string userChoiceStr = Console.ReadLine();

            if (int.TryParse(userChoiceStr, out int userChoice))
            {
                if (userChoice >= 0 && userChoice <= m_CurrentItem.SubItems.Count)
                {
                    return userChoice;
                }
            }
            Console.WriteLine("Invalid choice. Please try again.");
            return -1;
        }

    }
}
