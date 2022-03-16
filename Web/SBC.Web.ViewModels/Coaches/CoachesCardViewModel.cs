namespace SBC.Web.ViewModels.Coaches
{
    using System.Collections.Generic;

    public class CoachesCardViewModel
    {
        public IEnumerable<CoachCardViewModel> Portions { get; set; }

        public bool ViewMoreAvailable { get; set; }
    }
}
