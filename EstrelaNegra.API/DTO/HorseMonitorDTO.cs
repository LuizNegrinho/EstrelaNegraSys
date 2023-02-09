using System.Diagnostics;

namespace EstrelaNegra.API.DTO
{
    public class HorseMonitorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sufixx { get; set; }
        public string Sex { get; set; }
        public int ActualHeight { get; set; }
        public DateTime BirthDate { get; set; }
        public int AgeDays { get; set; }
        public int AgeMonths { get; set; }
        public int AgeYears { get; set; }
        public Nullable<DateTime> LastLexington { get; set; }       
        public Nullable<DateTime> LastDeworming { get; set; }
        public Nullable<DateTime> LastTriequi { get; set; }
        public Nullable<DateTime> LastGarrotilho { get; set; }
        public bool NeedBoosterLexington { get; set; }
        public bool NeedBoosterDeworming { get; set; }
        public bool NeedBoosterTriequi { get; set; }
        public bool NeedBoosterGarrotilho { get; set; }
        public bool HeightWarning { get; set; }
        public string AgeRange { get; set; }
        public string AgeFormated { get; internal set; }
    }
}
