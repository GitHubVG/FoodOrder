using FoodOrder.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrder.Entities;
using FoodOrder.Entities.DTO;

namespace FoodOrder.Repository
{
    public class UnitOfWork : IDisposable
    {
        private FoodOrderContext context;

        private UsersContext userContext;
        private GenericRepository<AspNetUsers> usersRepository;

        private GenericRepository<Restaurant> restaurantRepository;
        private GenericRepository<RestaurantDTO> restaurantDtoRepository;
        private GenericRepository<Person> personRepository;
        private GenericRepository<Food> foodRepository;
        private GenericRepository<Score> scoreRepository;

        public UnitOfWork()
        {
            context = new FoodOrderContext();
            userContext = new UsersContext();
        }


        public GenericRepository<AspNetUsers> UsersRepository
        {
            get
            {

                if (this.usersRepository == null)
                {
                    this.usersRepository = new GenericRepository<AspNetUsers>(userContext);
                }
                return usersRepository;
            }
        }

        public GenericRepository<Restaurant> RestaurantRepository
        {
            get
            {

                if (this.restaurantRepository == null)
                {
                    this.restaurantRepository = new GenericRepository<Restaurant>(context);
                }
                return restaurantRepository;
            }
        }

        public GenericRepository<RestaurantDTO> RestauranDTOtRepository
        {
            get
            {

                if (this.restaurantDtoRepository == null)
                {
                    this.restaurantDtoRepository = new GenericRepository<RestaurantDTO>(context);
                }
                return restaurantDtoRepository;
            }
        }





        public GenericRepository<Person> PersonRepository
        {
            get
            {

                if (this.personRepository == null)
                {
                    this.personRepository = new GenericRepository<Person>(context);
                }
                return personRepository;
            }
        }
        public GenericRepository<Food> FoodRepository
        {
            get
            {

                if (this.foodRepository == null)
                {
                    this.foodRepository = new GenericRepository<Food>(context);
                }
                return foodRepository;
            }
        }
        public GenericRepository<Score> ScoreRepository
        {
            get
            {

                if (this.scoreRepository == null)
                {
                    this.scoreRepository = new GenericRepository<Score>(context);
                }
                return scoreRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
