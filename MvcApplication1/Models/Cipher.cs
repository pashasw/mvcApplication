using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.UI;
using System.Web.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcApplication1.Models
{
    public class Cipher
    {
        [Key]
        public int Id { get; set; }
        public int oldSymbolId { get; set; }
        public string newSymbol { get; set; }
    }
}