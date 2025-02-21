using mission6_Nimmer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Movie
{
    [Key]
    public int MovieId { get; set; }  // Primary key

    [ForeignKey("Category")]
    public int? CategoryId { get; set; } // Nullable Foreign Key

    public Category? Category { get; set; } // Nullable Navigation Property

    [Required]
    public string Title { get; set; }

    [Range(1888, 2099, ErrorMessage = "Year must be between 1888 and 2099")]
    public int Year { get; set; }

    public string? Director { get; set; } // Nullable (optional)

    public string? Rating { get; set; } // Nullable (optional)

    public bool Edited { get; set; }

    public string? LentTo { get; set; }
    public bool CopiedToPlex { get; set; }
    public string? Notes { get; set; }
}

