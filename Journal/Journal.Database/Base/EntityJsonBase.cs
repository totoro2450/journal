using System.Text.Json.Serialization;
using Journal.Database.Interfaces;
using Journal.Shared.Helpers;

namespace Journal.Database.Base
{
    public class EntityJsonBase: EntityBase, IEntityJsonBase
    {
        public string Name { get; set; } = string.Empty;
        public string? Json { get; set; }
        public string Type { get; set; } = typeof(Object).AssemblyQualifiedName!;
        public bool IsEncrypted { get; set; }

        [JsonIgnore]
        public object? Value
        {
            get => Deserialize(Json);
            set => Json = Serialize(value);
        }

        private string? Serialize(object? value)
        {
            string? json = JsonHelper.ToJsonOrNull(value);
            if (value == null)
            {
                Type = typeof(Object).AssemblyQualifiedName!;
                return null;
            }
            else
            {
                Type = value.GetType().AssemblyQualifiedName!;
            }

            if (IsEncrypted)
                json = EncryptionHelper.Encrypt(json, Name);

            return json;
        }

        private object? Deserialize(string? json)
        {
            if (string.IsNullOrEmpty(json)) return null;

            if (IsEncrypted)
                json = EncryptionHelper.Decrypt(json, Name);

            var targetType = System.Type.GetType(Type);
            dynamic value = JsonHelper.FromJsonOrNull(json, targetType!)!;
            return value;
        }
    }
}
