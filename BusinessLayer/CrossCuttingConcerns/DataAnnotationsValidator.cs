﻿namespace BusinessLayer.CrossCuttingConcerns
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;

    public class DataAnnotationsValidator : IValidator
    {
        private readonly IServiceProvider container;

        public DataAnnotationsValidator(IServiceProvider container)
        {
            this.container = container;
        }

        [DebuggerStepThrough]
        void IValidator.ValidateObject(object instance)
        {
            var context = new ValidationContext(instance, null, null);

            // Throws an exception when instance is invalid.
            Validator.ValidateObject(instance, context, validateAllProperties: true);
        }
    }
}
