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
            this.Size = new Size(600, 220);
            this.MinimumSize = new Size(600, 220);
            this.MaximumSize = new Size(600, 700);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackgroundImage = Image.FromFile(@"../../images/editbg.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Text = "Message Box";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //panel customization
            pnl_Buttons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 100,
                BackColor = Color.Transparent,
            };

            //button customization
            btn_Left = new Button
            {
                Size = new Size(100, 40),
                Text = "Abort",
                Location = new Point(130, 25),
                BackColor = Color.Gray,
                Font = new Font("Times New Roman", 14, FontStyle.Regular),
            };
            btn_Right = new Button
            {
                Size = new Size(100, 40),
                Text = "Ignore",
                Location = new Point(270, 25),
                BackColor = Color.Gray,
                Font = new Font("Times New Roman", 14, FontStyle.Regular),
            };
            btn_Middle = new Button
            {
                Size = new Size(100, 40),
                Text = "Retry",
                Location = new Point(410, 25),
                BackColor = Color.Gray,
                Font = new Font("Times New Roman", 14, FontStyle.Regular),
            };

            //label customization
            lbl_Text = new Label
            {

                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ultricies ipsum vel lacus dapibus, sit amet facilisis diam rhoncus. Donec dignissim lacus id ex feugiat, at scelerisque arcu gravida. Nulla ante ex, pulvinar quis fringilla sed, fringilla et neque. Cras eu imperdiet enim, ac vulputate dui.",
                MinimumSize = new Size(400, 684),
                MaximumSize = new Size(400, 684),
                Font = new Font("Times New Roman", 12, FontStyle.Regular),
                AutoEllipsis = true,
                Anchor = AnchorStyles.Top,
                Location = new Point(130, 30),
                BackColor = Color.Transparent,
                ForeColor = Color.Black,
            };

            //picture box customization
            picbox_Icon = new PictureBox
            {
                BackgroundImage = Image.FromFile(@"../../images/error.png"),
                BackgroundImageLayout = ImageLayout.Stretch,
                Size = new Size(64, 64),
                MinimumSize = new Size(64, 64),
                MaximumSize = new Size(64, 64),
                Location = new Point(30, 30),
                BackColor = Color.Transparent,
            };

            //adding controls
            this.Controls.Add(pnl_Buttons);
            this.Controls.Add(picbox_Icon);
            this.Controls.Add(lbl_Text);
            pnl_Buttons.Controls.Add(btn_Left);
            pnl_Buttons.Controls.Add(btn_Middle);
            pnl_Buttons.Controls.Add(btn_Right);

            //event handlers
            this.Load += Handle_Load;
        }

        void Handle_Load(object sender, EventArgs e)
        {
            //measuring the size of the label text
            Size size = TextRenderer.MeasureText(lbl_Text.Text, lbl_Text.Font);
            int satırsayi = size.Width / 380;
            this.Height += (satırsayi * 19);
            Console.WriteLine(size);

        }

    }
}
