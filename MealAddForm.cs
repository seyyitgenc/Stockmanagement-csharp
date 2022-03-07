using System;
using System.Windows.Forms;
using System.Drawing;

using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace stockmanagement
{
    public class MealAddForm : Form
    {
        //fields
        private XElement xelement = XElement.Load(@"..\..\stockmanagement.xml");
        GeneralForm gf = new GeneralForm();
        private int mealquantity = 0;
        public string customer_id = "";
        private string meal_id = "";
        private string[] date;

        private DataGridView customermeal_datagridview;
        private DataGridViewButtonColumn selectbutton = new DataGridViewButtonColumn();

        private customtextbox txtbox1 = new customtextbox();
        private customtextbox txtbox_customer = new customtextbox();

        private Button btn_add;
        private Button btn_mainform;
        private Button btn_update;
        private Button btn_delete;

        private DateTimePicker dateTimePicker = new DateTimePicker();

        private Label lbl_quantity = new Label();
        private Label lbl_date = new Label();
        private Label lbl_selecteddate = new Label();
        private Label lbl_datetime = new Label();
        private Label lbl_customername = new Label();
        private Label lbl_customer = new Label();


        public MealAddForm()
        {
            this.Size = new Size(600, 600);
            this.BackColor = Color.DimGray;
            this.MaximumSize = new Size(600, 600);
            this.MinimumSize = new Size(600, 600);
            this.Load += Handle_Load;
            this.FormClosed += Handle_FormClosed;
            this.Text = "Meal Add Form";
            CenterToScreen();
            Render();
        }
        public void Render()
        {
            //button customization
            btn_add = new Button
            {
                Size = new Size(100, 40),
                Location = new Point(70, 300),
                Text = "Add Meal",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                Padding = new Padding(0, 0, 0, 5),
            };
            btn_update = new Button
            {
                Size = new Size(100, 40),
                Location = new Point(190, 300),
                Text = "Update Meal",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                Padding = new Padding(0, 0, 0, 5),
            };
            btn_delete = new Button
            {
                Size = new Size(100, 40),
                Location = new Point(310, 300),
                Text = "Delete Meal",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                Padding = new Padding(0, 0, 0, 5),
            };
            btn_mainform = new Button
            {
                Size = new Size(100, 40),
                Location = new Point(430, 300),
                Text = "Main Form",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                Padding = new Padding(0, 0, 0, 5),
            };

            //datetimepicker customization
            dateTimePicker.Location = new Point(220, 200);
            dateTimePicker.Width = 230;
            dateTimePicker.CalendarFont = new Font("Tahoma", 10F, FontStyle.Italic,
               GraphicsUnit.Point, ((Byte)(0)));
            dateTimePicker.CalendarForeColor = Color.Black;
            dateTimePicker.CalendarMonthBackground = Color.Orange;
            dateTimePicker.CalendarTitleBackColor = Color.Yellow;
            dateTimePicker.CalendarTitleForeColor = Color.Black;
            dateTimePicker.CustomFormat = "dd MMMM, yyyy - dddd";
            dateTimePicker.Format = DateTimePickerFormat.Custom;

            //datagridview customization
            customermeal_datagridview = new DataGridView
            {
                CellBorderStyle = DataGridViewCellBorderStyle.Sunken,
                GridColor = Color.Blue,
                MultiSelect = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = false,
                AllowUserToResizeRows = false,
                ColumnCount = 4,
                Dock = DockStyle.Bottom
            };
            //datagridview select button customization
            selectbutton.Name = "Select";
            selectbutton.Text = "Select";
            selectbutton.UseColumnTextForButtonValue = true;
            selectbutton.FlatStyle = FlatStyle.Standard;
            //textbox customization
            txtbox1.Location = new Point(220, 100);
            txtbox_customer.Location = new Point(220, 50);
            txtbox_customer.Enabled = false;
            txtbox_customer.Texts = "TSTET NAME TESTSM";


            //label customization
            lbl_quantity.Text = "Meal Quantity : ";
            lbl_quantity.AutoSize = true;
            lbl_quantity.Font = new Font("Tahoma", 12F, FontStyle.Italic,
               GraphicsUnit.Point, ((Byte)(0)));
            lbl_quantity.Location = new Point(90, 102);
            lbl_quantity.ForeColor = Color.Black;

            //lbl selecteddate
            lbl_selecteddate.Text = "Selected Date : ";
            lbl_selecteddate.AutoSize = true;
            lbl_selecteddate.Font = new Font("Tahoma", 12F, FontStyle.Italic,
               GraphicsUnit.Point, ((Byte)(0)));
            lbl_selecteddate.Location = new Point(90, 150);
            lbl_selecteddate.ForeColor = Color.Black;
            //lbl date
            lbl_date.AutoSize = true;
            lbl_date.Font = new Font("Tahoma", 12F, FontStyle.Italic,
               GraphicsUnit.Point, ((Byte)(0)));
            lbl_date.Location = new Point(270, 150);
            lbl_date.ForeColor = Color.AliceBlue;
            //lbl datetable
            lbl_datetime.AutoSize = true;
            lbl_datetime.Text = "Date : ";
            lbl_datetime.Font = new Font("Tahoma", 12F, FontStyle.Italic,
               GraphicsUnit.Point, ((Byte)(0)));
            lbl_datetime.Location = new Point(158, 198);
            lbl_datetime.ForeColor = Color.Black;

            //lbl customer
            lbl_customer.AutoSize = false;
            lbl_customer.Font = new Font("Tahoma", 12F, FontStyle.Bold,
               GraphicsUnit.Point, ((Byte)(0)));
            lbl_customer.ForeColor = Color.Black;
            lbl_customer.Location = new Point(123, 55);
            lbl_customer.Text = "Customer : ";

            //adding controls to the from
            this.Controls.Add(btn_add);
            this.Controls.Add(btn_update);
            this.Controls.Add(btn_delete);
            this.Controls.Add(dateTimePicker);
            this.Controls.Add(txtbox1);
            this.Controls.Add(btn_mainform);
            this.Controls.Add(lbl_quantity);
            this.Controls.Add(lbl_selecteddate);
            this.Controls.Add(lbl_date);
            this.Controls.Add(lbl_datetime);
            this.Controls.Add(lbl_customer);
            this.Controls.Add(lbl_customername);
            this.Controls.Add(txtbox_customer);
            this.Controls.Add(customermeal_datagridview);

            //event handlers
            dateTimePicker.ValueChanged += DateTimePicker_ValueChanged;
            btn_add.Click += Btn_Add_Click;
            btn_update.Click += Btn_Update_Click;
            btn_delete.Click += Btn_Delete_Click;
            btn_mainform.Click += Btn_Mainform_Click;
            txtbox1.KeyPress += Txtbox1_KeyPress;
            customermeal_datagridview.CellContentClick += Customermeal_Datagridview_CellContentClick;
        }
        void countmeals()
        {
            var updatecustomer = xelement.Descendants("customer").ToList();

            //counting meals after adding new stuff
            var count = xelement.Descendants("meal").ToList();
            foreach (XElement x in count)
            {
                if (customer_id == x.Element("customer_id").Value)
                    mealquantity += Convert.ToInt32(x.Element("meal_quantity").Value);
            }

            foreach (XElement x in updatecustomer)
            {
                if (x.Element("customer_id").Value.ToString() == customer_id)
                    x.Element("customer_loan").Value = (Convert.ToInt32(x.Element("customer_price").Attribute("price").Value) * mealquantity).ToString();
            }
            xelement.Save(@"../../stockmanagement.xml");

        }
        void getmeals()
        {
            customermeal_datagridview.Rows.Clear();
            //populating datagridview with customer meals
            var getMeal = from x in xelement.Descendants("meal")
                          where (string)x.Element("customer_id").Value == customer_id.ToString()
                          select new
                          {
                              xmlcid = x.Element("customer_id").Value,
                              xmlmid = x.Element("meal_id").Value,
                              xmlquantity = x.Element("meal_quantity").Value,
                              xmldate = x.Element("meal_date").Attribute("date").Value,
                          };
            foreach (var x in getMeal)
            {
                customermeal_datagridview.Rows.Add("", x.xmlcid, x.xmlmid, x.xmlquantity, x.xmldate);
            }

            //customization of datagridview headers
            customermeal_datagridview.Columns[0].HeaderText = "Select";
            customermeal_datagridview.Columns[1].HeaderText = "Customer ID";
            customermeal_datagridview.Columns[2].HeaderText = "Meal ID";
            customermeal_datagridview.Columns[3].HeaderText = "Quantity";
            customermeal_datagridview.Columns[4].HeaderText = "Date";
        }
        void Handle_Load(object sender, EventArgs e)
        {
            btn_update.Enabled = false;
            btn_delete.Enabled = false;

            lbl_date.Text = dateTimePicker.Value.ToString("dd MMMM yyyy");
            date = dateTimePicker.Value.ToString("dd MM yyyy").Split(' ');
            customermeal_datagridview.Columns.Insert(0, selectbutton);

            //pulling customer name according to id
            var getCustomer = from x in xelement.Descendants("customer")
                              where (string)x.Element("customer_id").Value == customer_id.ToString()
                              select new
                              {
                                  xmlid = x.Element("customer_id").Value,
                                  xmlname = x.Element("customer_name").Value,
                              };
            foreach (var x in getCustomer)
                txtbox_customer.Texts = x.xmlname;
            getmeals();
        }

        void Handle_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            gf.Show();
        }

        void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            lbl_date.Text = dateTimePicker.Value.Date.ToString("dd MMMM yyyy");
            date = dateTimePicker.Value.Date.ToString("dd MM yyyy").Split(' ');
        }

        //btn_add event handler
        void Btn_Add_Click(object sender, EventArgs e)
        {
            int i = 1;
            Boolean updated = false;
            var add = xelement.Descendants("meal").ToList();

            try
            {
                if (string.IsNullOrEmpty(txtbox1.Texts))
                    MessageBox.Show("Textbox can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    foreach (XElement x in add)
                    {
                        if (x.Element("meal_id").Value == "")
                        {
                            updated = true;
                            x.SetElementValue("customer_id", customer_id);
                            x.SetElementValue("meal_id", i);
                            x.SetElementValue("meal_quantity", txtbox1.Texts);
                            x.Element("meal_date").SetAttributeValue("date", date[0] + " " + date[1] + " " + date[2]);
                            break;
                        }
                        i++;
                    }

                    if (updated == false)
                    {

                        xelement.Add(
                               new XElement("meal",
                               new XElement("customer_id", customer_id),
                               new XElement("meal_id", i),
                               new XElement("meal_quantity", txtbox1.Texts),
                               new XElement("meal_date", new XAttribute("date", date[0] + " " + date[1] + " " + date[2]))));

                    }
                    xelement.Save(@"../../stockmanagement.xml");
                    MessageBox.Show("Element Succesfully Updated", "Update Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getmeals();
                    countmeals();
                }
            }
            catch
            {
                MessageBox.Show("Somethings Wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //btn_update event handler
        void Btn_Update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbox1.Texts))
                MessageBox.Show("Textbox can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                var update = xelement.Descendants("meal").ToList();
                foreach (XElement x in update)
                {
                    if (x.Element("meal_id").Value.ToString() == meal_id)
                    {
                        x.SetElementValue("meal_quantity", txtbox1.Texts);
                        x.Element("meal_date").SetAttributeValue("date", date[0] + " " + date[1] + " " + date[2]);
                    }
                }

                btn_add.Enabled = true;
                btn_update.Enabled = false;
                btn_delete.Enabled = false;
                txtbox1.Texts = "";
                xelement.Save(@"../../stockmanagement.xml");
                countmeals();
                getmeals();
            }
        }
        //btn_delete event handler
        void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                var delete = xelement.Descendants("meal").ToList();
                foreach (XElement x in delete)
                {
                    if (x.Element("meal_id").Value.ToString() == meal_id)
                    {
                        x.SetElementValue("meal_id", "");
                        x.SetElementValue("customer_id", "");
                        x.SetElementValue("meal_quantity", "");
                        x.Element("meal_date").SetAttributeValue("date", null);
                    }
                }
                xelement.Save(@"../../stockmanagement.xml");
                MessageBox.Show("Element Succesfully Deleted", "Delete Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_add.Enabled = true;
                btn_update.Enabled = false;
                btn_delete.Enabled = false;
                txtbox1.Texts = "";
                getmeals();
                countmeals();

            }
            catch
            {
                MessageBox.Show("Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //btn_mainform event handler
        void Btn_Mainform_Click(object sender, EventArgs e)
        {
            this.Hide();
            gf.Show();
        }
        //txtbox1 eventhandler
        void Txtbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        void Customermeal_Datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            string time = "";
            if (e.ColumnIndex == 0)
            {
                txtbox1.Texts = customermeal_datagridview.Rows[index].Cells[3].Value.ToString();
                time = customermeal_datagridview.Rows[index].Cells[4].Value.ToString();
                meal_id = customermeal_datagridview.Rows[index].Cells[2].Value.ToString();
                date = time.Split(' ');
                dateTimePicker.Value = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));
            }
            btn_add.Enabled = false;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
        }
    }
}
