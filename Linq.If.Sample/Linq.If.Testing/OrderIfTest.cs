using Linq.If.Sample;
using Linq.If.Sample.Enums;
using Linq.If.Testing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Linq.If.Testing
{
    public class OrderIfTest
    {
        private readonly DatabaseContext context;
        public OrderIfTest()
        {
            context = LinqIfDbContextFactory.Create();
        }
        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { 0, new List<string> { "Apple","BMW", "Pandol 500 Tabs","Pandol Extra Tabs" } };
            yield return new object[] { 1, new List<string> { "BMW", "Pandol Extra Tabs", "Apple", "Pandol 500 Tabs" }};
            yield return new object[] { 2, new List<string> { "Pandol 500 Tabs","Pandol Extra Tabs", "Apple","BMW" } };
        }
        [Theory]
        [MemberData(nameof(Data))]
        public void GetProductsOrderByIf(int productSortBy,List<string> expected)
        {
            var products = context.Products
                .OrderByIf(productSortBy==1,p=>p.Quantity)
                .OrderByIf(productSortBy == 2, p => p.Price)
                .OrderByIf(productSortBy == 3, p => p.ExpiryDate)
                .Select(p=>p.Name).ToList();
            
            Assert.True(Enumerable.SequenceEqual(products,expected));
        }
        
        ~OrderIfTest() { context.Dispose(); }
    }
}
