using System.ComponentModel.DataAnnotations;
using TicketFinder.Attributes;

namespace TicketFinder.Models.ViewModels
{
    public class GetBusJourneyFormData
    {
        [Required(ErrorMessage = "This field is required.")]
        public int OriginId { get; set; }

        public string Origin { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public int DestinationId { get; set; }

        public string Destination { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DateMustBeInFuture(ErrorMessage = "The date cannot be before today.")]
        public DateTime DepartureDate { get; set; }
    }
}
