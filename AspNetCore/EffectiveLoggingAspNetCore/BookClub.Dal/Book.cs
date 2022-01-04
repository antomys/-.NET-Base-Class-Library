using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClub.Dal;

[Table("Book")]
public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Title { get; set; } = null!;
    
    public string Author { get; set; } = null!;
    
    public string Category { get; set; } = null!;
    
    public string Genre { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
}