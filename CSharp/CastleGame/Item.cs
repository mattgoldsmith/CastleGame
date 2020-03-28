using System;
using System.Collections.Generic;
using System.Text;

namespace CastleGame
{
    class Item
    {
        string name;
        string takeRoom;
        string useRoom;
        public Item(string name, string takeRoom, string useRoom)
        {
            SetName(name);
            SetRoom(takeRoom);
            SetUseRoom(useRoom);
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
            this.takeRoom = room;
        }

        public string GetRoom()
        {
            return this.takeRoom;
        }

        private void SetUseRoom(string room)
        {
            this.useRoom = room;
        }

        public string GetUseRoom()
        {
            return this.useRoom;
        }
    }
}
