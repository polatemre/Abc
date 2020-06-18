using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>//eğer model değişmişse veritabanını oluştur.
    {
        protected override void Seed(DataContext context)
        {
            //buraya test verilerimizi ekliyoruz.

            var kategoriler = new List<Category>()
            {
                new Category(){ Name="Kamera", Description="Kamera ürünleri"},
                new Category(){ Name="Bilgisayar", Description="Bilgisayar ürünleri"},
                new Category(){ Name="Elektronik", Description="Elektronik ürünleri"},
                new Category(){ Name="Telefon", Description="Telefon ürünleri"},
                new Category(){ Name="Beyaz Eşya", Description="Beyaz Eşya ürünleri"}
            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges(); //Yazdık çünkü ürünü eklemeden önce kategorilerin eklenmesi gerekiyor.

            //aynı işlemi ürünler içinde yapıyoruz.

            var urunler = new List<Product>()
            {
                new Product(){ Name="Canon EOS 250d 18-55mm WiFi® DSLR Fotoğraf Makinesi", Description="Hediye; Çanta + 32GB Kart+UV Filtre + Kart Okuyucu + Temizlik Kiti Hediye; Çanta + 32GB Kart+UV Filtre + Kart Okuyucu + Temizlik Kiti Hediye; Çanta + 32GB Kart+UV Filtre + Kart Okuyucu + Temizlik Kiti", Price=4100, Stock=85, IsApproved=false, CategoryId=1, IsHome=true, Image="1.jpg"},
                new Product(){ Name="Canon EOS 250d 18-55mm WiFi® DSLR Fotoğraf Makinesi", Description="Canon Türkiye Garanti + Ücretsiz Kargo Canon Türkiye Garanti + Ücretsiz Kargo Canon Türkiye Garanti + Ücretsiz Kargo", Price=3900, Stock=170, IsApproved=true, CategoryId=1, IsHome=true, Image="2.jpg"},
                new Product(){ Name="Canon EOS 250d 18-55mm IS STM WiFi® DSLR Fotoğraf Makinesi", Description="Hediye; Çanta + 32GB Kart+UV Filtre + Kart Okuyucu + Temizlik Kiti", Price=4300, Stock=200, IsApproved=true, CategoryId=1, IsHome=true, Image="3.jpg"},
                new Product(){ Name="Nikon D3500 AF-P 18-55mm (Yeni Nesil) DSLR Fotoğraf Makinesi", Description="Hediye; Çanta + 32GB Kart+UV Filtre + Kart Okuyucu + Temizlik Kiti", Price=3100, Stock=20, IsApproved=false, CategoryId=1, Image="4.jpg"},
                new Product(){ Name="Canon EOS 2000d 18-55mm IS II 24.1mp Wi-Fi®DSLR Fotoğraf Makinesi", Description="Hediye; Çanta + 32GB Kart+UV Filtre + Kart Okuyucu + Temizlik Kiti", Price=3570, Stock=100, IsApproved=true, CategoryId=1, Image="5.jpg"},

                new Product(){ Name="HP 255 G7 9TV56ES01 Ryzen5 2500U 8GB 256SSD FHD 15.6 DOS", Description="Hp Türkiye Garantili * Ücretsiz Kargo * Sıfır Ürün", Price=3570, Stock=100, IsApproved=false, CategoryId=2, Image="1.jpg"},
                new Product(){ Name="LENOVO 81MT0046TXN6 V145 A4-9125 8GB 128GB SSD 15.6 DOS", Description="LENOVO TÜRKİYE GARANTİLİ!!! ADINIZA FATURALI!!! KAPALI KUTU!!!", Price=2650, Stock=50, IsApproved=true, CategoryId=2, IsHome=true, Image="2.jpg"},
                new Product(){ Name="Huawei Matebook D14 AMD Ryzen 5 3500U 8GB 512GB SSD 14", Description="Huawei Türkiye Garantili+%100 Orjinal+Sıfır Kapalı Kutu+W10", Price=5150, Stock=75, IsApproved=true, CategoryId=2, Image="3.jpg"},
                new Product(){ Name="Lenovo V155-15API 81V50010TX AMD Ryzen 5 3500U 8GB 256GB 15,6 FHD", Description="** N11 ÖZEL FİYAT ** LENOVO RYZEN 5 8GB 256 SSD VEGA 8**", Price=3900,Stock=80, IsApproved=false, CategoryId=2, IsHome=true, Image="4.jpg"},
                new Product(){ Name="Lenovo V155-15API AMD Ryzen 5 3500U 8GB 256GB F.dos 81V50010TX", Description="LENOVO TÜRKİYE GARANTİLİ ADINIZA FATURALI KAPALI KUTU", Price=3900, Stock=85, IsApproved=true, CategoryId=2, Image="5.jpg"},

                new Product(){ Name="11 Aşamalı 12 LT Metal Tanklı LG Membran Seç. Su Arıtma Cihazı", Description="Ankastre Lüks Musluk - Anti Bakteriyel Tank - Nano Mineral", Price=2000, Stock=123, IsApproved=true, CategoryId=3, IsHome=true, Image="1.jpg"},
                new Product(){ Name="Philips FC9323/07 PowerPro Compact 750 W Toz Torbasız Elektrikli Süpürge", Description="Türk Philips A.Ş. Garantili ve Faturalı", Price=1500, Stock=321, IsApproved=false, CategoryId=3, IsHome=true, Image="2.jpg"},
                new Product(){ Name="Arzum AR1032 Shake'N Take Kişisel 300 W Smoothie Blender", Description="Tüm Ürünlerimiz Faturalı, Orijinal ve Garantili", Price=1000, Stock=500, IsApproved=true, CategoryId=3, Image="3.jpg"},
                new Product(){ Name="Xiaomi Mi Vacuum Cleaner Akıllı Robot Süpürge", Description="Garantili Ürün / Global Versiyon / %100 ORİJİNAL ÜRÜN", Price=500, Stock=987, IsApproved=false, CategoryId=3, Image="4.jpg"},
                new Product(){ Name="Arzum OK004 Okka Minio Türk Kahve Makinesi", Description="Tüm Ürünlerimiz Faturalı, Orijinal ve Garantili", Price=15, Stock=789, IsApproved=true, CategoryId=3, Image="5.jpg"},

                new Product(){ Name="Samsung Galaxy M31 128 GB (Samsung Türkiye Garantili)", Description="Samsung Türkiye Garantili", Price=4000, Stock=100, IsApproved=true, CategoryId=4, Image="1.jpg"},
                new Product(){ Name="Samsung Galaxy M11 Duos 32 GB (Samsung Türkiye Garantili)", Description="Samsung Türkiye Garantili", Price=3570, Stock=100, IsApproved=true, CategoryId=4, IsHome=true, Image="2.jpg"},
                new Product(){ Name="Xiaomi Redmi 8A 32 GB Duos (Xiaomi Türkiye Garantili)", Description="Orjinal ürün ,adınıza faturalı", Price=3000, Stock=100, IsApproved=false, CategoryId=4, Image="3.jpg"},
                new Product(){ Name="Xiaomi Redmi Note 8 Pro 64 GB/6 GB (Xiaomi Türkiye Garantili)", Description="Sıfır / Kapalı Kutu /Adınıza Faturalı", Price=2500, Stock=100, IsApproved=true, CategoryId=4, IsHome=true, Image="4.jpg"},
                new Product(){ Name="Huawei P30 Lite 64 GB (Huawei Türkiye Garantili)", Description="Kapalı Kutu, 2 Yıl Distribütör Garantili", Price=2000, Stock=100, IsApproved=true, CategoryId=4, Image="5.jpg"},

                //new Product(){ Name="Vestel CDE-M1102 W A+ 182 LT 6 Çekmeceli Dikey Derin Dondurucu", Description="6 Çekmeceli / Ücretsiz Kargo / 3 Yıl Garanti", Price=3750, Stock=100, IsApproved=true, CategoryId=4},
                //new Product(){ Name="Baymak Elegant Plus 12 A++ 12000Btu İnverter Klima (Montaj Dahil)", Description="Ücretsiz Montaj | Ücretsiz Kargo | 5 Yıl Garanti | 2020 Model R32", Price=3500, Stock=100, IsApproved=true, CategoryId=4},
                //new Product(){ Name="Regal Pratik BM 210 A++ 2 Programlı 12 Kişilik Bulaşık Makinesi", Description="Regal PRATIK BM 210", Price=2500, Stock=100, IsApproved=false, CategoryId=4},
                //new Product(){ Name="Vestel CD-L1103 W A+ 290 LT 7 Çek meceli Dikey Derin Dondurucu", Description="ÜCRETSİZ KARGO", Price=1000, Stock=100, IsApproved=true, CategoryId=4},
                //new Product(){ Name="Profilo CGA242X0TR A+++ 1200 Devir 9 KG Çamaşır Makinesi", Description="Profilo CGA242X0TR A+++ 1200 Devir 9 KG Çamaşır Makinesi", Price=1750, Stock=100, IsApproved=true, CategoryId=4},
            };

            foreach (var urun in urunler)
            {
                context.Products.Add(urun);

            }

            context.SaveChanges(); // burdan sonra veritabanına aktarıyor.

            base.Seed(context);
        }
    }
}