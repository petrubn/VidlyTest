using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidlyTest.Models
{
    public class MembershipType
    {
        /*[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }

        public static readonly int Unknown = 0;
        public static readonly int Weekly = 1;*/
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }

        public static readonly int Daily = 0;
        public static readonly int Weekly = 1;
        
    }
}