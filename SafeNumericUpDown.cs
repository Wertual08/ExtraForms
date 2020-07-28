using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraForms
{
    public class SafeNumericUpDown : NumericUpDown
    {
        private EventHandler FakeHandler = null;

        public new event EventHandler ValueChanged
        {
            add
            {
                FakeHandler += value;
                base.ValueChanged += value;
            }
            remove
            {
                FakeHandler -= value;
                base.ValueChanged -= value;
            }
        }

        public new decimal Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                base.ValueChanged -= FakeHandler;
                base.Value = value;
                base.ValueChanged += FakeHandler;
            }
        }
    }
}