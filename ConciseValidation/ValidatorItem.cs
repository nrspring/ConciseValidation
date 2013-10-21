using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConciseValidation
{
    public partial class ValidatorItem<rootType,fieldType>
    {
        public Validator<rootType> ParentValidator { get; set; }
        public string FieldName { get; set; }
        public fieldType FieldValue { get; set; }
        public Boolean CanContinue { get; set; }
        public string FieldDescription { get; set; }

        public ValidatorItem<rootType, fieldType> SetFieldDescription(string description)
        {
            var returnResponse = new ValidatorItem<rootType,fieldType>()
                {
                    ParentValidator = this.ParentValidator,
                    FieldName = this.FieldName,
                    FieldValue = this.FieldValue,
                    CanContinue = true,
                    FieldDescription = description
                };

            return returnResponse;
        }
    }
}
