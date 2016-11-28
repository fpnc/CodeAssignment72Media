using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeAssignment72Media.Models
{
    public class Numbers
    {
        [Required(ErrorMessage = "Input required")]
        [RegularExpression("^[0-9]+(,[0-9]+)*$", ErrorMessage = "Error")]
        public string Input { get; set; }

        public string Message { get; set; }
    }
}