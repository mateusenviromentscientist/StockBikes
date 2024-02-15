namespace StockBikes.Context.Entities
{
    public class Bike
    {
        public int BikeID { get; set; }
        public int SeatID { get; set; }
        public int LeftPedalID { get; set; }
        public int RightPedalID { get; set; }
        public int LeftWheelID { get; set; }
        public int RightWheelID { get; set; }

        public Seat Seat { get; set; }
        public Pedal LeftPedal { get; set; }
        public Pedal RightPedal { get; set; }
        public Wheel LeftWheel { get; set; }
        public Wheel RightWheel { get; set; }
    }

    public class Seat
    {
        public int SeatID { get; set; }
        public string Description { get; set; }
    }

    public class Pedal
    {
        public int PedalID { get; set; }
        public string Description { get; set; }
    }

    public class Frame
    {
        public int FrameID { get; set; }
        public string Description { get; set; }
    }

    public class Tube
    {
        public int TubeID { get; set; }
        public string Description { get; set; }
    }

    public class Wheel
    {
        public int WheelID { get; set; }
        public int FrameID { get; set; }
        public int TubeID { get; set; }
        public string Description { get; set; }

        public Frame Frame { get; set; }
        public Tube Tube { get; set; }
    }
}
