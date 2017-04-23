// * ==========================================================================
// Application : Master.Classes 
// Classe : DateHeure 
// Fonctions : Classe de gestion de xxx 
// License:  License LGPL 
// Version :  0.01 du 05/02/2010 
// Lien : http://masterclasses.codeplex.com 
// Auteur(s) : Teal
// CopyLeft  :  CopyRight (C) 2010 Master 2 CCI Tours <master2cci@laposte.net>
// Création : 05/02/2010
// Etat : en cours
// Controle du :
// Licence : 
// L'autorisation est accordée, à titre gratuit, à toute personne d'obtenir une copie 
// de ce logiciel et de ses fichiers de documentation, pour pouvoir utiliser 
// ce logiciel sans restriction, y compris, sans s'y limiter, les droits 
// d'utiliser, de copier, de modifier, de fusionner, de publier, de distribuer, 
// de sous-licence, et / ou de vendre les copies du Logiciel, et d'autoriser les 
// personnes auxquelles le logiciel est livré de le faire, sous réserve des 
// conditions suivantes:
// 
// Les avis de droit d'auteur et la présente autorisation doivent être inclus dans 
// toutes les copies ou parties substantielles du Logiciel.
// 
// LE LOGICIEL EST FOURNI "TEL QUEL", SANS GARANTIE DE QUELQUE NATURE QUE CE SOIT, 
// EXPLICITE OU  IMPLICITE, Y COMPRIS, MAIS SANS Y LIMITER LES GARANTIES DE QUALITE 
// MARCHANDE, D'ADEQUATION A UN USAGE PARTICULIER ET D'ABSENCE DE CONTREFAÇON. EN 
// AUCUN CAS LES AUTEURS OU LES TITULAIRES DE DROITS D'AUTEUR POURRONT ETRE TENUE 
// RESPONSABLES DE TOUT DOMMAGE,  RÉCLAMATION OU AUTRE  RESPONSABILITE, DANS LE 
// CADRE D'UNE ACTION DE CONTRAT, UN DELIT OU AUTRE, DÉCOULANT DE, OU EN RELATION 
// AVEC LE LOGICIEL OU DE SON UTILISATION OU AUTRES EN RELATION AVEC LE LOGICIEL.
// Licence LGPL : http://commonlibrarynet.codeplex.com/license 
// *---------------------------------------------------------------------------
//
// * ==========================================================================

