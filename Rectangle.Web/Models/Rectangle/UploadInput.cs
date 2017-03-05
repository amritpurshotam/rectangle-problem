using System.ComponentModel.DataAnnotations;
using System.Web;

namespace RectangleProblem.Models.Rectangle
{
    public class UploadInput
    {
        [Required(ErrorMessage = "A Rectangles File is required.")]
        [Display(Name = "Rectangles File")]
        public HttpPostedFileBase RectanglesFile { get; set; }
    }
}