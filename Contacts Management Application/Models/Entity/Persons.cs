using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts_Management_Application.Models.Entity
{
    [Table("Persons")]
    public class Persons
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Surname")]
        public string SurName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Phone")]
        public int Phone { get; set; }
    }
}