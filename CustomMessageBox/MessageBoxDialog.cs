using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using static stockmanagement.MessageBoxForm;

namespace stockmanagement
{
    public abstract class CustomMessageBox
    {
        public static MsgResult Show(string text)
        {
            MsgResult result;
            using (var msgForm = new MessageBoxForm(text))
                result = (MsgResult)msgForm.ShowDialog();
            return result;
        }
        public static MsgResult Show(string text, string caption)
        {
            MsgResult result;
            using (var msgForm = new MessageBoxForm(text, caption))
                result = (MsgResult)msgForm.ShowDialog();
            return result;
        }
        public static MsgResult Show(string text, string caption, MsgButtons buttons)
        {
            MsgResult result;
            using (var msgForm = new MessageBoxForm(text, caption, buttons))
                result = (MsgResult)msgForm.ShowDialog();
            return result;
        }
        public static MsgResult Show(string text, string caption, MsgButtons buttons, MsgIcon icon)
        {
            MsgResult result;
            using (var msgForm = new MessageBoxForm(text, caption, buttons, icon))
                result = (MsgResult)msgForm.ShowDialog();
            return result;
        }

    }
}
