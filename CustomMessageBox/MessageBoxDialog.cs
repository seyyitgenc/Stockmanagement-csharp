using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using static stockmanagement.MessageBoxForm;

namespace stockmanagement
{
    public abstract class CustomMessageBox
    {
        public static DialogResult Show(string text)
        {
            DialogResult result;
            using (var msgForm = new MessageBoxForm(text))
                result = msgForm.ShowDialog();
            return result;
        }
        public static DialogResult Show(string text, string caption)
        {
            DialogResult result;
            using (var msgForm = new MessageBoxForm(text, caption))
                result = msgForm.ShowDialog();
            return result;
        }
        public static DialogResult Show(string text, string caption, MsgButtons buttons)
        {
            DialogResult result;
            using (var msgForm = new MessageBoxForm(text, caption, buttons))
                result = msgForm.ShowDialog();
            return result;
        }


    }
}
