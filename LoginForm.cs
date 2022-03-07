﻿using System;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace stockmanagement
{
    public class LoginForm : Form
    {
        //creating custom textbox
        customtextbox cxt = new customtextbox();
        customtextbox cxt2 = new customtextbox();
        custombtn cbtn = new custombtn();
        public LoginForm()
        {
            Text = "Login Form";
            this.Size = new Size(600, 600);
            this.MaximumSize = new Size(600, 600);
            this.MinimumSize = new Size(600, 600);
            this.BackgroundImage = Image.FromFile(@"../../images/bg.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            CenterToScreen();
            Render();
            this.FormClosed += Handle_FormClosed;
        }
        //fields
        private PictureBox pic_user;

        private Label lbl_login;
        private Label lbl_username;
        private Label lbl_password;
        private Button btn_login;

        private void Render()
        {
            //adding custom textboxes into the form
            this.Controls.Add(cxt);
            this.Controls.Add(cxt2);

            cxt.Location = new Point(170, 260);
            cxt2.Location = new Point(170, 320);
            cxt.Texts = "Username...";
            cxt2.Texts = "Password...";

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
            cxt.Enter += cxt_GotFocus;
            cxt.Leave += cxt_LostFocus;
            cxt.KeyPress += Cxt_KeyPress;
            cxt2.Enter += cxt2_GotFocus;
            cxt2.Leave += cxt2_LostFocus;
            cxt2.KeyPress += Cxt2_KeyPress;
        }



        //end render
        void Cxt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                login();
        }


        void Cxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                login();
        }


        //for username textbox enter event
        void cxt_GotFocus(object sender, EventArgs e)
        {
            cxt.Texts = "";
            cxt.GotFocus -= cxt_GotFocus;
            cxt.ForeColor = Color.Black;
        }
        //for username textbox leave event
        void cxt_LostFocus(object sender, EventArgs e)
        {
            if (cxt.Texts == "")
            {
                cxt.Texts = "Username...";
                cxt.ForeColor = Color.DimGray;
                cxt.GotFocus += cxt_GotFocus;
            }
        }
        //for password textbox enter event
        void cxt2_GotFocus(object sender, EventArgs e)
        {
            cxt2.Texts = "";
            cxt2.GotFocus -= cxt2_GotFocus;
            cxt2.ForeColor = Color.Black;
            cxt2.PasswordChar = true;
        }
        //for password textbox leave event
        void cxt2_LostFocus(object sender, EventArgs e)
        {
            if (cxt2.Texts == "")
            {
                cxt2.Texts = "Password...";
                cxt2.ForeColor = Color.DimGray;
                cxt2.GotFocus += cxt2_GotFocus;
                cxt2.PasswordChar = false;
            }
        }
        //get login parameters
        void login()
        {
            string username = cxt.Texts;
            string password = cxt2.Texts;
            string fromxml_user = "";
            string fromxml_psw = "";
            string fromxml_imageurl = "";
            //get user information
            try
            {
                XDocument doc = XDocument.Load(@"..\..\stockmanagement.xml");
                var getUser = from x in doc.Descendants("user").Where(x => (string)x.Element("user_username") == username && (string)x.Element("user_password") == password)
                              select new
                              {
                                  xmluser = x.Element("user_username").Value,
                                  xmlpsw = x.Element("user_password").Value,
                                  role = x.Element("user_role").Value,
                                  image = x.Element("user_image").Attribute("url").Value,
                              };
                //bind username
                foreach (var x in getUser)
                {
                    fromxml_user = x.xmluser;
                    fromxml_psw = x.xmlpsw;
                    fromxml_imageurl = x.image;
                }
                //compare with textbox result
                if (fromxml_psw == password && fromxml_user == username)
                {
                    GeneralForm gf = new GeneralForm();
                    if (fromxml_imageurl != "")
                        gf.picboxuser.Image = Image.FromFile(@"../../images/" + fromxml_imageurl);
                    this.Hide();
                    gf.Show();
                }
                else
                    MessageBox.Show("Wrong Password or Username !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Somethings Wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //login void end

        //login button
        void Btn_Login_Click(object sender, EventArgs e)
        {
            login();
        }
        //login click end

        void Handle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }
}
