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

        //panel fields
        private Panel pnl_titlebar;
        private Panel pnl_content;
        private Panel leftpaneldesign;
        private Panel product_controls_panel;
        private Panel customer_controls_panel;
        private Panel upper_panel;
        private Panel left_panel;
        private Panel main_panel;

        //button fields
        private Button pnl_product_add_btn;
        private Button pnl_prdct_btn;
        private Button pnl_customer_btn;
        private Button show_prdct_btn;
        private Button show_customer_btn;
        private Button storage_prdct_btn;
        private Button outofstock_prdct_btn;
        private Button btn_Close;
        private Button btn_Minimize;

        private DataGridViewButtonColumn selectbutton = new DataGridViewButtonColumn();

        //linklabel fields
        private LinkLabel lbl_expenses;
        private LinkLabel lbl_payments;
        private LinkLabel lbl_statistics;
        private LinkLabel lbl_income;
        private LinkLabel lbl_bills;

        //label fields
        private Label lbl_welcome;
        private Label lbl_user;
        private Label lbl_role;
        private Label lbl_home;
        private Label lbl_meal_quantity;

        //drawing components 
        private void Render()
        {
            RenderCustomer();//rendering customer controls
            RenderProductEditPanel();//rendering product edit controls

            //panel customization
            pnl_titlebar = new Panel
            {
                Dock = DockStyle.Top,
                BackColor = Color.CornflowerBlue,
                MaximumSize = new Size(1000, 30),
            };
            pnl_content = new Panel
            {
                Dock = DockStyle.Fill,
            };
            main_panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.CornflowerBlue,
            };
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
                Size = new Size(0, 50),
                BackColor = Color.Crimson,
                Dock = DockStyle.Top,
            };

            //datagridview edit button
            selectbutton.Text = "Edit";
            selectbutton.UseColumnTextForButtonValue = true;
            selectbutton.FlatStyle = FlatStyle.Flat;

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

            //button for exit
            btn_Close = new Button
            {
                Text = "X",
                Size = new Size(35, 30),
                MaximumSize = new Size(35, 30),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point),
                Dock = DockStyle.Right,
            };
            btn_Close.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 79, 95);
            btn_Close.FlatAppearance.BorderSize = 0;

            btn_Minimize = new Button
            {
                Text = "_",
                Size = new Size(35, 30),
                MaximumSize = new Size(35, 30),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point),
                Dock = DockStyle.Right,
                TextAlign = ContentAlignment.MiddleCenter,
            };
            btn_Minimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 79, 95);
            btn_Minimize.FlatAppearance.BorderSize = 0;

            //button for visualizing product panel buttons
            pnl_prdct_btn = new Button
            {
                Size = new Size(150, 40),
                Location = new Point(0, 140),
                Text = "Product Controls",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.BlueViolet,
                ForeColor = Color.White,
                Dock = DockStyle.Top,
            };
            pnl_prdct_btn.FlatAppearance.BorderSize = 0;
            //show customer control panel button
            pnl_customer_btn = new Button
            {
                Size = new Size(150, 40),
                Location = new Point(0, 320),
                Text = "Customer Controls",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.BlueViolet,
                ForeColor = Color.White,
                Dock = DockStyle.Top
            };
            pnl_customer_btn.FlatAppearance.BorderSize = 0;
            //button customization

            //show products
            show_prdct_btn = new Button
            {
                Dock = DockStyle.Top,
                Size = new Size(100, 40),
                Location = new Point(210, 440),
                Text = "Show Products",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                Padding = new Padding(0, 0, 0, 5),
            };
            show_prdct_btn.FlatAppearance.BorderSize = 0;

            //displays used products button
            show_customer_btn = new Button
            {
                Dock = DockStyle.Top,
                Size = new Size(100, 40),
                Location = new Point(210, 440),
                Text = "Customers",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
            };
            show_customer_btn.FlatAppearance.BorderSize = 0;

            //showing out of stock products
            outofstock_prdct_btn = new Button
            {
                Dock = DockStyle.Top,
                Size = new Size(100, 40),
                Text = "Show Out of Stock",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
            };
            outofstock_prdct_btn.FlatAppearance.BorderSize = 0;

            //panel product add control
            pnl_product_add_btn = new Button
            {
                Dock = DockStyle.Top,
                Size = new Size(100, 40),
                Text = "Product Add",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
            };
            pnl_product_add_btn.FlatAppearance.BorderSize = 0;

            //show what's in the storage button
            storage_prdct_btn = new Button
            {
                Dock = DockStyle.Top,
                Size = new Size(100, 40),
                Text = "Show Storage",
                Font = new Font("Georgia", 10, FontStyle.Regular, GraphicsUnit.Point),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
            };
            storage_prdct_btn.FlatAppearance.BorderSize = 0;

            //label control for header 
            lbl_home = new Label
            {
                Location = new Point(60, 25),
                Font = new Font("Georgia", 10),
                Text = "Home",
                AutoSize = true,
            };
            lbl_expenses = new LinkLabel
            {
                Location = new Point(160, 25),
                Font = new Font("Georgia", 10),
                Text = "Expenses",
                AutoSize = true,
                LinkColor = Color.White,
                LinkBehavior = LinkBehavior.NeverUnderline,
            };
            lbl_payments = new LinkLabel
            {
                Location = new Point(260, 25),
                Font = new Font("Georgia", 10),
                Text = "Payments",
                AutoSize = true,
                LinkColor = Color.White,
                LinkBehavior = LinkBehavior.NeverUnderline,
            };
            lbl_statistics = new LinkLabel
            {
                Location = new Point(360, 25),
                Font = new Font("Georgia", 10),
                Text = "Statistics",
                AutoSize = true,
                LinkColor = Color.White,
                LinkBehavior = LinkBehavior.NeverUnderline,
            };
            lbl_income = new LinkLabel
            {
                Location = new Point(460, 25),
                Font = new Font("Georgia", 10),
                Text = "Income",
                AutoSize = true,
                LinkColor = Color.White,
                LinkBehavior = LinkBehavior.NeverUnderline,
            };
            lbl_bills = new LinkLabel
            {
                Location = new Point(540, 25),
                Font = new Font("Georgia", 10, FontStyle.Regular),
                Text = "Bills",
                AutoSize = true,
                LinkColor = Color.White,
                LinkBehavior = LinkBehavior.NeverUnderline,
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
            this.Padding = new Padding(2, 0, 2, 2);
            this.BackColor = Color.CornflowerBlue;
            this.FormBorderStyle = FormBorderStyle.None;

            //adding controls to the form
            this.Controls.Add(pnl_content);
            this.Controls.Add(pnl_titlebar);

            //adding controls to the title panel
            pnl_titlebar.Controls.Add(btn_Minimize);
            pnl_titlebar.Controls.Add(btn_Close);
            //adding controls to the content panel
            pnl_content.Controls.Add(main_panel);
            pnl_content.Controls.Add(left_panel);
            pnl_content.Controls.Add(upper_panel);
            pnl_content.Controls.Add(customer_panel);
            pnl_content.Controls.Add(product_addedit_panel);

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
            upper_panel.Controls.Add(lbl_expenses);
            upper_panel.Controls.Add(lbl_payments);
            upper_panel.Controls.Add(lbl_statistics);
            upper_panel.Controls.Add(lbl_income);
            upper_panel.Controls.Add(lbl_bills);

            //main panel controls
            main_panel.Controls.Add(productdatagridview);
            main_panel.Controls.Add(customerdatagridview);

            //button Cick Events
            outofstock_prdct_btn.Click += Outofstock_Prdct_Btn_Click;//out of stock visible
            storage_prdct_btn.Click += Storage_Prdct_Btn_Click;//storage panel visible
            pnl_prdct_btn.Click += Pnl_prdct_btn_CLick;//product panel visible
            pnl_customer_btn.Click += Pnl_Customer_Btn_Click;
            pnl_product_add_btn.Click += Pnl_Product_Add_Btn_Click;
            pnl_customer_add_btn.Click += Pnl_Customer_Add_Btn_Click;

            show_prdct_btn.Click += Show_Prdct_Btn_Click;
            show_customer_btn.Click += Show_Customer_Btn_Click;//customer panel visible

            //title bar designers
            btn_Close.Click += Btn_Close_Click;
            btn_Minimize.Click += Btn_Minimize_Click;
            pnl_titlebar.MouseDown += Pnl_TitleBar_MouseDown;
            pnl_titlebar.MouseUp += Pnl_TitleBar_MouseUp;
            pnl_titlebar.MouseMove += Pnl_TitleBar_MouseMove;

            //datagridview events
            productdatagridview.CellContentClick += ProductDatagridview_CellContentClick;
            customerdatagridview.CellContentClick += Customerdatagridview_CellContentClick;
        }
        //end of render
    }
}