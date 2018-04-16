using System.ComponentModel.DataAnnotations;

namespace Vegas.Controllers.Resources
{
    public class KeyValuePairResource
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}