#region Références

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace Master.Classes.DateHeure
{
    /// <summary>
    ///	Classe de gestion des Dates et Heures.
    ///	</summary>	
    public class DateHeure
    {
        #region Attributs

        #endregion

        #region Constantes

        #endregion

        #region Propriétés

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Aujourds the hui.
        /// </summary>
        /// <returns></returns>
        public string AujourdHui()
        {
            var today = DateTime.Now.ToString();
            return today;
        }

        /// <summary>
        /// Dates the du jour.
        /// </summary>
        /// <returns></returns>
        public string DateDuJour()
        {
            DateTime dtDuJour = DateTime.Now;
            string DateDuJour = string.Format("{0:dd/MM/yy HH:mm:ss}", dtDuJour);
            return DateDuJour;
        }

        /// <summary>
        /// Periodes the jours ouvrés.
        /// </summary>
        /// <param name="debutP">The debut P.</param>
        /// <param name="finP">The fin P.</param>
        /// <returns></returns>
        public int PeriodeJoursOuvres(DateTime debutP, DateTime finP)
        {
            int nombreDeJours = (finP.Subtract(debutP)).Days;//calcule le nombre de jours dans la période debutP-finP

            int jourDeLaSemaine = RetournePositionJourDeLaSemaine(finP);

            int reste = (nombreDeJours - jourDeLaSemaine) / 7;//reste correspond au nombre de semaines dans l'intervalle sans compter la semaine actuelle (du debut de la periode)

            int resultat = (nombreDeJours - (1 + reste) * 2);

            return resultat;
        }

         /// <summary>
        /// Gets the position jour de la semaine.
        /// </summary>
        /// <param name="ToDate">To date.</param>
        /// <returns></returns> 
        private static int RetournePositionJourDeLaSemaine(DateTime ToDate)//pondère le jour de la semain pour en tenir compte dans le calcul de semaines
        {
            int result;
            switch ( ToDate.DayOfWeek )
            {
                case DayOfWeek.Monday:
                    result = 5;
                    break;
                case DayOfWeek.Tuesday:
                    result = 4;
                    break;
                case DayOfWeek.Wednesday:
                    result = 3;
                    break;
                case DayOfWeek.Thursday:
                    result = 2;
                    break;
                case DayOfWeek.Friday:
                    result = 1;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;

        } 

        /// <summary>
        /// Numeroes the semaine julien.
        /// </summary>
        /// <param name="ParamMaDate">The param ma date.</param>
        /// <returns>Valeur entière du numéro de la semaine (calendrier Julien).</returns>
        public int NumeroSemaineJulien(DateTime ParamMaDate)
        {
            // Calcul du numéro de semaine du calendrier Julien ...
            int CalculJuliena = (14 - ParamMaDate.Month) / 12;
            int CalculJulieny = ParamMaDate.Year + 4800 - CalculJuliena;
            int CalculJulienm = ParamMaDate.Month + 12 * CalculJuliena - 3;
            int NumeroJourJulien = ParamMaDate.Day + (153 * CalculJulienm + 2) / 5 + 365 * CalculJulieny
            + CalculJulieny / 4 - CalculJulieny / 100 + CalculJulieny / 400
            - 32045;

            int d4 = (NumeroJourJulien + 31741 - (NumeroJourJulien % 7)) % 146097 % 36524 % 1461;
            int L = d4 / 1460;
            int d1 = ((d4 - L) % 365) + L;
            // Calcul du numéro de semaine "classique" ...
            double NumSemaine = d1 / 7 + 1;
            return Convert.ToInt32(NumSemaine);
        }

        /// <summary>
        /// Numeroes the semaine gregorien.
        /// </summary>
        /// <param name="MaDate">The ma date.</param>
        /// <returns>Valeur entière du numéro de la semaine (calendrier Grégorien).</returns>
        public int NumeroSemaineGregorien(DateTime MaDate)
        {
            System.Globalization.GregorianCalendar calendrier = new System.Globalization.GregorianCalendar();
            int currentWeek = calendrier.GetWeekOfYear(new DateTime(MaDate.Year,
            MaDate.Month, MaDate.Day), System.Globalization.CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday);
            return currentWeek;
        }

        /// <summary>
        /// Gets the premier jour semaine.
        /// </summary>
        /// <param name="numeroSemaine">The numero semaine.</param>
        /// <param name="annee">The annee.</param>
        /// <returns>Premier jour de la semaine.</returns>
        public DateTime RetournePremierJourSemaine(int numeroSemaine, int annee)
        {
            Calendar cal = CultureInfo.InvariantCulture.Calendar;

            //initialise le premier janvier de l'année
            DateTime date = new DateTime(annee, 1, 1);

            //Cherche le lundi suivant
            int Jour = Convert.ToInt32(date.DayOfWeek);
            date = date.AddDays(8 - Jour);

            //extrait le numéro de semaine du lundi
            int Semaine = cal.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            //ajoute le nombre de semaine
            Semaine = 7 * (numeroSemaine - Semaine);
            date = date.AddDays(Semaine);

            return date;
        }
        
        /// <summary>
        /// Conversions the duree date.
        /// </summary>
        /// <param name="Date1">The date1.</param>
        /// <param name="Date2">The date2.</param>
        /// <returns></returns>
        public string ConversionDureeDate(DateTime Date1, DateTime Date2)
        {
            //Si date2 est antérieure à Date1, la fonction renvoie un nombre
            //négatif. La valeur absolue étant toujours l'intervalle entre les deux dates.
            TimeSpan Intervalle = Date2 - Date1;
            string Duree = string.Format("{0:dd/MM/yy HH:mm:ss}", Intervalle);
            return Duree;
        }

        /// <summary>
        /// Dates the GMT.
        /// </summary>
        /// <returns></returns>
        public DateTime DateGmt()
        {
            //Renvoie la date GMT+0
            return DateTime.UtcNow;
        }

        #endregion

        #region Méthodes protégées

        #endregion

        #region Méthodes privées

        #endregion

        #region Initialisation, finalisation

        #region Constructeurs

        /// <summary>
        ///	Initialise une nouvelle instance de la classe <see cref="DateHeure"/>.	
        /// </summary>
        public DateHeure()
        {
            // TODO: Constructeur de la classe DateHeure
        }

        /// <summary>
        /// Retourne une valeur <see cref="System.String"/> représentant cette instance.
        /// </summary>
        /// <returns>
        /// Valeur <see cref="System.String"/> représentant cette instance.
        /// </returns> 
        public override string ToString()
        {
            return "DateHeure";
        }

        #endregion

        #endregion
    }
}
