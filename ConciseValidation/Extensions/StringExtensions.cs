using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConciseValidation.Extensions
{
    public static class StringExtensions
    {
        public static ValidatorItem<rootType, string> NotNull<rootType>(this ValidatorItem<rootType, string> item, string errorMessage)
        {
            var returnResponse = new ValidatorItem<rootType, string>()
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

            return returnResponse;
        }

        public static ValidatorItem<rootType, string> NotNull<rootType>(this ValidatorItem<rootType, string> item)
        {
            return item.NotNull(string.Format("{0} is a required field.", item.FieldDescription));
        }

        public static ValidatorItem<rootType, string> MaxLength<rootType>(this ValidatorItem<rootType, string> item, int length, string errorMessage)
        {
            var returnResponse = new ValidatorItem<rootType, string>()
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
                    if (item.FieldValue.Length > length)
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

        public static ValidatorItem<rootType, string> MaxLength<rootType>(this ValidatorItem<rootType, string> item, int length)
        {
            return item.MaxLength(length, string.Format("{0} has a maximum length of {1}.", item.FieldDescription, length));
        }

        public static ValidatorItem<rootType, string> MinLength<rootType>(this ValidatorItem<rootType, string> item, int length, string errorMessage)
        {
            var returnResponse = new ValidatorItem<rootType, string>()
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
                    if (item.FieldValue.Length < length)
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

        public static ValidatorItem<rootType, string> MinLength<rootType>(this ValidatorItem<rootType, string> item, int length)
        {
            return item.MinLength(length, string.Format("{0} has a minimum length of {1}.", item.FieldDescription, length));
        }

        public static ValidatorItem<rootType, string> MatchRegex<rootType>(this ValidatorItem<rootType, string> item, string pattern, string errorMessage)
        {
            var returnResponse = new ValidatorItem<rootType, string>()
            {
                ParentValidator = item.ParentValidator,
                FieldName = item.FieldName,
                FieldValue = item.FieldValue,
                CanContinue = false,
                FieldDescription = item.FieldDescription
            };

            if (item.CanContinue)
            {
                if (!Regex.IsMatch(item.FieldValue, pattern))
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
            return returnResponse;
        }

        public static ValidatorItem<rootType, string> MatchPhone<rootType>(this ValidatorItem<rootType, string> item, string errorMessage)
        {
            string pattern = @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}";
            return item.MatchRegex(pattern, errorMessage);
        }

        public static ValidatorItem<rootType, string> MatchPhone<rootType>(this ValidatorItem<rootType, string> item)
        {
            string errorMessage = string.Format("{0} must be a valid phone number.", item.FieldDescription);
            return item.MatchPhone(errorMessage);
        }

        public static ValidatorItem<rootType, string> MatchEmail<rootType>(this ValidatorItem<rootType, string> item, string errorMessage)
        {
            string pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            return item.MatchRegex(pattern, errorMessage);
        }

        public static ValidatorItem<rootType, string> MatchEmail<rootType>(this ValidatorItem<rootType, string> item)
        {
            string errorMessage = string.Format("{0} must be a valid email address.", item.FieldDescription);
            return item.MatchEmail(errorMessage);
        }

        public static ValidatorItem<rootType, string> IsDate<rootType>(this ValidatorItem<rootType, string> item, string errorMessage)
        {
            var returnResponse = new ValidatorItem<rootType, string>()
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

        public static ValidatorItem<rootType, string> IsDate<rootType>(this ValidatorItem<rootType, string> item)
        {
            return item.IsDate(string.Format("{0} must be a valid date.", item.FieldDescription));
        }

        public static ValidatorItem<rootType, string> IsNumber<rootType>(this ValidatorItem<rootType, string> item, string errorMessage)
        {
            var returnResponse = new ValidatorItem<rootType, string>()
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
                    Decimal value = 0;
                    if (!Decimal.TryParse(item.FieldValue, out value))
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

        public static ValidatorItem<rootType, string> IsNumber<rootType>(this ValidatorItem<rootType, string> item)
        {
            return item.IsNumber(string.Format("{0} must be a valid number.", item.FieldDescription));
        }
    }
}
