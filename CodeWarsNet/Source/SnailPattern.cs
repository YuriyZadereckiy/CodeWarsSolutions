using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsNet.Source
{
    public class SnailPattern
    {
        private static void TraverseAround(int[][] source, (int Row, int Col) startPos, int count, List<int> result)
        {
            // Recursively traverse source array
            // End traversal
            if (count == 0) return;
            if (source[startPos.Row].Length == 0) return;
            if (count == 1)
            {
                result.Add(source[startPos.Row][startPos.Col]);
                return;
            }

            // Traverse outer quad
            var row = startPos.Row;
            var col = startPos.Col;
            for (int i = 0; i < count - 1; i++) result.Add(source[row][col++]);
            for (int i = 0; i < count - 1; i++) result.Add(source[row++][col]);
            for (int i = 0; i < count - 1; i++) result.Add(source[row][col--]);
            for (int i = 0; i < count - 1; i++) result.Add(source[row--][col]);

            // Traverse inner quad
            TraverseAround(source, (startPos.Row + 1, startPos.Col + 1), count - 2, result);
        }

        public static int[] Snail(int[][] array)
        {
            var result = new List<int>(array.Length);

            TraverseAround(array, (0, 0), array.Length, result);

            return result.ToArray();
        }
    }
}
