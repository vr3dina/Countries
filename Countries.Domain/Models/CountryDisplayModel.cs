using System.ComponentModel;

namespace Domain.Models
{
    public class CountryDisplayModel
    {
        public string Name { get; set; }

        [DisplayName("Code")]
        public string Alpha3Code { get; set; }
        public double Area { get; set; }
        public int Population { get; set; }
        public string Capital { get; set; }
        public string Region { get; set; }
    }
}
