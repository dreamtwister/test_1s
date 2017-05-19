using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            AuthorsList = new List<string>();
        }

        /// <summary>
        /// Book identifier
        /// </summary>
        public string BookId { get; set; }

        /// <summary>
        /// Book title
        /// </summary>
        [Display(Name = "Title")]
        [Required()]
        [StringLength(30, ErrorMessage = "Title must up to 30 characters")]
        public string Title { get; set; }

        /// <summary>
        /// Book authors for show in table
        /// </summary>
        [Display(Name = "Authors")]
        public string Authors { get; set; }

        /// <summary>
        /// Book authors for edit
        /// </summary>
        [Display(Name = "Athors")]
        public List<string> AuthorsList { get; set; }

        /// <summary>
        /// Author last name
        /// </summary>
        [Display(Name = "Last name")]
        public string AuthorLastName { get; set; }

        /// <summary>
        /// Author first name
        /// </summary>
        [Display(Name = "First name")]
        public string AuthorFirstName { get; set; }

        /// <summary>
        /// Page count
        /// </summary>
        [Display(Name = "Page count")]
        [Required()]
        [Range(0, 10000, ErrorMessage = "Page count must between 0 and 10000 characters")]
        public int PageCount { get; set; }

        /// <summary>
        /// Publisher
        /// </summary>
        [Display(Name = "Publisher")]
        [StringLength(30, ErrorMessage = "Must up to 30 characters")]
        public string Publisher { get; set; }

        /// <summary>
        /// The year of publication
        /// </summary>
        [Display(Name = "Year of publication")]
        [Required()]
        [Range(1800, int.MaxValue, ErrorMessage = "Not earlier then 1800")]
        public int Year { get; set; }

        /// <summary>
        /// Book image
        /// </summary>
        [Display(Name = "Image")]
        public string BookImageUrl { get; set; }
    }
}
