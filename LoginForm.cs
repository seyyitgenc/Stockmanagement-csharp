using System;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace stockmanagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            CenterToScreen();
            Render();
        }
        XDocument xelement = XDocument.Load(@"..\..\stockmanagement.xml");
        GeneralForm gf = new GeneralForm();
        //get login parameters
        void login()
        {
            Boolean is_correct = false;
            //get user information
            try
            {
                var getUser = xelement.Descendants("user").ToList();
                //bind username
                foreach (var x in getUser)
                {
                    if (is_correct == true)
                        break;
                    if (x.Element("user_username").Value == txt_username.Texts &&
                     x.Element("user_password").Value == txt_password.Texts)
                    {
                        is_correct = true;
                        gf.Show();
                        this.Hide();
                        gf.picboxuser.Image = Image.FromFile(@"../../images/" + x.Element("user_image").Attribute("url").Value);
                    }
                    else
                        is_correct = false;
                }

                if (is_correct == false)
                    MessageBox.Show("Wrong Password or Username !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch
            {
                MessageBox.Show("Somethings Wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //login void end

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
            txt_username.Texts = "";
            txt_username.GotFocus -= cxt_GotFocus;
            txt_username.ForeColor = Color.Black;
        }
        //for username textbox leave event
        void cxt_LostFocus(object sender, EventArgs e)
        {
            if (txt_username.Texts == "")
            {
                txt_username.Texts = "Username...";
                txt_username.ForeColor = Color.DimGray;
                txt_username.GotFocus += cxt_GotFocus;
            }
        }
        //for password textbox enter event
        void cxt2_GotFocus(object sender, EventArgs e)
        {
            txt_password.Texts = "";
            txt_password.GotFocus -= cxt2_GotFocus;
            txt_password.ForeColor = Color.Black;
            txt_password.PasswordChar = true;
        }
        //for password textbox leave event
        void cxt2_LostFocus(object sender, EventArgs e)
        {
            if (txt_password.Texts == "")
            {
                txt_password.Texts = "Password...";
                txt_password.ForeColor = Color.DimGray;
                txt_password.GotFocus += cxt2_GotFocus;
                txt_password.PasswordChar = false;
            }
        }
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
