using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drone_Cargo
{
    public class record
    {
        string username;
        string name;
        string surname;
        string password;

        string userPhoneNumber;
        string userAddress;
        string shippingAddress1;
        string shippingAddress2;

        public record(string _username, string _name, string _surname, string _password, string _phoneNum, string _address, string _sAddress1, string _sAddress2)
        {

            username = _username;
            name = _name;
            surname = _surname;
            password = _password;

            if(_address == null)
                userAddress = "-";
            else
                userAddress = _address;

            if (_phoneNum == null)
                userPhoneNumber = "-";
            else
                userPhoneNumber = _phoneNum;

            if (_sAddress1 == null)
                shippingAddress1 = "-";
            else
                shippingAddress1 = _sAddress1;

            if (_sAddress2 == null)
                shippingAddress2 = "-";
            else
                shippingAddress2 = _sAddress2;

        }


        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }

        public string UserAddress
        {
            get
            {
                return userAddress;
            }

            set
            {
                userAddress = value;
            }
        }

        public string ShippingAddress1
        {
            get
            {
                return shippingAddress1;
            }

            set
            {
                shippingAddress1 = value;
            }
        }

        public string ShippingAddress2
        {
            get
            {
                return shippingAddress2;
            }

            set
            {
                shippingAddress2 = value;
            }
        }

        public string UserPhoneNumber
        {
            get
            {
                return userPhoneNumber;
            }

            set
            {
                userPhoneNumber = value;
            }
        }
    }




    public class cargo
    {

        string sender_name;
        string sender_surname;
        string sender_address; 
        string sender_phone_number;

        string reciever_name;
        string receiver_surname;
        string destination_adress;
        string receiver_phone_number;

        string cargo_weight;
        string cargo_id;
        string cargo_state;

        public cargo(string sname, string ssurname, string saddress, string sphonenum ,string name, string surname, string address, string rphonenum, string id, string we, string state)
        {

            Sender_name = sname;
            Sender_surname = ssurname;
            Sender_address = saddress;
            Sender_phone_number = sphonenum;

            reciever_name = name;
            receiver_surname = surname;
            destination_adress = address;
            receiver_phone_number = rphonenum;


            cargo_state = state;
            cargo_id = id;
            cargo_weight = we;

        }


        public string Receiver_name
        {
            get
            {
                return reciever_name;
            }

            set
            {
                reciever_name = value;
            }
        }

        public string Receiver_surname
        {
            get
            {
                return receiver_surname;
            }

            set
            {
                receiver_surname = value;
            }
        }

        public string Destination_adress
        {
            get
            {
                return destination_adress;
            }

            set
            {
                destination_adress = value;
            }
        }

        public string Receiver_phone_number
        {
            get
            {
                return receiver_phone_number;
            }

            set
            {
                receiver_phone_number = value;
            }
        }

  

        public string Cargo_weight
        {
            get
            {
                return cargo_weight;
            }

            set
            {
                cargo_weight = value;
            }
        }


        public string Cargo_id
        {
            get
            {
                return cargo_id;
            }

            set
            {
                cargo_id = value;
            }
        }

        public string Cargo_state
        {
            get
            {
                return cargo_state;
            }

            set
            {
                cargo_state = value;
            }
        }

        public string Sender_name
        {
            get
            {
                return sender_name;
            }

            set
            {
                sender_name = value;
            }
        }

        public string Sender_surname
        {
            get
            {
                return sender_surname;
            }

            set
            {
                sender_surname = value;
            }
        }

        public string Sender_address
        {
            get
            {
                return sender_address;
            }

            set
            {
                sender_address = value;
            }
        }

        public string Sender_phone_number
        {
            get
            {
                return sender_phone_number;
            }

            set
            {
                sender_phone_number = value;
            }
        }

   
    }


}