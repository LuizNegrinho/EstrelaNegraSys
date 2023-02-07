using EstrelaNegra.API.Interfaces;
using EstrelaNegra.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using EstrelaNegra.API.DTO;

namespace EstrelaNegra.API.Repositories
{
    public class HorseRepository : IHorseRepository
    {
        private readonly HENContext _context;
        private readonly ConnectionStringModel _connection;
        private readonly IConfiguration _configuration;

        public HorseRepository(HENContext context, IOptions<ConnectionStringModel> connection, IConfiguration configuration)
        {
            _context = context;
            _connection = connection.Value;
            _configuration = configuration;
            _connection.Connection = _configuration.GetConnectionString("DefaultConnection");
        }

       

        public void Add(Equine horse)
        {            
            _context.Equine.Add(horse);
        }

        public void Delete(Equine horse)
        {
            _context.Equine.Remove(horse);
        }

        public async Task<ICollection<Equine>> GetAll()
        {
            return await _context.Equine.ToListAsync();
        }

        public async Task<Equine> GetById(int id)
        {
            var horse = await _context.Equine.Where(x => x.HorseId == id).FirstOrDefaultAsync();
            return horse;
        }

        public void Update(Equine horse)
        {
            _context.Entry(horse).State = EntityState.Modified;
        }
        public async Task<bool> SaveAllAsync() 
        { 
            return await _context.SaveChangesAsync() > 0;
        }     

        #region Growth
        public async Task<ICollection<EquineGrowth>> GetGrowth(int id)
        {
            return await _context.EquineGrowth.Where(x => x.HorseId == id).ToListAsync();
        }

        public string GetNameById(int id)
        {
            var query = $"SELECT HORSE_NAME FROM EQUINE WHERE HORSE_ID = {id}";

            using var sql = new SqlConnection(_connection.Connection);
            return sql.Query<string>(query).FirstOrDefault();
        }   
        #endregion
        #region Health

        public async Task<ICollection<EquineHlthFlwup>> GetHealth(int id)
        {
            return await _context.EquineHlthFlwup.Where(x => x.HorseId == id).ToListAsync();
        }
        #endregion

        #region Alternative Queries
        public ICollection<DropDownDTO> GetNameList()
        {
            var query = $"SELECT HORSE_NAME AS HorseName, HORSE_ID AS HorseId FROM EQUINE";

            using var sql = new SqlConnection(_connection.Connection);
            return sql.Query<DropDownDTO>(query).ToList();
        }
        #endregion
    }
}
