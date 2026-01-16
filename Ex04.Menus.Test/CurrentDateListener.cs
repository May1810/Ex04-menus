using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class CurrentDateListener : ISelectionListener
    {
        public void OnSelected()
        {
            MenuLogicActions.ShowCurrentDate();
        }
    }
}
