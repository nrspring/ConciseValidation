using System;
using System.Collections.Generic;
using ConciseValidation.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConciseValidation_UnitTests.ExtensionMethods
{
    [TestClass]
    public class PredicateExtenstions
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
    }
}
