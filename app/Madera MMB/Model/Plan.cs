﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madera_MMB.Model
{
    class Plan
    {
        #region properties
        public string reference { get; set; }
        public string label { get; set; }
        public Projet projet { get; set; }
        public string creation { get; set; }
        public string modification { get; set; }
        public Couverture couverture { get; set; }
        public CoupePrincipe coupePrincipe { get; set; }
        public Plancher plancher { get; set; }
        public Gamme gamme { get; set; }
        public List<Module> modules { get; set; }
        #endregion

        #region Ctor
        public Plan(string label, Projet unprojet,Plancher unplancher, Couverture unecouverture, CoupePrincipe unecoupe, Gamme unegamme)
        {
            this.label = label;
            this.projet = unprojet;
            this.plancher = unplancher;
            this.couverture = unecouverture;
            this.coupePrincipe = unecoupe;
            this.gamme = unegamme;
        }
        public Plan(string reference, string label, string creation, string modification, Projet unprojet, Plancher unplancher, Couverture unecouverture, CoupePrincipe unecoupe, Gamme unegamme, List<Module> modules)
        {
            this.reference = reference;
            this.label = label;
            this.creation = creation;
            this.modification = modification;
            this.projet = unprojet;
            this.plancher = unplancher;
            this.couverture = unecouverture;
            this.coupePrincipe = unecoupe;
            this.gamme = unegamme;
            this.modules = modules;
        }
        #endregion

        #region privates methods
        private void tracerSlot()
        {
        }


        #endregion
        #region public methods
        public Devis genereDevis()
        {
            Devis generateDevis = new Devis();
            return generateDevis;
        }

        // Copie de Plan //
        public Plan DeepCopy()
        {
            Plan other = (Plan)this.MemberwiseClone();
            other.reference = this.reference + "Copied";
            other.label = String.Copy(label+"(Copie)");
            other.coupePrincipe = this.coupePrincipe;
            other.couverture = this.couverture;
            other.plancher = this.plancher;
            other.gamme = this.gamme;
            other.modules = this.modules;
            return other;
        }
        #endregion
    }
}
