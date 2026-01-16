using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceMenu = Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public static class InterfaceMenuBuilder
    {
        public static void RunInterfaceMenu()
        {
            InterfaceMenu.MainMenu mainMenu = new InterfaceMenu.MainMenu();
            mainMenu.RootItem.AddSubItem(buildVersionAndLowercaseSubMenu());
            mainMenu.RootItem.AddSubItem(buildCurrentDateAndTimeSubMenu());
            mainMenu.Show();
        }

        private static InterfaceMenu.MenuItem buildVersionAndLowercaseSubMenu()
        {
            InterfaceMenu.MenuItem versionAndLowercaseSubMenu = new InterfaceMenu.MenuItem("Version and Lowercase");
            InterfaceMenu.MenuItem showVersionItem = new InterfaceMenu.MenuItem("Show Version");
            showVersionItem.SetSelectionListener(new VersionListener());
            InterfaceMenu.MenuItem countLowerCaseItem = new InterfaceMenu.MenuItem("Count Lowercase");
            countLowerCaseItem.SetSelectionListener(new CountLowercaseListener());
            versionAndLowercaseSubMenu.AddSubItem(showVersionItem);
            versionAndLowercaseSubMenu.AddSubItem(countLowerCaseItem);
            return versionAndLowercaseSubMenu;
        }

        private static InterfaceMenu.MenuItem buildCurrentDateAndTimeSubMenu()
        {
            InterfaceMenu.MenuItem currentDateAndTimeSubMenu = new InterfaceMenu.MenuItem("Show Current Date/Time");
            InterfaceMenu.MenuItem showCurrentTimeItem = new InterfaceMenu.MenuItem("Show Current Time");
            showCurrentTimeItem.SetSelectionListener(new CurrentTimeListener());
            InterfaceMenu.MenuItem showCurrentDateItem = new InterfaceMenu.MenuItem("Show Current Date");
            showCurrentDateItem.SetSelectionListener(new CurrentDateListener());
            currentDateAndTimeSubMenu.AddSubItem(showCurrentTimeItem);
            currentDateAndTimeSubMenu.AddSubItem(showCurrentDateItem);
            return currentDateAndTimeSubMenu;
        }
    }
}
