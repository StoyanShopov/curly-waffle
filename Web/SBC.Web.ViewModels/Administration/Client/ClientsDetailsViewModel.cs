namespace SBC.Web.ViewModels.Administration.Client
{
    using System.Collections.Generic;

    public class ClientsDetailsViewModel
    {
        public IEnumerable<ClientDetailsViewModel> Portions { get; set; }

        public bool ViewMoreAvaliable { get; set; }
    }
}
