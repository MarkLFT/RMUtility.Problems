using System.Text.Json.Serialization;

namespace RMUtility.Business.Models;

[JsonSerializable(typeof(Rate))]
internal partial class RateContext : JsonSerializerContext
{ }
