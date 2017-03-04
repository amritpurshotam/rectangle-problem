using System.ComponentModel.DataAnnotations;

namespace RectangleProblem.Models.Rectangle
{
    public class GenerateRectangleInput
    {
        [Required]
        [Range(3, 30, ErrorMessage = "Number of rectangles must be between 3 and 30 inclusive.")]
        [Display(Name = "Number of rectangles")]
        public byte NumberOfRectangles { get; set; }
    }
}