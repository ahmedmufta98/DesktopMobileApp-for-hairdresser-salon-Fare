using eHairdresserSalonFare.Model;
using System.Collections.Generic;

namespace eHairdresserSalonFare.Api.IRepository
{
    public interface IRecommendedHairdressersRepository
    {
        List<Hairdresser> RecommendedHairdressers(int hairdresserId);
    }
}
