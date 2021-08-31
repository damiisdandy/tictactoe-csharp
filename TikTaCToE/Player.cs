using System;

namespace TikTaCToE
{
    class Player
    {
        public string Name { get; set; }
        public char Character { get; set; }
        public Player(string name, char character)
        {
            Name = name;
            Character = character;
        }
    }
}
