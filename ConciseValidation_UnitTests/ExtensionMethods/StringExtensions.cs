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
            validator.ValidateField(item => item.TestString).NotNull().MaxLength(3);

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
            validator.ValidateField(item => item.TestString).NotNull().MaxLength(3);

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
            validator.ValidateField(item => item.TestString).NotNull().MaxLength(4);

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
            validator.ValidateField(item => item.TestString).NotNull("Test Error Message");

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
            validator.ValidateField(item => item.TestString).NotNull("Test Error Message");

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
            validator.ValidateField(item => item.TestString).NotNull();

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
            validator.ValidateField(item => item.TestString).MaxLength(10, "Test Error Message");

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
            validator.ValidateField(item => item.TestString).MaxLength(3, "Test Error Message");

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
            validator.ValidateField(item => item.TestString).MaxLength(3);

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
            validator.ValidateField(item => item.TestString).MinLength(3, "Test Error Message");

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
            validator.ValidateField(item => item.TestString).MinLength(5, "Test Error Message");

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
            validator.ValidateField(item => item.TestString).MinLength(5);

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
            validator.ValidateField(item => item.TestString).MatchRegex(".e..", "Test Error Message");

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
            validator.ValidateField(item => item.TestString).MatchRegex(".a..", "Test Error Message");

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
                validator.ValidateField(item => item.TestString).MatchPhone();

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
            validator.ValidateField(item => item.TestString).MatchPhone();

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
            validator.ValidateField(item => item.TestString).MatchPhone("Test Error Message");

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
                validator.ValidateField(item => item.TestString).MatchEmail();

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
            validator.ValidateField(item => item.TestString).MatchEmail();

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
            validator.ValidateField(item => item.TestString).MatchEmail("Test Error Message");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("Test Error Message", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_IsDate_And_I_Have_Passed_Valid_Values_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            List<String> dateList = new List<string>()
                {
                    "1/1/2013",
                    "01/01/2013",
                    "1/1/13",
                    "01/01/13",
                    "2/29/2012",
                    "2/29/12",
                    "01-Jan-2013",
                    "1-Jan-2013",
                    "1-January-2013",
                    "01-January-2013",
                    "01-Jan-13",
                    "1-Jan-13",
                    "1-January-13",
                    "01-January-13",
                    "29-Feb-2012",
                    "29-February-2012",
                    "29-Feb-12",
                    "29-February-12"
                };

            foreach (var currentItem in dateList)
            {
                //Arrange
                var test = new Support.TestItem() { TestString = currentItem };
                var validator = new ConciseValidation.Validator<Support.TestItem>(test);

                //Act
                validator.ValidateField(item => item.TestString).IsDate();

                //Assert
                Assert.AreEqual(0, validator.ValidatorErrors.Count);
            }
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_IsDate_And_I_Have_Passed_Invalid_Values_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            List<String> dateList = new List<string>()
                {
                    "1/32/2013",
                    "0/1/2013",
                    "2/29/2013",
                    "test",
                    "32-January-2013",
                    "1-Februarie-2013"
                };

            foreach (var currentItem in dateList)
            {
                //Arrange
                var test = new Support.TestItem() { TestString = currentItem };
                var validator = new ConciseValidation.Validator<Support.TestItem>(test);

                //Act
                validator.ValidateField(item => item.TestString).IsDate();

                //Assert
                Assert.AreEqual(1, validator.ValidatorErrors.Count);
                Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
                Assert.AreEqual("TestString must be a valid date.", validator.ValidatorErrors[0].Message);
            }
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_IsNumeric_And_It_Is_Numeric_Then_Return_Proper_response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "3.14" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestString).IsNumber();

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_IsNumeric_And_It_Is_Not_Numeric_Then_Return_Proper_response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "aaaa" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestString).IsNumber("Test Error Message");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("Test Error Message", validator.ValidatorErrors[0].Message);
        }
    }
}
