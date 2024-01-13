using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stocky.Business.Contracts;
using Stocky.Data;
using Stocky.Models.DTO;
using Stocky.Models;
using Stocky.Models.Dtos;

namespace Stocky.Business.Impls
{
    public class  AchatItemAdminServiceImpl : AchatItemAdminService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public  AchatItemAdminServiceImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<AchatItemDto> GetAchatItems()
        {
            if (_context.achatItems == null)
            {
                throw new ApplicationException("not found");
            }
            return _mapper.Map<IEnumerable<AchatItemDto>>(_context.achatItems.ToList());
        }

        public AchatItemDto GetAchatItem(int id)
        {
            var achatItem = _context.achatItems.FirstOrDefault(c => c.Id == id);

            if (achatItem == null)
            {
                throw new ApplicationException("not found");
            }

            return _mapper.Map<AchatItemDto>(achatItem);
        }

        public void PutAchatItem(int id, AchatItemDto achatItem)
        {
            if (!AchatItemExists(id))
            {
                throw new ApplicationException("not found");
            }
            AchatItem updatedAchatItem = _mapper.Map<AchatItem>(achatItem);
            _context.Entry(updatedAchatItem).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void PostAchatItem(AchatItemDto achatItem)
        {
            if (AchatItemExists(achatItem.Id))
            {
                throw new ApplicationException("Already exist");
            }
            AchatItem savedAchatItem = _mapper.Map<AchatItem>(achatItem);
            _context.achatItems.Add(savedAchatItem);
            _context.SaveChanges();
        }

        public void DeleteAchatItem(int id)
        {
            if (!AchatItemExists(id))
            {
                throw new ApplicationException("not found");
            }
            var produit = _context.achatItems.FirstOrDefault(c => c.Id == id);
            AchatItem removedAchatItem = _mapper.Map<AchatItem>(produit);
            var achat = _context.achatItems.FirstOrDefault(c => c.Id == id);
            AchatItem removedAchatItem = _mapper.Map<AchatItem>(achat);

            _context.achatItems.Remove(removedAchatItem);
            _context.SaveChanges();
        }

        private bool AchatItemExists(int id)
        {
            return (_context.achatItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
