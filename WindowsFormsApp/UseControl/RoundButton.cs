using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.UseControl
{
    public partial class RoundButton : Label
    {
        public RoundButton()
        {
            InitializeComponent();
            radius = 80;
            this.Size = new Size(Radius, Radius);
            this.FlatStyle = FlatStyle.Flat;
            this.BorderStyle = BorderStyle.None;
            //this.FlatAppearance.BorderSize = 0;
            this.BackgroundImage = imageEnter;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.TextAlign = ContentAlignment.MiddleCenter;
        }

        public RoundButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
