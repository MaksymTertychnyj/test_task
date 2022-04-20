using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_task.Data.Entities
{
    public class Account
    {
        public string Name { get; set; }
        public string IncidentName { get; set; }
        public Incident Incident { get; set; }
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
