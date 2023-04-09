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
        public static string TaskAddedMessage = "Görev Eklendi.";
        public static string TaskNameUpdated = "Görev Adı Güncellendi.";
        public static string TaskNameDeleted = "Görev Silindi.";
        public static string TaskNameAlreadyExists = "Görev Adı Zaten Mevcut.";
        public static string UnitAddedMessage = "Birim Eklendi.";
        public static string UnitNameDeleted = "Birim Silindi";
        public static string BranchAddedMessage = "Şube Eklendi";
        public static string BranchNameDeleted = "Şube Silindi";
        public static string UnitNameUpdated = "Birim Adı Güncellendi";
        public static string UnitNameAlreadyExists = "Birim Adı Zaten Mevcut";
        public static string NationalIdAlreadyExists = "Girdiğiniz kimlik kodu zaten mevcut. Kontrol ediniz";
        public static string EmployeeUpdated = "Personel bilgileri güncellendi.";
        public static string AuthorizationDenied = "Yetkilendirme Reddedildi";
        public static string BranchNameUpdated = "Şube ismi güncellendi";
        public static string BranchNameAlreadyExists = "Şube adı zaten mevcut";
    }
}
