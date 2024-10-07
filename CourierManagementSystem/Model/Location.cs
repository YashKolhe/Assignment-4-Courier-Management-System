using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Model
{
    public class Location
    {
        private int locationID;
        public int LocationID
        {
            get { return locationID; }
            set { locationID = value; }
        }
        private string locationName;
        public string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public Location()
        {

        }

        public Location(int ID, string LocationName, string Address)
        {
            LocationID = ID;
            this.LocationName = LocationName;
            this.Address = Address;
        }


        public override string ToString()
        {
            return $"Location ID : {LocationID}\t LocationName : {LocationName}\t Address : {Address}";
        }
    }
}
