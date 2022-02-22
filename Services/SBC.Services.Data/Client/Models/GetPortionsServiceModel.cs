namespace SBC.Services.Data.Client.Models
{
    using System.Collections.Generic;

    using SBC.Web.ViewModels.Administration.Client;

    public class GetPortionsServiceModel
    {
        public IEnumerable<GetPortionResponseModel> Portions { get; set; }

        public bool ViewMoreAvaliable { get; set; }
    }
}
