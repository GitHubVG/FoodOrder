using FoodOrder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Core
{
    public class Votes
    {

        //brisanje svih glasova nakon 16h


        private UnitOfWork unitOfWork;

        public Votes()
        {
            unitOfWork = new UnitOfWork();
           
        }

        public void removeAllVotes()
        {
            if(DateTime.Now.Hour>=16 && DateTime.Now.Hour<=8)
            {
                foreach (var person in unitOfWork.PersonRepository.Get())
                {
                    person.RestaurantVote = null;
                    unitOfWork.Save();
                    
                }
            }

        }


    }
}
