using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //Car
        public static string CarAdded = "Car added";
        public static string CarDeleted = "Car deleted";
        public static string CarUpdated = "Car updated";
        public static string CarGetAll = "Car get all";
        public static string CarDetails = "Car detail listed";
        public static string CarListed = "Car listed";
        public static string CarNameInvalid = "Car name is invalid";

        //Brand
        public static string BrandAdded = "Brand added";
        public static string BrandDeleted = "Brand deleted";
        public static string BrandUpdated = "Brand updated";
        public static string BrandListed = "Brand listed";

        //Color
        public static string ColorAdded = "Color added";
        public static string ColorDeleted = "Color deleted";
        public static string ColorUpdated = "Color updated";
        public static string ColorListed = "Color listed";

        //Customer
        public static string CustomerAdded = "Customer added";
        public static string CustomerDeleted = "Customer deleted";
        public static string CustomerUpdated = "Customer updated";
        public static string CustomerListed = "Customer listed";
        

        //Rental
        public static string RentalAdded = "Rental added";
        public static string RentalDeleted = "Rental deleted";
        public static string RentalUpdated = "Rental Updated";
        public static string RentalListed = "Rental listed";
        public static string RentalInvalid = "Rental is invalid";


        //User
        public static string UserNameInvalid = "User name is invalid";
        public static string UserAdded = "User added";
        public static string UserDeleted = "User deleted.";
        public static string UserUpdated = "User Updated.";
        public static string UserListed = "User listed.";

        //CarImage
        public static string SameNameExist;
    }
}
