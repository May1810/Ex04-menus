using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        private string m_MenuTitle;
        private List<MenuItem> m_SubItems;
        private MenuItem m_ParentItem;
        public event Action SelectedItem;

        public string MenuTitle
        {
            get { return m_MenuTitle; }
        }

        public List<MenuItem> SubItems
        {
            get { return m_SubItems; }
        }

        public MenuItem ParentItem
        {
            get { return m_ParentItem; }
        }

        public MenuItem(string i_NewMenuTitle)
        {
            m_MenuTitle = i_NewMenuTitle;
            m_SubItems = new List<MenuItem>();
            m_ParentItem = null;
            SelectedItem = null;
        }

        public void AddSubItem(MenuItem i_NewSubItem)
        {
            i_NewSubItem.m_ParentItem = this;
            m_SubItems.Add(i_NewSubItem);
        }

        public void OnSelectedItem()
        {
            if (SelectedItem != null && m_SubItems.Count == 0)
            {
                SelectedItem.Invoke();
            }
        }

    }
}
