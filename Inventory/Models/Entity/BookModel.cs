using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory.Models.Entity
{
    public class BookModel
    {

        public int BookModelId { get; set; }

        [Required(ErrorMessage = "Please specify a title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please specify the description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please specify a rating")]
        public string Rating { get; set; }



    }
}