using System.ComponentModel.DataAnnotations;

namespace wt_lab4_4mvc_vinnik.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите владельца счёта")]
        public string Owner { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите номер счёта")]
        public string AccountNumber { get; set; } = string.Empty;

        [Range(0, 100000000, ErrorMessage = "Баланс не может быть отрицательным")]
        public decimal Balance { get; set; }

        public string AccountType { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
