using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        private MenuItem m_RootItem;
        private MenuItem m_CurrentItem;

        public MainMenu()
        {
            m_RootItem = new MenuItem("Main Menu");
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
                    MenuItem selectedItem =
                        m_CurrentItem.SubItems[userChoice - 1];

                    if (selectedItem.SubItems.Count > 0)
                    {
                        m_CurrentItem = selectedItem;
                    }
                    else
                    {
                        selectedItem.OnSelectedItem();
                    }
                }
            }
        }

        private void displayMenu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(
                string.Format("** {0} **", m_CurrentItem.MenuTitle));
            Console.ResetColor();

            Console.WriteLine("------------------------");

            for (int i = 0; i < m_CurrentItem.SubItems.Count; i++)
            {
                Console.WriteLine(
                    string.Format("{0}. {1}",
                        i + 1,
                        m_CurrentItem.SubItems[i].MenuTitle));
            }

            string exitOrBack =
                m_CurrentItem == m_RootItem ? "Exit" : "Back";

            Console.WriteLine(string.Format("0. {0}", exitOrBack));
            Console.WriteLine(">> ");
        }

        private int getUserChoice()
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                if (choice >= 0 &&
                    choice <= m_CurrentItem.SubItems.Count)
                {
                    return choice;
                }
            }

            Console.WriteLine("Invalid choice. Please try again.");
            return -1;
        }
    }
}
