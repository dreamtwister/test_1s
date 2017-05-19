using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core
{
    public class AuthorViewModel
    {
        /// <summary>
        /// identifier
        /// </summary>
        [Required()]
        public int Id { get; set; }

        /// <summary>
        /// Author name
        /// </summary>
        [Display(Name = "Author")]
        [Required()]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
