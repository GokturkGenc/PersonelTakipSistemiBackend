using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class OperationValidator : AbstractValidator<OperationClaim>
    {
        public OperationValidator()
        {
            RuleFor(op => op.Name).MinimumLength(2);
            RuleFor(op => op.Name).NotEmpty();
        }
    }
}
