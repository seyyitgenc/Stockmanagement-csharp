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
            int rowCount = size.Width / 400;
            this.Height += (rowCount * 19)-80;
            CenterToScreen();
        }

        //enum for messageboxbuttons
        public enum MsgButtons
        {
            Ok = 0,
            OkCancel = 1,
            RetryCancel = 2,
            YesNo = 3,
            YesNoCancel = 4,
            SendDontSendCancel = 6,
        }

        //enum for dialogresult
        public enum MsgResult
        {
            Cancel = 1,
            Retry = 2,
            Yes = 3,
            No = 4,
            Ok = 5,
            DontSend = 6,
            Send = 7,
        }

        //enum for messageboxicon
        public enum MsgIcon
        {
            error = 0,
            information = 1,
            warning = 2,
        }

        //constructors
        public MessageBoxForm(string text)
        {
            Render();
            lbl_Text.Text = text;
            this.lbl_Caption.Text = "Infjfkdsfkdsajfkdsfkdsnfjdsfjdsfjdsfsjbfbsabffffffdsffkdsaormation";
            SetButtons(MsgButtons.Ok);
        }
        public MessageBoxForm(string text, string caption)
        {
            Render();
            lbl_Text.Text = text;
            this.lbl_Caption.Text = caption;
            SetButtons(MsgButtons.Ok);
        }
        public MessageBoxForm(string text, string caption, MsgButtons buttons)
        {
            Render();
            lbl_Text.Text = text;
            this.lbl_Caption.Text = caption;
            SetButtons(buttons);
        }
        public MessageBoxForm(string text, string caption, MsgButtons buttons, MsgIcon icon)
        {
            Render();
            lbl_Text.Text = text;
            this.lbl_Caption.Text = caption;
            SetButtons(buttons);
            setIcon(icon);
        }
        //icon
        private void setIcon(MsgIcon icon)
        {
            switch (icon)
            {
                case MsgIcon.error:
                    picbox_Icon.BackgroundImage = Image.FromFile(@"../../images/error.png");
                    break;
                case MsgIcon.information:
                    picbox_Icon.BackgroundImage = Image.FromFile(@"../../images/information.png");
                    break;
                case MsgIcon.warning:
                    picbox_Icon.BackgroundImage = Image.FromFile(@"../../images/warning.png");
                    break;
            }
        }
        //button
        private void SetButtons(MsgButtons buttons)
        {
            switch (buttons)
            {
                case MsgButtons.Ok:
                    btn_Left.Visible = false;
                    btn_Right.Visible = false;
                    //Ok Button
                    btn_Middle.Visible = true;
                    btn_Middle.Text = "Ok";
                    btn_Middle.DialogResult = (DialogResult)MsgResult.Ok;
                    break;
                case MsgButtons.OkCancel:
                    btn_Left.Visible = false;
                    //Ok Button
                    btn_Middle.Visible = true;
                    btn_Middle.Text = "Ok";
                    btn_Middle.DialogResult = (DialogResult)MsgResult.Ok;
                    //Cancel Button
                    btn_Right.Text = "Cancel";
                    btn_Right.Visible = true;
                    btn_Right.DialogResult = (DialogResult)MsgResult.Cancel;
                    break;
                case MsgButtons.YesNo:
                    btn_Left.Visible = false;
                    //Yes Button
                    btn_Middle.Visible = true;
                    btn_Middle.Text = "Yes";
                    btn_Middle.DialogResult = (DialogResult)MsgResult.Yes;
                    //No Button
                    btn_Right.Visible = true;
                    btn_Right.Text = "No";
                    btn_Right.DialogResult = (DialogResult)MsgResult.No;
                    break;
                case MsgButtons.RetryCancel:
                    btn_Left.Visible = false;
                    //Retry Button
                    btn_Middle.Visible = true;
                    btn_Middle.Text = "Retry";
                    btn_Middle.DialogResult = (DialogResult)MsgResult.Retry;
                    //Cancel Button
                    btn_Right.Visible = true;
                    btn_Right.Text = "Cancel";
                    btn_Right.DialogResult = (DialogResult)MsgResult.Cancel;
                    break;
                case MsgButtons.YesNoCancel:
                    //Yes Button
                    btn_Left.Visible = true;
                    btn_Left.Text = "Yes";
                    btn_Left.DialogResult = (DialogResult)MsgResult.Yes;
                    //No Button
                    btn_Middle.Visible = true;
                    btn_Middle.Text = "No";
                    btn_Middle.DialogResult = (DialogResult)MsgResult.No;
                    //Cancel Button
                    btn_Right.Visible = true;
                    btn_Right.Text = "Cancel";
                    btn_Right.DialogResult = (DialogResult)MsgResult.Cancel;
                    break;
                case MsgButtons.SendDontSendCancel:
                    //Send Button
                    btn_Left.Visible = true;
                    btn_Left.Text = "Send";
                    btn_Left.DialogResult = (DialogResult)MsgResult.Send;
                    //Dont Send Button
                    btn_Middle.Visible = true;
                    btn_Middle.Text = "Don't Send";
                    btn_Middle.DialogResult = (DialogResult)MsgResult.DontSend;
                    //Cancel Button
                    btn_Right.Visible = true;
                    btn_Right.Text = "Cancel";
                    btn_Right.DialogResult = (DialogResult)MsgResult.Cancel;
                    break;
            }
        }

        void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
