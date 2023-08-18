using Assessment.JCCM.DAL.Interfaces;
using Assessment.JCCM.DataTypes;
using Assessment.JCCM.DataTypes.Request;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.JCCM.DAL.Implementations
{
    public class OlympicVenueDA : IOlympicVenueDA
    {
        protected readonly IConnectionFactory _connectionFactory;

        public OlympicVenueDA()
        {
            _connectionFactory = new ConnectionFactory();
        }
        public async Task<bool> Create(OlympicVenueRequestDto olympicVenue)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var parameters = new DynamicParameters();

                parameters.Add("@name", olympicVenue.Name);
                parameters.Add("@complexesNumber", olympicVenue.ComplexesNumber);
                parameters.Add("@budget", olympicVenue.Budget);
                parameters.Add("@countryName", olympicVenue.CountryName);
                parameters.Add("@cityName", olympicVenue.CityName);
                var response = await connection.ExecuteAsync("dbo.usp_createOlympicVenue", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return (response > 0);
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var parameters = new DynamicParameters();

                parameters.Add("@id", id);
                var response = await connection.ExecuteAsync("dbo.usp_deleteOlympicVenue", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return (response > 0);
            }
        }

        public async Task<OlympicVenueDto> FindById(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var parameters = new DynamicParameters();

                parameters.Add("@id", id);
                var response = await connection.QueryFirstOrDefaultAsync<OlympicVenueDto>("dbo.usp_getOlympicVenue", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return response;
            }
        }

        public async Task<List<OlympicVenueDto>> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var response = await connection.QueryAsync<OlympicVenueDto>("dbo.usp_getAllOlympicVenue", commandType: System.Data.CommandType.StoredProcedure);
                return response?.ToList();
            }
        }

        public async Task<bool> Update(int id, OlympicVenueRequestDto olympicVenue)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var parameters = new DynamicParameters();

                parameters.Add("@id", id);
                parameters.Add("@name", olympicVenue.Name);
                parameters.Add("@complexesNumber", olympicVenue.ComplexesNumber);
                parameters.Add("@budget", olympicVenue.Budget);
                parameters.Add("@countryName", olympicVenue.CountryName);
                parameters.Add("@cityName", olympicVenue.CityName);
                var response = await connection.ExecuteAsync("dbo.usp_updateOlympicVenue", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return (response > 0);
            }
        }
    }
}
