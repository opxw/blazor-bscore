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
		public string? MarkupString { get; set; }
		public Dictionary<string, Action> Bindings { get; set; } = new();
	}

	public class HtmlAttributeBase
	{
		private string _tag = string.Empty;
		private List<BsoHtmlBuilderItem> _tags = new List<BsoHtmlBuilderItem>();
		private Dictionary<string, Action> _events = new();
		private Dictionary<string, Action> _binds = new();

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

		public HtmlAttributeBase Event(string name, Action a)
		{
			_events.Add(name, a);
			return this;
		}

		public HtmlAttributeBase Bind(string name, string value, Action a)
		{
			var item = new BsoHtmlBuilderItem()
			{
				Name = name,
				Value = value,
				Kind = HtmlTagKind.Binder
			};

			item.Bindings.Add(name, a);

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

		public HtmlAttributeBase Content(string? content)
		{
			if (content == null)
				return this;

			var count = _tags.Where(x => x.Kind == HtmlTagKind.Content).Count();
			_tags.Add(new BsoHtmlBuilderItem()
			{
				Kind = HtmlTagKind.Content,
				SortOrder = _tags.Count + 1,
				Group = count + 1,
				MarkupString = content
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

				/// events
				foreach (var ev in _events)
				{
					b.AddAttribute(2, ev.Key, EventCallback.Factory.Create(this, ev.Value));
				}


				//binding
				//foreach (var bd in _binds)
				//{
				//	b.AddAttribute(3, bd.Key, EventCallback.Factory.CreateBinder(this, value => bd.Value = value, bd.Value));
				//}

				/// BINDINGS
				var bindGroups = _tags.Where(x => x.Kind == HtmlTagKind.Binder).OrderBy(x => x.Name).ToList();
				foreach (var bind in bindGroups)
				{
					b.AddAttribute(3, bind.Name, EventCallback.Factory.Create(this, bind.Bindings.FirstOrDefault().Value));
				}

				/// CONTENT
				var contents = _tags.Where(x => x.Kind == HtmlTagKind.Content).OrderBy(x => x.SortOrder).ToList();
				foreach (var c in contents)
				{
					if (!string.IsNullOrWhiteSpace(c.MarkupString))
						b.AddContent(4, new MarkupString(c.MarkupString));
					else
						b.AddContent(4, c.Content);
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
