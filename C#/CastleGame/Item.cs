using System;
using System.Collections.Generic;
using System.Text;

namespace CastleGame
{
    class Item
    {
        string name;
        string room;
        public Item(string name, string room)
        {
            SetName(name);
            SetRoom(room);
        }
   
        private void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }

        private void SetRoom(string room)
        {
            this.room = room;
        }

        public string GetRoom()
        {
            return this.room;
        }
    }
}
