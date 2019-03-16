using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http.Testing;
using HerhalingsOefening.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MCT.HerhalingsOefening
{
    [TestClass]
    public class RestaurantRepositoryTest
    {
        [TestMethod]
        public async Task Get_Restaurant_With_Valid_Url()
        {
            
            using (var httpTest = new HttpTest())
            {
                //arrange
                var repoRestaurant = new RestaurantRepository();

                //act 

                await repoRestaurant.GetRestaurants();

                //assert
                httpTest.ShouldHaveCalled("https://restaurantfunction.azurewebsites.net/api/restaurants")
                    .WithVerb(HttpMethod.Get);
            }

            
        }
    }
}
