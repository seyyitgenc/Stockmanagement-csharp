using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace stockmanagement
{
    public partial class MessageBoxForm : Form
    {
        //picbox
        public PictureBox picbox_Icon;

        //buttons
        public Button btn_Left;
        public Button btn_Middle;
        public Button btn_Right;

        //labels
        public Label lbl_Text;

        //panels
        private Panel pnl_Buttons;

        void Render()
        {
            //form customization
            this.Size = new Size(600, 300);

            //panel customization
            pnl_Buttons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 100,
                BackColor = Color.Yellow,
            };

            //button customization
            btn_Left = new Button
            {
                Size = new Size(120, 50),
                Text = "Abort",
                Location = new Point(100, 25),
                BackColor = Color.Gray,
                Font = new Font("Times New Roman", 14, FontStyle.Regular),
            };
            btn_Right = new Button
            {
                Size = new Size(120, 50),
                Text = "Ignore",
                Location = new Point(240, 25),
                BackColor = Color.Gray,
                Font = new Font("Times New Roman", 14, FontStyle.Regular),
            };
            btn_Middle = new Button
            {
                Size = new Size(120, 50),
                Text = "Retry",
                Location = new Point(380, 25),
                BackColor = Color.Gray,
                Font = new Font("Times New Roman", 14, FontStyle.Regular),
            };

            //label customization

            lbl_Text = new Label
            {
                MaximumSize = new Size(200, 600),
                MinimumSize = new Size(200, 700),
                Location = new Point(100, 100),
            };
            //adding controls
            this.Controls.Add(pnl_Buttons);
            this.Controls.Add(picbox_Icon);
            this.Controls.Add(lbl_Text);
            pnl_Buttons.Controls.Add(btn_Left);
            pnl_Buttons.Controls.Add(btn_Middle);
            pnl_Buttons.Controls.Add(btn_Right);
        }
    }
}
