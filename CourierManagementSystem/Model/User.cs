using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Model
{
    public class User
    {
        private int userID;
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string contactNumber;
        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public User()
        {

        }

        public User(int ID, string name, string Email, string Password, string ContactNumber, string Address)
        {
            userID = ID;
            userName = name;
            email = Email;
            password = Password;
            contactNumber = ContactNumber;
            address = Address;
        }

        public override string ToString()
        {
            return $"User ID : {userID}\t User Name : {userName}\t email : {email}\t Password : {password}\t Contact Number : {contactNumber}\t Address : {address} ";
        }

    }
}
