using FoodOrder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Process
{
    public class PieChart
    {

        private UnitOfWork unitOfWork;
        private List<PieChart> allChartInfo;
        private List<int> listOfVotes;

        public PieChart()
        {
            unitOfWork = new UnitOfWork();
            allChartInfo = new List<PieChart>();
            listOfVotes = new List<int>();
        }


        public string RestaurantName { get; set; }
        public int Broj { get; set; }



        public List<PieChart> InfoToDisplayInPieChart()
        {
            var restaurantAndVotes = unitOfWork.RestaurantRepository.Get().SelectMany(s => s.Person, (vote, person) => new { id = vote.ID, vote.RestaurantName, person.RestaurantVote });


            foreach (var item in restaurantAndVotes)
            {
                if (!listOfVotes.Any(x => x == item.RestaurantVote))
                {
                    PieChart pieChart = new PieChart();
                    pieChart.RestaurantName = item.RestaurantName;
                    pieChart.Broj = restaurantAndVotes.Where(x => x.RestaurantVote == item.RestaurantVote).Count();
                    allChartInfo.Add(pieChart);
                    listOfVotes.Add((int)item.RestaurantVote);
                }


            }


            return allChartInfo;

        }
    }
}
