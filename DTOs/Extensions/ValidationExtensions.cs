using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Extensions;

public static class ValidationExtensions
{
    public static IDictionary<string, string[]> ToDictonary(this ValidationResult validationResult) =>
        validationResult.Errors
        .GroupBy(x => x.PropertyName)
        .ToDictionary(
            g => g.Key,
            g => g.Select(x => x.ErrorMessage).ToArray());
}

