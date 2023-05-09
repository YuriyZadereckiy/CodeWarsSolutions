using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsNet.Source
{
    public class BattleshipField
    {
        public static bool ValidateBattlefield(int[,] field)
        {
            if (field.GetLength(0) > 10 || field.GetLength(1) > 10) return false;

            // Ship (size,count)
            var ships = new Dictionary<int, int>
            {
                {1,4},
                {2,3},
                {3,2},
                {4,1}
            };

            // Vertical ships at current iteration
            // (col, size)
            var verticalShips = new Dictionary<int, int>();
            var horizontalShips = new Stack<int>();

            var totalShipFields = 20;
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    var top = row > 0 ? field[row - 1, col] : 0;
                    var down = row < 9 ? field[row+1, col] : 0;
                    var left = col > 0 ? field[row, col - 1] : 0;
                    var right = col < 9 ? field[row, col + 1] : 0;
                    var curr = field[row, col];

                    // check validity of the field
                    if (left + right > 0 && top + down > 0) return false;
                    if (curr == 1) totalShipFields--;
                    if (totalShipFields < 0) return false;

                    // check size of found ships
                    if (curr == 1)
                    {
                        // middle of vertical ship
                        if (top + down == 2)
                        {
                            verticalShips[col]++;
                        }
                        // middle of horizontal ship
                        else if (left + right == 2)
                        {
                            horizontalShips.Push(1);
                        }
                        // vertical ship end
                        else if (top == 1)
                        {
                            var size = verticalShips[col] + 1;
                            if (size > 4) return false;

                            ships[size]--;
                            verticalShips.Remove(col);
                        }
                        // vertical ship start
                        else if (down == 1)
                        {
                            verticalShips[col] = 1;
                        }
                        // horizontal ship end
                        else if (left == 1)
                        {
                            var size = horizontalShips.Count + 1;
                            if (size > 4) return false;

                            ships[size]--;
                            horizontalShips.Clear();
                        }
                        // horizontal ship start
                        else if (right == 1)
                        {
                            horizontalShips.Push(1);
                        }
                        // Single ship
                        else
                        {
                            ships[1]--;
                        }
                    }
                }
            }

            return totalShipFields == 0 &&
                   ships.Values.All(v=>v == 0);
        }

        public static bool ValidateBattlefield2(int[,] field)
        {
            if (field.GetLength(0) > 10 || field.GetLength(1) > 10) return false;

            var totalShipFields = 20;
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (totalShipFields < 0) return false;

                    var top = row > 0 ? field[row - 1, col] : 0;
                    var down = row < 9 ? field[row+1, col] : 0;
                    var left = col > 0 ? field[row, col - 1] : 0;
                    var right = col < 9 ? field[row, col + 1] : 0;
                    var curr = field[row, col];

                    if (left + right > 0 && top + down > 0) return false;
                    if (curr == 1) totalShipFields--;

                    // vertical ships can be identified by col
                    // there cannot be more than 1 vertical ship in col for this row
                }
            }

            return totalShipFields == 0;
        }
    }
}
