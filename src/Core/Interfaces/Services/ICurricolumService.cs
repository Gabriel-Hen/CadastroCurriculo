using Core.Entities;
using Core.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services;
public interface ICurricolumService
{
    Task<IEnumerable<Curricolum>> GetAllByUserId(int userId);
    Task<Curricolum> Create(CurricolumRequest request, int authenticatedUserId);
    Task<Curricolum> GetById(int id);
    Task<IEnumerable<Curricolum>> GetAll();
}
