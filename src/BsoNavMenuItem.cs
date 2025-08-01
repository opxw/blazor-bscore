using static Opx.Blazor.BsCore.BsoConst;

namespace Opx.Blazor.BsCore
{
	public class BsoNavMenuItem
	{
		public int Id { get; set; } = 0;
		public string Title { get; set; } = string.Empty;
		public string Icon { get; set; } = string.Empty;
		public string Href { get; set; } = string.Empty;
		public int ParentId { get; set; } = -1;
		public NavMenuKind MenuKind { get; set; }
	}
}