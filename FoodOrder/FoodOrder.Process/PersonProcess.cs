using FoodOrder.Entities;
using FoodOrder.Entities.DTO;
using FoodOrder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Process
{
    public class PersonProcess
    {
        public UnitOfWork unitOfWork;
        private PersonDTO personDto;
        private MappingPersonDTO mapPerson;


        public PersonProcess()
        {
            unitOfWork = new UnitOfWork();
            personDto = new PersonDTO();
            mapPerson = new MappingPersonDTO();


        }


        public List<PersonDTO> getAllPersons()
        {

            return mapPerson.getPersons(unitOfWork.PersonRepository.Get().ToList());

        }
        public PersonDTO getPersonById(string id)
        {

            return mapPerson.getPersonById(unitOfWork.PersonRepository.Get().Single(x=>x.UserID==id));

        }

        public Person getPersonByUserId(string id)
        {

            return unitOfWork.PersonRepository.Get().Single(x=>x.UserID==id);
        }

    }
}
