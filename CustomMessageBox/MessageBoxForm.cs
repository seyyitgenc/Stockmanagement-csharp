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
    }
}
