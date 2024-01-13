using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stocky.Business.Contracts;
using Stocky.Data;
using Stocky.Models.DTO;
using Stocky.Models;
using Stocky.Models.Dtos;

namespace Stocky.Business.Impls
{
    public class  ClientAdminServiceImpl : ClientAdminService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public  ClientAdminServiceImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ClientDto> GetClients()
        {
            if (_context.clients == null)
            {
                throw new ApplicationException("not found");
            }
            return _mapper.Map<IEnumerable<ClientDto>>(_context.clients.ToList());
        }

        public ClientDto GetClient(int id)
        {
            var client = _context.clients.FirstOrDefault(c => c.Id == id);

            if (client == null)
            {
                throw new ApplicationException("not found");
            }

            return _mapper.Map<ClientDto>(client);
        }

        public void PutClient(int id, ClientDto client)
        {
            if (!ClientExists(id))
            {
                throw new ApplicationException("not found");
            }
            Client updatedClient = _mapper.Map<Client>(client);
            _context.Entry(updatedClient).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void PostClient(ClientDto client)
        {
            if (ClientExists(client.Id))
            {
                throw new ApplicationException("Already exist");
            }
            Client savedClient = _mapper.Map<Client>(client);
            _context.clients.Add(savedClient);
            _context.SaveChanges();
        }

        public void DeleteClient(int id)
        {
            if (!ClientExists(id))
            {
                throw new ApplicationException("not found");
            }

            _context.clients.Remove(removedClient);
            _context.SaveChanges();
        }

        private bool ClientExists(int id)
        {
            return (_context.clients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
