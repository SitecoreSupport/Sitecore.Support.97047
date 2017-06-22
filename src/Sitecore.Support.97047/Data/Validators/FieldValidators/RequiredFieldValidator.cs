namespace Sitecore.Support.Data.Validators.FieldValidators
{
    using Sitecore.Data.Validators;
    using System;
    using System.Runtime.Serialization;

    public class RequiredFieldValidator : StandardValidator
    {
        public RequiredFieldValidator()
        {
        }

        protected RequiredFieldValidator(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected override ValidatorResult Evaluate()
        {
            if (!string.IsNullOrEmpty(base.ControlValidationValue))
            {
                return ValidatorResult.Valid;
            }
            if (base.GetItem() == null)
            {
                return ValidatorResult.Unknown;
            }
            string[] arguments = new string[] { base.GetFieldDisplayName() };
            base.Text = base.GetText("Field \"{0}\" must contain a value.", arguments);
            return base.GetFailedResult(ValidatorResult.CriticalError);
        }

        protected override ValidatorResult GetMaxValidatorResult()
        {
           return base.GetFailedResult(ValidatorResult.CriticalError);
        }

        public override string Name 
        {
            get
            {
               return "Required";
            }
        }
    }
}