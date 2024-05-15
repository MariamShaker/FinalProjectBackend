using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.ApplicationUser.Command.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Command.Validations
{
	public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
	{
		#region Fields
		

		#endregion
		#region Constructors
		public ChangePasswordValidator()
		{
			
			ApplyValidationsRules();
			ApplyCustomValidationsRules();
		}

		#endregion
		#region Handle Functions
		public void ApplyValidationsRules()
		{

			RuleFor(x => x.Id)
				.NotEmpty().WithMessage("Must Not Empty")
			.NotNull().WithMessage("Must Not Null");
				

			RuleFor(x => x.CurrentPassword)
				 .NotEmpty().WithMessage("Must Not Empty")
				 .NotNull().WithMessage("Must Not Null");
			RuleFor(x => x.NewPassword)
				 .NotEmpty().WithMessage("Must Not Empty")
				 .NotNull().WithMessage("Must Not Null");
			RuleFor(x => x.ConfirmPassword)
				 .Equal(x => x.NewPassword).WithMessage("ConfirmPassword Must Equal NewPassword");

		}

		public void ApplyCustomValidationsRules()
		{

		}

		#endregion
	}
}
