using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        public static string EmailListed = "Email listed";
        public static string ClaimsListed = "Claims listed";
        public static string EmailUpdated = "Email updated";
        public static string EmailIsAlreadyExists;


        //CarImage
        public static string SameNameExist;


        //Payment
        public static string PaymentInformationSaved = "Payment information saved";
        public static string PaymentDeleted = "Payment deleted";
        public static string PaymentUpdated= "Payment updated";
        public static string PaymentListed="Payment listed";
        public static string PaymentSuccessful = "Payment successful";
        public static string ThisCardIsAlreadyRegisteredForThisCustomer = "This card is already registered for this customer";

        //Card
        public static string CardAdded;
        public static string CardDeleted;
        public static string CardUpdated;

        //Auth
        public static string UserRegistered = "User registered";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password error";
        public static string LoginSuccessful = "Successfull login";
        public static string UserAlreadyExists = "User already exists";
        public static string AccessTokenCreated = "Access Token created";
        public static string FirstNameAndLastNameUpdated = "Firstname and lastname updated";
     
    }
}
