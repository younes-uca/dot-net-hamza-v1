﻿using Stocky.Data;

namespace Stocky.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Libelle { get; set; }
        public string Barcode { get; set; }
        public string Discription { get; set; }
        public Decimal PrixAchatMoyen { get; set; }
        public Decimal Quantite { get; set; }
        public Decimal SeuilAlert { get; set; }
    }
}
