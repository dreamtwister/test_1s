using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core
{
    public class AuthorsValidator
    {
        public ValidationResult Validate(List<string> authors)
        {
            var result = new ValidationResult ();

            if (authors == null || !authors.Any())
            {
                result.Messages.Add("must by at least one author");
            }

            if (authors != null)
                foreach (var author in authors)
                {
                    var splitAuthor = author.Trim().Split();
                    if (splitAuthor.Count() < 2)
                    {
                        result.Messages.Add(author + " must have first and last name");
                    }
                    else
                    {
                        if (splitAuthor[0].Length > 20)
                            result.Messages.Add(author + " First name is too large(must up to 20 characters)");
                        if (splitAuthor[1].Length > 20)
                            result.Messages.Add(author + " Last name is too large(must up to 20 characters)");
                    }

                }
            result.Result = !result.Messages.Any();
            return result;
        }
    }

    public class ValidationResult
    {
        public ValidationResult()
        {
            Messages = new List<string>();
        }

        /// <summary>
        /// Result of validation
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// Validation Messages
        /// </summary>
        public List<string> Messages { get; set; }
    }
}
