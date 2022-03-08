using System;
using System.Windows.Forms;
using System.Drawing;

namespace stockmanagement
{
    partial class GeneralForm
    {
        //picture fields
        public custompicturebox picboxuser;
        private PictureBox picboxhome;

        //datagridview field

        private DataGridView customerdatagridview;
        private DataGridView productdatagridview;

        //panel fields
        private Panel leftpaneldesign;
        private Panel product_controls_panel;
        private Panel customer_controls_panel;
        private Panel upper_panel;
        private Panel left_panel;
        private Panel main_panel;
        private Panel customer_panel;
        private Panel product_addedit_panel;

        //toggle button field
        private customtogglebtn product_toggle_available = new customtogglebtn();

        //textbox field

        private customtextbox txt_customer_address = new customtextbox();
        private customtextbox txt_customer_loan = new customtextbox();
        private customtextbox txt_customer_telephone = new customtextbox();
        private customtextbox txt_customer_price = new customtextbox();
        private customtextbox txt_customer_meal_quantity = new customtextbox();

        private customtextbox txt_product_name = new customtextbox();
        private customcombobox cmbox_product_category = new customcombobox();
        private customcombobox cmbox_product_type = new customcombobox();
        private customtextbox txt_product_price = new customtextbox();
        private customtextbox txt_product_quantity = new customtextbox();
        private customtextbox txt_product_worth = new customtextbox();
        private customtextbox txt_customer_name = new customtextbox();

        //button fields
        private Button product_add_btn;
        private Button product_edit_btn;
        private Button product_delete_btn;

        private Button pnl_product_add_btn;
        private Button pnl_prdct_btn;
        private Button pnl_customer_btn;
        private Button show_prdct_btn;
        private Button show_customer_btn;
        private Button storage_prdct_btn;
        private Button outofstock_prdct_btn;

        private Button customer_mealadd_btn;
        private Button customer_update_btn;
        private Button customer_delete_btn;
        private Button pnl_customer_add_btn;
        private Button customer_add_btn;

        private DataGridViewButtonColumn editbutton = new DataGridViewButtonColumn();

        //label fields

        private Label lbl_product_name;
        private Label lbl_product_category;
        private Label lbl_product_price;
        private Label lbl_product_type;
        private Label lbl_product_quantity;
        private Label lbl_product_available;
        private Label lbl_product_onoff;
        private Label lbl_customer_title;
        private Label lbl_product_title;
        private Label lbl_product_worth;

        public Label lbl_welcome;
        public Label lbl_user;
        public Label lbl_role;
        private Label lbl_home;
        private Label lbl_meal_quantity;

        private Label lbl_customer_name;
        private Label lbl_customer_name_title;
        private Label lbl_customer_address;
        private Label lbl_customer_loan;
        private Label lbl_customer_telephone;
        private Label lbl_customer_price;

        //drawing components 
        private void Render()
        {
            //product panel for visualize staff buttons
            product_controls_panel = new Panel
            {
                Location = new Point(0, 185),
                Size = new Size(150, 120),
                BackColor = Color.AliceBlue,
                AutoSize = true,
                Dock = DockStyle.Top,
            };
            customer_controls_panel = new Panel
            {
                Location = new Point(0, 360),
                Size = new Size(150, 120),
                BackColor = Color.AliceBlue,
                AutoSize = true,
                Dock = DockStyle.Top,
            };
            //line panel
            leftpaneldesign = new Panel
            {
                Size = new Size(150, 150),
                Dock = DockStyle.Top,
                AutoSize = false,
                Visible = true,
                BorderStyle = BorderStyle.None,
            };
            //left panel
            left_panel = new Panel
            {
                Dock = DockStyle.Left,
                Size = new Size(150, 0),
                Location = new Point(0, 0),
                BackColor = Color.MediumSlateBlue,
            };
            //upper panel 
            upper_panel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(0, 50),
                BackColor = Color.Crimson,
                Dock = DockStyle.Top,
            };
            //main panel
            main_panel = new Panel
            {
                Location = new Point(150, 50),
                BackColor = Color.Aquamarine,
                Size = new Size(850, 650)
            };
            //customer panel
            customer_panel = new Panel
            {
                Location = new Point(150, 50),
                Size = new Size(850, 650)
            };
            //product add edit panel
            product_addedit_panel = new Panel
            {
                Location = new Point(150, 50),
                Size = new Size(850, 650)
            };
            customer_panel.BackgroundImage = Image.FromFile(@"../../images/editbg.jpg");
            customer_panel.BackgroundImageLayout = ImageLayout.Stretch;

