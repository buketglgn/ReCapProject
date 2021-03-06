﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constant
{
   public static class Messages
    {
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string CustomerAdded = "Müsteri eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string CustomerDeleted = "Müsteri Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string CustomerUpdated = "Müsteri Güncellendi";
        public static string RentalAdded = "Araç Kiralandı (Rental tablosuna eklendi)";
        public static string RentalDeleted = "Arac Rental Tablsoundan Silindi";
        public static string RentalDelivered = "Araç Teslim Edildi";
        public static string RentalBusy = "Araç Suan Kullanımda, Kiralanamaz..";
        public static string RentalUpdated = "Arac Bilgisi Tabloda güncellendi";
        public static string NoRecording = "Kayıt Bulunamadı";
        public static string CarAdded = "Yeni Arac Sisteme Eklendi";
        public static string CarDeleted = "Arac Sistemden Silindi";
        public static string CarUpdated = "Arac Güncellendi";
        public static string CarDidntAdded = "Eklenemedi-Arac Bilgisi en az 2 karakter olmalı";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated= "Marka Güncellendi";
        public static string ColorAdded = "Color Eklendi";
        public static string ColorDeleted = "Color Silindi";
        public static string ColorUpdated = "Color Güncellendi";
        public static string UserNotFound = "Kullanıcı Bulunumadı.";
        public static string IncorrectPassword = "Parola hatalı.";
        public static string SuccessfulLogin = "Login başarılı";
        public static string UserAlreadyExists = "kullanıcı zaten mevcut";
        public static string Registered = "Kullanıcı Başarılı bir sekilde kayıt oldu.";
        public static string AccessTokenCreated = "Access Token Olusturuldu..";
        public static string AuthorizationDenied = "yetkiniz yok";
        public static string RentalCheckIsCarReturnError = "araç kullanımda";
        public static string RentalGetAllSuccess = "Tüm kiralanan araclar listeleniyor(detayları ile)";
        public static string CreditCardAdded = "Kredi Kartı Eklendi";
        public static string CreditCardDeleted = "Kredi Kartı Silindi";
        public static string CreditCardUpdated = "Kredi Kartı Güncellendi";
        public static string FindexAdded = "findex eklendi";
        public static string FindexDeleted = "findex silindi";
        public static string FindexUpdated = "findex güncellendi";
    }
}
