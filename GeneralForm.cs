using System;
using System.Windows.Forms;
using System.Drawing;

using System.Xml;
using System.Xml.Linq;
using System.Linq;
using static stockmanagement.MessageBoxForm;

namespace stockmanagement
{
    public partial class GeneralForm : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        private XElement xelement = XElement.Load(@"..\..\stockmanagement.xml");

        private string customerid = "";
        private int productid;
        private int mealquantity;
        //form
        public GeneralForm()
        {
            Render();
            CenterToScreen();
        }

        //form load event handler
        void Handle_Load(object sender, EventArgs e)
        {
            customerdatagridview.Columns.Insert(0, selectbutton);
            productdatagridview.Columns.Insert(0, selectbutton);
            GetCustomers();
            Get_product();
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
            picboxuser.Image = Image.FromFile(@"../../images/userm.png");
        }

        //form closed event handler
        void Handle_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Hide();
        }

        //for closing form
        void Btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        //for minimizing form
        void Btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //for moving form
        void Pnl_TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point(
                    (Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);

                Update();
            }
        }
        void Pnl_TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        void Pnl_TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        //button eventhandlers
        private void Pnl_prdct_btn_CLick(object sender, EventArgs e)
        {
            Leftshowpanel(product_controls_panel);
        }

        void Pnl_Customer_Btn_Click(object sender, EventArgs e)
        {
            Leftshowpanel(customer_controls_panel);
        }

        //populating product datagridview
        public void Get_product()
        {
            productdatagridview.Rows.Clear();
            productdatagridview.Columns[0].HeaderText = "Select";
            productdatagridview.Columns[1].HeaderText = "Id";
            productdatagridview.Columns[2].HeaderText = "Name";
            productdatagridview.Columns[3].HeaderText = "Type";
            productdatagridview.Columns[4].HeaderText = "Category";
            productdatagridview.Columns[5].HeaderText = "Price";
            productdatagridview.Columns[6].HeaderText = "Quantity";
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
                productdatagridview.Rows.Add("", x.xmlid, x.xmlname, x.xmltype, x.xmlcategory, x.xmlprice, x.xmlquantity);
           
        }

        //populating customerdatdagridview 
        public void GetCustomers()
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
        void Show_Prdct_Btn_Click(object sender, EventArgs e)
        {
            main_panel.Visible = true;
            Showgrid(productdatagridview);
            Get_product();
        }
        void Checkavailable(int data)
        {
            productdatagridview.Rows.Clear();
            productdatagridview.Columns[0].HeaderText = "Select";
            productdatagridview.Columns[1].HeaderText = "Id";
            productdatagridview.Columns[2].HeaderText = "Name";
            productdatagridview.Columns[3].HeaderText = "Type";
            productdatagridview.Columns[4].HeaderText = "Category";
            productdatagridview.Columns[5].HeaderText = "Price";
            productdatagridview.Columns[6].HeaderText = "Quantity";
            try
            {
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
                    productdatagridview.Rows.Add("", x.xmlid, x.xmlname, x.xmltype, x.xmlcategory, x.xmlprice, x.xmlquantity);
                Showgrid(productdatagridview);
                main_panel.Visible = true;

            }
            catch (Exception e)
            {
                CustomMessageBox.Show("Unexpected Behaviour. Here Is Your Crash Report : \n\n" + e, "Somethings Wrong!", MsgButtons.SendDontSendCancel, MsgIcon.error);
            }
        }

        //show datagridview of storage
        void Storage_Prdct_Btn_Click(object sender, EventArgs e)
        {
            Checkavailable(1);
        }

        //show datagirdview of outofstock
        void Outofstock_Prdct_Btn_Click(object sender, EventArgs e)
        {
            Checkavailable(0);
        }

        //show customers gridview
        void Show_Customer_Btn_Click(object sender, EventArgs e)
        {
            main_panel.Visible = true;
            Showgrid(customerdatagridview);
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
                lbl_customer_name.Visible = false;
                txt_customer_name.Visible = false;
                txt_customer_meal_quantity.Visible = true;
                lbl_meal_quantity.Visible = true;
            }
        }
        //customer mealadd button event handler
        void Customer_Mealadd_Btn_Click(object sender, EventArgs e)
        {
            MealAddForm maf = new MealAddForm
            {
                customer_id = customerid
            };
            this.Hide();
            maf.Show();
        }
        //customer update button
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
                CustomMessageBox.Show("Update Succesfully Completed !", "Update", MsgButtons.Ok, MsgIcon.information);
                GetCustomers();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Unexpected behaviour!! \n" + ex, "Somethhings Wrong", MsgButtons.Ok, MsgIcon.error);
            }
        }

        void Customer_delete()
        {
            txt_customer_loan.Texts = "";
            txt_customer_price.Texts = "";
            txt_customer_address.Texts = "";
            txt_customer_telephone.Texts = "";
            txt_customer_meal_quantity.Texts = "";
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
                        MsgResult dialogResult = CustomMessageBox.Show("This customer has " + Convert.ToInt32(x.Element("customer_loan").Value) + " TL loan.\nAre you sure want to delete this customer?", "Warning", MsgButtons.YesNo, MsgIcon.error);
                        if (dialogResult == MsgResult.Yes)
                        {
                            x.SetElementValue("customer_id", "");
                            x.SetElementValue("customer_name", "");
                            x.SetElementValue("customer_address", "");
                            x.SetElementValue("customer_phonenumber", "");
                            x.SetElementValue("customer_loan", "");
                            x.Element("customer_price").SetAttributeValue("price", "");
                            Customer_delete();
                            GetCustomers();
                            updated = true;
                        }
                        else
                            break;
                    }
                    else
                    {
                        x.SetElementValue("customer_id", "");
                        x.SetElementValue("customer_name", "");
                        x.SetElementValue("customer_address", "");
                        x.SetElementValue("customer_phonenumber", "");
                        x.SetElementValue("customer_loan", "");
                        x.Element("customer_price").SetAttributeValue("price", "");
                        CustomMessageBox.Show("Customer Succesfully Deleted", "Deleted", MsgButtons.Ok, MsgIcon.information);
                        Customer_delete();
                        GetCustomers();
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
                    CustomMessageBox.Show("Customer Succesfully Deleted", "Deleted", MsgButtons.Ok, MsgIcon.information);
                    break;
                }
            }
            xelement.Save(@"../../stockmanagement.xml");
        }
        //customer add button
        void Customer_Add_Btn_Click(object sender, EventArgs e)
        {
            int i = 1;
            Boolean updated = false;
            try
            {
                var update = xelement.Descendants("customer").ToList();
                foreach (XElement x in update)
                {
                    if (x.Element("customer_id").Value == "")
                    {
                        updated = true;
                        x.SetElementValue("customer_id", i);
                        x.SetElementValue("customer_name", txt_customer_name.Texts);
                        x.SetElementValue("customer_phonenumber", txt_customer_telephone.Texts);
                        x.SetElementValue("customer_address", txt_customer_address.Texts);
                        x.SetElementValue("customer_loan", 0);
                        x.Element("customer_price").SetAttributeValue("price", txt_customer_price.Texts);
                        break;
                    }
                    i++;
                }
                if (updated == false)
                {
                    xelement.Add(
                      new XElement("customer", new XElement("customer_id", i),
                      new XElement("customer_name", txt_customer_name.Texts),
                      new XElement("customer_phonenumber", txt_customer_telephone.Texts),
                      new XElement("customer_address", txt_customer_address.Texts),
                      new XElement("customer_loan", 0),
                      new XElement("customer_price", new XAttribute("price", txt_customer_price.Texts))));
                }
                CustomMessageBox.Show("Customer Succesfully Added", "Adding Succesfull", MsgButtons.Ok, MsgIcon.information);
                xelement.Save(@"../../stockmanagement.xml");
                GetCustomers();
            }
            catch
            {
                CustomMessageBox.Show("Fill The Blankets!", "Warning", MsgButtons.Ok, MsgIcon.warning);
            }
        }
        //show customer panel button
        void Pnl_Customer_Add_Btn_Click(object sender, EventArgs e)
        {
            txt_customer_loan.Texts = "";
            txt_customer_price.Texts = "";
            txt_customer_address.Texts = "";
            txt_customer_telephone.Texts = "";
            txt_customer_name.Texts = "";
            txt_customer_meal_quantity.Texts = "";

            customer_delete_btn.Enabled = false;
            customer_add_btn.Enabled = true;
            customer_update_btn.Enabled = false;
            customer_mealadd_btn.Enabled = false;
            main_panel.Visible = false;
            product_addedit_panel.Visible = false;
            customer_panel.Visible = true;
            txt_customer_meal_quantity.Visible = false;
            lbl_meal_quantity.Visible = false;
            lbl_customer_name_title.Visible = false;
            lbl_customer_loan.Visible = false;
            txt_customer_loan.Visible = false;
            txt_customer_name.Visible = true;
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

        //product datagridview cell clicked event
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
                if (Convert.ToInt32(productdatagridview.Rows[index].Cells[6].Value) > 0)
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
                Product_add_event_finished();
                Get_product();
                CustomMessageBox.Show("Product Succesfully Added", "Adding Succesfull", MsgButtons.Ok, MsgIcon.information);
                xelement.Save(@"../../stockmanagement.xml");
            }
            catch
            {
                CustomMessageBox.Show("Fill The Blankets!", "Warning", MsgButtons.Ok, MsgIcon.warning);
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
                CustomMessageBox.Show("Element Succesfully Deleted", "Delete Succesfull", MsgButtons.Ok, MsgIcon.information);
                main_panel.Visible = true;
                product_addedit_panel.Visible = false;
                Get_product();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.ToString(), "Error", MsgButtons.Ok, MsgIcon.error);
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
                Get_product();
            }
            catch
            {
                CustomMessageBox.Show("Fill The Blankets!", "Error", MsgButtons.Ok, MsgIcon.error);
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
        void Product_add_event_finished()
        {
            txt_product_name.Texts = "";
            txt_product_price.Texts = "";
            txt_product_worth.Texts = "";
            txt_product_quantity.Texts = "";
        }

        //panel visible function
        public void Hidepanel()
        {
            customer_panel.Visible = false;
            product_addedit_panel.Visible = false;
            main_panel.Visible = false;
        }
        public void Showpanel(Panel panel)
        {
            if (panel.Visible == false)
            {
                Hidepanel();
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

        public void Leftshowpanel(Panel panel)
        {
            if (panel.Visible == false)
            {
                //lefthidepanel();
                panel.Visible = true;
            }
            else
                panel.Visible = false;
        }
        public void Hidegrid()
        {
            productdatagridview.Visible = false;
            customer_panel.Visible = false;
            customerdatagridview.Visible = false;
        }
        public void Showgrid(DataGridView dgv)
        {
            if (dgv.Visible == false)
            {
                Hidegrid();
                dgv.Visible = true;
            }
            else
                dgv.Visible = true;
        }
    }
}