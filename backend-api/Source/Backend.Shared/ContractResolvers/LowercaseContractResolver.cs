using Newtonsoft.Json.Serialization;

namespace Backend.Shared.ContractResolvers
{
	public class LowercaseContractResolver : DefaultContractResolver
	{
		protected override string ResolvePropertyName(string propertyName)
		{
			return propertyName.ToLower();
		}
	}
}
