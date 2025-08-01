using Microsoft.AspNetCore.Components;

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
}