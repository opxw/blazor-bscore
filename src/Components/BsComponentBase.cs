using Microsoft.AspNetCore.Components;

namespace Opx.Blazor.BsCore.Components
{
	public partial class BsComponentBase : ComponentBase
	{
		[Parameter]
		public string? Id { get; set; }

		[Parameter]
		public string? Class { get; set; }

		[Parameter]
		public string? Name { get; set; }

		protected bool IsIdDefined => !string.IsNullOrEmpty(Id);
		protected bool IsClassDefined => !string.IsNullOrEmpty(Class);
		protected bool IsNameDefined => !string.IsNullOrEmpty(Name);

		protected void AppendClass(string value)
		{
			string s = "";
			if (IsClassDefined)
			{
				s = Class.TrimEnd().TrimStart();
				s = $"{s} {value.TrimStart().TrimEnd()}";

				Class = s;
			}
			else
				Class = value;
		}

		protected void InsertClass(string value)
		{
			if (IsClassDefined)
			{
				var s = Class.TrimStart().TrimEnd();
				Class = $"{value} {s}";
			}
			else
				Class = value;
		}
	}
}