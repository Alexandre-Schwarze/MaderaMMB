﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madera_MMB.Model
{
    class Projet
    {
        #region properties
        public string reference { get; set; }
        public string nom { get; set; }
        public DateTime creation { get; set; }
        public DateTime modification { get; set; }
        public Commercial commercial { get; set; }
        public Client client { get; set; }
        #endregion

        #region Ctor
        public Projet(string reference, string nom, DateTime creation, DateTime modification, Client client, Commercial commercial)
        {
            this.reference = reference;
            this.nom = nom;
            this.creation = creation;
            this.modification = modification;
            this.commercial = commercial;
            this.client = client;
        }
        public Projet(Client client, Commercial commercial) 
        {
            this.commercial = commercial;
            this.client = client;
        }
        #endregion
    }
}
