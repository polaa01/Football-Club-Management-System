using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Fudbalski_Klub
{
    public class StretchImageButton: Button
    {
        public Image ButtonImage { get; set; }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (ButtonImage != null)
            {  
                Rectangle imageRect = new Rectangle(0, 0, this.Width, this.Height);
                 pevent.Graphics.DrawImage(ButtonImage, imageRect); }
            if (!string.IsNullOrEmpty(this.Text)) 
            { TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter); }
        }
    }
}

