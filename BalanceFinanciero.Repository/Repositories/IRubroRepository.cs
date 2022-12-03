using BalanceFinanciero.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceFinanciero.Repository.Repositories
{
    public interface IRubroRepository
    {
        Task<IEnumerable<Rubro>> GetAll();
        Task<Rubro> GetSingle(int id);
        Task<bool> Insert(Rubro rubro);
        Task<bool> Update(Rubro rubro);
        Task<bool> Delete(int id);
    }
}
