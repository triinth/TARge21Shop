﻿namespace TARge21Shop.Models.RealEstate
{
    public class RealEstateIndexViewModel
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public double Size { get; set; }
        public int Floor { get; set; }
        public int Price { get; set; }
        public int RoomCount { get; set; }

        // only in database
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
