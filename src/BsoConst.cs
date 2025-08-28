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
			Content,
			Event,
			Binder
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

		public enum BadgePos
		{
			TopRightCorner,
			Default
		}

		public enum ControlStyle
		{
			Default,
			[Label("outline")]
			Outline,
			[Label("soft")]
			Soft,
			[Label("bordered")]
			Bordered
		}

		public enum BadgeKind
		{
			Text,
			Dot
		}

		public enum DivLayoutKind
		{
			Container,
			Wrapper,
			NotSet
		}

		public enum ControlState
		{
			NotSet,
			Progress,
		}

		public enum UIVisibility
		{
			Visible,
			Hidden,
			NotSet
		}

		public enum SpinnerSize
		{
			[Label("-sm")]
			Small,
			[Label("")]
			Medium,
			[Label("avatar-sm")]
			Large,
			[Label("avatar-lg")]
			XtraLarge,
		}

		public enum SpinnerTextPosition
		{
			Right,
			Bottom
		}

		public enum SpinnerStyle
		{
			[Label("border")]
			Border,
			[Label("grow")]
			Grow
		}

		public enum GridSizeKind
		{
			[Label("sm")]
			Small,
			[Label("md")]
			Medium,
			[Label("lg")]
			Large,
			[Label("xl")]
			XtraLarge,
			[Label("")]
			Auto,
		}

		public enum RowVertALign
		{
			[Label("align-items-start")]
			Start,
			[Label("align-items-center")]
			Center,
			[Label("align-items-end")]
			End
		}

		public enum RowHorzAlign
		{
			[Label("justify-content-start")]
			Start,
			[Label("justify-content-center")]
			Center,
			[Label("justify-content-end")]
			End,
			[Label("justify-content-between")]
			Between,
			[Label("justify-content-around")]
			Around
		}

		public enum ValueGrowthKind
		{
			Stagnant,
			Increase,
			Decrease
		}
	}
}
