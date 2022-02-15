namespace SBC.Services.Data.Client.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class GetPortionsServiceModel
    {
        public IEnumerable<GetPortionServiceModel> Portions { get; set; }

        public bool ViewMoreAvaliable { get; set; }
    }
}
