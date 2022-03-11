using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace stockmanagement
{
    public partial class MessageBoxForm : Form
    {
        public MessageBoxForm()
        {
            CenterToScreen();
            Render();
        }
        //messagebox load event
        void Handle_Load(object sender, EventArgs e)
        {
            //measuring the size of the label text
            Size size = TextRenderer.MeasureText(lbl_Text.Text, lbl_Text.Font);
            int rowCount = size.Width / 380;
            this.Height += (rowCount * 19);
        }

        //enum for messageboxbuttons
        public enum MsgButtons
        {
            Ok = 0,
            OkCancel = 1,
            RetryCancel = 2,
            YesNo = 3,
            YesNoCancel = 4,
            AbortRetryIgnore = 5,
            SendDontSendCancel = 6,
        }

        //constructors
        public MessageBoxForm(string text)
        {
            Render();
            lbl_Text.Text = text;
            SetButtons(MsgButtons.Ok);
        }
        public MessageBoxForm(string text, string caption)
        {
            Render();
            lbl_Text.Text = text;
            this.Text = caption;
            SetButtons(MsgButtons.Ok);
        }
        public MessageBoxForm(string text, string caption, MsgButtons buttons)
        {
            Render();
            lbl_Text.Text = text;
            this.Text = caption;
            SetButtons(buttons);
        }


        private void SetButtons(MsgButtons buttons)
        {
            switch (buttons)
            {
                case MsgButtons.Ok:
                    //OK Button
                    btn_Middle.Visible = true;
                    btn_Middle.Text = "Ok";
                    btn_Middle.DialogResult = DialogResult.OK;//Set DialogResult
                    break;
            }
        }
    }
}
