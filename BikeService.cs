
using System.ComponentModel.DataAnnotations;

namespace StockBike
{
    public sealed class SettingsBike
    {
        public SettingsBike()
        {
        }

        public SettingsBike(int? seat, int? pedals, int? wheels, int? frames, int? tube, int? ammountBikes)
        {
            Seat = seat;
            Pedals = pedals;
            Wheels = wheels;
            Frames = frames;
            Tube = tube;
            AmmountBikes = ammountBikes;
        }

        public int? Seat { get; set; }
        public int? Pedals { get; set; }
        public int? Wheels { get; set; }
        public int? Frames { get; set; }
        public int? Tube { get; set; }
        public int? AmmountBikes { get; set; }

        public int? GetBikesAmmount()
        {

            int seats = 50;
            int pedals = 60;
            int frames = 60;
            int tubes = 35;

            int wheels = Math.Min(frames, tubes);

            int bikes = Math.Min(Math.Min(seats, pedals / 2), wheels / 2);

            return bikes;
        }

        public int? GetBikesProjection(SettingBikeDto model)
        {
            Validator(model);

            int wheels = Math.Min((int)model.Frames, (int)model.Tube);

            int bikes = Math.Min(Math.Min((int)model.Seat, (int) model.Pedals / 2), wheels / 2);

            return bikes;
        }

        public static void Validator(SettingBikeDto model)
        {
            ArgumentNullException.ThrowIfNull(model);
            if (model.Pedals < 2) throw new Exception("Pedals Should be more than 1");
            if (model.Tube < 1) throw new Exception("Tube Should be more than 1");
            if (model.Seat < 1) throw new Exception("Seat Should be at least 1 ");
            if (model.Frames < 1) throw new Exception("Frames Should be at least 1 ");
        }

    }

    public class SettingBikeDto
    {
        public int? Seat { get; set; }
        public int? Pedals { get; set; }
        public int? Frames { get; set; }
        public int? Tube { get; set; }
    }
}
