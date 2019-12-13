using System;
using System.Collections.Generic;
using System.Text;

namespace CastleGame
{
    class Room
    {
        private string name;
        private string description;
        private Dictionary<string,string> neighbours;
        public Room(string name, string description, Dictionary<string,string> neighbours)
        {
            SetName(name);
            SetDescription(description);
            this.neighbours = new Dictionary<string, string>();
            setNeighbours(neighbours);
        }

        private void SetName (string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }

        private void SetDescription(string description)
        {
            this.description = description;
        }

        public string GetDesciption()
        {
            return this.description;
        }

        private void setNeighbours(Dictionary<string,string> neighbours)
        {
            this.neighbours = neighbours;
        }

        public Dictionary<string,string> getNeighbours()
        {
            return this.neighbours;
        }
    }
}
