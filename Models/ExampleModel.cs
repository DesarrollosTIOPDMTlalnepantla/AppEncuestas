using System.ComponentModel.DataAnnotations;

public class ExampleModel
{
    [Required]
    [StringLength(10, ErrorMessage = "Nombre muy largo.")]
    public string? Name { get; set; }
}