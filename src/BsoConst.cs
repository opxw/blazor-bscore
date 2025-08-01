using FastEnumUtility;

namespace Opx.Blazor.BsCore
{
	public static class BsoConst
	{
		public enum ChildContentPos
		{
			Inside,
			After,
			Before
		}

		public enum HtmlTagKind
		{
			Element,
			Attribute,
			Content
		}

		public enum ThemeColor
		{
			[Label("light")]
			Light,
			[Label("dark")]
			Dark,
		}

		public enum ColorKind
		{
			[Label("primary")]
			Primary,
			[Label("success")]
			Success,
			[Label("info")]
			Info,
			[Label("warning")]
			Warning,
			[Label("danger")]
			Danger,
			[Label("dark")]
			Dark,
			[Label("secondary")]
			Secondary,
			[Label("light")]
			Light,
			[Label("white")]
			White,
			[Label("")]
			NotSet
		}

		public enum ElementSize
		{
			[Label("lg")]
			Large,
			[Label("md")]
			Medium,
			[Label("sm")]
			Small,
			[Label("")]
			NotSet
		}

		public enum NavMenuKind
		{
			Group,
			Item
		}
	}
}
