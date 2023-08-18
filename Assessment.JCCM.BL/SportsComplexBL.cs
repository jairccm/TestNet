using Assessment.JCCM.DataTypes.Request;
using Assessment.JCCM.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment.JCCM.DAL.Implementations;
using Assessment.JCCM.DAL.Interfaces;

namespace Assessment.JCCM.BL
{
    public class SportsComplexBL
    {
        public static async Task<bool> Create(SportsComplexRequestDto sportsComplex) 
        {
            ISportsComplexDA _sportsComplexDA = new SportsComplexDA();
            return await _sportsComplexDA.Create(sportsComplex);
        }
        public static async Task<bool> Update(int id, SportsComplexRequestDto sportsComplex) 
        {
            ISportsComplexDA _sportsComplexDA = new SportsComplexDA();
            return await _sportsComplexDA.Update(id,sportsComplex);
        }
        public static async Task<bool> Delete(int id) 
        {
            ISportsComplexDA _sportsComplexDA = new SportsComplexDA();
            return await _sportsComplexDA.Delete(id);
        }
        public static async Task<List<SportsComplexDto>> GetAll() 
        {
            ISportsComplexDA _sportsComplexDA = new SportsComplexDA();
            return await _sportsComplexDA.GetAll();
        }
        public static async Task<SportsComplexDto> FindById(int id) 
        {
            ISportsComplexDA _sportsComplexDA = new SportsComplexDA();
            return await _sportsComplexDA.FindById(id);
        }
    }
}
