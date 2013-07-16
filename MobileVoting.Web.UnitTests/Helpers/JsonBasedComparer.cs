using Newtonsoft.Json;

namespace MobileVoting.Web.UnitTests.Helpers
{
    public class JsonBasedComparer
    {
        public static bool Compare<T>(T first, T second)
        {
            var firstSerialised = JsonConvert.SerializeObject(first);
            var secondSerialised = JsonConvert.SerializeObject(second);
            return firstSerialised == secondSerialised;
        }
    }
}
