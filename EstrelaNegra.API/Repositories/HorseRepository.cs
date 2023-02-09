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


        #region Base Entities

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

        #endregion

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

        public HorseMonitorModel GetMonitorData(int id)
        {
            var result = new HorseMonitorModel();
            var query = $@"SELECT
 EQ.HORSE_ID   AS Id
,EQ.HORSE_NAME AS Name
,EQ.SUFIXX	   AS Sufixx
,EQ.SEX        AS Sex
,
(
	SELECT MAX(MaxHeight) 
	FROM (VALUES 
	(EQG.M0),(EQG.M1),(EQG.M2),(EQG.M3),(EQG.M5),(EQG.M6),(EQG.M7),(EQG.M8),(EQG.M9),
	(EQG.M10),(EQG.M11),(EQG.M12),(EQG.M13),(EQG.M14),(EQG.M15),(EQG.M16),(EQG.M17),(EQG.M18),
	(EQG.M19),(EQG.M20),(EQG.M21),(EQG.M22),(EQG.M23),(EQG.M24),(EQG.M25),(EQG.M26),(EQG.M27),
	(EQG.M28),(EQG.M29),(EQG.M30),(EQG.M31),(EQG.M32),(EQG.M33),(EQG.M34),(EQG.M35),(EQG.M36),
	(EQG.M36),(EQG.M48),(EQG.M60),(EQG.ACTUAL)
	) AS MaxHeight(MaxHeight)
 ) AS ActualHeight
 , CONVERT(DATE, EQ.BIRTH, 23) AS BirthDate 
 , CASE WHEN CONVERT(CHAR(10), EQH.LEX8, 23) = '1900-01-01' THEN NULL ELSE CONVERT(DATE, EQH.LEX8, 23) END AS LastLexington
 , CASE WHEN CONVERT(CHAR(10), EQH.VERM_IVE, 23) = '1900-01-01' THEN NULL ELSE CONVERT(DATE, EQH.VERM_IVE, 23) END AS LastDeworming
 , CASE WHEN CONVERT(CHAR(10), EQH.TRIEQUI, 23) = '1900-01-01' THEN NULL ELSE CONVERT(DATE, EQH.TRIEQUI, 23) END AS LastTriequi
 , CASE WHEN CONVERT(CHAR(10), EQH.GARROTILHO, 23) = '1900-01-01' THEN NULL ELSE CONVERT(DATE, EQH.GARROTILHO, 23) END AS LastGarrotilho

FROM EQUINE EQ
JOIN EQUINE_GROWTH EQG ON EQ.HORSE_ID = EQG.HORSE_ID
JOIN EQUINE_HLTH_FLWUP EQH ON EQ.HORSE_ID = EQH.HORSE_ID
WHERE EQ.HORSE_ID = {id}

ORDER BY BirthDate DESC";

            using var sql = new SqlConnection(_connection.Connection);
            result = sql.Query<HorseMonitorModel>(query).FirstOrDefault();
            return result;
        }
        #endregion
    }
}
