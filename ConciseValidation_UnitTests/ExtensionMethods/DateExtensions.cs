using System;
using System.Security.AccessControl;
using ConciseValidation.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConciseValidation_UnitTests.ExtensionMethods
{
    [TestClass]
    public class DateExtensions
    {
        [TestMethod]
        public void Given_I_Pass_A_Date_That_Is_Beyond_The_Max_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestDateTime = new System.DateTime(2001,11,11) };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<DateTime>(item => item.TestDateTime).MaxDate(new System.DateTime(1992, 12, 24));

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestDateTime", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("TestDateTime has a maximum date of 12/24/1992.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Pass_A_Date_That_Is_Not_Beyond_The_Max_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestDateTime = new System.DateTime(2001, 11, 11) };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<DateTime>(item => item.TestDateTime).MaxDate(new System.DateTime(2013, 01, 01));

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Pass_A_Date_That_Is_At_The_Max_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestDateTime = new System.DateTime(2001, 11, 11) };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<DateTime>(item => item.TestDateTime).MaxDate(new System.DateTime(2001, 11, 11));

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }










        [TestMethod]
        public void Given_I_Pass_A_Date_That_Is_Before_The_Min_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestDateTime = new System.DateTime(2001, 11, 11) };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<DateTime>(item => item.TestDateTime).MinDate(new System.DateTime(2013, 1, 1));

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestDateTime", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("TestDateTime has a minimum date of 01/01/2013.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Pass_A_Date_That_Is_After_The_Min_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestDateTime = new System.DateTime(2001, 11, 11) };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<DateTime>(item => item.TestDateTime).MinDate(new System.DateTime(1992, 12, 24));

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Pass_A_Date_That_Is_At_The_Min_Then_I_Should_Be_Returned_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem() { TestDateTime = new System.DateTime(2001, 11, 11) };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField<DateTime>(item => item.TestDateTime).MinDate(new System.DateTime(2001, 11, 11));

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }
    }
}
