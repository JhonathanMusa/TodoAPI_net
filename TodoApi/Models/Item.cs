using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Tarea { get; set; }
    }
}
