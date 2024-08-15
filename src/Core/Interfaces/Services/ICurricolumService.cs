using Core.Entities;
using Core.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services;
public interface ICurricolumService
{
    Task<IEnumerable<Curricolum>> GetAll(int userId);
    Task<Curricolum> Create(CurricolumRequest request, int authenticatedUserId);
}
