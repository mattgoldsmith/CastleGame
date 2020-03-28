using System;
using System.Collections.Generic;
using System.Text;

namespace CastleGame
{
    class Room
    {
        private string name;
        private string description;
        private Dictionary<string, string> neighbours;
        private string itemUsedDesc;
        public Room(string name, string description, Dictionary<string, string> neighbours, string itemUsedDesc = null)
        {
            SetName(name);
            SetDescription(description);
            this.neighbours = new Dictionary<string, string>();
            SetNeighbours(neighbours);
            SetItemUsedDescription(itemUsedDesc);
        }

        private void SetName(string name)
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
            return description;
        }

        private void SetNeighbours(Dictionary<string, string> neighbours)
        {
            this.neighbours = neighbours;
        }

        public Dictionary<string, string> GetNeighbours()
        {
            return this.neighbours;
        }

        private void SetItemUsedDescription(string description)
        {
            this.itemUsedDesc = description;
        }

        public string GetItemUsedDesciption()
        {
            return itemUsedDesc;
        }
    }
}
