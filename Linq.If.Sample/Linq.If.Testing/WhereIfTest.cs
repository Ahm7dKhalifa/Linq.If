using Linq.If.Sample;
using Linq.If.Sample.Enums;
using Linq.If.Testing.Common;
using System;
using System.Linq;
using Xunit;

namespace Linq.If.Testing
{
    public class WhereIfTest
    {
        private readonly DatabaseContext context;
        public WhereIfTest()
        {
            context=LinqIfDbContextFactory.Create();
        }
        [Theory]
        [InlineData(3, 2)]
        [InlineData(2, 1)]
        [InlineData(1, 1)]
        [InlineData(0,4)]
        public void GetProductsByCategory(int category,int expected)
        {
           var products=  context.Products.WhereIf(category > 0,p=>p.CategoryId==category).ToList();
            Assert.Equal(expected, products.Count);
        }
        ~WhereIfTest() { context.Dispose(); }
    }
}
