using System;
using System.Collections.Generic;
using ConciseValidation.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConciseValidation_UnitTests.ExtensionMethods
{
    [TestClass]
    public class DateExtensions
    {
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
        public void Given_I_Want_To_Validate_A_String_MaxDate_And_I_Have_Passed_Valid_Values_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            List<String> dateList = new List<string>()
                {
                    "4/1/2013",
                    "04/01/2013",
                    "01-April-2013",
                    "1-April-2013",
                    "01-April-13",
                    "1-April-13",
                    "01-Apr-2013",
                    "1-Apr-2013",
                    "01-Apr-13",
                    "1-Apr-13",
                };

            foreach (var currentItem in dateList)
            {
                //Arrange
                var test = new Support.TestItem() { TestString = currentItem };
                var validator = new ConciseValidation.Validator<Support.TestItem>(test);

                //Act
                validator.ValidateField(item => item.TestString).MaxDate(DateTime.Parse("4/1/13"));

                //Assert
                Assert.AreEqual(0, validator.ValidatorErrors.Count);
            }
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MaxDate_And_I_Have_Passed_Invalid_Values_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            List<String> dateList = new List<string>()
                {
                    "4/1/2013",
                    "04/01/2013",
                    "01-April-2013",
                    "1-April-2013",
                    "01-April-13",
                    "1-April-13",
                    "01-Apr-2013",
                    "1-Apr-2013",
                    "01-Apr-13",
                    "1-Apr-13",
                };

            foreach (var currentItem in dateList)
            {
                //Arrange
                var test = new Support.TestItem() { TestString = currentItem };
                var validator = new ConciseValidation.Validator<Support.TestItem>(test);

                //Act
                validator.ValidateField(item => item.TestString).MaxDate(DateTime.Parse("3/31/13"));

                //Assert
                Assert.AreEqual(1, validator.ValidatorErrors.Count);
                Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
                Assert.AreEqual("TestString has a maximum date of 03/31/2013.", validator.ValidatorErrors[0].Message);
            }
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MaxDate_With_A_Custom_Error_Message_And_I_Have_Passed_An_Invalid_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "4/1/13" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestString).MaxDate(DateTime.Parse("3/31/13"), "Test Error Message");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("Test Error Message", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MinDate_And_I_Have_Passed_Valid_Values_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            List<String> dateList = new List<string>()
                {
                    "4/1/2013",
                    "04/01/2013",
                    "01-April-2013",
                    "1-April-2013",
                    "01-April-13",
                    "1-April-13",
                    "01-Apr-2013",
                    "1-Apr-2013",
                    "01-Apr-13",
                    "1-Apr-13",
                };

            foreach (var currentItem in dateList)
            {
                //Arrange
                var test = new Support.TestItem() { TestString = currentItem };
                var validator = new ConciseValidation.Validator<Support.TestItem>(test);

                //Act
                validator.ValidateField(item => item.TestString).MinDate(DateTime.Parse("4/1/13"));

                //Assert
                Assert.AreEqual(0, validator.ValidatorErrors.Count);
            }
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MinDate_And_I_Have_Passed_Invalid_Values_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            List<String> dateList = new List<string>()
                {
                    "4/1/2013",
                    "04/01/2013",
                    "01-April-2013",
                    "1-April-2013",
                    "01-April-13",
                    "1-April-13",
                    "01-Apr-2013",
                    "1-Apr-2013",
                    "01-Apr-13",
                    "1-Apr-13",
                };

            foreach (var currentItem in dateList)
            {
                //Arrange
                var test = new Support.TestItem() { TestString = currentItem };
                var validator = new ConciseValidation.Validator<Support.TestItem>(test);

                //Act
                validator.ValidateField(item => item.TestString).MinDate(DateTime.Parse("4/2/13"));

                //Assert
                Assert.AreEqual(1, validator.ValidatorErrors.Count);
                Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
                Assert.AreEqual("TestString has a minimum date of 04/02/2013.", validator.ValidatorErrors[0].Message);
            }
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_MinDate_With_A_Custom_Error_Message_And_I_Have_Passed_An_Invalid_Value_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestString = "4/1/13" };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestString).MinDate(DateTime.Parse("4/2/13"), "Test Error Message");

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("Test Error Message", validator.ValidatorErrors[0].Message);
        }
    }
}
