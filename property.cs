using System;
using System.Collections.Generic;
using System.Text;

namespace landmark_realty
{
    class property
    {
        public property(string ID, int size, int rooms, int bathrooms, string address, int floor, string type, string status, int price)
        {
            this.ID = ID;
            this.size = size;
            this.rooms = rooms;
            this.bathrooms = bathrooms;
            this.address = address;
            this.floor = floor;
            this.type = type;
            this.status = status;
            this.price = price;
        }

        public string ID { get; set; }
        public int size { get; set; }
        public int rooms { get; set; }
        public int bathrooms { get; set; }
        public string address { get; set; }
        public int floor { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public int price { get; set; }
    }
}
