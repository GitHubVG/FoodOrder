using FoodOrder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Core
{
    public class VotingCheck
    {
        private UnitOfWork unitOfWork;
        private int score;
       

        public VotingCheck()
        {
            unitOfWork = new UnitOfWork();
        }

        public bool CheckIfUserAlreadyVoted(string idOfLoggedUserFromLocalDb,int? idOfFood)
        {
            var curretUser = unitOfWork.PersonRepository.Get().Single(userID => userID.UserID == idOfLoggedUserFromLocalDb);
            var test = unitOfWork.ScoreRepository.Get().Where(x => x.PersonID == curretUser.ID).Where(x => x.FoodID == idOfFood).ToList();

            if(test.Count>0)
            {
                this.score = test.First().ReviewScore;
                return true;
            }
            else
            {
                return false;
            }

        }

        public int CheckReviewScore()
        {

            return score;
        }

    }
}
