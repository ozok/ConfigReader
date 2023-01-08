using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Configuration : BaseEntity
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Value { get; set; }

        [Required]
        [StringLength(128)]
        public string ApplicationName { get; set; }
    }
}
