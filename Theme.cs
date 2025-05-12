using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Fudbalski_Klub
{
    public class Theme
    {
        public Font Font { get; set; }
        public Color TextColor { get; set; } //bijela, iskoristicemo je i za boju teksta u header-u DGW-a
        public Color PanelColor { get; set; }
        public Color InsertButton { get; set; }
        public Color UpdateButton { get; set; }
        public Color DeleteButton { get; set; }

        
        

        public Color DgvHeader {  get; set; }
        public Color DgvRowsBack { get; set; }
        public Color DgvAlternateRows { get; set; }

        public Color DgvRowsFore { get; set; } //crna
        //public Color Background { get; set; }
        public Color DgvHeaderFore { get; set; }

        public Color PanelButton { get; set; } //meni, unutar svakog mini panela nalazi se dugme i pictureBox

        public Color DgvBackColor { get; set; }

        //eventualno dodati za combobox-ove i dodatne kontrole

    }
}
