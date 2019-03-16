using System.Collections.Generic;
using System.Threading.Tasks;
using HerhalingsOefening.Models;

namespace HerhalingsOefening.Services
{
    public interface IRestaurantAppService
    {
        Task<List<Restaurant>> GetRestaurants();
        Task<List<Review>> GetReviews(string id);
        Task AddReview(string id, Review review);
    }
}