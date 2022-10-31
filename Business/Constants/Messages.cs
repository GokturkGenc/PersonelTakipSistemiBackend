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
        // GENERAL MESSAGES 
        public static string MaintenanceTime = "Şu anda hizmet verilmemektedir.";


        //BRAND MESSAGES
        public static string BrandAddedMessage = "Marka ekleme işlemi başarılı";
        public static string BrandNameInvalid = "Marka ismi en az 3 karakterden oluşmalıdır.";
        public static string BrandsListed = "Markalar Listelendi";
        public static string CarCountOfBrandError = "Bir markadan en fazla 10 adet araç bulunabilir.";
        public static string BrandNameAlreadyExists = "Aynı isimde bir marka zaten var.";
        public static string BrandLimitExceeded= "Bir markada bulunabilecek araç sayısı aşıldı.";

        //CAR MESSAGES
        public static string CarAddedMessage = "Araç ekleme işlemi başarılı";
        public static string CarPriceInvalid = "Araç fiyatı 0 liradan fazla olmalıdır.";
        public static string CarsListed = "Araçlar listelendi";
        public static string CarUpdated = "Araç bilgileri güncellendi.";


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

        //CarImage MESSAGES
        public static string ImageAdded = "Resim yükleme işlemi tamamlandı.";
        public static string ImageLimitWarning = "Resim yükleme limiti aşıldı.";

        //AUTH MESSAGES
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string ClaimsListed = "Kullanıcının claimleri listelendi.";
        public static string UserRegistered = "Kullanıcı kaydedildi.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola Hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Bu mail zaten kullanılıyor.";
        public static string AccessTokenCreated = "Token üretildi.";

    }
}
