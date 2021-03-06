﻿using Madera_MMB.Lib.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madera_MMB.Model
{
    public class Plan
    {
        #region Properties
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
        /// <summary>
        /// Constructeur de plan à la création dans ParamPlan
        /// </summary>
        /// <param name="label"></param>
        /// <param name="unprojet"></param>
        /// <param name="unplancher"></param>
        /// <param name="unecouverture"></param>
        /// <param name="unecoupe"></param>
        /// <param name="unegamme"></param>
        public Plan(string reference, string label, string creation, Projet unprojet, Plancher unplancher, Couverture unecouverture, CoupePrincipe unecoupe, Gamme unegamme = null)
        {
            this.reference = reference;
            this.label = label;
            this.creation = creation;
            this.projet = unprojet;
            this.plancher = unplancher;
            this.couverture = unecouverture;
            this.coupePrincipe = unecoupe;
            this.gamme = unegamme;
        }

        /// <summary>
        /// Constructeur de Plan à la génération depuis BDD
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="label"></param>
        /// <param name="creation"></param>
        /// <param name="modification"></param>
        /// <param name="unprojet"></param>
        /// <param name="unplancher"></param>
        /// <param name="unecouverture"></param>
        /// <param name="unecoupe"></param>
        /// <param name="modules"></param>
        /// <param name="unegamme"></param>
        public Plan(string reference, string label, string creation, string modification, Projet unprojet, Couverture unecouverture, CoupePrincipe unecoupe, List<Module> modules, Plancher unplancher, Gamme unegamme = null)
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

        
        public Plan(Plan plan, string lareference)
        {
            this.projet = plan.projet;
            this.reference = lareference;
            this.label = plan.label += "(copy)";
            this.creation = DateTime.Now.ToString();
            this.plancher = plan.plancher;
            this.couverture = plan.couverture;
            this.coupePrincipe = plan.coupePrincipe;
            this.modules = plan.modules;
            this.gamme = plan.gamme;
        }
        #endregion

        #region Privates methods
        //private void tracerSlot()
        //{
        //}
        #endregion

        #region Public methods
        //public Devis GenererDevis()
        //{
        //    Devis generateDevis = new Devis();
        //    return generateDevis;
        //}

        // Copie de Plan //
        //public Plan DeepCopy()
        //{
        //    Plan other = (Plan)this.MemberwiseClone();
        //    other.reference = this.reference + "Copied";
        //    other.label = String.Copy(label+"(Copie)");
        //    other.coupePrincipe = this.coupePrincipe;
        //    other.couverture = this.couverture;
        //    other.plancher = this.plancher;
        //    other.gamme = this.gamme;
        //    other.modules = this.modules;
        //    return other;
        //}
        #endregion
    }
}
