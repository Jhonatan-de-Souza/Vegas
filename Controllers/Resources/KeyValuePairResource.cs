using System.ComponentModel.DataAnnotations;

namespace Vega.Controllers.Resources
{
    public class KeyValuePairResource
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}