namespace VP.CodingChallenge.WCNet.Validators;

public class WcOptionsValidator
{
    public static Boolean Validate<T>(T configObject, out List<ValidationResult> validationResults)
    {
        validationResults = [];
        if (configObject == null)
        {
            validationResults.Add(new ValidationResult($"The {nameof(configObject)} cannot be null."));
            return false;
        }

        var validationContext = new ValidationContext(configObject, null, null);

        return Validator.TryValidateObject(configObject, validationContext, validationResults, true);
    }
}

