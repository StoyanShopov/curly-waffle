namespace SBC.Web.ViewModels.Company
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CompanyViewModel : IMapFrom<Company>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
