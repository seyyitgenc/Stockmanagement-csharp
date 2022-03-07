using System;
using System.Windows.Forms;
using System.Drawing;

using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace stockmanagement
{
    public class GeneralForm : Form
    {
        private XElement xelement = XElement.Load(@"..\..\stockmanagement.xml");
        private string customerid = "";
        private int productid;
        private int mealquantity = 0;
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

        //form
        public GeneralForm()
        {
            Text = "Main Form";
            this.Size = new Size(1000, 700);
            this.MaximumSize = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            this.FormClosed += Handle_FormClosed;
            this.Load += Handle_Load;
            Render();
            CenterToScreen();
        }

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

        //form load event handler
        void Handle_Load(object sender, EventArgs e)
        {
            customerdatagridview.Columns.Insert(0, editbutton);
            productdatagridview.Columns.Insert(0, editbutton);
            getCustomers();
            customer_controls_panel.Visible = false;
            product_controls_panel.Visible = false;
            customer_panel.Visible = false;
            customerdatagridview.Visible = false;
            productdatagridview.Visible = false;
            product_addedit_panel.Visible = false;
            main_panel.Visible = true;

            //for product category combobox items
            var getcategory = from cat in xelement.Descendants("category")
                              where (string)cat.Element("category_id") != ""
                              select new
                              {
                                  xmlcatid = cat.Element("category_id").Value,
                                  xmlcatname = cat.Element("category_name").Value
                              };
            foreach (var x in getcategory)
                cmbox_product_category.Items.Add(x.xmlcatname);

            //for product type combobox items
            var gettype = from type in xelement.Descendants("type")
                          where (string)type.Element("type_id") != ""
                          select new
                          {
                              xmltypeid = type.Element("type_id").Value,
                              xmltypename = type.Element("type_name").Value
                          };
            foreach (var x in gettype)
                cmbox_product_type.Items.Add(x.xmltypename);
        }

        //form closed event handler
        void Handle_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Hide();
        }
        //button eventhandlers

        private void pnl_prdct_btn_CLick(object sender, EventArgs e)
        {
            leftshowpanel(product_controls_panel);
        }


        void Pnl_Customer_Btn_Click(object sender, EventArgs e)
        {
            leftshowpanel(customer_controls_panel);
        }

        public void get_product()
        {
            productdatagridview.Rows.Clear();
            try
            {
                var product = from x in xelement.Descendants("product")
                              where (string)x.Element("product_available").Attribute("type") != null
                              select new
                              {
                                  xmlid = x.Element("product_id").Value,
                                  xmlname = x.Element("product_name").Value,
                                  xmlcategory = x.Element("product_category").Value,
                                  xmltype = x.Element("product_type").Value,
                                  xmlprice = x.Element("product_price").Value,
                                  xmlquantity = x.Element("product_quantity").Value,
                                  xmlavailable = x.Element("product_available").Attribute("type").Value
                              };
                foreach (var x in product)
                    productdatagridview.Rows.Add("", x.xmlid, x.xmlname, x.xmltype, x.xmlcategory, x.xmlprice, x.xmlquantity, x.xmlavailable);
                productdatagridview.Columns[0].HeaderText = "Edit";
                productdatagridview.Columns[1].HeaderText = "Id";
                productdatagridview.Columns[2].HeaderText = "Name";
                productdatagridview.Columns[3].HeaderText = "Type";
                productdatagridview.Columns[4].HeaderText = "Category";
                productdatagridview.Columns[5].HeaderText = "Price";
                productdatagridview.Columns[6].HeaderText = "Quantity";
                productdatagridview.Columns[7].HeaderText = "Available";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        void Show_Prdct_Btn_Click(object sender, EventArgs e)
        {
            main_panel.Visible = true;
            showgrid(productdatagridview);
            get_product();
        }
        void checkavailable(int data)
        {
            productdatagridview.Rows.Clear();
            productdatagridview.Columns.Clear();
            try
            {
                productdatagridview.Columns.Insert(0, editbutton);
                productdatagridview.ColumnCount = 8;
                var getProduct = from x in xelement.Descendants("product")
                                 where (string)x.Element("product_available").Attribute("type") == data.ToString()
                                 select new
                                 {
                                     xmlid = x.Element("product_id").Value,
                                     xmlname = x.Element("product_name").Value,
                                     xmlcategory = x.Element("product_category").Value,
                                     xmltype = x.Element("product_type").Value,
                                     xmlprice = x.Element("product_price").Value,
                                     xmlquantity = x.Element("product_quantity").Value,
                                     xmlavailable = x.Element("product_available").Attribute("type").Value
                                 };
                foreach (var x in getProduct)
                    productdatagridview.Rows.Add("", x.xmlid, x.xmlname, x.xmltype, x.xmlcategory, x.xmlprice, x.xmlquantity, x.xmlavailable);
                showgrid(productdatagridview);
                main_panel.Visible = true;
                productdatagridview.Columns[0].HeaderText = "Edit";
                productdatagridview.Columns[1].HeaderText = "Id";
                productdatagridview.Columns[2].HeaderText = "Name";
                productdatagridview.Columns[3].HeaderText = "Type";
                productdatagridview.Columns[4].HeaderText = "Category";
                productdatagridview.Columns[5].HeaderText = "Price";
                productdatagridview.Columns[6].HeaderText = "Quantity";
                productdatagridview.Columns[7].HeaderText = "Available";
            }
            catch
            {
                MessageBox.Show("Somethings Wrong!", "Error");
            }
        }

        //show datagridview of storage
        void Storage_Prdct_Btn_Click(object sender, EventArgs e)
        {
            checkavailable(1);
        }

        //show datagirdview of outofstock
        void Outofstock_Prdct_Btn_Click(object sender, EventArgs e)
        {
            checkavailable(0);
        }

        //populating customerdatdagridview 
        public void getCustomers()
        {
            customerdatagridview.Rows.Clear();
            customerdatagridview.Columns[0].HeaderText = "Select";
            customerdatagridview.Columns[1].HeaderText = "Id";
            customerdatagridview.Columns[2].HeaderText = "Name";
            customerdatagridview.Columns[3].HeaderText = "Number";
            customerdatagridview.Columns[4].HeaderText = "Address";
            customerdatagridview.Columns[5].HeaderText = "Price";
            customerdatagridview.Columns[6].HeaderText = "Loan";

            var getCustomer = from x in xelement.Descendants("customer")
                              select new
                              {
                                  xmlid = x.Element("customer_id").Value,
                                  xmlname = x.Element("customer_name").Value,
                                  xmlnumber = x.Element("customer_phonenumber").Value,
                                  xmladdress = x.Element("customer_address").Value,
                                  xmlloan = x.Element("customer_loan").Value,
                                  xmlprice = x.Element("customer_price").Attribute("price").Value,
                              };
            foreach (var x in getCustomer)
            {
                if (x.xmlid != "")
                    customerdatagridview.Rows.Add("", x.xmlid, x.xmlname, x.xmlnumber, x.xmladdress, x.xmlprice, x.xmlloan);
            }
        }
        //show customers gridview
        void Show_Customer_Btn_Click(object sender, EventArgs e)
        {
            main_panel.Visible = true;
            showgrid(customerdatagridview);
        }

        //customer datagridview 
        void Customerdatagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.ColumnIndex == 0)
            {
                txt_customer_loan.Texts = customerdatagridview.Rows[index].Cells[6].Value.ToString();
                txt_customer_price.Texts = customerdatagridview.Rows[index].Cells[5].Value.ToString();
                txt_customer_address.Texts = customerdatagridview.Rows[index].Cells[4].Value.ToString();
                txt_customer_telephone.Texts = customerdatagridview.Rows[index].Cells[3].Value.ToString();
                lbl_customer_name_title.Text = customerdatagridview.Rows[index].Cells[2].Value.ToString();
                customerid = customerdatagridview.Rows[index].Cells[1].Value.ToString();
                mealquantity = 0;
                lbl_customer_title.Location = new Point((customer_panel.Width - lbl_customer_title.Width) / 2, 60);
                lbl_customer_name_title.Location = new Point((customer_panel.Width - lbl_customer_name_title.Width) / 2, 110);
                var count = xelement.Descendants("meal").ToList();
                foreach (XElement x in count)
                {
                    if (customerid == x.Element("customer_id").Value)
                        mealquantity += Convert.ToInt32(x.Element("meal_quantity").Value);
                }
                txt_customer_meal_quantity.Texts = mealquantity.ToString();
                main_panel.Visible = false;
                customer_panel.Visible = true;
                product_addedit_panel.Visible = false;
                customer_add_btn.Enabled = false;
                customer_update_btn.Enabled = true;
                customer_delete_btn.Enabled = true;
                customer_mealadd_btn.Enabled = true;
                lbl_customer_name_title.Visible = true;
                lbl_customer_loan.Visible = true;
                txt_customer_loan.Visible = true;
                txt_product_name.Visible = false;
                lbl_customer_name.Visible = false;
            }
        }
        //customer mealadd button event handler
        void Customer_Mealadd_Btn_Click(object sender, EventArgs e)
        {
            MealAddForm maf = new MealAddForm();
            maf.customer_id = customerid;
            this.Hide();
            maf.Show();
        }

        void Customer_Update_Btn_Click(object sender, EventArgs e)
        {
            Boolean updated = false;
            try
            {
                var customerUpdate = xelement.Descendants("customer").ToList();
                foreach (XElement x in customerUpdate)
                {
                    if (x.Element("customer_id").Value == customerid)
                    {
                        x.SetElementValue("customer_address", txt_customer_address.Texts);
                        x.SetElementValue("customer_phonenumber", txt_customer_telephone.Texts);
                        x.Element("customer_price").SetAttributeValue("price", txt_customer_price.Texts);
                        updated = true;
                    }
                    if (updated == true)
                        break;
                }
                xelement.Save(@"../../stockmanagement.xml");
                MessageBox.Show("Update Succesfully Completed !", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getCustomers();
            }
            catch
            {
                MessageBox.Show("Somethnig Went Wrong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Customer_Delete_Btn_Click(object sender, EventArgs e)
        {
            Boolean updated = false;
            var customerDelete = xelement.Descendants("customer").ToList();
            var mealDelete = xelement.Descendants("meal").ToList();

            //customer delete
            foreach (XElement x in customerDelete)
            {
                if (x.Element("customer_id").Value == customerid)
                {
                    if (Convert.ToInt32(x.Element("customer_loan").Value) > 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("This customer has " + Convert.ToInt32(x.Element("customer_loan").Value) + " TL loan.\nAre you sure want to delete this customer?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            x.SetElementValue("customer_id", "");
                            x.SetElementValue("customer_name", "");
                            x.SetElementValue("customer_address", "");
                            x.SetElementValue("customer_phonenumber", "");
                            x.SetElementValue("customer_loan", "");
                            x.Element("customer_price").SetAttributeValue("price", "");
                            txt_customer_loan.Texts = "";
                            txt_customer_price.Texts = "";
                            txt_customer_address.Texts = "";
                            txt_customer_telephone.Texts = "";
                            txt_customer_meal_quantity.Texts = "";
                            getCustomers();
                            updated = true;
                        }
                        else
                            break;
                    }
                }
                if (updated == true)
                {
                    foreach (XElement y in mealDelete)
                    {
                        if (y.Element("customer_id").Value == customerid)
                        {
                            y.SetElementValue("customer_id", "");
                            y.SetElementValue("meal_id", "");
                            y.SetElementValue("meal_quantity", "");
                            y.Element("meal_date").SetAttributeValue("date", "");
                        }
                    }
                    MessageBox.Show("Update Succesfully Completed", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
            }
            xelement.Save(@"../../stockmanagement.xml");
        }

        void Customer_Add_Btn_Click(object sender, EventArgs e)
        {

        }

        void Pnl_Customer_Add_Btn_Click(object sender, EventArgs e)
        {
            txt_customer_loan.Texts = "";
            txt_customer_price.Texts = "";
            txt_customer_address.Texts = "";
            txt_customer_telephone.Texts = "";
            txt_customer_meal_quantity.Texts = "";
            customer_delete_btn.Enabled = false;
            customer_add_btn.Enabled = true;
            customer_update_btn.Enabled = false;
            customer_mealadd_btn.Enabled = false;
            main_panel.Visible = false;
            product_addedit_panel.Visible = false;
            customer_panel.Visible = true;
            lbl_customer_name_title.Visible = false;
            lbl_customer_loan.Visible = false;
            txt_customer_loan.Visible = false;
            txt_product_name.Visible = true;
            lbl_customer_name.Visible = true;
            lbl_customer_title.Location = new Point((customer_panel.Width - lbl_customer_title.Width) / 2, 60);
        }

        //only accept numbers textbox for 
        void Txt_Product_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        //datagridview cell clicked event
        void ProductDatagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.ColumnIndex == 0)
            {
                //name textbox value
                txt_product_name.Texts = productdatagridview.Rows[index].Cells[2].Value.ToString();
                //type combobox value selection
                cmbox_product_type.SelectedItem = productdatagridview.Rows[index].Cells[3].Value.ToString();
                //category combobox value selection
                cmbox_product_category.SelectedItem = productdatagridview.Rows[index].Cells[4].Value.ToString();

                //setting up available btn
                if (Convert.ToInt32(productdatagridview.Rows[index].Cells[7].Value) == 1)
                {
                    product_toggle_available.Checked = true;
                    lbl_product_onoff.Text = "Available";
                }
                else
                {
                    product_toggle_available.Checked = false;
                    lbl_product_onoff.Text = "Not Available";
                }
                int price = Convert.ToInt32(productdatagridview.Rows[index].Cells[5].Value);
                int quantity = Convert.ToInt32(productdatagridview.Rows[index].Cells[6].Value);
                txt_product_price.Texts = price.ToString();
                txt_product_quantity.Texts = quantity.ToString();
                txt_product_worth.Texts = (price * quantity).ToString();
                productid = Convert.ToInt32(productdatagridview.Rows[index].Cells[1].Value);
                main_panel.Visible = false;
                customer_panel.Visible = false;
                product_addedit_panel.Visible = true;
                product_delete_btn.Enabled = true;
                product_add_btn.Enabled = false;
                product_edit_btn.Enabled = true;
            }
        }

        //product add button
        void Product_Add_Btn_Click(object sender, EventArgs e)
        {
            int i = 1;
            Boolean updated = false;
            string product_quantity = txt_product_quantity.Texts;

            try
            {
                var update = xelement.Descendants("product").ToList();
                foreach (XElement x in update)
                {
                    if (x.Element("product_id").Value == "")
                    {
                        updated = true;
                        x.SetElementValue("product_id", i);
                        x.SetElementValue("product_name", txt_product_name.Texts);
                        x.SetElementValue("product_category", cmbox_product_category.SelectedItem.ToString());
                        x.SetElementValue("product_type", cmbox_product_type.SelectedItem.ToString());
                        x.SetElementValue("product_price", txt_product_price.Texts);
                        x.SetElementValue("product_quantity", txt_product_quantity.Texts);

                        if (Convert.ToInt32(txt_product_quantity.Texts) > 0)
                            x.Element("product_available").SetAttributeValue("type", 1);
                        else
                            x.Element("product_available").SetAttributeValue("type", 0);
                        break;
                    }
                    i++;
                }
                if (updated == false)
                {
                    if (Convert.ToInt32(txt_product_quantity.Texts) > 0)
                        product_quantity = "1";
                    else
                        product_quantity = "0";
                    xelement.Add(
                      new XElement("product", new XElement("product_id", i),
                      new XElement("product_name", txt_product_name.Texts),
                      new XElement("product_category", cmbox_product_category.SelectedItem.ToString()),
                      new XElement("product_type", cmbox_product_type.SelectedItem.ToString()),
                      new XElement("product_price", txt_product_price.Texts),
                      new XElement("product_quantity", txt_product_quantity.Texts),
                      new XElement("product_available", new XAttribute("type", product_quantity))));
                }
                product_add_event_finished();
                get_product();
                MessageBox.Show("Product Succesfully Added", "Adding Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xelement.Save(@"../../stockmanagement.xml");
            }
            catch
            {
                MessageBox.Show("Fill The Blankets!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //product delete button
        void Product_Delete_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                var delete = xelement.Descendants("product").ToList();
                foreach (XElement x in delete)
                {
                    if (x.Element("product_id").Value == productid.ToString())
                    {
                        x.SetElementValue("product_id", "");
                        x.SetElementValue("product_name", "");
                        x.SetElementValue("product_category", "");
                        x.SetElementValue("product_type", "");
                        x.SetElementValue("product_price", "");
                        x.SetElementValue("product_quantity", "");
                        x.Element("product_available").SetAttributeValue("type", null);
                    }
                }
                xelement.Save(@"../../stockmanagement.xml");
                MessageBox.Show("Element Succesfully Deleted", "Delete Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                main_panel.Visible = true;
                product_addedit_panel.Visible = false;
                get_product();
            }
            catch
            {
                MessageBox.Show("Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //product update button
        void Product_Edit_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                var update = xelement.Descendants("product").ToList();
                foreach (XElement x in update)
                {
                    if (x.Element("product_id").Value == productid.ToString())
                    {
                        x.SetElementValue("product_name", txt_product_name.Texts);
                        x.SetElementValue("product_category", cmbox_product_category.SelectedItem.ToString());
                        x.SetElementValue("product_type", cmbox_product_type.SelectedItem.ToString());
                        x.SetElementValue("product_price", txt_product_price.Texts);
                        x.SetElementValue("product_quantity", txt_product_quantity.Texts);

                        if (Convert.ToInt32(txt_product_quantity.Texts) > 0)
                            x.Element("product_available").SetAttributeValue("type", 1);

                        else
                            x.Element("product_available").SetAttributeValue("type", 0);
                    }
                }
                xelement.Save(@"../../stockmanagement.xml");
                MessageBox.Show("Update Succesfully Completed", "Update Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                main_panel.Visible = true;
                product_addedit_panel.Visible = false;
                get_product();
            }
            catch
            {
                MessageBox.Show("Fill The Blankets!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Pnl_Product_Add_Btn_Click(object sender, EventArgs e)
        {
            product_addedit_panel.Visible = true;
            main_panel.Visible = false;
            customer_panel.Visible = false;
            product_delete_btn.Enabled = false;
            product_add_btn.Enabled = true;
            product_edit_btn.Enabled = false;
            txt_product_name.Texts = "";
            txt_product_price.Texts = "";
            txt_product_worth.Texts = "";
            txt_product_quantity.Texts = "";
            product_toggle_available.Checked = false;
            lbl_product_onoff.Text = "Not Available";
        }
        void product_add_event_finished()
        {
            txt_product_name.Texts = "";
            txt_product_price.Texts = "";
            txt_product_worth.Texts = "";
            txt_product_quantity.Texts = "";
        }

        //panel visible function
        public void hidepanel()
        {
            customer_panel.Visible = false;
            product_addedit_panel.Visible = false;
            main_panel.Visible = false;
        }
        public void showpanel(Panel panel)
        {
            if (panel.Visible == false)
            {
                hidepanel();
                panel.Visible = true;
            }
            else
                panel.Visible = false;
        }
        /*
            public void lefthidepanel()
        {
            product_controls_panel.Visible = false;
            customer_controls_panel.Visible = false;
        }
        */

        public void leftshowpanel(Panel panel)
        {
            if (panel.Visible == false)
            {
                //lefthidepanel();
                panel.Visible = true;
            }
            else
                panel.Visible = false;
        }
        public void hidegrid()
        {
            productdatagridview.Visible = false;
            customer_panel.Visible = false;
            customerdatagridview.Visible = false;
        }
        public void showgrid(DataGridView dgv)
        {
            if (dgv.Visible == false)
            {
                hidegrid();
                dgv.Visible = true;
            }
            else
                dgv.Visible = true;
        }
    }
}