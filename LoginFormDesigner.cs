using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace stockmanagement
{
    public partial class LoginForm
    {
        //fields
        private PictureBox pic_user;

        private Label lbl_login;
        private Label lbl_username;
        private Label lbl_password;
        private Button btn_login;

        //textboxes
        customtextbox txt_username = new customtextbox();
        customtextbox txt_password = new customtextbox();
        custombtn cbtn = new custombtn();
        private void Render()
        {
            //login form
            this.Text = "Login Form";
            this.Size = new Size(600, 600);
            this.MaximumSize = new Size(600, 600);
            this.MinimumSize = new Size(600, 600);
            this.BackgroundImage = Image.FromFile(@"../../images/bg.jpg");

            this.BackgroundImageLayout = ImageLayout.Stretch;
            //adding custom textboxes into the form
            this.Controls.Add(txt_username);
            this.Controls.Add(txt_password);

            txt_username.Location = new Point(170, 260);
            txt_password.Location = new Point(170, 320);
            txt_username.Texts = "Username...";
            txt_password.Texts = "Password...";

            //picture for login screen
            pic_user = new PictureBox
            {
                BackColor = Color.Transparent,
                Image = Image.FromFile(@"../../images/icon2.png"),
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(250, 40),
            };

            lbl_username = new Label
            {
                Text = "Your Username :",
                Location = new Point(170, 240),
                BackColor = Color.Transparent,
                ForeColor = Color.AliceBlue,
                Font = new Font("Georgia", 11, FontStyle.Regular, GraphicsUnit.Point),
                Width = 140,
            };
            lbl_password = new Label
            {
                Text = "Your Password :",
                Location = new Point(170, 300),
                BackColor = Color.Transparent,
                ForeColor = Color.AliceBlue,
                Font = new Font("Georgia", 11, FontStyle.Regular, GraphicsUnit.Point),
                Width = 135,
            };

            lbl_login = new Label
            {
                Text = "Login",
                Location = new Point(260, 170),
                BackColor = Color.Transparent,
                ForeColor = Color.AliceBlue,
                BorderStyle = BorderStyle.None,
                Font = new Font("Georgia", 20, FontStyle.Regular, GraphicsUnit.Point),
            };

            //resizing lbl_login control according to text
            int txtHeight = TextRenderer.MeasureText("Login", lbl_login.Font).Height + 1;
            int txtWidth = TextRenderer.MeasureText("Login", lbl_login.Font).Width + 1;

            //button for login
            btn_login = new Button
            {
                Dock = DockStyle.None,
                Size = new Size(100, 40),
                Location = new Point(250, 370),
                Text = "Login",
                Font = new Font("Georgia", 16, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.AliceBlue,
                ForeColor = Color.Black,
            };
            btn_login.FlatAppearance.BorderSize = 3;

            lbl_login.MinimumSize = new Size(txtWidth, txtHeight);

            //adding controls to the form
            this.Controls.Add(pic_user);
            this.Controls.Add(btn_login);
            this.Controls.Add(lbl_username);
            this.Controls.Add(lbl_password);
            this.Controls.Add(lbl_login);

            //event handler for login button
            btn_login.Click += Btn_Login_Click;

            //event handlers for textboxs
            txt_username.Enter += Cxt_GotFocus;
            txt_username.Leave += Cxt_LostFocus;
            txt_username.KeyPress += Cxt_KeyPress;
            txt_password.Enter += Cxt2_GotFocus;
            txt_password.Leave += Cxt2_LostFocus;
            txt_password.KeyPress += Cxt2_KeyPress;

            //event handlers for form
            this.FormClosed += Handle_FormClosed;
        }
        //end render
    }
}