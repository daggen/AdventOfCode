using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeLib.Travel
{
    public class Seat
    {
        public Seat(string boardingPass)
        {
            var rowNumAsBinary = boardingPass.Substring(0,7)
                                     .Replace("B", "1")
                                     .Replace("F", "0");
            Row = Convert.ToInt32(rowNumAsBinary, 2);

            var seatNumAsBinary = boardingPass.Substring(7)
                                            .Replace("R", "1")
                                            .Replace("L", "0");

            Column = Convert.ToInt32(seatNumAsBinary, 2);
            SeatId = Row * 8 + Column;
        }

        public static List<Seat> Parse(List<string> input) =>
            input.Select(boardingPass => new Seat(boardingPass)).ToList();

        public int SeatId { get; }
        public int Row { get; }
        public int Column { get; }
    }
}
