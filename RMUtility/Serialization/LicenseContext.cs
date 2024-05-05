using System.Text.Json.Serialization;

namespace RMUtility.Business.Models;

[JsonSerializable(typeof(RawLicense))]
internal partial class LicenseContext : JsonSerializerContext
{ }
