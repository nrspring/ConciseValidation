using System;
using System.Dynamic;
using ConciseValidation.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConciseValidation_UnitTests.ExtensionMethods
{
    [TestClass]
    public class PropertyNameAsString
    {
        [TestMethod]
        public void Given_I_Have_A_String_Value_And_I_Pass_The_Property_Name_Then_It_Should_Process_Correctly()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "aaaa" };
            var validatorPass = new ConciseValidation.Validator<Support.TestItem>(test);
            var validatorFail = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validatorFail.ValidateField<string>("TestString").MaxLength(3,"Test Error Message");
            validatorPass.ValidateField<string>("TestString").NotNull();

            //Assert
            Assert.AreEqual(1, validatorFail.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validatorFail.ValidatorErrors[0].Field);
            Assert.AreEqual("Test Error Message", validatorFail.ValidatorErrors[0].Message);

            Assert.AreEqual(0, validatorPass.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Have_A_Int_Value_And_I_Pass_The_Property_Name_Then_It_Should_Process_Correctly()
        {
            //Arrange
            var test = new Support.TestItem() { TestInt = 17 };
            var validatorPass = new ConciseValidation.Validator<Support.TestItem>(test);
            var validatorFail = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validatorFail.ValidateField<int>("TestInt").MaxValue(3, "Test Error Message");
            validatorPass.ValidateField<int>("TestInt").MinValue(3);

            //Assert
            Assert.AreEqual(1, validatorFail.ValidatorErrors.Count);
            Assert.AreEqual("TestInt", validatorFail.ValidatorErrors[0].Field);
            Assert.AreEqual("Test Error Message", validatorFail.ValidatorErrors[0].Message);

            Assert.AreEqual(0, validatorPass.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Have_A_Double_Value_And_I_Pass_The_Property_Name_Then_It_Should_Process_Correctly()
        {
            //Arrange
            var test = new Support.TestItem() { TestDouble = 17 };
            var validatorPass = new ConciseValidation.Validator<Support.TestItem>(test);
            var validatorFail = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validatorFail.ValidateField<double>("TestDouble").MaxValue(3, "Test Error Message");
            validatorPass.ValidateField<double>("TestDouble").MinValue(3);

            //Assert
            Assert.AreEqual(1, validatorFail.ValidatorErrors.Count);
            Assert.AreEqual("TestDouble", validatorFail.ValidatorErrors[0].Field);
            Assert.AreEqual("Test Error Message", validatorFail.ValidatorErrors[0].Message);

            Assert.AreEqual(0, validatorPass.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Have_A_DateTime_Value_And_I_Pass_The_Property_Name_Then_It_Should_Process_Correctly()
        {
            //Arrange
            var test = new Support.TestItem() { TestDateTime = new DateTime(2015,1,2) };
            var validatorPass = new ConciseValidation.Validator<Support.TestItem>(test);
            var validatorFail = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validatorFail.ValidateField<DateTime>("TestDateTime").MaxDate(new DateTime(2015, 1, 1), "Test Error Message");
            validatorPass.ValidateField<DateTime>("TestDateTime").MaxDate(new DateTime(2015, 1, 3));

            //Assert
            Assert.AreEqual(1, validatorFail.ValidatorErrors.Count);
            Assert.AreEqual("TestDateTime", validatorFail.ValidatorErrors[0].Field);
            Assert.AreEqual("Test Error Message", validatorFail.ValidatorErrors[0].Message);

            Assert.AreEqual(0, validatorPass.ValidatorErrors.Count);
        }
    }
}
