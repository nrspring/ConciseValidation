using System;
using ConciseValidation.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConciseValidation_UnitTests.ExtensionMethods
{
    [TestClass]
    public class IntegerExtensions
    {
        [TestMethod]
        public void Given_I_Pass_A_Value_And_It_Is_More_Than_The_Max_Then_It_Will_Return_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestInt = 17
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestInt).MaxValue(16);

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestInt", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("TestInt has a maximum value of 16.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Pass_A_Value_And_It_Is_Less_Than_The_Max_Then_It_Will_Return_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestInt = 17
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestInt).MaxValue(20);

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }

        [TestMethod]
        public void Given_I_Pass_A_Value_And_It_Is_Less_Than_The_Min_Then_It_Will_Return_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestInt = 17
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestInt).MinValue(20);

            //Assert
            Assert.AreEqual(1, validator.ValidatorErrors.Count);
            Assert.AreEqual("TestInt", validator.ValidatorErrors[0].Field);
            Assert.AreEqual("TestInt has a minimum value of 20.", validator.ValidatorErrors[0].Message);
        }

        [TestMethod]
        public void Given_I_Pass_A_Value_And_It_Is_More_Than_The_Min_Then_It_Will_Return_The_Proper_Response()
        {
            //Arrange
            var test = new Support.TestItem()
            {
                TestInt = 17
            };
            var validator = new ConciseValidation.Validator<Support.TestItem>(test);

            //Act
            validator.ValidateField(item => item.TestInt).MinValue(16);

            //Assert
            Assert.AreEqual(0, validator.ValidatorErrors.Count);
        }
    }
}
