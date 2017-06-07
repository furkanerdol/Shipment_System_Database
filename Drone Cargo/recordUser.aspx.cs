using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Drone_Cargo
{
    public partial class recordUser : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            confirmLabel.ForeColor = System.Drawing.Color.Red;
        }

        
        // User sign up button actions
        protected void recordButton_Click(object sender, EventArgs e)
        {
            // Control text fields
            bool flag = true;

            if (text_rUsername.Text == "" || text_rUsername.Text == "Can not be blank")
            {

                text_rUsername.BackColor = System.Drawing.Color.LightGray;
                text_rUsername.Text = "Can not be blank";
                flag = false;
            }

            if (text_rName.Text == "" || text_rName.Text == "Can not be blank")
            {
                text_rName.BackColor = System.Drawing.Color.LightGray;
                text_rName.Text = "Can not be blank";
                flag = false;
            }

            if (text_rSurname.Text == "" || text_rSurname.Text == "Can not be left blank")
            {
                text_rSurname.BackColor = System.Drawing.Color.LightGray;
                text_rSurname.Text = "Can not be blank.";
                flag = false;
            }

            if (text_rPassword.Text == "" || text_rConfirmPassword.Text == "" || text_rPassword.Text == "" || text_rConfirmPassword.Text == "")
            {
                confirmLabel.Text = "Can not be blank.";
                flag = false;
            }

            else if (text_rConfirmPassword.Text != text_rPassword.Text)
            {

                text_rConfirmPassword.BackColor = System.Drawing.Color.Gray;
                text_rConfirmPassword.Text = "";

                text_rPassword.BackColor = System.Drawing.Color.Gray;
                text_rPassword.Text = "";

                confirmLabel.Text = "These passwords do not match.";

                flag = false;
            }

            if (text_rAdress.Text == "" || text_rAdress.Text == "Can not be left blank")
            {
                text_rAdress.BackColor = System.Drawing.Color.LightGray;
                text_rAdress.Text = "Can not be blank.";
                flag = false;
            }

            if (text_rShippingAddress1.Text == "" || text_rShippingAddress1.Text == "Can not be left blank")
            {
                text_rShippingAddress1.BackColor = System.Drawing.Color.LightGray;
                text_rShippingAddress1.Text = "Can not be blank.";
                flag = false;
            }

            if (text_rShippingAddress2.Text == "" || text_rShippingAddress2.Text == "Can not be left blank")
            {
                text_rShippingAddress2.BackColor = System.Drawing.Color.LightGray;
                text_rShippingAddress2.Text = "Can not be blank.";
                flag = false;
            }

            if (text_rPhoneNumber.Text == "" || text_rPhoneNumber.Text == "Can not be left blank")
            {
                text_rPhoneNumber.BackColor = System.Drawing.Color.LightGray;
                text_rPhoneNumber.Text = "Can not be blank.";
                flag = false;
            }

            if (flag)
            {
                // Create db connection
                OleDbConnection cnn = new OleDbConnection("Provider= ORAOLEDB.ORACLE ; Data Source=orcl; User ID = SYSTEM; Password = database; Trusted_Connection=True");

                // Open db connection
                cnn.Open();

                // New command object
                OleDbCommand cmd = new OleDbCommand();

                // Assign command object and connection
                cmd.Connection = cnn;

                // Send get user query
                string temp = "select * from DC_USERS where USERNAME = '" + text_rUsername.Text + "'";
                cmd.CommandText = temp;
                cmd.CommandType = CommandType.Text;

                // Reader to recieve message from database
                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string alertString = "alert('" + "This username is used. Try another one.!" + "');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", alertString, true);

                    return;
                }

                // Create user record object
                record rec = new Drone_Cargo.record(text_rUsername.Text, text_rName.Text, text_rSurname.Text, text_rPassword.Text,
                                                    text_rPhoneNumber.Text, text_rAdress.Text, text_rShippingAddress1.Text, text_rShippingAddress2.Text);


                string sorgu = "INSERT into DC_USERS (USERNAME, NAME, SURNAME, PASSWORD, PHONE_NUMBER, ADDRESS, SADDRESS1, SADDRESS2, CARGO1_ID) " +

                                             "Values(:USERNAME, :NAME, :SURNAME, :PASSWORD, :PHONE_NUMBER, :ADDRESS, :SADDRESS1, :SADDRESS2, :CARGO1_ID)";

                cnn.Close();
                cnn.Open();
                cmd = new OleDbCommand(sorgu, cnn);

                // Add new user
                try
                {
                    cmd.Parameters.AddWithValue(":USERNAME", rec.Username);
                    cmd.Parameters.AddWithValue(":NAME", rec.Name);
                    cmd.Parameters.AddWithValue(":SURNAME", rec.Surname);
                    cmd.Parameters.AddWithValue(":PASSWORD", rec.Password);
                    cmd.Parameters.AddWithValue(":PHONE_NUMBER", rec.UserPhoneNumber);
                    cmd.Parameters.AddWithValue(":ADDRESS", rec.UserAddress);
                    cmd.Parameters.AddWithValue(":SADDRESS1", rec.ShippingAddress1);
                    cmd.Parameters.AddWithValue(":SADDRESS2", rec.ShippingAddress2);
                    cmd.Parameters.AddWithValue(":CARGO1_ID", "-");

                    cmd.ExecuteNonQuery();

                    recordMessage.Text = "Recording was successful!";

                    string alertString = "alert('" + "Recording was successful!" + "');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", alertString, true);


                }
                catch (Exception)
                {
                    string alertString = "alert('" + "Shipping registration failed!" + "');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", alertString, true);

                }

                // Assign initial strings to text fields
                renewAllText();

            }

        }

        // Assign initial strings to text fields
        private void renewAllText()
        {

            text_rUsername.BackColor = System.Drawing.Color.White;
            text_rUsername.Text = "";


            text_rName.BackColor = System.Drawing.Color.White;
            text_rName.Text = "";


            text_rSurname.BackColor = System.Drawing.Color.White;
            text_rSurname.Text = "";


            text_rPassword.BackColor = System.Drawing.Color.White;
            text_rPassword.Text = "";


            text_rConfirmPassword.BackColor = System.Drawing.Color.White;
            text_rConfirmPassword.Text = "";

            text_rAdress.BackColor = System.Drawing.Color.White;
            text_rAdress.Text = "";

            text_rPhoneNumber.BackColor = System.Drawing.Color.White;
            text_rPhoneNumber.Text = "";

            text_rShippingAddress1.BackColor = System.Drawing.Color.White;
            text_rShippingAddress1.Text = "";

            text_rShippingAddress2.BackColor = System.Drawing.Color.White;
            text_rShippingAddress2.Text = "";


            confirmLabel.Text = "";

        }

    }
}