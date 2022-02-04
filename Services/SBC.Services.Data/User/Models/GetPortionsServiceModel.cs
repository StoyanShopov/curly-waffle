namespace SBC.Services.Data.User.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class GetPortionsServiceModel
    {
        public IEnumerable<GetPortionServiceModel> Portions { get; set; }

        public bool ViewMoreAvaliable => this.Portions.Count() < 3 ? false : true;
    }
}
