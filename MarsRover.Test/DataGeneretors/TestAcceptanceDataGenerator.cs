using MarsRover.Domain.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MarsRover.Test.DataGeneretors
{
    public class TestAcceptanceDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _acceptanceData = new List<object[]>
        {
            new object[] { new Point(1, 2), new Size(5, 5), "N", "LMLMLMLMM", new Point(1, 3), Direction.N },
            new object[] { new Point(3, 3), new Size(5, 5), "E", "MMRMMRMRRM", new Point(5, 1), Direction.E }
        };

        public IEnumerator<object[]> GetEnumerator() => _acceptanceData.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
