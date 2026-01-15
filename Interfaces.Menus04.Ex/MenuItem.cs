using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private string m_MenuTitle;
        private List<MenuItem> m_SubItems;
        private MenuItem m_ParentItem;
        private ISelectionListener m_SelectionListener;

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
            m_SelectionListener = null;
        }

        public void AddSubItem(MenuItem i_NewSubItem)
        {
            i_NewSubItem.m_ParentItem = this;
            m_SubItems.Add(i_NewSubItem);
        }

        public void SetSelectionListener(ISelectionListener i_Listener)
        {
            m_SelectionListener = i_Listener;
        }

        public void OnSelected()
        {
            if (m_SelectionListener != null && m_SubItems.Count == 0)
            {
                m_SelectionListener.OnSelected();
            }
        }

    }
}
