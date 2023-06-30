using System.Text.Json.Serialization;

namespace dotnet_rpn.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RgpClass
    {
        Knight = 1,
        Mage = 2,
        Cleric = 3
    }
}