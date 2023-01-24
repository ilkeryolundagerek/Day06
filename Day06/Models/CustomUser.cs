using Newtonsoft.Json;

namespace Day06.Models
{
    public class CustomUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
