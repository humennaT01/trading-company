using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALEF.Concrete
{
    public class PersonDalEf : IPersonDal
    {
        private readonly IMapper _mapper;

        public PersonDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PersonDTO CreatePerson(PersonDTO person)
        {
            using (var entities = new AdministratorEntities())
            {
                Person p = _mapper.Map<Person>(person);
                entities.People.Add(p);
                entities.SaveChanges();
                return _mapper.Map<PersonDTO>(p);
            }
        }

        public void DeletePerson(int id)
        {
            using (var entities = new AdministratorEntities())
            {
                var p = entities.People.SingleOrDefault(pp => pp.PersonID == id);
                if (p == null)
                {
                    return;
                }
                entities.People.Remove(p);
                entities.SaveChanges();
            }
        }

        public List<PersonDTO> GetAllPersons()
        {
            using (var entities = new AdministratorEntities())
            {
                var people = entities.People.ToList();
                return _mapper.Map<List<PersonDTO>>(people);
            }
        }

        public PersonDTO GetPersonById(int id)
        {
            using (var entities = new AdministratorEntities())
            {
                var person = entities.People.SingleOrDefault(p => p.PersonID == id);
                return _mapper.Map<PersonDTO>(person);
            }
        }

        public PersonDTO UpdatePerson(PersonDTO person)
        {
            using (var entities = new AdministratorEntities())
            {
                entities.People.AddOrUpdate(_mapper.Map<Person>(person));
                var per = entities.People.Single(p => p.PersonID == person.PersonID);
                entities.SaveChanges();
                return _mapper.Map<PersonDTO>(per);
            }
        }

    }
}


