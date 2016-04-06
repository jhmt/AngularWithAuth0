using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipmentsAPI.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }

        public static List<Shipment> Create()
        {
            return new List<Shipment>
            {
                new Shipment
                {
                    Id = 123,
                    Destination = "NorthShore",
                    Origin = "Manukau"
                },
                new Shipment
                {
                    Id = 343,
                    Destination = "Wellignton",
                    Origin = "Auckland"
                }
            };
        }

    }
}