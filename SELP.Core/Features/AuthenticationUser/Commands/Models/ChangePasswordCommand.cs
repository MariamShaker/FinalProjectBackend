﻿using MediatR;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Command.Models
{
	public class ChangePasswordCommand : IRequest<Response<string>>
	{
		public string Id { get; set; }
		public string CurrentPassword { get; set; }
		public string NewPassword {  get; set; }
		public string ConfirmPassword { get; set;}
	}
}