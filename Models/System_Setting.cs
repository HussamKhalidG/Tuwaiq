using System.ComponentModel.DataAnnotations;
using Website1.ViewModels;

namespace Website1.Models
{
    public class System_Setting
    {
        [Key]
        public int Id { get; set; }

        public string Key { get; set; }


        public string Value { get; set; }

    }
}
