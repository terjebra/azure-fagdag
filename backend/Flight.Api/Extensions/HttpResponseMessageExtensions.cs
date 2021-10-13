using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Flight.Api.Extensions
{
    public static class HttpResponseMessageExtensions
    {

        public static async Task<T> Deserialize<T>(this HttpResponseMessage message)
        {
            var serializer = new XmlSerializer(typeof(T));
            var responseBody = await message.Content.ReadAsStringAsync();
            using var stringReader = new StringReader(responseBody);
            return (T) serializer.Deserialize(stringReader);
        }
    }
}