using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stocky.Business.Contracts;
using Stocky.Data;
using Stocky.Models.DTO;
using Stocky.Models;
using Stocky.Models.Dtos;

namespace Stocky.Business.Impls
{
    public class  AchatAdminServiceImpl : AchatAdminService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public  AchatAdminServiceImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<AchatDto> GetAchats()
        {
            if (_context.achats == null)
            {
                throw new ApplicationException("not found");
            }
            return _mapper.Map<IEnumerable<AchatDto>>(_context.achats.ToList());
        }

        public AchatDto GetAchat(int id)
        {
            var achat = _context.achats.FirstOrDefault(c => c.Id == id);

            if (achat == null)
            {
                throw new ApplicationException("not found");
            }

            return _mapper.Map<AchatDto>(achat);
        }

        public void PutAchat(int id, AchatDto achat)
        {
            if (!AchatExists(id))
            {
                throw new ApplicationException("not found");
            }
            Achat updatedAchat = _mapper.Map<Achat>(achat);
            _context.Entry(updatedAchat).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void PostAchat(AchatDto achat)
        {
            if (AchatExists(achat.Id))
            {
                throw new ApplicationException("Already exist");
            }
            Achat savedAchat = _mapper.Map<Achat>(achat);
            _context.achats.Add(savedAchat);
            _context.SaveChanges();
        }

        public void DeleteAchat(int id)
        {
            if (!AchatExists(id))
            {
                throw new ApplicationException("not found");
            }
            var client = _context.achats.FirstOrDefault(c => c.Id == id);
            Achat removedAchat = _mapper.Map<Achat>(client);

            _context.achats.Remove(removedAchat);
            _context.SaveChanges();
        }

        private bool AchatExists(int id)
        {
            return (_context.achats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