            product_addedit_panel.BackgroundImage = Image.FromFile(@"../../images/editbg.jpg");
            product_addedit_panel.BackgroundImageLayout = ImageLayout.Stretch;
            //datagridviews
            customerdatagridview = new DataGridView
            {
                Dock = DockStyle.Top,
                CellBorderStyle = DataGridViewCellBorderStyle.Sunken,
                GridColor = Color.Blue,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AutoSize = true,
                MultiSelect = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = false,
                AllowUserToResizeRows = false,
                BorderStyle = BorderStyle.None,
                ColumnCount = 7,
            };
            DataGridViewRow rowcustomer = this.customerdatagridview.RowTemplate;
            rowcustomer.DefaultCellStyle.BackColor = Color.Tan;

            productdatagridview = new DataGridView
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
                ColumnCount = 8,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            };
            DataGridViewRow row = this.productdatagridview.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.Tan;
            //datagridview edit button

            editbutton.Text = "Edit";
            editbutton.Name = "Edit";
            editbutton.DataPropertyName = "Edit";
            editbutton.UseColumnTextForButtonValue = true;
            editbutton.FlatStyle = FlatStyle.Standard;

            //datagridview edit button end

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

            //product add edit controls customization

            txt_product_name.Location = new Point(400, 170);
            txt_product_quantity.Location = new Point(400, 290);
            txt_product_price.Location = new Point(400, 330);
            txt_product_worth.Location = new Point(400, 370);

            txt_product_quantity.Size = new Size(200, 30);
            txt_product_price.Size = new Size(200, 30);
            txt_product_name.Size = new Size(200, 30);
            txt_product_worth.Size = new Size(200, 30);
            txt_product_worth.Enabled = false;

            //somethings changed
            cmbox_product_type.Location = new Point(400, 250);
            cmbox_product_category.Location = new Point(400, 210);

            cmbox_product_type.Size = new Size(200, 30);
            cmbox_product_category.Size = new Size(200, 30);

            cmbox_product_type.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbox_product_category.DropDownStyle = ComboBoxStyle.DropDownList;

            product_toggle_available.Location = new Point(400, 413);
            product_toggle_available.Size = new Size(60, 25);
            product_toggle_available.BackColor = Color.Transparent;
            product_toggle_available.Enabled = false;

