using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;
using System.Collections;
using System.Drawing.Design;

namespace ExtraForms
{
    [Designer(typeof(ExtraTabManagerDesigner))]
    public partial class ExtraTabManager : UserControl
    {
        private List<ExtraTab> TabPages = new List<ExtraTab>();
        private int TabsOffset = 0;
        private Size ButtonSize = new Size(8, 8);

        protected void RenderTab(Graphics g, int x, int y, int w, int h, string text)
        {
            g.DrawRectangle(new Pen(new SolidBrush(SystemColors.ButtonShadow), 1.0f), x, y, w, h);
            g.FillRectangle(new SolidBrush(SystemColors.ButtonFace), x + 1, y + 1, w - 1, h - 1); ;
            g.DrawString(text, TabHeaderFont, Brushes.Black, x + 1, y + 1);
        }
        private void RenderTabs(Graphics g)
        {
            int curs = TabsOffset;

            for (int i = 0; i < TabPages.Count; i++)
            {
                var tab = TabPages[i];

                var size = g.MeasureString(tab.Text, TabHeaderFont);
                var w = (int)Math.Ceiling(size.Width) + 2;
                var h = (int)Math.Ceiling(size.Height) + 2; 
                
                if (curs + w > 0) RenderTab(g, curs, 0, w, h, tab.Text);

                curs += w;

                if (curs > ClientSize.Width) break;
            }
        }

        public Font TabHeaderFont { get; set; } = SystemFonts.DefaultFont;
        public bool NewTabButton { get; set; } = false;
        public bool CloseTabButton { get; set; } = false;
        public int SelectedIndex { get; set; } = -1;

        public ExtraTabManager()
        {
            InitializeComponent();

            var tabc = new TabControl();
            var button = new Button();
            

            TabPages.Add(new ExtraTab("Shit"));
            TabPages.Add(new ExtraTab("Sin"));
            TabPages.Add(new ExtraTab("Cunt"));
            TabPages.Add(new ExtraTab("Fuck"));
            TabPages.Add(new ExtraTab("Pussy"));
            TabPages.Add(new ExtraTab("Cock"));
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            RenderTabs(e.Graphics);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            //e.Graphics.FillRectangle(Brushes.Black, 10, 10, 10, 10);
        }
    }
    public class TabEventArgs : EventArgs
    {
    }
    public class ExtraTab
    {
        public string Text { get; set; }
        
        public ExtraTab()
        {

        }
        public ExtraTab(string text)
        {
            Text = text;
        }
    }

    public class ExtraTabManagerDesigner : ParentControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            //var contentsPanel = ((ExtraTabManager)Control).ContentsPanel;
            //this.EnableDesignMode(contentsPanel, "ContentsPanel");
        }
        public override bool CanParent(Control control)
        {
            return false;
        }
        protected override void OnDragOver(DragEventArgs de)
        {
            de.Effect = DragDropEffects.None;
        }
        protected override IComponent[] CreateToolCore(ToolboxItem tool,
            int x, int y, int width, int height, bool hasLocation, bool hasSize)
        {
            return null;
        }
    }
    public class MyPanelDesigner : ParentControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules selectionRules = base.SelectionRules;
                selectionRules &= ~SelectionRules.AllSizeable;
                return selectionRules;
            }
        }
        protected override void PostFilterAttributes(IDictionary attributes)
        {
            base.PostFilterAttributes(attributes);
            attributes[typeof(DockingAttribute)] = new DockingAttribute(DockingBehavior.Never);
        }
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            var propertiesToRemove = new string[] {
            "Dock", "Anchor",
            "Size", "Location", "Width", "Height",
            "MinimumSize", "MaximumSize",
            "AutoSize", "AutoSizeMode",
            "Visible", "Enabled",
        };
            foreach (var item in propertiesToRemove)
            {
                if (properties.Contains(item))
                    properties[item] = TypeDescriptor.CreateProperty(this.Component.GetType(),
                        (PropertyDescriptor)properties[item],
                        new BrowsableAttribute(false));
            }
        }
    }
}
