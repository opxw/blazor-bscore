using FastEnumUtility;
using Microsoft.AspNetCore.Components;
using static Opx.Blazor.BsCore.BsoConst;

public static class Utils
{
	public static string Hash(string s)
	{
		return $"#{s}";
	}

	public static string IconSizeClass(int size, int defVal = 16)
	{
		var value = defVal;
		if (size > 0)
			value = size;

		return $"fs-{value}";
	}

	public static string DashPattern(string text)
	{
		var a = text.Split(' ').ToList();
		var result = "";

		foreach (var s in a)
		{
			result += $"{s.Trim()}-";
		}

		return result.Substring(0, result.Length - 1);
	}

	public static string Append(this string dest, string src)
	{
		var temp = dest.TrimEnd();
		temp += $"{dest} {src}";

		return temp;
	}

	public static List<string> GetPaths(this NavigationManager s)
	{
		var path = s.Uri.Replace(s.BaseUri, string.Empty);

		return path.Split("/").ToList<string>();
	}

	public static string UCaseFirst(this string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			return s;
		}
		if (s.Length == 1)
		{
			return s.ToUpper();
		}
		return char.ToUpper(s[0]) + s.Substring(1);
	}

	public static string FirstLetter(this string s)
	{
		if (string.IsNullOrWhiteSpace(s))
			return "";

		return s.Substring(0, 1).ToUpper();
	}

	// Margin Bottom
	public static string mb(int value)
	{
		if (value <= -1)
			return "";

		return $"mb-{value}";
	}

	// Medium Breakpoint
	public static string md(int value)
	{
		if (value <= -1)
			return "";

		return $"md-{value}";
	}

	// Large Breakpoint
	public static string lg(int value)
	{
		if (value <= -1)
			return "";

		return $"lg-{value}";
	}

	public static string GetClass(this SpinnerStyle style)
	{
		return $"spinner-{style.GetLabel()}";
	}

	public static string GetClass(this SpinnerSize size, SpinnerStyle style, SpinnerTextPosition textPos = SpinnerTextPosition.Right)
	{
		var value = size.GetLabel(); 
		var result = string.Empty;

		switch (size)
		{
			case SpinnerSize.Small:
				result = $"{style.GetClass()}{value}";
				break;
			case SpinnerSize.Large:
			case SpinnerSize.XtraLarge:
				result = value;
				break;
			default:
				result = "";
				break;
		}

		if (textPos == SpinnerTextPosition.Right)
			result += " me-2";

		return result;
	}
}