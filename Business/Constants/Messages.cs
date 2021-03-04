using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string Added = "Eklendi"; 
        public static string Deleted = "Silindi";
        public static string Updated = "Güncellendi";
        public static string NameInvalid = "Girdiğiniz isim geçersiz";
        public static string Invalid = "Girdiniz bilgi ya da bilgiler geçersiz";
        public static string MaintenanceTime = "Bakımda";
        public static string Listed = "Ürünler listelendi";
        public static string NotReturned = "Kiralamaya çalıştığınız araç teslim edilmedi";
        public static string PhotoNumberlimitExceded="Bir aracın alabileceği fotograf limitine uşlaşılmıştır";
        public static string UserNotFound="kullanıcı bulunamadı";
        public static string PasswordError="Şifre hatalı";
        public static string SuccessfulLogin= "Giriş başarılı";
        public static string UserAlreadyExists="Kullanıcı zaten mevcut";
        public static string UserRegistered ="Kullanıcı başarıyla kayıt oldu";
        public static string AccessTokenCreated="Access Token başarı ile oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";
    }
}
