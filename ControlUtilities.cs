using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraForms
{
    public static class ControlUtilities
    {
        private static void UpDown_MouseWheel(object sender, MouseEventArgs e)
        {
            var he = (HandledMouseEventArgs)e;
            he.Handled = true;

            var updown = (UpDownBase)sender;
            if (he.Delta > 0) updown.UpButton();
            if (he.Delta < 0) updown.DownButton();
        }
        public static void FixMouseWheel(this UpDownBase updown)
        {
            updown.MouseWheel += UpDown_MouseWheel;
        }
        public static void SetNumericValue(this NumericUpDown numeric, object value)
        {
            if (typeof(bool) == value.GetType())
            {
                numeric.Minimum = 0;
                numeric.Maximum = 1;
                numeric.DecimalPlaces = 0;
                numeric.Increment = 1;
                numeric.Value = (bool)value ? 1 : 0;
            }
            else if (typeof(sbyte) == value.GetType())
            {
                numeric.Minimum = sbyte.MinValue;
                numeric.Maximum = sbyte.MaxValue;
                numeric.DecimalPlaces = 0;
                numeric.Increment = 1;
                numeric.Value = (sbyte)value;
            }
            else if (typeof(byte) == value.GetType())
            {
                numeric.Minimum = byte.MinValue;
                numeric.Maximum = byte.MaxValue;
                numeric.DecimalPlaces = 0;
                numeric.Increment = 1;
                numeric.Value = (byte)value;
            }
            else if (typeof(short) == value.GetType())
            {
                numeric.Minimum = short.MinValue;
                numeric.Maximum = short.MaxValue;
                numeric.DecimalPlaces = 0;
                numeric.Increment = 1;
                numeric.Value = (short)value;
            }
            else if (typeof(ushort) == value.GetType())
            {
                numeric.Minimum = ushort.MinValue;
                numeric.Maximum = ushort.MaxValue;
                numeric.DecimalPlaces = 0;
                numeric.Increment = 1;
                numeric.Value = (ushort)value;
            }
            else if (typeof(int) == value.GetType())
            {
                numeric.Minimum = int.MinValue;
                numeric.Maximum = int.MaxValue;
                numeric.DecimalPlaces = 0;
                numeric.Increment = 1;
                numeric.Value = (int)value;
            }
            else if (typeof(uint) == value.GetType())
            {
                numeric.Minimum = uint.MinValue;
                numeric.Maximum = uint.MaxValue;
                numeric.DecimalPlaces = 0;
                numeric.Increment = 1;
                numeric.Value = (uint)value;
            }
            else if (typeof(long) == value.GetType())
            {
                numeric.Minimum = long.MinValue;
                numeric.Maximum = long.MaxValue;
                numeric.DecimalPlaces = 0;
                numeric.Increment = 1;
                numeric.Value = (long)value;
            }
            else if (typeof(ulong) == value.GetType())
            {
                numeric.Minimum = ulong.MinValue;
                numeric.Maximum = ulong.MaxValue;
                numeric.DecimalPlaces = 0;
                numeric.Increment = 1;
                numeric.Value = (ulong)value;
            }
            else if (typeof(float) == value.GetType())
            {
                numeric.Minimum = Convert.ToDecimal(int.MinValue);
                numeric.Maximum = Convert.ToDecimal(int.MaxValue);
                numeric.DecimalPlaces = 6;
                numeric.Increment = 0.1m;
                numeric.Value = Convert.ToDecimal((float)value);
            }
            else if (typeof(double) == value.GetType())
            {
                numeric.Minimum = Convert.ToDecimal(long.MinValue);
                numeric.Maximum = Convert.ToDecimal(long.MaxValue);
                numeric.DecimalPlaces = 12;
                numeric.Increment = 0.1m;
                numeric.Value = Convert.ToDecimal((double)value);
            }
            else if (typeof(decimal) == value.GetType())
            {                         
                numeric.Minimum = decimal.MinValue;
                numeric.Maximum = decimal.MaxValue;
                numeric.DecimalPlaces = 12;
                numeric.Increment = 0.1m;
                numeric.Value = (decimal)value;
            }
            else return;
        }

        public static void EnableDoubleBuffering<T>(T control)
        {
            typeof(T).InvokeMember("DoubleBuffered", BindingFlags.SetProperty |
                BindingFlags.Instance | BindingFlags.NonPublic, null, control,
                new object[] { true });
        }

        public static void MooveSelection(Control control, int i)
        {
            int Index = -1, MinInd = -1, MaxInd = -1, Count = -1;
            if (control.GetType() == typeof(ListBox))
            {
                var c = (ListBox)control;
                Index = c.SelectedIndex;
                MinInd = Math.Min(0, c.Items.Count - 1);
                MaxInd = c.Items.Count - 1;
                Count = c.Items.Count;
            }
            if (control.GetType() == typeof(ComboBox))
            {
                var c = (ComboBox)control;
                Index = c.SelectedIndex;
                MinInd = Math.Min(0, c.Items.Count - 1);
                MaxInd = c.Items.Count - 1;
                Count = c.Items.Count;
            }
            if (control.GetType() == typeof(DomainUpDown))
            {
                var c = (DomainUpDown)control;
                Index = c.SelectedIndex;
                MinInd = Math.Min(0, c.Items.Count - 1);
                MaxInd = c.Items.Count - 1;
                Count = c.Items.Count;
            }
            if (Count < 1) return;
            if (Index == -1 && i < 0) Index = 0;
            Index = (Index + i) % Count;
            if (Index < 0) Index += Count;
            if (Index < MinInd) Index = MinInd;
            if (Index > MaxInd) Index = MaxInd;
            if (control.GetType() == typeof(ListBox)) ((ListBox)control).SelectedIndex = Index;
            if (control.GetType() == typeof(ComboBox)) ((ComboBox)control).SelectedIndex = Index;
            if (control.GetType() == typeof(DomainUpDown)) ((DomainUpDown)control).SelectedIndex = Index;
        }

        public static void LoadSubform(this Form main, Form sub)
        {
            main.StartPosition = FormStartPosition.Manual;
            sub.StartPosition = FormStartPosition.Manual;

            sub.SizeGripStyle = main.SizeGripStyle;
            sub.WindowState = main.WindowState;
            if (sub.WindowState != FormWindowState.Normal)
            {
                sub.Location = main.RestoreBounds.Location;
                sub.Size = main.RestoreBounds.Size;
            }
            else
            {
                sub.Location = main.Location;
                sub.Size = main.Size;
            }
            sub.Focus();
            main.Visible = false;
            sub.ShowDialog(main);
            main.Visible = true;
            main.SizeGripStyle = sub.SizeGripStyle;
            main.WindowState = sub.WindowState;
            if (sub.WindowState != FormWindowState.Normal)
            {
                main.Location = sub.RestoreBounds.Location;
                main.Size = sub.RestoreBounds.Size;
            }
            else
            {
                main.Location = sub.Location;
                main.Size = sub.Size;
            }
            main.Focus();
        }

        public static bool SelectNode(this TreeView tree, string path)
        {
            if (path == "")
            {
                tree.SelectedNode = null;
                return true;
            }

            var names = path.Split(new string[] { tree.PathSeparator }, StringSplitOptions.None);
            var nodes = tree.Nodes;
            TreeNode node = null;
            foreach (var name in names)
            {
                bool found = false;
                foreach (TreeNode n in nodes)
                {
                    if (n.Text == name)
                    {
                        node = n;
                        nodes = n.Nodes;
                        found = true;
                        break;
                    }
                }
                if (!found) return false;
            }
            tree.SelectedNode = node;

            return true;
        }
        public static TreeNode FindNode(this TreeView tree, string path)
        {
            if (path == "") return null; 
            var names = path.Split(new string[] { tree.PathSeparator }, StringSplitOptions.None);
            var nodes = tree.Nodes;
            TreeNode node = null;
            foreach (var name in names)
            {
                bool found = false;
                foreach (TreeNode n in nodes)
                {
                    if (n.Text == name)
                    {
                        node = n;
                        nodes = n.Nodes;
                        found = true;
                        break;
                    }
                }
                if (!found) return null;
            }
            return node;
        }
        public static TreeNodeCollection FindNodes(this TreeView tree, string path)
        {
            if (path == "") return tree.Nodes;
            var names = path.Split(new string[] { tree.PathSeparator }, StringSplitOptions.None);
            var nodes = tree.Nodes;
            foreach (var name in names)
            {
                bool found = false;
                foreach (TreeNode n in nodes)
                {
                    if (n.Text == name)
                    {
                        nodes = n.Nodes;
                        found = true;
                        break;
                    }
                }
                if (!found) return null;
            }
            return nodes;
        }
    }
}
