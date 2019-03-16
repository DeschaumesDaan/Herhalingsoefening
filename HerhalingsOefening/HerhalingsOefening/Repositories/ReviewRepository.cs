using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using HerhalingsOefening.Models;

namespace HerhalingsOefening.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        public async Task<List<Review>> GetReviewsById(string restaurantId)
        {
            try
            {
                var getResponse =
                    await
                        $"https://restaurantfunction.azurewebsites.net/api/reviews?restaurantId={restaurantId}"
                            .GetJsonAsync<List<Review>>();
                return getResponse;
            }
            catch (FlurlHttpException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task AddReviewAsync(string id, Review review)
        {
            try
            {
                var postResponse = await string.Format("https://restaurantfunction.azurewebsites.net/api/reviews?restaurantId={0}", id).PostJsonAsync(review);
                if (postResponse.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    new ArgumentException(postResponse.StatusCode.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
