using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Interfaces
{
    public interface IPersonDal
    {
        PersonDTO GetPersonById(int id);
        List<PersonDTO> GetAllPersons();
        PersonDTO UpdatePerson(PersonDTO person);
        PersonDTO CreatePerson(PersonDTO person);
        void DeletePerson(int id);
    }
}
