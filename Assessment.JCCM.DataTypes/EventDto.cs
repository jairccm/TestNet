using System;

namespace Assessment.JCCM.DataTypes
{
    public class EventDto
    {
        public int Id { get; set; }
        public int SportsComplexId { get; set; }
        public DateTime EventDate { get; set; }
        public short Duration { get; set; }
        public short ParticipantsNumber { get; set; }
        public short CommissionersNumber { get; set; }
    }

}
