#region Références
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Master.Contacts.Metier
{
    /// <summary>
    /// Classe représentant un rendez-vous iCalandar
    /// </summary>
    /// <see cref="http://fr.wikipedia.org/wiki/ICalendar"/>
    /// <remarks>
    /// Contenu :
    /// 
    /// iCalendar est un standard (RFC 5545) pour les échanges de données de 
    /// calendrier. Ce standard est aussi connu sous le nom d'iCal. Il 
    /// définit la structuration des données dans un fichier de type 
    /// événement de calendrier, ce n'est donc pas un protocole.
    /// 
    /// DTSTART: Date de début de l'événement
    /// DTEND: Date de fin de l'événement
    /// SUMMARY: Titre de l'événement
    /// LOCATION: Lieu de l'événement
    /// CATEGORIES: Catégorie de l'événement (ex: Conférence, Fête, ...)
    /// STATUS: Statut de l'événement (TENTATIVE, CONFIRMED, CANCELLED)
    /// DESCRIPTION: Description de l'événement
    /// TRANSP: Définit si la ressource affectée à l'évenement est rendu indisponible (OPAQUE, TRANSPARENT)
    /// </remarks>
    public class Calendrier
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public Calendrier()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Version
        /// </summary>
        public string Version
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Date de début
        /// </summary>
        public DateTime DateDebut
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Date de fin
        /// </summary>
        public DateTime DateFin
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Contenu du calendrier
        /// </summary>
        /// <example>
        /// 
        /// BEGIN:VCALENDAR
        /// VERSION:2.0
        /// PRODID:-//hacksw/handcal//NONSGML v1.0//EN
        ///  BEGIN:VEVENT
        ///  DTSTART:19970714T170000Z
        ///  DTEND:19970715T035959Z
        ///  SUMMARY:Bastille Day Party
        ///  END:VEVENT
        /// END:VCALENDAR
        /// 
        /// </example>
        public string ToString()
        {
            StringBuilder sbEvenement = new StringBuilder();
            sbEvenement.AppendLine("BEGIN:VEVENT");

            /*
            sbContact.AppendLine(string.Format("SUMMARY:{0}",
                this.Description 
              ); 
            */

            sbEvenement.AppendLine("END:VEVENT");

            return sbEvenement.ToString();
        }

        /// <summary>
        /// Exportation du calendrier
        /// </summary>
        public void Export()
        {
            throw new System.NotImplementedException();
        }
    }
}
