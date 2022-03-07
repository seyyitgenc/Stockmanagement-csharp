using System;
using System.Windows.Forms;
using System.Drawing;
namespace stockmanagement
{
    public class custommessagebox : Form
    {
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private PictureBox picturebox = new PictureBox();
        private Label label = new Label();
        public custommessagebox()
        {
            this.Size = new Size(350, 300);
            CenterToScreen();
            Render();
            this.Text = "Operation";
            this.BackColor = Color.AntiqueWhite;
        }

        private void Render()
        {
            label.Text = "Please Select \n  Operation";
            label.Font = new Font("Georgia", 20, FontStyle.Regular, GraphicsUnit.Point);
            label.ForeColor = Color.Black;
            label.AutoSize = true;
            label.Location = new Point(130, 50);
            picturebox.Location = new Point(10, 30);
            picturebox.Size = new Size(100, 100);
            picturebox.Image = Image.FromFile(@"../../images/bg.jpg");

            btn1 = new Button
            {
                Size = new Size(80, 40),
                Location = new Point(30, 180),
                Text = "Add Meal",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
            };
            btn2 = new Button
            {
                Size = new Size(80, 40),
                Location = new Point(130, 180),
                Text = "Delete",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
            };
            btn3 = new Button
            {
                Size = new Size(80, 40),
                Location = new Point(230, 180),
                Text = "Update",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
            };
            this.Controls.Add(btn1);
            this.Controls.Add(btn2);
            this.Controls.Add(btn3);
            this.Controls.Add(picturebox);
            this.Controls.Add(label);
            btn1.Click += Btn1_Click;
        }

        void Btn1_Click(object sender, EventArgs e)
        {

        }

    }



}
