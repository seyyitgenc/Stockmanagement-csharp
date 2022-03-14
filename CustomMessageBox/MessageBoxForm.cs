using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace stockmanagement
{
    public partial class MessageBoxForm : Form
    {
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

        void ResizeForm()
        {
            this.Height += txt_message.Height;
            CenterToScreen();
        }

        //constructors
        public MessageBoxForm(string text)
        {
            Render();
            txt_message.Text = text;
            lbl_Caption.Text = "Information";
            SetButtons(MsgButtons.Ok);
            ResizeForm();
        }
        public MessageBoxForm(string text, string caption)
        {
            Render();
            txt_message.Text = text;
            lbl_Caption.Text = caption;
            SetButtons(MsgButtons.Ok);
            ResizeForm();
        }
        public MessageBoxForm(string text, string caption, MsgButtons buttons)
        {
            Render();
            txt_message.Text = text;
            lbl_Caption.Text = caption;
            SetButtons(buttons);
            ResizeForm();
        }
        public MessageBoxForm(string text, string caption, MsgButtons buttons, MsgIcon icon)
        {
            Render();
            txt_message.Text = text;
            lbl_Caption.Text = caption;
            SetButtons(buttons);
            setIcon(icon);
            ResizeForm();
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
                    btn_Right.BackColor = Color.DimGray;
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
                    btn_Right.BackColor = Color.IndianRed;
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
                    btn_Right.BackColor = Color.DimGray;
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
                    btn_Middle.BackColor = Color.IndianRed;
                    //Cancel Button
                    btn_Right.Visible = true;
                    btn_Right.Text = "Cancel";
                    btn_Right.DialogResult = (DialogResult)MsgResult.Cancel;
                    btn_Right.BackColor = Color.DimGray;
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
                    btn_Middle.BackColor = Color.IndianRed;
                    //Cancel Button
                    btn_Right.Visible = true;
                    btn_Right.Text = "Cancel";
                    btn_Right.DialogResult = (DialogResult)MsgResult.Cancel;
                    btn_Right.BackColor = Color.DimGray;
                    break;
            }
        }
        void Btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        //for moving form
        void Pnl_TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point(
                    (Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);

                Update();
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
