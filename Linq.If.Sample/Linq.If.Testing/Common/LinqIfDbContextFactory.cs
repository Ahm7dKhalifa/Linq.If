using Linq.If.Sample;
using Linq.If.Sample.Enums;
using Linq.If.Sample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Linq.If.Testing.Common
{
    public class LinqIfDbContextFactory
    {
        public static DatabaseContext Create()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var context = new DatabaseContext(options,true);
            context.Database.EnsureCreated();
            SeedProducts(context);
            context.SaveChanges();
            return context;
        }

        private static void SeedProducts(DatabaseContext context)
        {
            var products = new List<Product>() {
                 new Product(){
                     Name="Apple"
                    ,ProductTypeId=(int)ProductTypesEnum.SerialNumber,
                     CategoryId=(int)CategoriesEnum.Mobile
                    ,Quantity=99
                    ,ExpiryDate=null
                    ,Price=1000},
                new Product(){
                     Name="BMW"
                    ,ProductTypeId=(int)ProductTypesEnum.SerialNumber,
                    CategoryId=(int)CategoriesEnum.Car
                   ,Quantity=10
                   ,ExpiryDate=null
                   ,Price=200000},
                new Product()
                {
                   Name=  "Pandol 500 Tabs"
                    ,ProductTypeId=(int) ProductTypesEnum.Barcode
                    ,CategoryId=(int)CategoriesEnum.Drug
                    ,Quantity= 200
                   , ExpiryDate=new DateTime(2023,11,1)
                   ,Price= 10
                }
                  ,new Product(){
                    Name= "Pandol Extra Tabs"
                   ,ProductTypeId=(int)ProductTypesEnum.Barcode
                   ,CategoryId=(int)CategoriesEnum.Drug
                   , Quantity=50
                   , ExpiryDate=new DateTime(2024,1,1)
                   ,Price=15
                    }
            };
            context.Products.AddRange(products);
        }
    }
}
