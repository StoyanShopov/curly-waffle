namespace SBC.Services.Data.Coach.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Models;

    public interface ILanguageCoachService
    {
        List<LanguageCoach> GetAllLanguagesCoach(int coachId);

        void DeleteAllLanguagesCoach(List<LanguageCoach> languagesCoach);
    }
}
