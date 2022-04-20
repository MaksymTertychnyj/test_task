using System.ComponentModel.DataAnnotations;

namespace test_task.Data.Entities
{
    public class RequestParameter
    {
        [Required]
        public string accountName { get; set; }

        public string contactFirstName { get; set; }

        public string contactLastName { get; set; }

        [Required]
        public string contactEmail { get; set; }

        public string incidentDescription { get; set; }
    }
}
