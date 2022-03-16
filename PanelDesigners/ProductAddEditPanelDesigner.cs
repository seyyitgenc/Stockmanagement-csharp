using System.Windows.Forms;
using System.Drawing;

namespace stockmanagement
{
    public partial class GeneralForm : Form
    {
        //panel fields
        private Panel product_addedit_panel;
        //toggle button field
        private customtogglebtn product_toggle_available = new customtogglebtn();

        //textbox field
        private customtextbox txt_product_name = new customtextbox();
        private customcombobox cmbox_product_category = new customcombobox();
        private customcombobox cmbox_product_type = new customcombobox();
        private customtextbox txt_product_price = new customtextbox();
        private customtextbox txt_product_quantity = new customtextbox();
        private customtextbox txt_product_worth = new customtextbox();

        //datagridview field
        private DataGridView productdatagridview;

        //label fields
        private Label lbl_product_name;
        private Label lbl_product_category;
        private Label lbl_product_price;
        private Label lbl_product_type;
        private Label lbl_product_quantity;
        private Label lbl_product_available;
        private Label lbl_product_onoff;
        private Label lbl_product_title;
        private Label lbl_product_worth;

        //button fields
        public Button product_add_btn;
        public Button product_edit_btn;
        public Button product_delete_btn;

        void RenderProductEditPanel()
        {
            //product add edit panel
            product_addedit_panel = new Panel
            {
                Location = new Point(150, 50),
                Size = new Size(850, 650)
            };
            product_addedit_panel.BackgroundImage = Image.FromFile(@"../../images/editbg.jpg");
            product_addedit_panel.BackgroundImageLayout = ImageLayout.Stretch;

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

            //product datagridview
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
                BackgroundColor=Color.Aquamarine,
            };
            DataGridViewRow row = this.productdatagridview.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.Tan;

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

            //event handlers

            txt_product_price.KeyPress += Txt_Product_KeyPress;
            txt_product_quantity.KeyPress += Txt_Product_KeyPress;
            product_add_btn.Click += Product_Add_Btn_Click;
            product_delete_btn.Click += Product_Delete_Btn_Click;
            product_edit_btn.Click += Product_Edit_Btn_Click;
        }
    }
}