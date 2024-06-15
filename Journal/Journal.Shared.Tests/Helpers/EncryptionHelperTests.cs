using Journal.Shared.Helpers;

namespace Journal.Shared.Tests.Helpers
{
    [TestFixture]
    public class EncryptionHelperTests
    {
        private string _key = "key";

        [Test]
        public void Encrypt_StringValue_EncryptsString()
        {
            var value = "value";

            var result = EncryptionHelper.Encrypt(value, _key);

            Assert.That(result, Is.Not.EqualTo(value));
        }

        [Test]
        public void Encrypt_JsonString_EncryptsString()
        {
            var value = "{\"key\":\"value\"}";

            var result = EncryptionHelper.Encrypt(value, _key);

            Assert.That(result, Is.Not.EqualTo(value));
        }

        [Test]
        public void Decrypt_StringValue_DecryptsString()
        {
            var value = "value";
            var encryptedValue = EncryptionHelper.Encrypt(value, _key);

            var result = EncryptionHelper.Decrypt(encryptedValue, _key);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Decrypt_JsonString_DecryptsString()
        {
            var value = "{\"key\":\"value\"}";
            var encryptedValue = EncryptionHelper.Encrypt(value, _key);

            var result = EncryptionHelper.Decrypt(encryptedValue, _key);

            Assert.That(result, Is.EqualTo(value));
        }
    }
}
