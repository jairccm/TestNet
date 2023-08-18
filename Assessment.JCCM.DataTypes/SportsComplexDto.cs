namespace Assessment.JCCM.DataTypes
{
    public class SportsComplexDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string HeadOrganization { get; set; }
        public decimal TotalArea { get; set; }
        public int OlympicVenueId { get; set; }
        public bool IsMultiSportsComplex { get; set; }
        public string SportName { get; set; }
    }
}
