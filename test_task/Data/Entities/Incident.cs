using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_task.Data.Entities
{
    public class Incident
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
