﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MS.Domain.IPerson;
using MS.Entities.Person;
using MS.Infra.Data.Context;

namespace MS.Infra.Data.Repository.Persons
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public PersonRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PersonVO>> FindAll()
        {
            // TODO: Return Paginated
            //  List<Person> persons = await _context.Persons.Take(100).Skip(200).OrderBy(p => p.Name).ToListAsync(); 
            List<Person> persons = await _context.Persons.ToListAsync();
            return _mapper.Map<List<PersonVO>>(persons);
        }

        public async Task<PersonVO> FindById(long id)
        {

            Person? person = await _context.Persons.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (person == null) throw new InvalidOperationException($"Não encontrado!");
            
            return _mapper.Map<PersonVO>(person);
        }

        public async Task<Person> FindByName(string name)
        {
            Person? person = await _context.Persons.Where(p => p.Name == name).FirstOrDefaultAsync();
            if (person == null) return null;
            
            return _mapper.Map<Person>(person);
        }

        public async Task<PersonVO> Create(PersonVO vo)
        {
            Person person = _mapper.Map<Person>(vo);
            person.PermissaoId = 2;
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return _mapper.Map<PersonVO>(person);
        }

        public async Task<PersonVO> Update(PersonVO vo)
        {
            try
            {
                Person person = _mapper.Map<Person>(vo);
                _context.Persons.Update(person);
                await _context.SaveChangesAsync();
                return _mapper.Map<PersonVO>(person);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Person? person = await _context.Persons.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (person == null) return false;
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
