using System.ComponentModel.DataAnnotations;
using Rectangle.Common;

namespace RectangleProblem.Models.Rectangle
{
    public class GenerateRectangleInput
    {
        [Required]
        [Range(Constants.MinRectangles, Constants.MaxRectangles, ErrorMessage = "Number of rectangles must be between 3 and 30 inclusive.")]
        [Display(Name = "Number of rectangles")]
        public byte NumberOfRectangles { get; set; }
    }
}