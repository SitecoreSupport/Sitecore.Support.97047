namespace Sitecore.Support.Data.Validators.FieldValidators
{
  using Sitecore.Data.Validators;
  using System;
  using System.Runtime.Serialization;

  [Serializable]
  public class RequiredFieldValidator : StandardValidator
  {
    #region Original code

    public RequiredFieldValidator()
    {
    }

    protected RequiredFieldValidator(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    #endregion

    #region Modified code

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
    #endregion

    #region Original code

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

    #endregion
  }
}