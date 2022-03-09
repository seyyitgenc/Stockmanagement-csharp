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
