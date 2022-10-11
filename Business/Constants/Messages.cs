﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        // GENERAL MESSAGES 
        public static string MaintenanceTime = "Şu anda hizmet verilmemektedir.";


        //BRAND MESSAGES
        public static string BrandAddedMessage = "Marka ekleme işlemi başarılı";
        public static string BrandNameInvalid = "Marka ismi en az 3 karakterden oluşmalıdır.";
        public static string BrandsListed = "Markalar Listelendi";


        //CAR MESSAGES
        public static string CarAddedMessage = "Araç ekleme işlemi başarılı";
        public static string CarPriceInvalid = "Araç fiyatı 0 liradan fazla olmalıdır.";
        public static string CarsListed = "Araçlar listelendi";


        //COLOR MESSAGES
        public static string ColorAddedMessage = "Renk ekleme işlemi başarılı.";
        public static string ColorNameInvalid = "Renk ismi en az 3 karakterden oluşmalıdır.";
        public static string ColorsListed = "Renkler Listelendi.";

        //RENTAL MESSAGES
        public static string RentalConfirm = "Araç kiralama işlemi başarılı.";
        public static string RentalsListed = "Girdiğiniz tarihte kiralanmış araçlar listelendi.";
        public static string RentalDenied = "Kiralama tamamlanamadı! Araç henüz teslim edilmemiş olabilir.";


        //USER - CUSTOMER MESSAGES
        public static string UserSignUpConfirm = "Kullanıcı kaydı başarılı.";
        public static string CustomerSignUpConfirmed = "Müşteri Kaydı Başarılı.";
        public static string UsersListed = "Kullanıcılar Listelendi.";
        
    }
}