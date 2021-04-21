using eHairdresserSalonFare.Model.DTO;
using System.Collections.Generic;

namespace eHairdresserSalonFare.Api.IRepository
{
    public interface IHairdresserHairstyleRepository
    {
        Model.HairdresserHairstyle Insert(int hairdresserId, int hairstyleId);
        Model.HairdresserHairstyle TryFind(int hairdresserId, int hairstyleId);
        List<Model.Hairstyle> FindHairstylesOfHairdresser(int hairdresserId);
        List<Model.Hairdresser> FindHairdressersForRating(int clientId);
    }
}
