using System;
using System.Security.AccessControl;
using ConciseValidation.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConciseValidation_UnitTests.ExtensionMethods
{
    [TestClass]
    public class PredicateExtensions
    {
        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_By_An_Inline_Function_And_The_String_Fails_Then_I_Will_Be_Returned_The_Expected_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestString = "Bob"
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestString)
                     .ValidateByFunction(x => x.FieldValue != "Bob", "The Name Cannot Be Bob.");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("The Name Cannot Be Bob.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_By_An_Inline_Function_And_The_String_Passes_Then_I_Will_Be_Returned_The_Expected_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestString = "Mikenna"
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestString)
                     .ValidateByFunction(x => x.FieldValue != "Bob", "The Name Cannot Be Bob.");

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_By_A_Predicate_And_The_String_Fails_Then_I_Will_Be_Returned_The_Expected_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestString = "Bob"
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestString)
                     .ValidateByFunction(x => CheckFirstName(x.FieldValue), "The Name Cannot Be Bob.");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("The Name Cannot Be Bob.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_By_A_Predicate_Function_And_The_String_Passes_Then_I_Will_Be_Returned_The_Expected_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestString = "Mikenna"
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestString)
                     .ValidateByFunction(x => CheckFirstName(x.FieldValue), "The Name Cannot Be Bob.");

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        private bool CheckFirstName(string value)
        {
            return value != "Bob";
        }


        [TestMethod]
        public void Given_I_Want_To_Validate_A_Date_By_An_Inline_Function_And_It_Fails_Then_I_Will_Be_Returned_The_Expected_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestDateTime = new System.DateTime(2001,11,11)
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestDateTime)
                     .ValidateByFunction(x => x.FieldValue == new System.DateTime(1992,12,24), "The Date is wrong.");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestDateTime", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("The Date is wrong.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_Date_By_An_Inline_Function_And_It_Passes_Then_I_Will_Be_Returned_The_Expected_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestDateTime = new System.DateTime(1992, 12, 24)
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestDateTime)
                     .ValidateByFunction(x => x.FieldValue == new System.DateTime(1992, 12, 24), "The Date is wrong.");

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_Date_By_A_Predicate_And_It_Fails_Then_I_Will_Be_Returned_The_Expected_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestDateTime = new System.DateTime(2011, 11, 11)
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestDateTime)
                     .ValidateByFunction(x => CheckDate(x.FieldValue), "The Date is wrong.");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestDateTime", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("The Date is wrong.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_Date_By_A_Predicate_Function_And_It_Passes_Then_I_Will_Be_Returned_The_Expected_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestDateTime = new System.DateTime(1992, 12, 24)
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestDateTime)
                     .ValidateByFunction(x => CheckDate(x.FieldValue), "The Date is wrong.");

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        private bool CheckDate(System.DateTime value)
        {
            return value == new System.DateTime(1992, 12, 24);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_An_Int_By_An_Inline_Function_And_The_String_Fails_Then_I_Will_Be_Returned_The_Expected_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestInt = 17
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestInt)
                     .ValidateByFunction(x => x.FieldValue != 17, "The number cannot be 17.");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestInt", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("The number cannot be 17.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_An_Int_By_An_Inline_Function_And_The_String_Passes_Then_I_Will_Be_Returned_The_Expected_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestInt = 18
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestInt)
                     .ValidateByFunction(x => x.FieldValue != 17, "The number cannot be 17.");

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_An_Int_By_A_Predicate_And_The_String_Fails_Then_I_Will_Be_Returned_The_Expected_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestInt = 17
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestInt)
                     .ValidateByFunction(x => CheckInt(x.FieldValue), "The number cannot be 17.");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestInt", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("The number cannot be 17.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_An_Int_By_A_Predicate_Function_And_The_String_Passes_Then_I_Will_Be_Returned_The_Expected_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestInt = 18
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestInt)
                     .ValidateByFunction(x => CheckInt(x.FieldValue), "The number cannot be 17.");

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        private bool CheckInt(int value)
        {
            return value != 17;
        }

















        [TestMethod]
        public void Given_I_Want_To_Validate_A_Double_By_An_Inline_Function_And_The_String_Fails_Then_I_Will_Be_Returned_The_Expected_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestDouble = 17.3
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestDouble)
                     .ValidateByFunction(x => x.FieldValue != 17.3, "The number cannot be 17.3.");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestDouble", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("The number cannot be 17.3.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_Double_By_An_Inline_Function_And_The_String_Passes_Then_I_Will_Be_Returned_The_Expected_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestDouble = 18.3
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestDouble)
                     .ValidateByFunction(x => x.FieldValue != 17.3, "The number cannot be 17.3.");

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_Double_By_A_Predicate_And_The_String_Fails_Then_I_Will_Be_Returned_The_Expected_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestDouble = 17.3
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestDouble)
                     .ValidateByFunction(x => CheckDouble(x.FieldValue), "The number cannot be 17.3.");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestDouble", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("The number cannot be 17.3.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_Double_By_A_Predicate_Function_And_The_String_Passes_Then_I_Will_Be_Returned_The_Expected_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestDouble = 18.3
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestDouble)
                     .ValidateByFunction(x => CheckDouble(x.FieldValue), "The number cannot be 17.3.");

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        private bool CheckDouble(double value)
        {
            return value != 17.3;
        }
    }
}
