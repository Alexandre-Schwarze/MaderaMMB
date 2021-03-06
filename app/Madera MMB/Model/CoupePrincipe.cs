﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Madera_MMB.Model
{
    public class CoupePrincipe
    {
        #region properties
        public int id { get; set; }
        public string label { get; set; }
        public int longueur { get; set; }
        public int largeur { get; set; }
        public int prixHT { get; set; }
        public bool statut { get; set; }
        public BitmapImage image { get; set; }
        #endregion

        #region Ctor
        public CoupePrincipe(int id, string label, int longueur, int largeur, int prix, bool statut, BitmapImage img)
        {
            this.id = id;
            this.label = label;
            this.longueur = longueur;
            this.largeur = largeur;
            this.prixHT = prix;
            this.image = img;
            this.statut = statut;
        }
        public CoupePrincipe() { }
        #endregion
    }
}
