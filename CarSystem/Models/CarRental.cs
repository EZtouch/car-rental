using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSystem.Models
{
    [Table("CarRental")]
    public partial class CarRental
    {
        public int ID { get; set; }

        [Display(Name = "Car ID")]
        public short CarID { get; set; }

        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }

        public short EmployeeID { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Rental Date")]
        [DataType(DataType.Date)]
        public DateTime RentalDate { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        [Display(Name = "Paid Amount")]
        [DataType(DataType.Currency)]
        public int PaidAmount { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Actual Returned Date")]
        [DataType(DataType.Date)]
        public DateTime? ActualReturnDate { get; set; }

        public virtual Car Car { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
