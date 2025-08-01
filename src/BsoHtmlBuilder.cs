using Microsoft.AspNetCore.Components;
using static Opx.Blazor.BsCore.BsoConst;

namespace Opx.Blazor.BsCore
{
	public class BsoHtmlBuilderItem
	{
		public string Name { get; set; }
		public string Value { get; set; }
		public int SortOrder { get; set; } = 0;
		public int Group { get; set; }
		public HtmlTagKind Kind { get; set; }
		public RenderFragment? Content { get; set; }
	}

	public class HtmlAttributeBase
	{
		private string _tag = string.Empty;
		private List<BsoHtmlBuilderItem> _tags = new List<BsoHtmlBuilderItem>();
		List<RenderFragment> _contents = new();

		public HtmlAttributeBase(string tag)
		{
			_tag = tag;
		}

		public HtmlAttributeBase Attribute(string name, string? value)
		{
			if (value == null)
				return this;

			var group = _tags.Where(x => x.Kind == HtmlTagKind.Element).LastOrDefault();
			var groupId = 0;

			if (group != null)
				groupId = group.Group;

			_tags.Add(new BsoHtmlBuilderItem
			{
				Name = name,
				Value = value,
				SortOrder = _tags.Count + 1,
				Kind = HtmlTagKind.Attribute,
				Group = groupId
			});

			return this;
		}

		public HtmlAttributeBase Content(RenderFragment? content)
		{
			if (content == null)
				return this;

			var count = _tags.Where(x => x.Kind == HtmlTagKind.Content).Count();
			_tags.Add(new BsoHtmlBuilderItem()
			{
				Kind = HtmlTagKind.Content,
				SortOrder = _tags.Count + 1,
				Group = count + 1,
				Content = content
			});

			return this;
		}

		public RenderFragment Render()
		{
			return (RenderFragment)(b =>
			{
				var tag = _tag;
				b.OpenElement(0, tag);

				/// ATTRIBUTES
				var attrGroups = _tags.Where(x => x.Kind == HtmlTagKind.Attribute).GroupBy(x => x.Name).ToList();
				var newAttrs = new List<BsoHtmlBuilderItem>();
				foreach (var group in attrGroups)
				{
					var values = _tags.Where(x => x.Name == group.Key).OrderBy(x => x.SortOrder).ToList();
					var valueOfName = "";
					foreach (var value in values)
					{
						valueOfName += $"{value.Value} ";
					}
					valueOfName = valueOfName.TrimEnd();
					b.AddAttribute(1, group.Key, valueOfName);
				}

				/// CONTENT
				var contents = _tags.Where(x => x.Kind == HtmlTagKind.Content).OrderBy(x => x.SortOrder).ToList();
				foreach (var c in contents)
				{
					b.AddContent(2, c.Content);
				}

				b.CloseElement();
			});
		}
	}

	public static class Builder
	{
		public static HtmlAttributeBase Build(string tag)
		{
			return new HtmlAttributeBase(tag);
		}

		public static HtmlAttributeBase Build(string tag, string? id = null, string? name = null)
		{
			return new HtmlAttributeBase(tag)
				.Attribute("id", id)
				.Attribute("name", name);
		}
	}
}
