using AutoMapper;
using EstrelaNegra.API.DTO;
using EstrelaNegra.API.Interfaces;
using EstrelaNegra.API.Models;
using System.Security.Cryptography;

namespace EstrelaNegra.API.Applications
{
    public class HorseApplication : IHorseApplication
    {
        private readonly IHorseRepository _horseRepository;
        private readonly IMapper _mapper;

        public HorseApplication(IHorseRepository horseRepository, IMapper mapper)
        {
            _horseRepository = horseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DropDownDTO>> GetHorseList()
        {
            /* #TODO - entender porque o mapper não funcionou aqui.
            var result = await _horseRepository.GetAll();
            var list = _mapper.Map<IEnumerable<DropDownDTO>>(result);
            */
            var list = _horseRepository.GetNameList();

            foreach (var horse in list) 
            {
                horse.HorseName = horse.HorseName.Split().First();
            }
            return list;
        }

        public async Task<HorseDTO> GetHorseById(int id)
        {
            var horse = await _horseRepository.GetById(id);
            HorseDTO monitorData = _mapper.Map<HorseDTO>(horse);


            var growth = await _horseRepository.GetGrowth(id);
            var health = await _horseRepository.GetHealth(id);

            var convertedGrowth = _mapper.Map<GrowthDTO>(growth.FirstOrDefault());
            var convertedHealth = _mapper.Map<HealthDTO>(health.FirstOrDefault());
            monitorData.EquineGrowth.Add(convertedGrowth);
            monitorData.EquineHlthFlwup.Add(convertedHealth);

            return monitorData;
        }

        public HorseMonitorDTO GetMonitorData(int id)
        {
            HorseMonitorModel horse = _horseRepository.GetMonitorData(id);

            HorseMonitorDTO horseMonitor = _mapper.Map<HorseMonitorDTO>(horse);

            DateTime today = DateTime.Today;

            horseMonitor.AgeDays = (int)(today - horseMonitor.BirthDate).TotalDays;

            horseMonitor.AgeMonths = MonthsTillToday(horseMonitor.BirthDate);

            horseMonitor.AgeYears = YearsOld(horseMonitor.BirthDate);

            horseMonitor.AgeFormated = $"{horseMonitor.AgeYears}a{horseMonitor.AgeMonths % 12}m{horseMonitor.AgeDays % DateTime.DaysInMonth((int)today.Year, (int)today.Month)}d"; //#TODO ainda precisa de ajuste nos dias

            if (horseMonitor.LastDeworming == null)
                horseMonitor.NeedBoosterDeworming = true;
            else
                horseMonitor.NeedBoosterDeworming = (MonthsTillToday((DateTime)horseMonitor.LastDeworming) > 6) ? true : false;

            if (horseMonitor.LastLexington == null)
                horseMonitor.NeedBoosterLexington = true;
            else
                horseMonitor.NeedBoosterLexington = (MonthsTillToday((DateTime)horseMonitor.LastLexington) > 6) ? true : false;

            if (horseMonitor.LastTriequi == null)
                horseMonitor.NeedBoosterTriequi = true;
            else
                horseMonitor.NeedBoosterTriequi = (MonthsTillToday((DateTime)horseMonitor.LastTriequi) > 6) ? true : false;
            
            if (horseMonitor.LastTriequi == null)
                horseMonitor.NeedBoosterGarrotilho = true;
            else
                horseMonitor.NeedBoosterGarrotilho = (MonthsTillToday((DateTime)horseMonitor.LastGarrotilho) > 6) ? true : false;

            horseMonitor.AgeRange = (MonthsTillToday(horseMonitor.BirthDate) > 36) ? "adulto" : "potro";

            return horseMonitor;
        }       


        private int MonthsTillToday(DateTime birth)
        {
            DateTime begin = birth;
            DateTime end = DateTime.Today;
            int monthSpan = MonthSpan(end) - MonthSpan(begin);
            if (begin.Day > end.Day)
            {
                monthSpan--;
            }
            return monthSpan;
        }

        private static int MonthSpan(DateTime date)
        {
            return date.Year * 12 + date.Month;
        }

        private static int YearsOld(DateTime data)
        { 
            DateTime now = DateTime.Now;

            try
            {
                int YearsOld = now.Year - data.Year;

                if (now.Month < data.Month || (now.Month == data.Month && now.Day < data.Day))
                {
                    YearsOld--;
                }

                return (YearsOld < 0) ? 0 : YearsOld;
            }
            catch
            {
                return 0;
            }
        }
    }
}
