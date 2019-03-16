using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using HerhalingsOefening.Models;
using HerhalingsOefening.Repositories;

namespace HerhalingsOefening.Services
{
    public class RestaurantAppService : IRestaurantAppService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IReviewRepository _reviewRepository;
        public RestaurantAppService(IRestaurantRepository restaurantRepository, IReviewRepository reviewRepository)
        {
            this._restaurantRepository = restaurantRepository;
            this._reviewRepository = reviewRepository;
        }

        public async Task<List<Restaurant>> GetRestaurants()
        {
            return await _restaurantRepository.GetRestaurants();
        }

        public async Task<List<Review>> GetReviews(string restaurantId)
        {
            try
            {
                return await _reviewRepository.GetReviewsById(restaurantId);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception Message: " + e.Message);
                throw;
            }
        }

        public async Task AddReview(string id, Review review)
        {
            await _reviewRepository.AddReviewAsync(id, review);
        }

       
    }
}
