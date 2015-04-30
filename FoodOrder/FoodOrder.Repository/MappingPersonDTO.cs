using AutoMapper;
using FoodOrder.Entities;
using FoodOrder.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Repository
{
    public class MappingPersonDTO
    {
        private PersonDTO personDto;
        private Person person;
        private List<PersonDTO> personsDto;
        public MappingPersonDTO()
        {
            personDto = new PersonDTO();
            person = new Person();
            personsDto = new List<PersonDTO>();

        }

        public List<PersonDTO> getPersons(List<Person> persons)
        {
            foreach (var person in persons)
            {
                Mapper.CreateMap<Person, PersonDTO>();
                personsDto.Add(Mapper.Map<PersonDTO>(persons));
            }

            return personsDto;
        }


        public PersonDTO getPersonById(Person person)
        {
            Mapper.CreateMap<Person, PersonDTO>();
            personDto = Mapper.Map<PersonDTO>(person);

            return personDto;
        }

    }
}
