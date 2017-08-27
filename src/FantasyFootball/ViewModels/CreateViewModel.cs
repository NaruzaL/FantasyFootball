using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyFootball.ViewModels
{
    public class CreateViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
