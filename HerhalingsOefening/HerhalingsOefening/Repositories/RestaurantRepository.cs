using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using HerhalingsOefening.Models;

namespace HerhalingsOefening.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public async Task<List<Restaurant>> GetRestaurants()
        {
            try
            {
                var result = await "https://restaurantfunction.azurewebsites.net/api/restaurants"
                    .GetJsonAsync<List<Restaurant>>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }
    }
}
