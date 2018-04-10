using System.ComponentModel.DataAnnotations;

namespace Vegas.Controllers.Resources
{
    public class FeaturesResource
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}