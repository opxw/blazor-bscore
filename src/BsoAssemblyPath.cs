namespace Opx.Blazor.BsCore
{
	public class BsoAssemblyPath
	{
		private string _assemblyName;

		public string AssemblyName
		{
			get => _assemblyName;
			set => _assemblyName = value ?? throw new ArgumentNullException(nameof(value), "Assembly name cannot be null");
		}

		public BsoAssemblyPath(string assemblyName)
		{
			_assemblyName = assemblyName;
		}

		private string BasePath(string src)
		{
			return $"_content/{_assemblyName}/{src}";
		}

		public string Asset(string src)
		{
			return BasePath($"assets/{src}");
		}

		public string Vendor(string name, string src)
		{
			return Asset($"vendors/{name}/{src}");
		}

		public string Images(string src)
		{
			return Asset($"images/{src}");
		}
	}
}