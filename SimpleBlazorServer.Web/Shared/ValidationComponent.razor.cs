using Blazorise;
using FluentValidation.Results;
using Microsoft.AspNetCore.Components;
using System.Linq;

namespace SimpleBlazorServer.Web.Shared
{
    public abstract class ValidationComponent : ComponentBase
    {
        public Validations Validations;
        public ValidationMode ValidationMode { get; set; } = ValidationMode.Manual;
        protected void SetValidationState(ValidatorEventArgs e, ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
            {
                e.Status = ValidationStatus.Error;
                e.ErrorText = validationResult.Errors.FirstOrDefault().ErrorMessage;
                return;
            }
            e.Status = ValidationStatus.None;
            e.ErrorText = "";
        }
        protected virtual bool ValidateAll() 
        {
            Validations.ClearAll();
            
            if (!Validations.ValidateAll()) 
            {
                ValidationMode = ValidationMode.Auto;
                return false;
            }

            return true;
        }
    }
}
