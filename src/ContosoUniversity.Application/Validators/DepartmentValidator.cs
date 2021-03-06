﻿using ContosoUniversity.Core.Entities;
using FluentValidation;

namespace ContosoUniversity.Application.Validators
{
    /// <summary>
    /// Fluent Validation validator for the Department entity. 
    /// </summary>
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(a=>a.DepartmentName)
                .NotNull()
                .WithMessage("Department name cannot be empty.")
                .NotEmpty()
                .WithMessage("Department name cannot be empty.")
                .Length(3,100)
                .WithMessage("Department name must be between 3 - 100 characters in length.");
        }
    }
}
