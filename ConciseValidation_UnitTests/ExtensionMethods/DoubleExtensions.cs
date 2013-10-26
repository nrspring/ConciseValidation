using System;
using ConciseValidation.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConciseValidation_UnitTests.ExtensionMethods
{
    [TestClass]
    public class DoubleExtensions
    {
        [TestMethod]
        public void Given_I_Pass_A_Value_And_It_Is_More_Than_The_Max_Then_It_Will_Return_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestDouble = 17.3
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestDouble).MaxValue(16.5);

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestDouble", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("TestDouble has a maximum value of 16.5.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Pass_A_Value_And_It_Is_Less_Than_The_Max_Then_It_Will_Return_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestDouble = 17.3
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestDouble).MaxValue(20.2);

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Pass_A_Value_And_It_Is_Less_Than_The_Min_Then_It_Will_Return_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestDouble = 17.3
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestDouble).MinValue(20.2);

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestDouble", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("TestDouble has a minimum value of 20.2.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Pass_A_Value_And_It_Is_More_Than_The_Min_Then_It_Will_Return_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestDouble = 17.3
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestDouble).MinValue(16.5);

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }
    }
}
