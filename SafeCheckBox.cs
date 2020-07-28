using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraForms
{
    public class SafeCheckBox : CheckBox
    {
        private EventHandler FakeHandler = null;

        public new event EventHandler CheckedChanged
        {
            add
            {
                FakeHandler += value;
                base.CheckedChanged += value;
            }
            remove
            {
                FakeHandler -= value;
                base.CheckedChanged -= value;
            }
        }

        public new bool Checked
        {
            get
            {
                return base.Checked;
            }
            set
            {
                base.CheckedChanged -= FakeHandler;
                base.Checked = value;
                base.CheckedChanged += FakeHandler;
            }
        }
    }
}
