using System;
using System.Collections.Generic;
using ConciseValidation.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConciseValidation_UnitTests.ExtensionMethods
{
    [TestClass]
    public class StringExtensions
    {
        [TestMethod]
        public void Given_I_Chain_Validation_And_The_First_Condition_Fails_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem();
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).NotNull().MaxLength(3);

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("TestString is a required field.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Chain_Validation_And_The_Second_Condition_Fails_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem(){ TestString="Test"};
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).NotNull().MaxLength(3);

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("TestString has a maximum length of 3.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Chain_Validation_And_All_Conditions_Pass_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "Test" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).NotNull().MaxLength(4);

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_NotNull_And_I_Have_Passed_A_NonNull_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() {TestString = "Test"};
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).NotNull("Test Error Message");

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_NotNull_With_A_Custom_Error_Message_And_I_Have_Passed_A_Null_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem();
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).NotNull("Test Error Message");

            //Assert
            Assert.AreEqual(1,validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("Test Error Message", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_NotNull_And_I_Have_Passed_A_Null_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem();
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).NotNull();

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("TestString is a required field.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MaxLength_And_I_Have_Passed_A_Valid_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "Test" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).MaxLength(10, "Test Error Message");

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MaxLength_With_A_Custom_Error_Message_And_I_Have_Passed_An_Invalid_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "Test" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).MaxLength(3, "Test Error Message");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("Test Error Message", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MaxLength_And_I_Have_Passed_An_Invalid_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "Test" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).MaxLength(3);

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("TestString has a maximum length of 3.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MinLength_And_I_Have_Passed_A_Valid_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "Test" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).MinLength(3, "Test Error Message");

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MinLength_With_A_Custom_Error_Message_And_I_Have_Passed_An_Invalid_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "Test" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).MinLength(5, "Test Error Message");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("Test Error Message", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MinLength_And_I_Have_Passed_An_Invalid_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "Test" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).MinLength(5);

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("TestString has a minimum length of 5.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MatchRegex_And_I_Have_Passed_A_Valid_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "Test" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).MatchRegex(".e..", "Test Error Message");

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MatchRegex_And_I_Have_Passed_An_Invalid_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "Test" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).MatchRegex(".a..", "Test Error Message");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("Test Error Message", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MatchPhone_And_I_Have_Passed_Valid_Values_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            
            List<String> phoneList = new List<string>()
                {
                    "(614) 111-2222",
                    "614-111-2222"
                };

            foreach (var currentItem in phoneList)
            {
                //Arrange
                var test = new Support.TestItem() { TestString = currentItem };
                var validator = new ConciseValidation.Validator<Support.TestItem>(test);

                //Act
                validator.ValidateField<string>(item => item.TestString).MatchPhone();

                //Assert
                Assert.AreEqual(0, validator.ValidatorErrors.Count);
            }
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MatchPhone_And_I_Have_Passed_An_Invalid_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "Test" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).MatchPhone();

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("TestString must be a valid phone number.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MatchPhone_With_A_Custom_Error_Message_And_I_Have_Passed_An_Invalid_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "Test" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).MatchPhone("Test Error Message");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("Test Error Message", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MatchEmail_And_I_Have_Passed_Valid_Values_Then_I_Should_Be_Returned_The_Proper_Response()
        {

            List<String> emailList = new List<string>()
                {
                    "a@b.com",
                    "a@b.b.com",
                    "a.a@b.com",
                    "a.a@b.b.bom",
                    "a@b.org",
                    "a@b.net",
                    "a@b.info",
                    "a@b.gov"
                };

            foreach (var currentItem in emailList)
            {
                //Arrange
                var test = new Support.TestItem() { TestString = currentItem };
                var validator = new ConciseValidation.Validator<Support.TestItem>(test);

                //Act
                validator.ValidateField<string>(item => item.TestString).MatchEmail();

                //Assert
                Assert.AreEqual(0, validator.ValidatorErrors.Count);
            }
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MatchEmail_And_I_Have_Passed_An_Invalid_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "Test" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).MatchEmail();

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("TestString must be a valid email address.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MatchEmail_With_A_Custom_Error_Message_And_I_Have_Passed_An_Invalid_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "Test" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<string>(item => item.TestString).MatchEmail("Test Error Message");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("Test Error Message", validator.ValidatorErrors[0].Message);
        }
    }
}
