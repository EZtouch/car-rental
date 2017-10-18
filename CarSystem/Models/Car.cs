using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSystem.Models
{
    [Table("Car")]
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            CarRentals = new HashSet<CarRental>();
        }

        [DisplayName("Car ID")]
        public short ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Make { get; set; }

        [Required]
        [StringLength(30)]
        public string Model { get; set; }

        public short Year { get; set; }

        [Required]
        [StringLength(20)]
        public string Type { get; set; }

        [StringLength(255)]
        public string Transmission { get; set; }

        [DisplayName("Rate Per Day")]
        public short? RatePerDay { get; set; }

        [DataType(DataType.ImageUrl)]
        [DisplayName("Image URL")]
        public string ImageURL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarRental> CarRentals { get; set; }
    }
}
