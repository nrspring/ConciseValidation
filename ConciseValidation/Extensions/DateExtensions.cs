using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConciseValidation.Extensions
{
    public static class DateExtensions
    {
        public static ValidatorItem<t> IsDate<t>(this ValidatorItem<t> item, string errorMessage)
        {
            var returnResponse = new ValidatorItem<t>()
            {
                ParentValidator = item.ParentValidator,
                FieldName = item.FieldName,
                FieldValue = item.FieldValue,
                CanContinue = false,
                FieldDescription = item.FieldDescription
            };

            if (item.CanContinue)
            {
                if (string.IsNullOrWhiteSpace(item.FieldValue))
                {
                    returnResponse.CanContinue = true;
                }
                else
                {
                    DateTime value = System.DateTime.MinValue;
                    if (!DateTime.TryParse(item.FieldValue, out value))
                    {
                        var newError = new ValidatorError()
                        {
                            Field = item.FieldName,
                            Message = errorMessage
                        };

                        item.ParentValidator.ValidatorErrors.Add(newError);
                    }
                    else
                    {
                        returnResponse.CanContinue = true;
                    }
                }
            }
            return returnResponse;
        }

        public static ValidatorItem<t> IsDate<t>(this ValidatorItem<t> item)
        {
            return item.IsDate(string.Format("{0} must be a valid date.", item.FieldDescription));
        }

        public static ValidatorItem<t> MaxDate<t>(this ValidatorItem<t> item, DateTime value, string errorMessage)
        {
            var returnResponse = new ValidatorItem<t>()
            {
                ParentValidator = item.ParentValidator,
                FieldName = item.FieldName,
                FieldValue = item.FieldValue,
                CanContinue = false,
                FieldDescription = item.FieldDescription
            };

            if (item.CanContinue)
            {
                if (string.IsNullOrWhiteSpace(item.FieldValue))
                {
                    returnResponse.CanContinue = true;
                }
                else
                {
                    DateTime parseValue = System.DateTime.MinValue;
                    if (!DateTime.TryParse(item.FieldValue, out parseValue) || parseValue > value)
                    {
                        var newError = new ValidatorError()
                        {
                            Field = item.FieldName,
                            Message = errorMessage
                        };

                        item.ParentValidator.ValidatorErrors.Add(newError);
                    }
                    else
                    {
                        returnResponse.CanContinue = true;
                    }
                }
            }
            return returnResponse;
        }

        public static ValidatorItem<t> MaxDate<t>(this ValidatorItem<t> item, DateTime value)
        {
            return item.MaxDate(value,
                                string.Format("{0} has a maximum date of {1}.", item.FieldDescription,
                                              value.ToString("MM/dd/yyyy")));
        }










        public static ValidatorItem<t> MinDate<t>(this ValidatorItem<t> item, DateTime value, string errorMessage)
        {
            var returnResponse = new ValidatorItem<t>()
            {
                ParentValidator = item.ParentValidator,
                FieldName = item.FieldName,
                FieldValue = item.FieldValue,
                CanContinue = false,
                FieldDescription = item.FieldDescription
            };

            if (item.CanContinue)
            {
                if (string.IsNullOrWhiteSpace(item.FieldValue))
                {
                    returnResponse.CanContinue = true;
                }
                else
                {
                    DateTime parseValue = System.DateTime.MinValue;
                    if (!DateTime.TryParse(item.FieldValue, out parseValue) || parseValue < value)
                    {
                        var newError = new ValidatorError()
                        {
                            Field = item.FieldName,
                            Message = errorMessage
                        };

                        item.ParentValidator.ValidatorErrors.Add(newError);
                    }
                    else
                    {
                        returnResponse.CanContinue = true;
                    }
                }
            }
            return returnResponse;
        }

        public static ValidatorItem<t> MinDate<t>(this ValidatorItem<t> item, DateTime value)
        {
            return item.MinDate(value,
                                string.Format("{0} has a minimum date of {1}.", item.FieldDescription,
                                              value.ToString("MM/dd/yyyy")));
        }
    }
}
