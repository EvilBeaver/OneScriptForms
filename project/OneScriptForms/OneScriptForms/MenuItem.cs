﻿using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class MenuItemEx : System.Windows.Forms.MenuItem
    {
        public osf.MenuItem M_Object;
    }

    public class MenuItem : Menu
    {
        public string Click;
        public new ClMenuItem dll_obj;
        public MenuItemEx M_MenuItem;
        public bool M_VisibleSaveState;
        public string Name;
        public string Popup;

        public MenuItem(System.Windows.Forms.MenuItem p1)
        {
            M_MenuItem = (MenuItemEx)p1;
            M_MenuItem.M_Object = this;
            base.M_Menu = M_MenuItem;
            M_MenuItem.Click += M_MenuItem_Click;
            M_MenuItem.Popup += M_MenuItem_Popup;
            Name = "";
            Click = "";
            Popup = "";
            M_VisibleSaveState = false;
        }

        public MenuItem(osf.MenuItem p1)
        {
            M_MenuItem = p1.M_MenuItem;
            M_MenuItem.M_Object = this;
            base.M_Menu = M_MenuItem;
            M_MenuItem.Click += M_MenuItem_Click;
            M_MenuItem.Popup += M_MenuItem_Popup;
            Name = "";
            Click = "";
            Popup = "";
            M_VisibleSaveState = false;
        }

        public MenuItem(string text = null, string click = null, System.Windows.Forms.Shortcut shortcut = System.Windows.Forms.Shortcut.None)
        {
            M_MenuItem = new MenuItemEx();
            M_MenuItem.M_Object = this;
            base.M_Menu = M_MenuItem;
            M_MenuItem.Click += M_MenuItem_Click;
            M_MenuItem.Popup += M_MenuItem_Popup;
            Name = "";
            Click = click;
            Popup = "";
            M_VisibleSaveState = false;
            M_MenuItem.Text = text;
            M_MenuItem.Shortcut = shortcut;
        }

        //Свойства============================================================

        public bool Checked
        {
            get { return M_MenuItem.Checked; }
            set { M_MenuItem.Checked = value; }
        }

        public bool Enabled
        {
            get { return M_MenuItem.Enabled; }
            set { M_MenuItem.Enabled = value; }
        }

        public int Index
        {
            get { return M_MenuItem.Index; }
            set { M_MenuItem.Index = value; }
        }

        public bool MdiList
        {
            get { return M_MenuItem.MdiList; }
            set { M_MenuItem.MdiList = value; }
        }

        public int MergeOrder
        {
            get { return M_MenuItem.MergeOrder; }
            set { M_MenuItem.MergeOrder = value; }
        }

        public int MergeType
        {
            get { return (int)M_MenuItem.MergeType; }
            set { M_MenuItem.MergeType = (System.Windows.Forms.MenuMerge)value; }
        }

        public osf.Menu Parent
        {
            get
            {
                dynamic p1 = M_MenuItem.Parent;
                if (M_MenuItem.Parent is System.Windows.Forms.MainMenu)
                {
                    return (Menu)((MainMenuEx)p1).M_Object;
                }
                if (M_MenuItem.Parent is System.Windows.Forms.ContextMenu)
                {
                    return (Menu)((ContextMenuEx)p1).M_Object;
                }
                if (M_MenuItem.Parent is MenuItemEx)
                {
                    return (Menu)((MenuItemEx)p1).M_Object;
                }
                return null;
            }
        }

        public bool RadioCheck
        {
            get { return M_MenuItem.RadioCheck; }
            set { M_MenuItem.RadioCheck = value; }
        }

        public int Shortcut
        {
            get { return (int)M_MenuItem.Shortcut; }
            set { M_MenuItem.Shortcut = (System.Windows.Forms.Shortcut)value; }
        }

        public string Text
        {
            get { return M_MenuItem.Text; }
            set { M_MenuItem.Text = value; }
        }

        public bool Visible
        {
            get { return M_MenuItem.Visible; }
            set
            {
                M_MenuItem.Visible = value;
                M_VisibleSaveState = value;
            }
        }

        //Методы============================================================

        public osf.MenuItem FromString(string p1)
        {
            MenuItem MenuItem1 = new MenuItem((string)null, (string)null, System.Windows.Forms.Shortcut.None);
            MenuItem1.Text = p1;
            return MenuItem1;
        }

        public void M_MenuItem_Click(object sender, System.EventArgs e)
        {
            if (Click.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = Click;
                EventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

        private void M_MenuItem_Popup(object sender, System.EventArgs e)
        {
            if (Popup.Length > 0)
            {
                EventArgs EventArgs1 = new EventArgs();
                EventArgs1.EventString = Popup;
                EventArgs1.Sender = this;
                OneScriptForms.EventQueue.Add(EventArgs1);
                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
            }
        }

    }

    [ContextClass ("КлЭлементМеню", "ClMenuItem")]
    public class ClMenuItem : AutoContext<ClMenuItem>
    {
        private ClMenuItemCollection menuItems;

        public ClMenuItem()
        {
            MenuItem MenuItem1 = new MenuItem();
            MenuItem1.dll_obj = this;
            Base_obj = MenuItem1;
            menuItems = new ClMenuItemCollection(Base_obj.MenuItems);
        }
		
        public ClMenuItem(MenuItem p1)
        {
            MenuItem MenuItem1 = p1;
            MenuItem1.dll_obj = this;
            Base_obj = MenuItem1;
            menuItems = new ClMenuItemCollection(Base_obj.MenuItems);
        }

        public ClMenuItem(string p1 = "", string p2 = "", int p3 = 0)
        {
            MenuItem MenuItem1 = new MenuItem(p1, p2, (System.Windows.Forms.Shortcut)p3);
            MenuItem1.dll_obj = this;
            Base_obj = MenuItem1;
            menuItems = new ClMenuItemCollection(Base_obj.MenuItems);
        }

        public MenuItem Base_obj;

        //Свойства============================================================

        [ContextProperty("Доступность", "Enabled")]
        public bool Enabled
        {
            get { return Base_obj.Enabled; }
            set { Base_obj.Enabled = value; }
        }

        [ContextProperty("Имя", "Name")]
        public string Name
        {
            get { return Base_obj.Name; }
            set { Base_obj.Name = value; }
        }

        [ContextProperty("Индекс", "Index")]
        public int Index
        {
            get { return Base_obj.Index; }
            set { Base_obj.Index = value; }
        }

        [ContextProperty("Нажатие", "Click")]
        public string Click
        {
            get { return Base_obj.Click; }
            set { Base_obj.Click = value; }
        }

        [ContextProperty("Отображать", "Visible")]
        public bool Visible
        {
            get { return Base_obj.Visible; }
            set { Base_obj.Visible = value; }
        }

        [ContextProperty("Переключатель", "RadioCheck")]
        public bool RadioCheck
        {
            get { return Base_obj.RadioCheck; }
            set { Base_obj.RadioCheck = value; }
        }

        [ContextProperty("Помечен", "Checked")]
        public bool Checked
        {
            get { return Base_obj.Checked; }
            set { Base_obj.Checked = value; }
        }

        [ContextProperty("ПорядокСлияния", "MergeOrder")]
        public int MergeOrder
        {
            get { return Base_obj.MergeOrder; }
            set { Base_obj.MergeOrder = value; }
        }

        [ContextProperty("Родитель", "Parent")]
        public IValue Parent
        {
            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
        }
        
        [ContextProperty("СочетаниеКлавиш", "Shortcut")]
        public int Shortcut
        {
            get { return (int)Base_obj.Shortcut; }
            set { Base_obj.Shortcut = value; }
        }

        [ContextProperty("Текст", "Text")]
        public string Text
        {
            get { return Base_obj.Text; }
            set { Base_obj.Text = value; }
        }

        [ContextProperty("ТипСлияния", "MergeType")]
        public int MergeType
        {
            get { return (int)Base_obj.MergeType; }
            set { Base_obj.MergeType = value; }
        }

        [ContextProperty("ЭлементыМеню", "MenuItems")]
        public ClMenuItemCollection MenuItems
        {
            get { return menuItems; }
        }

        //Методы============================================================

        [ContextMethod("КлонироватьМеню", "CloneMenu")]
        public ClMenuItem CloneMenu()
        {
            MenuItem MenuItem4 = new MenuItem();

            MenuItem4.Enabled = Base_obj.Enabled;
            MenuItem4.Name = Base_obj.Name;
            MenuItem4.Index = Base_obj.Index;
            MenuItem4.Click = Base_obj.Click;
            MenuItem4.Visible = Base_obj.Visible;
            MenuItem4.RadioCheck = Base_obj.RadioCheck;
            MenuItem4.Checked = Base_obj.Checked;
            MenuItem4.MergeOrder = Base_obj.MergeOrder;
            MenuItem4.Shortcut = (int)Base_obj.Shortcut;
            MenuItem4.Text = Base_obj.Text;
            MenuItem4.MergeType = (int)Base_obj.MergeType;

            for (int i = 0; i < Base_obj.MenuItems.Count; i++)
            {
                MenuItem CurrentMenuItem = Base_obj.MenuItems[i];
                MenuItem MenuItem5 = new MenuItem();

                MenuItem5.Enabled = CurrentMenuItem.Enabled;
                MenuItem5.Name = CurrentMenuItem.Name;
                MenuItem5.Index = CurrentMenuItem.Index;
                MenuItem5.Click = CurrentMenuItem.Click;
                MenuItem5.Visible = CurrentMenuItem.Visible;
                MenuItem5.RadioCheck = CurrentMenuItem.RadioCheck;
                MenuItem5.Checked = CurrentMenuItem.Checked;
                MenuItem5.MergeOrder = CurrentMenuItem.MergeOrder;
                MenuItem5.Shortcut = (int)CurrentMenuItem.Shortcut;
                MenuItem5.Text = CurrentMenuItem.Text;
                MenuItem5.MergeType = (int)CurrentMenuItem.MergeType;

                MenuItem NewMenuItem = MenuItem4.MenuItems.Add(MenuItem5);
                if (CurrentMenuItem.MenuItems.Count > 0)
                {
                    BypassMenu(NewMenuItem, CurrentMenuItem.MenuItems);
                }
            }
            return new ClMenuItem(MenuItem4);
        }

        public void BypassMenu(MenuItem MenuItem, MenuItemCollection MenuItems)
        {
            for (int i = 0; i < MenuItems.Count; i++)
            {
                MenuItem CurrentMenuItem = MenuItems[i];
                MenuItem MenuItem5 = new MenuItem();

                MenuItem5.Enabled = CurrentMenuItem.Enabled;
                MenuItem5.Name = CurrentMenuItem.Name;
                MenuItem5.Index = CurrentMenuItem.Index;
                MenuItem5.Click = CurrentMenuItem.Click;
                MenuItem5.Visible = CurrentMenuItem.Visible;
                MenuItem5.RadioCheck = CurrentMenuItem.RadioCheck;
                MenuItem5.Checked = CurrentMenuItem.Checked;
                MenuItem5.MergeOrder = CurrentMenuItem.MergeOrder;
                MenuItem5.Shortcut = (int)CurrentMenuItem.Shortcut;
                MenuItem5.Text = CurrentMenuItem.Text;
                MenuItem5.MergeType = (int)CurrentMenuItem.MergeType;

                MenuItem NewMenuItem = MenuItem.MenuItems.Add(MenuItem5);
                if (CurrentMenuItem.MenuItems.Count > 0)
                {
                    BypassMenu(NewMenuItem, CurrentMenuItem.MenuItems);
                }
            }
        }

        [ContextMethod("ПолучитьГлавноеМеню", "GetMainMenu")]
        public ClMainMenu GetMainMenu()
        {
            return (ClMainMenu)OneScriptForms.RevertObj(Base_obj.GetMainMenu());
        }
        
        [ContextMethod("ЭлементМеню", "MenuItem")]
        public ClMenuItem MenuItem(int p1)
        {
            return new ClMenuItem(Base_obj.MenuItems[p1]);
        }
        
        [ContextMethod("ЭлементыМеню", "MenuItems")]
        public ClMenuItem MenuItems2(int p1)
        {
            return (ClMenuItem)OneScriptForms.RevertObj(Base_obj.MenuItems[p1]);
        }
    }
}
