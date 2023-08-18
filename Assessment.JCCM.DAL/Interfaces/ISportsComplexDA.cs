using Assessment.JCCM.DataTypes.Request;
using Assessment.JCCM.DataTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assessment.JCCM.DAL.Interfaces
{
    public interface ISportsComplexDA
    {
        Task<bool> Create(SportsComplexRequestDto sportsComplex);
        Task<bool> Update(int id, SportsComplexRequestDto sportsComplex);
        Task<bool> Delete(int id);
        Task<List<SportsComplexDto>> GetAll();
        Task<SportsComplexDto> FindById(int id);
    }
}
