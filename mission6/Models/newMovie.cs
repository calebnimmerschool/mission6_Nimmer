using System.ComponentModel.DataAnnotations; // Import necessary namespace

namespace mission6_Nimmer.Models
{
    public class NewMovie
    {
        [Key]
        public int MovieId { get; set; }  // ✅ Primary key

        [Required]
        public string Category { get; set; }  // ✅ Ensure it's required

        [Required]
        public string Title { get; set; }  // ✅ Title should not be nullable

        [Range(1888, 2099, ErrorMessage = "Year must be between 1888 and 2099")]
        public int Year { get; set; }  // ✅ Adds validation (movies started in 1888)

        [Required]
        public string Director { get; set; }  // ✅ Ensure it's required

        [Required]
        public string Rating { get; set; }  // ✅ Required because of dropdown options

        public bool Edited { get; set; }  // ✅ Bool fields are fine without `[Required]`

        //[Display(Name = "Lent To")]
        public string? LentTo { get; set; }  // ✅ Fixed naming convention (see issue #2)

        public string Notes { get; set; }  // ✅ Optional, so `[Required]` not needed
    }
}

