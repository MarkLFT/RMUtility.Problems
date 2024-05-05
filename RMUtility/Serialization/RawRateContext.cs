using System.Text.Json.Serialization;
using RMUtility.Services;

namespace RMUtility.Business.Models;

[JsonSerializable(typeof(RawRate))]
internal partial class RawRateContext : JsonSerializerContext
{ }
