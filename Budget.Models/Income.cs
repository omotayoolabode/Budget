using System.ComponentModel.DataAnnotations;

namespace Budget.Models
{
    public class Income
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Income Name")]
        public string IncomeName { get; set; }
        [Display(Name = "Income Description")]
        public string IncomeDescription { get; set; }
    }
}
