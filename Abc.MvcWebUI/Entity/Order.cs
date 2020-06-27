using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    public class Order //Container temel bilgiler burada olur.
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }

        public string Username { get; set; }
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }

        public List<OrderLine> OrderLines { get; set; }

    }

    public class OrderLine //Her elemanı temsil eden satır. Her bir eleman için geren detay bilgiler. Buraya gelen bilgiler tamamlanmış kayıtlar.
    {
        public int Id { get; set; }

        public int OrderId { get; set; } //Yabancı anahtar. Order classının idsi.
        public virtual Order Order { get; set; } //Her bir orderdan orderLine tablosundan bir ordera gidebilmek için. Virtual: LeasyLoading kavramını etkin hale getirmek için.

        public int Quantity { get; set; }
        public double Price { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}