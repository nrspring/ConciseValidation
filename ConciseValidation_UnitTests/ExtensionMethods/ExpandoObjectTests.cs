using System;
using System.Dynamic;
using ConciseValidation.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConciseValidation_UnitTests.ExtensionMethods
{
    [TestClass]
    public class ExpandoObjectTests
    {
        [TestMethod]
        public void Given_I_Pass_In_An_Expando_Object_Then_Things_Should_Behave_As_Expected()
        {
            //Arrange
            dynamic test = new ExpandoObject();
            test.TestString = "Bubba";
            
            var validatorPass = new ConciseValidation.Validator<ExpandoObject>(test);
            var validatorFail = new ConciseValidation.Validator<ExpandoObject>(test);

            //Act
            validatorFail.ValidateField<string>("TestString").MaxLength(3, "Test Error Message");
            validatorPass.ValidateField<string>("TestString").NotNull();

            //Assert
            Assert.AreEqual(1, validatorFail.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validatorFail.ValidatorErrors[0].Field);
            Assert.AreEqual("Test Error Message", validatorFail.ValidatorErrors[0].Message);

            Assert.AreEqual(0, validatorPass.ValidatorErrors.Count);
        }
    }
}
