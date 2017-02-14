﻿using Madera_MMB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madera_MMB.Lib;
using System.Data.SQLite;
using System.Data;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace Madera_MMB.CAD
{
    public class CouvertureCAD
    {
        #region properties
        public List<Couverture> listecouverture { get; set; }
        public Connexion conn { get; set; }
        private Couverture couverture { get; set; }
        private string SQLQuery { get; set; }
        #endregion

        #region Ctor
        public CouvertureCAD(Connexion co)
        {
            this.conn = co;
            listecouverture = new List<Couverture>();
            listAllCouverture();
        }
        #endregion

        #region privates methods
        private void listAllCouverture() 
        {
            SQLQuery = "SELECT * FROM couverture";
            conn.LiteCo.Open();
            using (SQLiteCommand command = new SQLiteCommand(SQLQuery, conn.LiteCo))
            {
                try
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Byte[] data = (Byte[])reader.GetValue(2);

                            Couverture couverture = new Couverture(reader.GetString(0), reader.GetInt32(1), ToImage(data));
                            listecouverture.Add(couverture);
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    Trace.WriteLine(" \n ################################################# ERREUR RECUPERATION COUVERTURES ################################################# \n" + ex.ToString() + "\n");
                }
            }
            conn.LiteCo.Close();
        }
        #endregion

        #region public methods
        public Couverture getCouvbyType(string type)
        {
            SQLQuery = "SELECT * FROM Couverture WHERE typeCouverture = " + type;
            SQLiteCommand command = (SQLiteCommand)conn.LiteCo.CreateCommand();
            command.CommandText = SQLQuery;
            SQLiteDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    Byte[] data = (Byte[])reader.GetValue(2);
                    this.couverture = new Couverture(reader.GetString(0), reader.GetInt32(1), ToImage(data));
                }
            }
            finally
            {
                reader.Close();
            }
            return couverture;
        }
        #endregion

        #region Tools
        /// <summary>
        /// Méthode de conversion de type byte array en BitmapImage
        /// </summary>
        /// <param name="array">tableau d'octets de l'image</param>
        /// <returns></returns>
        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; 
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
        #endregion
    }
}