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
        public Label lbl_Text;
        public Label lbl_Caption;
        //panels
        private Panel pnl_Buttons;
        private Panel pnl_TitleBar;
        private Panel pnl_Body;

        //fields for moving form
        private bool mouseDown;
        private Point lastLocation;

        void Render()
        {
            //form customization
            this.Size = new Size(600, 220);
            this.MinimumSize = new Size(600, 220);
            this.MaximumSize = new Size(600, 700);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Message Box";
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(2);
            this.BackColor = Color.CornflowerBlue;

            pnl_TitleBar = new Panel
            {
                BackColor = Color.CornflowerBlue,
                Dock = DockStyle.Top,
                Location = new Point(2, 2),
                Size = new Size(600, 30),
            };

            pnl_Body = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.WhiteSmoke,
            };
            //panel customization
            pnl_Buttons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.WhiteSmoke,
            };
            //button customization
            btn_Left = new Button
            {
                Size = new Size(100, 40),
                Text = "Abort",
                Location = new Point(130, 0),
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
                Location = new Point(410, 0),
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
                Location = new Point(270, 0),
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
            lbl_Text = new Label
            {
                Text = "it's workinggggg",
                MinimumSize = new Size(400, 684),
                MaximumSize = new Size(400, 684),
                Font = new Font("Times New Roman", 12, FontStyle.Regular),
                AutoEllipsis = true,
                Anchor = AnchorStyles.Top,
                Location = new Point(130, 50),
                BackColor = Color.Transparent,
                ForeColor = Color.Black,
            };
            lbl_Caption = new Label
            {
                Text = "Caption",
                Font = new Font("Times New Roman", 12, FontStyle.Regular),
                MaximumSize = new Size(300, 25),
                Location = new Point(20, 0),
                Anchor = AnchorStyles.Left,
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
            };
            //picture box customization
            picbox_Icon = new PictureBox
            {
                BackgroundImage = Image.FromFile(@"../../images/error.png"),
                BackgroundImageLayout = ImageLayout.Stretch,
                Size = new Size(64, 64),
                Anchor = AnchorStyles.Top,
                MinimumSize = new Size(64, 64),
                MaximumSize = new Size(64, 64),
                Location = new Point(30, 50),
                BackColor = Color.Transparent,
            };
            //adding controls
            this.Controls.Add(pnl_Buttons);
            this.Controls.Add(pnl_TitleBar);
            this.Controls.Add(pnl_Body);
            pnl_Body.Controls.Add(picbox_Icon);
            pnl_Body.Controls.Add(lbl_Text);
            pnl_TitleBar.Controls.Add(btn_Close);
            pnl_TitleBar.Controls.Add(lbl_Caption);
            pnl_Buttons.Controls.Add(btn_Left);
            pnl_Buttons.Controls.Add(btn_Middle);
            pnl_Buttons.Controls.Add(btn_Right);

            //event handlers
            this.Load += Handle_Load;
            btn_Close.Click += Btn_Close_Click;
            pnl_TitleBar.MouseDown += Pnl_TitleBar_MouseDown;
            pnl_TitleBar.MouseUp += Pnl_TitleBar_MouseUp;
            pnl_TitleBar.MouseMove += Pnl_TitleBar_MouseMove;
        }
        //for moving form
        void Pnl_TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }
        void Pnl_TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        void Pnl_TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
    }
}
