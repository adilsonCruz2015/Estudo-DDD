using ADC.Portal.Solution.Domain.ObjectValue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADC.Portal.Solution.Test.Domain.ObjectValue
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void Category_IsValid()
        {
            Category category = new Category("Eletrodomésticos")
            {
                Description = "uma descrição qualquer"
            };

            Assert.IsTrue(category.IsValid());
        }

        [TestMethod]
        public void Category_Name_Empty_Invalid()
        {
            Category category = new Category("")
            {
                Description = "uma descrição qualquer"
            };

            Assert.IsFalse(category.IsValid());
        }

        [TestMethod]
        public void Category_Name_null_Invalid()
        {
            Category category = new Category(null)
            {
                Description = "uma descrição qualquer"
            };

            Assert.IsFalse(category.IsValid());
        }

        [TestMethod]
        public void Category_Description_Max_Length_Invalid()
        {
            Category category = new Category("Eletrodomésticos")
            {
                Description = "uma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualquer"
            };

            Assert.IsFalse(category.IsValid());
        }

        [TestMethod]
        public void Category_Description_Max_Length_Valid()
        {
            Category category = new Category("Eletrodomésticos")
            {
                Description = "auma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição qualqueruma descrição q"
            };

            Assert.IsTrue(category.IsValid());
        }
    }
}
