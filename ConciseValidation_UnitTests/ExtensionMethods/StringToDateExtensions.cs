using System;
using System.Collections.Generic;
using ConciseValidation.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConciseValidation_UnitTests.ExtensionMethods
{
    [TestClass]
    public class StringToDateExtensions
    {
        [TestMethod]
        public void Given_I_Pass_A_Valid_Date_And_I_Test_For_Maximum_I_Should_Get_The_Proper_Response()
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
                DateTime maxDate = new System.DateTime(2000, 1, 1);
                System.DateTime.TryParse(currentItem, out maxDate);
                validator.ValidateField(item => item.TestString).IsDateConvertToDate().MaxDate(maxDate.AddDays(1));

                //Assert
                Assert.AreEqual(0, validator.ValidatorErrors.Count);
            }
        }

        [TestMethod]
        public void Given_I_Pass_A_Valid_Date_And_I_Test_For_Past_The_Maximum_Date_I_Should_Get_The_Proper_Response()
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
                DateTime maxDate = new System.DateTime(2000, 1, 1);
                System.DateTime.TryParse(currentItem, out maxDate);
                validator.ValidateField(item => item.TestString).IsDateConvertToDate().MaxDate(maxDate.AddDays(-1));
                string testString = string.Format("TestString has a maximum date of {0}.", maxDate.AddDays(-1).ToString("MM/dd/yyyy"));

                //Assert
                Assert.AreEqual(1, validator.ValidatorErrors.Count);
                Assert.AreEqual(testString, validator.ValidatorErrors[0].Message);
            }
        }

        [TestMethod]
        public void Given_I_Pass_A_Valid_Date_And_I_Test_For_Minimum_I_Should_Get_The_Proper_Response()
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
                DateTime maxDate = new System.DateTime(2100, 1, 1);
                System.DateTime.TryParse(currentItem, out maxDate);
                validator.ValidateField(item => item.TestString).IsDateConvertToDate().MinDate(maxDate.AddDays(-1));

                //Assert
                Assert.AreEqual(0, validator.ValidatorErrors.Count);
            }
        }

        [TestMethod]
        public void Given_I_Pass_A_Valid_Date_And_I_Test_For_Past_The_Minimum_Date_I_Should_Get_The_Proper_Response()
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
                DateTime maxDate = new System.DateTime(2000, 1, 1);
                System.DateTime.TryParse(currentItem, out maxDate);
                validator.ValidateField(item => item.TestString).IsDateConvertToDate().MinDate(maxDate.AddDays(+1));
                string testString = string.Format("TestString has a minimum date of {0}.", maxDate.AddDays(+1).ToString("MM/dd/yyyy"));

                //Assert
                Assert.AreEqual(1, validator.ValidatorErrors.Count);
                Assert.AreEqual(testString, validator.ValidatorErrors[0].Message);
            }
        }

        [TestMethod]
        public void Given_I_Want_To_Validate_A_String_IsDateConvertToDate_And_I_Have_Passed_Invalid_Values_Then_I_Should_Be_Returned_The_Proper_Response()
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
                validator.ValidateField(item => item.TestString).IsDateConvertToDate();

                //Assert
                Assert.AreEqual(1, validator.ValidatorErrors.Count);
                Assert.AreEqual("TestString", validator.ValidatorErrors[0].Field);
                Assert.AreEqual("TestString must be a valid date.", validator.ValidatorErrors[0].Message);
            }
        }
    }
}
