using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iManage.Models
{
    public class Client
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Occupation { get; set; }

        [DisplayFormat(DataFormatString ="dd-MMM-yyyy HH:mm")]
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [NotMapped]
        public string CreatedDateFormatted { get { return CreatedDate.ToString("dd MMMM yyyy HH:mm"); } }

        [NotMapped]
        public string ModifiedDateFormatted { get { return ModifiedDate?.ToString("dd MMMM yyyy HH:mm"); } }

        public Client()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
