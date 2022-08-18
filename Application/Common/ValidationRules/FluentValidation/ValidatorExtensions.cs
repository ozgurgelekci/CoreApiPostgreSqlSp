using FluentValidation;

namespace Application.Common.ValidationRules.FluentValidation
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> NotEmptyMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
        {
            string errorMessage = "{PropertyName} cannot be empty.";

            return rule.Configure(config =>
            {
                config.CurrentValidator.Options.SetErrorMessage(errorMessage);
            });
        }

        public static IRuleBuilderOptions<T, TProperty> MaxLengthMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
        {
            string errorMessage = "{PropertyName} should be {MaxLength} lengths.";

            return rule.Configure(config =>
            {
                config.CurrentValidator.Options.SetErrorMessage(errorMessage);
            });
        }

        public static IRuleBuilderOptions<T, TProperty> MinLengthMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
        {
            string errorMessage = "{PropertyName} should be {MinLength} lengths.";

            return rule.Configure(config =>
            {
                config.CurrentValidator.Options.SetErrorMessage(errorMessage);
            });
        }
    }
}
