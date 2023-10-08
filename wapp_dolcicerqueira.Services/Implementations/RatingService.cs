using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Services.Interfaces;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using wapp_dolcicerqueira.Repositories.Implementations;

namespace wapp_dolcicerqueira.Services.Implementations
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IUserRepository _userRepository;

        public RatingService(IRatingRepository ratingRepository, IUserRepository userRepository)
        {
            _ratingRepository = ratingRepository;
            _userRepository = userRepository;
        }

        public List<Rating> GetAll()
        {
            var ratings = _ratingRepository.GetAll();
            foreach (var rating in ratings)
            {
                rating.Author = _userRepository.GetById(rating.AuthorId);
            }
            return ratings;
        }

        public Rating GetById(int id)
        {
            Rating rating = _ratingRepository.GetById(id);
            if (rating == null)
            {
                throw new ArgumentException($"Não foi possível encontrar o rating com o ID {id}.", nameof(id));
                // Ou retorne um valor padrão, como: return new Rating();
                // Ou retorne null: return null;
            }

            rating.Author = _userRepository.GetById(rating.AuthorId);
            return rating;
        }

        public List<Rating> GetByIdRecipe(int id)
        {
            var ratings = _ratingRepository.GetByIdRecipe(id);
            foreach (var rating in ratings)
            {
                rating.Author = _userRepository.GetById(rating.AuthorId);
            }
            return ratings;
        }

        public int GetRatingAvg(List<Rating> ratings)
        {
            if (ratings.Count == 0)
            {
                return 0;
            }

            int avg = 0;
            foreach (var rating in ratings)
            {
                avg += rating.Ratings;
            }

            avg /= ratings.Count;
            return avg;
        }

        public Rating Save(Rating rating)
        {
            if (rating.RatingId > 0)
                return _ratingRepository.Update(rating);
            else
                return _ratingRepository.Add(rating);
        }

        public void Delete(int id)
        {
            _ratingRepository.Delete(id);
        }
    }
}
