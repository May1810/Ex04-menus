using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsMenu = Ex04.Menus.Events;
using Ex04.Menus.Test;


namespace Ex04.Menus.Test
{
    public static class EventsMenuBuilder
    {
        public static void RunEventsMenu()
        {
            EventsMenu.MainMenu mainMenu = new EventsMenu.MainMenu();
            mainMenu.RootItem.AddSubItem(buildVersionAndLowercaseSubMenu());
            mainMenu.RootItem.AddSubItem(buildCurrentDateAndTimeSubMenu());
            mainMenu.Show();
        }

        private static EventsMenu.MenuItem buildVersionAndLowercaseSubMenu()
        {
            EventsMenu.MenuItem versionAndLowercaseSubMenu =
                new EventsMenu.MenuItem("Version and Lowercase");

            EventsMenu.MenuItem showVersionItem =
                new EventsMenu.MenuItem("Show Version");
            showVersionItem.SelectedItem += MenuLogicActions.ShowVersion;

            EventsMenu.MenuItem countLowerCaseItem =
                new EventsMenu.MenuItem("Count Lowercase");
            countLowerCaseItem.SelectedItem += MenuLogicActions.CountLowercase;

            versionAndLowercaseSubMenu.AddSubItem(showVersionItem);
            versionAndLowercaseSubMenu.AddSubItem(countLowerCaseItem);

            return versionAndLowercaseSubMenu;
        }

        private static EventsMenu.MenuItem buildCurrentDateAndTimeSubMenu()
        {
            EventsMenu.MenuItem currentDateAndTimeSubMenu =
                new EventsMenu.MenuItem("Show Current Date/Time");

            EventsMenu.MenuItem showCurrentTimeItem =
                new EventsMenu.MenuItem("Show Current Time");
            showCurrentTimeItem.SelectedItem += MenuLogicActions.ShowCurrentTime;

            EventsMenu.MenuItem showCurrentDateItem =
                new EventsMenu.MenuItem("Show Current Date");
            showCurrentDateItem.SelectedItem += MenuLogicActions.ShowCurrentDate;

            currentDateAndTimeSubMenu.AddSubItem(showCurrentTimeItem);
            currentDateAndTimeSubMenu.AddSubItem(showCurrentDateItem);

            return currentDateAndTimeSubMenu;
        }
    }
}
