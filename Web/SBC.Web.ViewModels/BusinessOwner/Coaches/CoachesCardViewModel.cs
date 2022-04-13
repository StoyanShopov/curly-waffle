namespace SBC.Web.ViewModels.BusinessOwner.Coaches
{
    using System.Collections.Generic;

    public class CoachesCardViewModel
    {
        public bool ViewMoreAvailable { get; set; }

        public IEnumerable<CoachCardViewModel> Portions { get; set; }
    }
}
