using System.Collections.Generic;
using System.Threading.Tasks;
using HerhalingsOefening.Models;

namespace HerhalingsOefening.Repositories
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetReviewsById(string id);
        Task AddReviewAsync(string id, Review review);
    }
}