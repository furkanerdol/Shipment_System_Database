using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Drone_Cargo
{
    public partial class _default : System.Web.UI.Page
    {
        // Sign in user name
        public static string currentUser;
        
        // Sign in user information object
        public static record currentUserInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            CargoText.Height = 500;
            CargoText.ReadOnly = true;
        }

        // Sign in button actions
        protected void btnKayit_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {

                if (txtUsername.Text != "" && txtPassword.Text != "")
                {
                    // Create db connection
                    OleDbConnection cnn = new OleDbConnection("Provider= ORAOLEDB.ORACLE ; Data Source=orcl; User ID = SYSTEM; Password = database; Trusted_Connection=True");

                    // Db connection open
                    cnn.Open();
                    OleDbCommand cmd = new OleDbCommand();

                    cmd.Connection = cnn;
                    try
                    {

                        // Send select query
                        cmd.CommandText = "select * from DC_USERS where USERNAME = '" + txtUsername.Text +
                                                    "' and PASSWORD = '" + txtPassword.Text + "'";


                        cmd.CommandType = CommandType.Text;

                        // Reader to query result
                        OleDbDataReader dr = cmd.ExecuteReader();

                        // Get information about user from reader
                        if (dr.Read())
                        {
                            // User information

                            record rec = new record(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetString(6), dr.GetString(7));

                            // User sign in is successful
                            string alertString = "alert('" + "WELCOME : " + rec.Username + " " + rec.ShippingAddress2 + "');";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", alertString, true);

                            // Transfer current user info
                            currentUser = rec.Username;
                            currentUserInfo = rec;

                            // Open new page
                            Server.Transfer("signIn.aspx");


                        }
                        else
                        {
                            // User sign in failed
                            string alertString = "alert('" + "Please Try Again!" + "');";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", alertString, true);

                            txtUsername.Text = "";
                            txtPassword.Text = "";
                        }

                        // Db connection close
                        cnn.Close();

                    }
                    catch (Exception)
                    {
                        // User sign in failed
                        string alertString = "alert('" + "User registration failed! Please try again." + "');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", alertString, true);

                    }
                }
                else
                {
                    // Fill in thre blanks
                    string alertString = "alert('" + "You must fill in the blank fields!" + "');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", alertString, true);
                }


            }

        }




        // Ship button actions
        protected void btn2_Click(object sender, EventArgs e)
        {
            // Control text areas
            bool flag = true;

            if (txtName.Text == "" & txtName.Text == "Can not be left blank")
            {

                txtName.Text = "Can not be left blank";
                flag = false;
            }

            if (txtSurname.Text == "" && txtSurname.Text == "Can not be left blank")
            {

                txtSurname.Text = "Can not be left blank";
                flag = false;
            }

            if (txtAddress.Text == "" && txtAddress.Text == "Can not be left blank")
            {

                txtAddress.Text = "Can not be left blank";
                flag = false;
            }

            if (txtPhoneNumber.Text == "" && txtPhoneNumber.Text == "Can not be left blank")
            {

                txtPhoneNumber.Text = "Can not be left blank";
                flag = false;
            }


            if (txtWeightOfCargo.Text == "" && txtWeightOfCargo.Text == "Can not be left blank")
            {

                txtWeightOfCargo.Text = "Can not be left blank";
                flag = false;
            }

            // If all of text areas filled
            if (flag)
            {
                // Create db connection
                OleDbConnection cnn = new OleDbConnection("Provider= ORAOLEDB.ORACLE ; Data Source=orcl; User ID = SYSTEM; Password = database; Trusted_Connection=True");

                // Generates unique id to cargos
                Guid g = Guid.NewGuid();
                string GuidString = Convert.ToBase64String(g.ToByteArray());
                GuidString = GuidString.Replace("=", "");
                GuidString = GuidString.Replace("+", "");

                GuidString = GuidString.Substring(0, 10);

                // Create new cargo object
                cargo cr = new cargo(txtName.Text, txtSurname.Text, txtAddress.Text, txtPhoneNumber.Text, txtReceiverName.Text, txtReceiverSurname.Text, txtDestinationAddress.Text, txtReceiverPhoneNum.Text, GuidString, txtWeightOfCargo.Text, "Packaging");


                string sorgu = "INSERT into CARGO (SENDER_NAME, SENDER_SURNAME, SENDER_ADDRESS, SENDER_PHONE_NUMBER, RECEIVER_NAME, RECEIVER_SURNAME, DESTINATION_ADDRESS, RECEIVER_PHONE_NUMBER, WEIGHT, STATUS, CARGO_ID) " +

                                "Values(:SENDER_NAME, :SENDER_SURNAME, :SENDER_ADDRESS, :SENDER_PHONE_NUMBER, :RECEIVER_NAME, :RECEIVER_SURNAME, :DESTINATION_ADDRESS, :RECEIVER_PHONE_NUMBER, :WEIGHT, :STATUS, :CARGO_ID)";


                OleDbCommand cmd = new OleDbCommand(sorgu, cnn);
                cnn.Open();
                
                // Adds cargo to cargo table
                try
                {
                    cmd.Parameters.AddWithValue(":SENDER_NAME", cr.Sender_name);
                    cmd.Parameters.AddWithValue(":SENDER_SURNAME", cr.Sender_surname);
                    cmd.Parameters.AddWithValue(":SENDER_ADDRESS", cr.Sender_address);
                    cmd.Parameters.AddWithValue(":SENDER_PHONE_NUMBER", cr.Sender_phone_number);

                    cmd.Parameters.AddWithValue(":RECEIVER_NAME", cr.Receiver_name);
                    cmd.Parameters.AddWithValue(":RECEIVER_SURNAME", cr.Receiver_surname);
                    cmd.Parameters.AddWithValue(":DESTINATION_ADDRESS", cr.Destination_adress);
                    cmd.Parameters.AddWithValue(":RECEIVER_PHONE_NUMBER", cr.Receiver_phone_number);

                    cmd.Parameters.AddWithValue(":WEIGHT", cr.Cargo_weight);
                    cmd.Parameters.AddWithValue(":STATUS", cr.Cargo_state);
                    cmd.Parameters.AddWithValue(":CARGO_ID", cr.Cargo_id);


                    cmd.ExecuteNonQuery();
                    cnn.Close();

                    // Process is successful
                    string alertString = "alert('" + "Shipping registration was successful!" + "');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", alertString, true);

                    string alertString2 = "alert('" + "Shipping tracking number : " + GuidString + "');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts2", alertString2, true);


                }
                catch (Exception)
                {
                    string alertString = "alert('" + "Shipping registration failed!" + "');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", alertString, true);

                }


            }
            else{
                string alertString = "alert('" + "You must fill in the blank fields!" + "');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", alertString, true);
            }

            txtName.Text = "";
            txtAddress.Text = "";
            txtPhoneNumber.Text = "";
            txtSurname.Text = "";
            txtWeightOfCargo.Text = "";

        }

        
        // Cargo tracking button actions
        protected void Button3_Click(object sender, EventArgs e)
        {

            CargoText.Text = "Cargo Text";

            OleDbConnection cnn = new OleDbConnection("Provider= ORAOLEDB.ORACLE ; Data Source=orcl; User ID = SYSTEM; Password = database; Trusted_Connection=True");
            cnn.Open();

            OleDbCommand cmd = new OleDbCommand();

            cmd.Connection = cnn;

            // Get cargo query
            cmd.CommandText = "select * from CARGO where CARGO_ID = '" + txtSorgu.Text + "'";

            cmd.CommandType = CommandType.Text;


            // Reader to received command
            OleDbDataReader dr = cmd.ExecuteReader();

            // Reads all information about cargo from database
            if (dr.Read())
            {
                // Create new cargo object
                cargo cr = new cargo(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetString(6), dr.GetString(7), dr.GetString(8), dr.GetString(9), dr.GetString(10));

                CargoText.Text = "Sender Name           : " + cr.Sender_name + "\n" +
                                    "Sender Surname        : " + cr.Sender_surname + "\n" +
                                    "Sender Address        : " + cr.Sender_address + "\n" +
                                    "Sender Phone Number   : " + cr.Sender_phone_number + "\n" +

                                    "------------------------------\n" +

                                    "Receiver Name         : " + cr.Receiver_name + "\n" +
                                    "Receiver Surname      : " + cr.Receiver_surname + "\n" +
                                    "Destination Address   : " + cr.Destination_adress + "\n" +
                                    "receiver Phone Number : " + cr.Sender_name + "\n" +

                                    "------------------------------\n" +

                                    "Cargo State           : " + cr.Cargo_state + "\n";

            }

            else
            {
                CargoText.Text = "No such cargo exists!";
            }
        }
    }
}
