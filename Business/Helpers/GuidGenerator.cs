

namespace Business.Helpers
{
    //Generates a new GUID for the Id property of the Contact class.
    public static class GuidGenerator
    {
        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
