using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace MvcApplication1.Models
{
    public class MessageFromClient
    {
        [Required(ErrorMessage = "Наберите сообщение")]
        public string Message { get; set; }
        [Key]
        public string Time { get; set; }
       // public string Code { get; set; }

    }
}