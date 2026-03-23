namespace ManufacturerManagerAWS.Application.Validators;

public class NotPleaseSelectOrEmpty : ValidationAttribute
{
    public NotPleaseSelectOrEmpty()
    {
        ErrorMessage = "{0} is required";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string s)
        {
            if (!string.IsNullOrWhiteSpace(s) && s != "0" && s.ToLower().Replace(" ", "") != "pleaseselect")
            {
                return ValidationResult.Success;
            }
        }

        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
    }

    public override string FormatErrorMessage(string name)
    {
        return string.Format(ErrorMessageString, name);
    }
}
