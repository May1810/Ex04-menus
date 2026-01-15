using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        private readonly string r_ItemTitle;
        private readonly List<MenuItem> r_SubItems;
        private MenuItem m_ParentItem;
        public event Action SelectedItem;

        public string ItemTitle
        {
            get { return r_ItemTitle; }
        }

        public List<MenuItem> SubItems
        {
            get { return r_SubItems; }
        }

        public MenuItem ParentItem
        {
            get { return m_ParentItem; }
        }

        public MenuItem(string i_NewMenuTitle)
        {
            r_ItemTitle = i_NewMenuTitle;
            r_SubItems = new List<MenuItem>();
            m_ParentItem = null;
            SelectedItem = null;
        }

        public void AddSubItem(MenuItem i_NewSubItem)
        {
            i_NewSubItem.m_ParentItem = this;
            r_SubItems.Add(i_NewSubItem);
        }

        public void OnSelectedItem()
        {
            if (SelectedItem != null && r_SubItems.Count == 0)
            {
                SelectedItem.Invoke();
            }
        }
    }
}