            lbl_product_name = new Label
            {
                Text = "Product Name :",
                AutoSize = true,
                Location = new Point(240, 173),
                BackColor = Color.Transparent,
                Font = new Font("Georgia", 12f, FontStyle.Regular),
                ForeColor = Color.Indigo,
            };
            lbl_product_type = new Label
            {
                Text = "Product Type :",
                AutoSize = true,
                Location = new Point(240, 253),
                BackColor = Color.Transparent,
                Font = new Font("Georgia", 12f, FontStyle.Regular),
                ForeColor = Color.Indigo,
            };
            lbl_product_price = new Label
            {
                Text = "Product Price :",
                AutoSize = true,
                Location = new Point(240, 333),
                BackColor = Color.Transparent,
                Font = new Font("Georgia", 12f, FontStyle.Regular),
                ForeColor = Color.Indigo,
            };
            lbl_product_quantity = new Label
            {
                Text = "Product Quantity :",
                AutoSize = true,
                Location = new Point(240, 293),
                BackColor = Color.Transparent,
                Font = new Font("Georgia", 12f, FontStyle.Regular),
                ForeColor = Color.Indigo,
            };
            lbl_product_category = new Label
            {
                Text = "Product Category :",
                AutoSize = true,
                Location = new Point(240, 213),
                BackColor = Color.Transparent,
                Font = new Font("Georgia", 12f, FontStyle.Regular),
                ForeColor = Color.Indigo,
            };
            lbl_product_worth = new Label
            {
                Text = "Current Worth : ",
                AutoSize = true,
                Font = new Font("Georgia", 12f, FontStyle.Regular),
                BackColor = Color.Transparent,
                Location = new Point(240, 373),
                ForeColor = Color.Indigo,
            };
            lbl_product_available = new Label
            {
                Text = "Product Available :",
                AutoSize = true,
                Location = new Point(240, 413),
                BackColor = Color.Transparent,
                Font = new Font("Georgia", 12f, FontStyle.Regular),
                ForeColor = Color.Indigo,
            };
            lbl_product_onoff = new Label
            {
                Text = "test",
                AutoSize = true,
                Location = new Point(465, 414),
                BackColor = Color.Transparent,
                Font = new Font("Georgia", 11f, FontStyle.Regular),
                ForeColor = Color.Black,
            };
            lbl_product_title = new Label
            {
                Text = "Add Product",
                AutoSize = true,
                Font = new Font("Georgia", 18f, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.Indigo,
            };
            lbl_product_title.Location = new Point((product_addedit_panel.Width - lbl_product_title.Width) / 2, 60);

            product_add_btn = new Button
            {
                Dock = DockStyle.None,
                Size = new Size(100, 40),
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                Location = new Point(245, 480),
                Text = "Add",
                Font = new Font("Georgia", 16, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,

            };

            product_edit_btn = new Button
            {
                Dock = DockStyle.None,
                Size = new Size(100, 40),
                Location = new Point(375, 480),
                Text = "Update",
                Font = new Font("Georgia", 16, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
            };
            product_delete_btn = new Button
            {
                Dock = DockStyle.None,
                Size = new Size(100, 40),
                Location = new Point(505, 480),
                Text = "Delete",
                Font = new Font("Georgia", 16, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
            };
            //product add edit controls customization end

            //picture box for picturing user image
            picboxuser = new custompicturebox
            {
                Size = new Size(120, 120),
                Location = new Point(15, 15),
                Anchor = AnchorStyles.Top,
            };
            //picture box for home button
            picboxhome = new PictureBox
            {
                Image = Image.FromFile(@"../../images/home.png"),
                BackColor = Color.Transparent,
                Size = new Size(50, 50),
                Location = new Point(10, 0),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };

            //button for visualizing product panel buttons
            pnl_prdct_btn = new Button
            {
                Size = new Size(150, 40),
                Location = new Point(0, 140),
                Text = "Product Controls",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.BlueViolet,
                ForeColor = Color.White,
                Dock = DockStyle.Top,
            };
            //show customer control panel button
            pnl_customer_btn = new Button
            {
                Size = new Size(150, 40),
                Location = new Point(0, 320),
                Text = "Customer Controls",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.BlueViolet,
                ForeColor = Color.White,
                Dock = DockStyle.Top
            };
            //button customization

            //show products
            show_prdct_btn = new Button
            {
                Dock = DockStyle.Top,
                Size = new Size(100, 40),
                Location = new Point(210, 440),
                Text = "Show Products",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                Padding = new Padding(0, 0, 0, 5),
            };

            //displays used products button

            show_customer_btn = new Button
            {
                Dock = DockStyle.Top,
                Size = new Size(100, 40),
                Location = new Point(210, 440),
                Text = "Customers",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
            };
            //showing out of stock products
            outofstock_prdct_btn = new Button
            {
                Dock = DockStyle.Top,
                Size = new Size(100, 40),
                Text = "Show Out of Stock",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
            };

            //panel product add control
            pnl_product_add_btn = new Button
            {
                Dock = DockStyle.Top,
                Size = new Size(100, 40),
                Text = "Product Add",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
            };

            //show what's in the storage button
            storage_prdct_btn = new Button
            {
                Dock = DockStyle.Top,
                Size = new Size(100, 40),
                Text = "Show Storage",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
            };
            //label control for header 
            lbl_home = new Label
            {
                Location = new Point(60, 25),
                Font = new Font("Georgia", 10),
                Text = "Home",
                Size = new Size(100, 20),

            };
            //label controls on user panel
            lbl_welcome = new Label
            {
                Text = "Welcome",
                ForeColor = Color.Black,
                Location = new Point(10, 10),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Georgia", 10)
            };

            lbl_role = new Label
            {
                Text = "Admin",
                ForeColor = Color.Black,
                Location = new Point(100, 50),
                Font = new Font("Georgia", 10),
                TextAlign = ContentAlignment.MiddleCenter
            };
            lbl_user = new Label
            {
                ForeColor = Color.Black,
                Location = new Point(100, 10),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Georgia", 10)
            };
            //end of label controls on user panel

            //general form customization
            this.Text = "Main Form";
            this.Size = new Size(1000, 700);
            this.MaximumSize = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            this.FormClosed += Handle_FormClosed;
            this.Load += Handle_Load;

            //adding controls to the form
            this.Controls.Add(left_panel);
            this.Controls.Add(upper_panel);
            this.Controls.Add(main_panel);
            this.Controls.Add(customer_panel);
            this.Controls.Add(product_addedit_panel);

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

            //adding control to the product add edit panel
            product_addedit_panel.Controls.Add(cmbox_product_category);
            product_addedit_panel.Controls.Add(cmbox_product_type);

            product_addedit_panel.Controls.Add(txt_product_worth);
            product_addedit_panel.Controls.Add(txt_product_name);
            product_addedit_panel.Controls.Add(txt_product_quantity);
            product_addedit_panel.Controls.Add(txt_product_price);

            product_addedit_panel.Controls.Add(product_add_btn);
            product_addedit_panel.Controls.Add(product_edit_btn);
            product_addedit_panel.Controls.Add(product_delete_btn);

            product_addedit_panel.Controls.Add(lbl_product_name);
            product_addedit_panel.Controls.Add(lbl_product_category);
            product_addedit_panel.Controls.Add(lbl_product_type);
            product_addedit_panel.Controls.Add(lbl_product_price);
            product_addedit_panel.Controls.Add(lbl_product_quantity);
            product_addedit_panel.Controls.Add(lbl_product_title);
            product_addedit_panel.Controls.Add(lbl_product_worth);
            product_addedit_panel.Controls.Add(product_toggle_available);
            product_addedit_panel.Controls.Add(lbl_product_onoff);
            product_addedit_panel.Controls.Add(lbl_product_available);

            //left panel controls
            left_panel.Controls.Add(customer_controls_panel);
            left_panel.Controls.Add(pnl_customer_btn);
            left_panel.Controls.Add(product_controls_panel);
            left_panel.Controls.Add(pnl_prdct_btn);
            left_panel.Controls.Add(leftpaneldesign);
            leftpaneldesign.Controls.Add(picboxuser);

            //product panel button controls
            product_controls_panel.Controls.Add(pnl_product_add_btn);
            product_controls_panel.Controls.Add(show_prdct_btn);
            product_controls_panel.Controls.Add(outofstock_prdct_btn);
            product_controls_panel.Controls.Add(storage_prdct_btn);

            //customer panel button controls
            customer_controls_panel.Controls.Add(pnl_customer_add_btn);
            customer_controls_panel.Controls.Add(show_customer_btn);

            //upper panel controls
            upper_panel.Controls.Add(picboxhome);
            upper_panel.Controls.Add(lbl_home);

            //main panel controls
            main_panel.Controls.Add(productdatagridview);
            main_panel.Controls.Add(customerdatagridview);

            //button Cick Events
            outofstock_prdct_btn.Click += Outofstock_Prdct_Btn_Click;//out of stock visible
            storage_prdct_btn.Click += Storage_Prdct_Btn_Click;//storage panel visible
            pnl_prdct_btn.Click += pnl_prdct_btn_CLick;//product panel visible
            pnl_customer_btn.Click += Pnl_Customer_Btn_Click;
            pnl_product_add_btn.Click += Pnl_Product_Add_Btn_Click;
            pnl_customer_add_btn.Click += Pnl_Customer_Add_Btn_Click;

            show_prdct_btn.Click += Show_Prdct_Btn_Click;
            show_customer_btn.Click += Show_Customer_Btn_Click;//customer panel visible
            customer_mealadd_btn.Click += Customer_Mealadd_Btn_Click;//customer meal add button
            customer_update_btn.Click += Customer_Update_Btn_Click;
            customer_delete_btn.Click += Customer_Delete_Btn_Click;
            customer_add_btn.Click += Customer_Add_Btn_Click;

            txt_customer_price.KeyPress += Txt_Product_KeyPress;
            txt_customer_telephone.KeyPress += Txt_Product_KeyPress;
            txt_product_price.KeyPress += Txt_Product_KeyPress;
            txt_product_quantity.KeyPress += Txt_Product_KeyPress;
            product_add_btn.Click += Product_Add_Btn_Click;
            product_delete_btn.Click += Product_Delete_Btn_Click;
            product_edit_btn.Click += Product_Edit_Btn_Click;

            //datagridview events
            productdatagridview.CellContentClick += ProductDatagridview_CellContentClick;
            customerdatagridview.CellContentClick += Customerdatagridview_CellContentClick;
        }
        //end of render
    }
}
