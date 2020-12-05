using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeLib.Travel
{
    public class Plane
    {
        public Plane(List<Seat> seats)
        {
            Seats = seats.Select(seat => seat.SeatId).OrderBy(i => i).ToList();
        }

        private List<int> Seats { get; }

        public int FindEmptySeat()
        {
            var l1 = Seats;
            var l2 = Seats.Skip(1);

            var emptySeat = l1.Zip(l2, (i1, i2) => (i1, i2))
                              .Where(pair => pair.i2 - pair.i1 == 2)
                              .Select(pair => pair.i1 +1)
                              .First();

            return emptySeat;
        }
    }
}
