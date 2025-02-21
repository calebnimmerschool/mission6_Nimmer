using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    public int CategoryId { get; set; }  // Primary key

    [Required]
    public string CategoryName { get; set; }  // Required category name

    public List<Movie>? Movies { get; set; } // Nullable Navigation Property
}



