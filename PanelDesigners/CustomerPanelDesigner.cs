using System;
using System.Windows.Forms;
using System.Drawing;

namespace stockmanagement
{
    public partial class GeneralForm : Form
    {
        //label fields
        private Label lbl_customer_name;
        private Label lbl_customer_name_title;
        private Label lbl_customer_address;
        private Label lbl_customer_loan;
        private Label lbl_customer_telephone;
        private Label lbl_customer_title;
        private Label lbl_customer_price;

        //datagridview field
        private DataGridView customerdatagridview;

        //button fields
        private Button customer_mealadd_btn;
        public Button customer_update_btn;
        public Button customer_delete_btn;
        private Button pnl_customer_add_btn;
        public Button customer_add_btn;

        //textbox fields
        private customtextbox txt_customer_name = new customtextbox();
        private customtextbox txt_customer_address = new customtextbox();
        private customtextbox txt_customer_loan = new customtextbox();
        private customtextbox txt_customer_telephone = new customtextbox();
        private customtextbox txt_customer_price = new customtextbox();
        private customtextbox txt_customer_meal_quantity = new customtextbox();

        //panel fields
        private Panel customer_panel;

        void RenderCustomer()
        {
            //customer panel
            customer_panel = new Panel
            {
                Location = new Point(150, 50),
                Size = new Size(850, 650)
            };
            customer_panel.BackgroundImage = Image.FromFile(@"../../images/editbg.jpg");
            customer_panel.BackgroundImageLayout = ImageLayout.Stretch;

            //Customer datagridview
            customerdatagridview = new DataGridView
            {
                Dock = DockStyle.Top,
                CellBorderStyle = DataGridViewCellBorderStyle.Sunken,
                GridColor = Color.Blue,
                AutoSize = true,
                MultiSelect = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = false,
                AllowUserToResizeRows = false,
                BorderStyle = BorderStyle.None,
                ColumnCount = 6,
                BackgroundColor = Color.Aquamarine,
            };
            DataGridViewRow rowcustomer = this.customerdatagridview.RowTemplate;
            rowcustomer.DefaultCellStyle.BackColor = Color.Tan;

            //customer panel controls customization;
            lbl_customer_loan = new Label
            {
                Text = "Loan :",
                AutoSize = true,
                ForeColor = Color.Black,
                Font = new Font("Georgia", 15, FontStyle.Regular, GraphicsUnit.Point),
                BackColor = Color.Transparent,
                Location = new Point(240, 170),
            };
            lbl_customer_price = new Label
            {
                Text = "Meal Price :",
                AutoSize = true,
                Font = new Font("Georgia", 15, FontStyle.Regular, GraphicsUnit.Point),
                BackColor = Color.Transparent,
                ForeColor = Color.Black,
                Location = new Point(240, 210),
            };
            lbl_customer_address = new Label
            {
                Text = "Address :",
                AutoSize = true,
                Font = new Font("Georgia", 15, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Location = new Point(240, 270),
            };
            lbl_customer_telephone = new Label
            {
                Text = "Number :",
                AutoSize = true,
                Font = new Font("Georgia", 15, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Location = new Point(240, 330),
            };
            lbl_meal_quantity = new Label
            {
                Text = "Meal Quantity :",
                AutoSize = true,
                Font = new Font("Georgia", 15, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Location = new Point(240, 370),
            };
            lbl_customer_name_title = new Label
            {
                AutoSize = true,
                ForeColor = Color.Indigo,
                BackColor = Color.Transparent,
                Font = new Font("Georgia", 20, FontStyle.Regular, GraphicsUnit.Point),
            };
            lbl_customer_name = new Label
            {
                Text = "Customer : ",
                AutoSize = true,
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Font = new Font("Georgia", 15, FontStyle.Regular, GraphicsUnit.Point),
                Location = new Point(240, 170),
            };
            lbl_customer_title = new Label
            {
                Text = "Customer Panel",
                AutoSize = true,
                Font = new Font("Georgia", 18f, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.Black,
            };

            customer_mealadd_btn = new Button
            {
                Text = "Add Meal",
                Font = new Font("Georgia", 16, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                Size = new Size(140, 40),
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                Location = new Point(155, 480),
            };
            customer_update_btn = new Button
            {
                Text = "Update",
                Font = new Font("Georgia", 16, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                Size = new Size(100, 40),
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                Location = new Point(335, 480),
            };
            customer_delete_btn = new Button
            {
                Text = "Delete",
                Font = new Font("Georgia", 16, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                Size = new Size(100, 40),
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                Location = new Point(465, 480),
            };
            customer_add_btn = new Button
            {
                Text = "Add Customer",
                Font = new Font("Georgia", 16, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                AutoSize = true,
                Size = new Size(140, 40),
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                Location = new Point(605, 480),
            };
            pnl_customer_add_btn = new Button
            {
                Dock = DockStyle.Top,
                Size = new Size(100, 40),
                Location = new Point(210, 440),
                Text = "Add Customer",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                Padding = new Padding(0, 0, 0, 5),
            };
            txt_customer_loan.Enabled = false;
            txt_customer_meal_quantity.Enabled = false;

            txt_customer_loan.Location = new Point(400, 170);
            txt_customer_name.Location = new Point(400, 170);
            txt_customer_price.Location = new Point(400, 210);
            txt_customer_address.Location = new Point(400, 250);
            txt_customer_telephone.Location = new Point(400, 330);
            txt_customer_meal_quantity.Location = new Point(400, 370);

            txt_customer_address.Multiline = true;
            txt_customer_address.Size = new Size(200, 70);
            txt_customer_loan.Size = new Size(200, 30);
            txt_customer_name.Size = new Size(200, 30);
            txt_customer_price.Size = new Size(200, 30);
            txt_customer_meal_quantity.Size = new Size(200, 30);
            txt_customer_telephone.Size = new Size(200, 30);
            //customer panel controls customization end;

            //adding controls to the customer panel
            customer_panel.Controls.Add(customer_mealadd_btn);
            customer_panel.Controls.Add(lbl_customer_name);
            customer_panel.Controls.Add(txt_customer_name);
            customer_panel.Controls.Add(lbl_customer_name_title);
            customer_panel.Controls.Add(txt_customer_loan);
            customer_panel.Controls.Add(txt_customer_price);
            customer_panel.Controls.Add(txt_customer_address);
            customer_panel.Controls.Add(txt_customer_telephone);
            customer_panel.Controls.Add(txt_customer_meal_quantity);
            customer_panel.Controls.Add(customer_update_btn);
            customer_panel.Controls.Add(customer_delete_btn);
            customer_panel.Controls.Add(lbl_customer_loan);
            customer_panel.Controls.Add(lbl_customer_price);
            customer_panel.Controls.Add(lbl_customer_address);
            customer_panel.Controls.Add(lbl_customer_telephone);
            customer_panel.Controls.Add(lbl_meal_quantity);
            customer_panel.Controls.Add(lbl_customer_title);
            customer_panel.Controls.Add(customer_add_btn);

            //event handlers
            customer_mealadd_btn.Click += Customer_Mealadd_Btn_Click;//customer meal add button
            customer_update_btn.Click += Customer_Update_Btn_Click;
            customer_delete_btn.Click += Customer_Delete_Btn_Click;
            customer_add_btn.Click += Customer_Add_Btn_Click;

            txt_customer_price.KeyPress += Txt_Product_KeyPress;
            txt_customer_telephone.KeyPress += Txt_Product_KeyPress;
        }
    }
}