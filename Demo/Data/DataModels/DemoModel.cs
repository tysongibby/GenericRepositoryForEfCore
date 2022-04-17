using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Data.DataModels
{
    // Represents the sub-segments of the chosen segment of study
    // Child of Subject, Parent of Flashcard
    [Table("DemoModel")]
    public class DemoModel
    {
        [Key]        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
  

    }
}
