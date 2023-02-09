namespace EstrelaNegra.API.Models
{
    public class HorseMonitorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sufixx { get; set; }
        public string Sex { get; set; }
        public int ActualHeight { get; set; }
        public DateTime BirthDate { get; set; }
        public Nullable<DateTime> LastLexington { get; set; }
        public Nullable<DateTime> LastDeworming { get; set; }
        public Nullable<DateTime> LastTriequi { get; set; }
        public Nullable<DateTime> LastGarrotilho { get; set; }
    }
}
