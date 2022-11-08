﻿namespace Cards.API.Models
{
    public class Card
    {
        public Guid Id { get; set; }
        public string CardholderName { get; set; }
        public string CardNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int CVC { get; set; }

    }
}
