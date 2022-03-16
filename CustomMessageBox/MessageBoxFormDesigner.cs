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
        private Button btn_Close;

        //labels
        public Label lbl_Caption;
        //panels
        private Panel pnl_Buttons;
        private Panel pnl_TitleBar;
        private Panel pnl_Body;
        private Panel pnl_TxtBody;

        private TextBox txt_message = new TextBox();
        //fields for moving form
        private bool mouseDown;
        private Point lastLocation;

        //constructor
        public MessageBoxForm()
        {
            Render();
        }
        //Components properties
        void Render()
        {
            //form customization
            this.Size = new Size(600, 220);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(2,0,2,2);
            this.BackColor = Color.CornflowerBlue;
            //textbox customization
            txt_message.Dock = DockStyle.Fill;
            txt_message.Multiline = true;
            txt_message.BorderStyle = BorderStyle.None;
            txt_message.BackColor = Color.WhiteSmoke;
            txt_message.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            txt_message.TextAlign = HorizontalAlignment.Left;
            txt_message.ReadOnly = true;
            txt_message.ForeColor = Color.Black;
            txt_message.WordWrap = true;
            txt_message.TabStop = false;
            txt_message.Cursor = Cursors.Default;

            //panel customization
            pnl_TitleBar = new Panel
            {
                BackColor = Color.CornflowerBlue,
                Dock = DockStyle.Top,
                Size = new Size(600, 30),
            };

            pnl_Body = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10, 10, 0, 0),
                Size = new Size(600, 0),
                AutoSize = true,
            };

            pnl_Buttons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 80,
                BackColor = Color.LightGray,
            };

            pnl_TxtBody = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 10, 20, 10),
            };
            //button customization
            btn_Left = new Button
            {
                Size = new Size(100, 40),
                Text = "Abort",
                Location = new Point(130, 10),
                BackColor = Color.SeaGreen,
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Times New Roman", 14, FontStyle.Regular),
                FlatStyle = FlatStyle.Flat,
            };
            btn_Left.FlatAppearance.BorderSize = 0;

            btn_Right = new Button
            {
                Size = new Size(100, 40),
                Text = "Ignore",
                Location = new Point(410, 10),
                BackColor = Color.SeaGreen,
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Times New Roman", 14, FontStyle.Regular),
                FlatStyle = FlatStyle.Flat,
            };

            btn_Right.FlatAppearance.BorderSize = 0;
            btn_Middle = new Button
            {
                Size = new Size(100, 40),
                Text = "Retry",
                Location = new Point(270, 10),
                BackColor = Color.SeaGreen,
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Times New Roman", 14, FontStyle.Regular),
                FlatStyle = FlatStyle.Flat,
            };
            btn_Middle.FlatAppearance.BorderSize = 0;

            btn_Close = new Button
            {
                Size = new Size(35, 30),
                Dock = DockStyle.Right,
                UseVisualStyleBackColor = false,
                Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point),
                Text = "X",
                ForeColor = Color.Red,
                FlatStyle = FlatStyle.Flat,
                TabIndex = 3,
            };
            btn_Close.FlatAppearance.BorderSize = 0;
            btn_Close.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 79, 95);

            //label customization
            lbl_Caption = new Label
            {
                Text = "Information",
                Font = new Font("Times New Roman", 12, FontStyle.Regular),
                AutoSize = true,
                Dock = DockStyle.Left,
                TextAlign = ContentAlignment.TopLeft,
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
            };
            //picture box customization
            picbox_Icon = new PictureBox
            {
                BackgroundImage = Image.FromFile(@"../../images/information.png"),
                BackgroundImageLayout = ImageLayout.Stretch,
                Dock = DockStyle.Left,
                MaximumSize = new Size(64, 64),
                MinimumSize = new Size(64, 64),
                BackColor = Color.Transparent,
                TabIndex = 3,
            };
            this.pnl_TitleBar.ResumeLayout(false);
            this.pnl_TitleBar.PerformLayout();
            this.pnl_Buttons.ResumeLayout(false);
            this.pnl_Body.ResumeLayout(false);
            this.pnl_Body.PerformLayout();
            //adding controls
            this.Controls.Add(pnl_Body);
            this.Controls.Add(pnl_TitleBar);
            this.Controls.Add(pnl_Buttons);


            pnl_TxtBody.Controls.Add(txt_message);
            pnl_Body.Controls.Add(pnl_TxtBody);
            pnl_Body.Controls.Add(picbox_Icon);
            pnl_TitleBar.Controls.Add(lbl_Caption);
            pnl_TitleBar.Controls.Add(btn_Close);
            pnl_Buttons.Controls.Add(btn_Left);
            pnl_Buttons.Controls.Add(btn_Middle);
            pnl_Buttons.Controls.Add(btn_Right);

            //event handlers
            btn_Close.Click += Btn_Close_Click;

            pnl_TitleBar.MouseDown += Pnl_TitleBar_MouseDown;
            pnl_TitleBar.MouseUp += Pnl_TitleBar_MouseUp;
            pnl_TitleBar.MouseMove += Pnl_TitleBar_MouseMove;
        }
    }
}
