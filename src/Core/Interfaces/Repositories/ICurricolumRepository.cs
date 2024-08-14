using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories;
public interface ICurricolumRepository
{
    Task<IEnumerable<Curricolum>> GetAll(int userId);
    Task<Curricolum> Create(Curricolum curricolum);
}
