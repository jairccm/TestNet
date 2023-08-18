using Assessment.JCCM.DataTypes;
using Assessment.JCCM.DataTypes.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assessment.JCCM.DAL.Interfaces
{
    public interface IOlympicVenueDA
    {
        Task<bool> Create(OlympicVenueRequestDto olympicVenue);
        Task<bool> Update(int id, OlympicVenueRequestDto olympicVenue);
        Task<bool> Delete(int id);
        Task<List<OlympicVenueDto>> GetAll();
        Task<OlympicVenueDto> FindById(int id);
    }
}
