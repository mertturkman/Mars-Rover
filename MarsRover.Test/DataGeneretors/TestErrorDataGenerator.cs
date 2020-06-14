using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRover.Test.DataGeneretors
{
    public class TestErrorDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _errorData = new List<object[]>
        {
            new object[] { new Point(0, 0), new Size(5, 5), "N", "MMLLMMM" },
            new object[] { new Point(3, 3), new Size(5, 5), "W", "MMMMMMM" }
        };

        public IEnumerator<object[]> GetEnumerator() => _errorData.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
