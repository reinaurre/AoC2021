using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public struct Coordinate
    {
        public int x;
        public int y;
    }

    public enum Direction
    {
        Forward,
        Down,
        Up,
    }

    public static class GridMovement
    {
        public static Coordinate TraverseGrid(Coordinate[] instructions)
        {
            Coordinate position = new Coordinate();

            foreach(Coordinate move in instructions)
            {
                position.x += move.x;
                position.y += move.y;

                //Console.WriteLine($"Current X: {position.x}.  Current Y: {position.y}.");
            }

            return position;
        }

        public static Coordinate[] ParseInstructions(string[] instructions)
        {
            Coordinate[] output = new Coordinate[instructions.Length];

            for (int i = 0; i < instructions.Length; i++)
            {
                output[i] = ParseInstruction(instructions[i]);
            }

            return output;
        }

        private static Coordinate ParseInstruction(string instruction)
        {
            string[] temp = instruction.Split(' ');
            int value = int.Parse(temp[1]);
            switch (temp[0])
            {
                case "forward": return new Coordinate() { x = value, y = 0 };
                case "up": return new Coordinate() { x = 0, y = value };
                case "down": return new Coordinate() { x = 0, y = -value };
            }

            throw new Exception();
        }
    }
}
