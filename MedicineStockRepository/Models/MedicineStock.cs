using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MedicineStockRepository.Models
{
    public partial class MedicineStock
    {
        [Required]
        public string MedicineId { get; set; }
        [Required]
        public string MedicineName { get; set; }
        [Required]
        public string ChemicalComposition { get; set; }
        [Required]
        public string TargetAilment { get; set; }
        [Required]
        public DateTime DateOfExpiry { get; set; }
        [Required]
        [Range(1, Int32.MaxValue,ErrorMessage ="Value should be greater than one")]
        public int? NumberOfTabletsInStock { get; set; }
    }
}
