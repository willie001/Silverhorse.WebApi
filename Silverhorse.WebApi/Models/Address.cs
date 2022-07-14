namespace Silverhorse.WebApi.Models
{
    public class Address
    {
        public string city { get; set; }
        public string street { get; set; }
        public string suite { get; set; }
        public string zipcode { get; set; }

        public Geo geo { get; set; }
    }
}
