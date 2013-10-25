using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConciseValidation.Extensions
{
    public static class StringToDateExtensions
    {
        public static ValidatorItem<rootType, DateTime> IsDateConvertToDate<rootType>(this ValidatorItem<rootType, string> item,string errorMessage)
        {
            var response = item.IsDate(errorMessage);

            var returnResponse = new ValidatorItem<rootType, DateTime>()
            {
                ParentValidator = item.ParentValidator,
                FieldName = item.FieldName,
                FieldValue = System.DateTime.Now,
                CanContinue = false,
                FieldDescription = item.FieldDescription
            };

            if (response.CanContinue)
            {
                var dateValue = System.DateTime.Now;

                if (DateTime.TryParse(item.FieldValue, out dateValue))
                {
                    returnResponse.FieldValue = dateValue;
                    returnResponse.CanContinue = true;
                }
            }

            return returnResponse;
        }

        public static ValidatorItem<rootType, DateTime> IsDateConvertToDate<rootType>(this ValidatorItem<rootType, string> item)
        {
            return item.IsDateConvertToDate(string.Format("{0} must be a valid date.", item.FieldDescription));
        }
    }
}
