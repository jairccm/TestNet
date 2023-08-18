using Assessment.JCCM.DAL.Interfaces;
using Assessment.JCCM.DataTypes;
using Assessment.JCCM.DataTypes.Request;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.JCCM.DAL.Implementations
{
    public class SportsComplexDA : ISportsComplexDA
    {
        protected readonly IConnectionFactory _connectionFactory;

        public SportsComplexDA()
        {
            _connectionFactory = new ConnectionFactory();
        }
        public async Task<bool> Create(SportsComplexRequestDto sportsComplex)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var parameters = new DynamicParameters();

                parameters.Add("@location", sportsComplex.Location);
                parameters.Add("@headOrganization", sportsComplex.HeadOrganization);
                parameters.Add("@totalArea", sportsComplex.TotalArea);
                parameters.Add("@olympicVenueId", sportsComplex.OlympicVenueId);
                parameters.Add("@isMultiSportsComplex", sportsComplex.IsMultiSportsComplex);
                parameters.Add("@sportName", sportsComplex.SportName);
                var response = await connection.ExecuteAsync("dbo.usp_createSportsComplex", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return (response > 0);
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var parameters = new DynamicParameters();

                parameters.Add("@id", id);
                var response = await connection.ExecuteAsync("dbo.usp_deleteSportsComplex", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return (response > 0);
            }
        }

        public async Task<SportsComplexDto> FindById(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var parameters = new DynamicParameters();

                parameters.Add("@id", id);
                var response = await connection.QueryFirstOrDefaultAsync<SportsComplexDto>("dbo.usp_getSportsComplex", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return response;
            }
        }

        public async Task<List<SportsComplexDto>> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var response = await connection.QueryAsync<SportsComplexDto>("dbo.usp_getAllSportsComplex", commandType: System.Data.CommandType.StoredProcedure);
                return response?.ToList();
            }
        }

        public async Task<bool> Update(int id, SportsComplexRequestDto sportsComplex)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var parameters = new DynamicParameters();

                parameters.Add("@id", id);
                parameters.Add("@location", sportsComplex.Location);
                parameters.Add("@headOrganization", sportsComplex.HeadOrganization);
                parameters.Add("@totalArea", sportsComplex.TotalArea);
                parameters.Add("@olympicVenueId", sportsComplex.OlympicVenueId);
                parameters.Add("@isMultiSportsComplex", sportsComplex.IsMultiSportsComplex);
                parameters.Add("@sportName", sportsComplex.SportName);
                var response = await connection.ExecuteAsync("dbo.usp_updateSportsComplex", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return (response > 0);
            }
        }
    }
}
