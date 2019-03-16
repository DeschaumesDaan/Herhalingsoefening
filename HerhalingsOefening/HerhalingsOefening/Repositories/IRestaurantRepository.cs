using System.Collections.Generic;
using System.Threading.Tasks;
using HerhalingsOefening.Models;

namespace HerhalingsOefening.Repositories
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetRestaurants();
    }
}