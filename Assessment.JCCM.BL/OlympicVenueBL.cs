using Assessment.JCCM.DataTypes.Request;
using Assessment.JCCM.DataTypes;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assessment.JCCM.DAL.Implementations;
using Assessment.JCCM.DAL.Interfaces;

namespace Assessment.JCCM.BL
{
    public class OlympicVenueBL
    {
        public static async Task<bool> Create(OlympicVenueRequestDto olympicVenue) 
        {
            IOlympicVenueDA _sportsComplexDA = new OlympicVenueDA();
            return await _sportsComplexDA.Create(olympicVenue);
        }
        public static async Task<bool> Update(int id, OlympicVenueRequestDto olympicVenue) 
        {
            IOlympicVenueDA _sportsComplexDA = new OlympicVenueDA();
            return await _sportsComplexDA.Update(id,olympicVenue);
        }
        public static async Task<bool> Delete(int id) 
        {
            IOlympicVenueDA _sportsComplexDA = new OlympicVenueDA();
            return await _sportsComplexDA.Delete(id);
        }
        public static async Task<List<OlympicVenueDto>> GetAll() 
        {
            IOlympicVenueDA _sportsComplexDA = new OlympicVenueDA();
            return await _sportsComplexDA.GetAll();
        }
        public static async Task<OlympicVenueDto> FindById(int id) 
        {
            IOlympicVenueDA _sportsComplexDA = new OlympicVenueDA();
            return await _sportsComplexDA.FindById(id);
        }
    }
}
