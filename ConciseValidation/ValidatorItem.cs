using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConciseValidation
{
    public partial class ValidatorItem<t>
    {
        public Validator<t> ParentValidator { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public Boolean CanContinue { get; set; }
        public string FieldDescription { get; set; }

        public ValidatorItem<t> SetFieldDescription(string description)
        {
            var returnResponse = new ValidatorItem<t>()
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
