using Microsoft.AspNetCore.Authorization;
using Solution.Model.Enums;
using System;
using System.Linq;

namespace Solution.Web.UI.Attributes
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
	public class AuthorizationAttribute : AuthorizeAttribute
	{
		public AuthorizationAttribute(params Roles[] roles)
		{
			Roles = string.Join(", ", roles.Select(role => Enum.GetName(role.GetType(), role)));
		}
	}
}
