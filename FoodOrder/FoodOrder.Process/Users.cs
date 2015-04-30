using FoodOrder.Entities;
using FoodOrder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodOrder.Core
{
    public class Users
    {
        private UnitOfWork unitOfWork;
        private Person person;

        public Users()
        {
            unitOfWork = new UnitOfWork();
            person = new Person();
        }

  
        public void SetJustRegisteredPerson(string firstName, string lastName,string id)
        {

            person.Last_name = firstName;
            person.First_name = lastName;
            person.UserID = id;
            unitOfWork.PersonRepository.Insert(person);
            unitOfWork.Save();

        }

    }
}
