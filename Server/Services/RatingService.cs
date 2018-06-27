using System.Collections.Generic;
using Models;
using Server.Contracts;
using Server.Managers;

namespace Server.Services
{
    public class RatingService : IRatingService
    {
        public PersistenceManager<Rating> Manager = new PersistenceManager<Rating>();

        public bool DeleteRating(Rating rating) => Manager.Delete(rating);

        public bool AddRating(Rating rating) => Manager.SaveOrUpdate(rating);
    }
}