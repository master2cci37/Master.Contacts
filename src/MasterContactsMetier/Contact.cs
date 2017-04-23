#region Références
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Master.Contacts.Metier
{
    /// <summary>
    /// Classe représentant un contact VCard
    /// </summary>
    /// <see cref="http://fr.wikipedia.org/wiki/VCard"/>
    /// <remarks>
    /// Contenu :
    /// 
    /// Le format vCard implémente les types de propriétés suivants. 
    /// Conformément à la spécification de la version 3.0, les vCards doivent 
    /// contenir la propriété VERSION, N et FN entre les entités BEGIN:VCARD et END:VCARD.
    /// 
    /// Nom	Description	Signification	Propriétés
    /// N	Nom (Name)	Une représentation structuré du nom de la personne, du lieu ou de la chose associé à l'objet vCard	(Obligatoire) Champs textes séparés par des point-virgules : Nom de Famille, Prénom(s), Nom(s) additionnel(s), Titre(s) (Dr, Pr, ...), Suffixe(s) (Jr, M.D.). Les champs peuvent contenir eux-mêmes plusieurs valeurs séparées par des virgules.
    /// FN	Nom formatté (Formatted Name)	La chaîne formatée représentant le nom associé à l'objet vCard	(Obligatoire) Unique champ texte
    /// NICKNAME	Surnom (Nickname)	Un nom descriptif ou familier donné à la place ou en addition du nom de la personne, du lieu ou de la chose associé	Un ou plusieurs champs textes séparés par des virgules
    /// PHOTO	Photographie (Photograph)	Une illustration ou une photographie de l'individu associé à la vCard	Une URI vers une ressource externe ou le contenu binaire de l'image en précisant encodage et type)
    /// BDAY	Date de naissance (Birthday)	Date de naissance de l'individu associé à la vCard	Date au format AAAA-MM-JJ ou ISO 8601
    /// ADR	Adresse de livraison (Delivery Address)	Une représentation structurée de l'adresse physique de livraison associé à l'objet vCard	Champs textes séparés par des points-virgules : Boîte postale, Adresse étendue, Nom de rue, Ville, Région (ou état/province), Code postal et Pays
    /// LABEL	Libellé de l'adresse (Label Address)	Libellé de l'adresse physique de livraison de la personne ou de l'objet associé à la vCard	Unique champ texte
    /// TEL	Téléphone (Telephone)	La chaîne du numéro de téléphone pour les appels vocaux associée à l'objet vCard	Unique champ texte
    /// EMAIL	Email (Email)	L'adresse email associée à l'objet vCard	Unique champ texte
    /// MAILER	Programme de mailing (Email Program) (Optionnel)	Le type de programme de mailing utilisé	Unique champ texte
    /// TZ	Fuseau horaire (Time Zone)	Indication du fuseau horaire courant de l'objet vCard	Décalage à l'UTC au format +05:30 ou -02:00
    /// GEO	Géopositionnement (Global Positioning)	Propriété indiquant la latitude et la longitude	Latitude et Longitude en décimale séparées par un point-virgule
    /// TITLE	Titre (Title)	Indique le titre du poste, de la fonction ou de la personne associée à l'objet vCard au sein d'une organisation)	Unique champ texte
    /// ROLE	Fonction (Role or occupation)	Le rôle, la profession ou la catégorie de métier de l'objet vCard au sein d'une organisation	Unique champ texte
    /// LOGO	Logo (Logo)	Une illustration ou le logo de l'organisation associé à l'individu de l'objet vCard	Une URI vers une ressource externe ou le contenu binaire de l'image en précisant encodage et type)
    /// AGENT	Agent (Agent)	Informations à propos d'une autre personne qui agira au nom de la personne associée à la vCard. Généralement, cela peut-être un administrateur, un assistant ou un secrétaire de l'individu de la vCard.	Une autre vCard ou une URI vers la vCard de l'Agent
    /// ORG	Nom ou département de l'organisation (Organization Name or Organizational unit)	Le nom et optionnellement le ou les département(s) associée à l'objet vCard. Cette propriété est basé sur les propriétés du Nom et du Département de l'organisation dans la norme X.520.	Champs textes séparés par des point-virgules : de l'entités la plus englobante à gauche à l'entité la plus précise au sein de l'organisation à droite.
    /// CATEGORIES	Catégorie (Category)	Catégories applicables à la vCard	Champs textes séparés par des virgules représentant chacun une catégorie
    /// NOTE	Note (Note)	Spécifie des informations supplémentaires ou un commentaire qui est associée à la vCard	Unique champ texte
    /// REV	Dernière révision (Last Revision)	Combinaison de la date du calendrier et l'heure du jour de la dernière mise à jour à l'objet vCard	Date au format AAAA-MM-JJ ou ISO 8601
    /// SORT-STRING	Texte pour le tri (Sort string)	La chaîne qui sera utilisée pour trier le nom de l'objet (exemple : "Croix" pour "de la Croix")	Unique champ texte
    /// SOUND	Son (Sound)	Par défaut, si cette propriété n'est pas regroupés avec les autres propriétés, elle précise la prononciation de la propriété FN (Formatted Name) de l'objet vCard.	Une URI vers une ressource externe ou le contenu binaire de l'image en précisant encodage et type)
    /// URL	URL (URL)	Le lien internet permettant d'obtenir les informations mises à jour en temps-réel de l'objet vCard	Une unique URI
    /// UID	Identifieur unique (Unique Identifier)	Indique une valeur qui représente un identifieur unique, persistant et global associé à l'objet vCard	Unique champ texte
    /// VERSION	Version (Version)	Version de la spécification vCard	(Obligatoire) Unique champ texte
    /// KEY	Clé public (Public Key)	La clé publique de chiffrement associée à l'objet vCard	Uni
    /// </remarks>
    public class Contact : IDisposable
    {
        /// <summary>
        /// N	Nom (Name)	Une représentation structuré du nom de la personne, 
        /// du lieu ou de la chose associé à l'objet vCard	(Obligatoire) Champs 
        /// textes séparés par des point-virgules : 
        /// Nom de Famille, Prénom(s), Nom(s) additionnel(s), Titre(s) 
        /// (Dr, Pr, ...), Suffixe(s) (Jr, M.D.). 
        /// Les champs peuvent contenir eux-mêmes plusieurs valeurs séparées par des virgules.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Retourne une chaine au format vcard représentant le contact actif
        /// </summary>
        /// <returns>Chaine au format vcard représentant le contact actif</returns>
        /// <example>
        /// 
        /// BEGIN:VCARD
        /// VERSION:3.0
        /// N:Gump;Forrest
        /// FN:Forrest Gump
        /// ORG:Bubba Gump Shrimp Co.
        /// TITLE:Shrimp Man
        /// PHOTO;VALUE=URL;TYPE=GIF:http://www.example.com/dir_photos/my_photo.gif
        /// TEL;TYPE=WORK,VOICE:(111) 555-1212
        /// TEL;TYPE=HOME,VOICE:(404) 555-1212
        /// ADR;TYPE=WORK:;;100 Waters Edge;Baytown;LA;30314;United States of America
        /// LABEL;TYPE=WORK:100 Waters Edge\nBaytown, LA 30314\nUnited States of America
        /// ADR;TYPE=HOME:;;42 Plantation St.;Baytown;LA;30314;United States of America
        /// LABEL;TYPE=HOME:42 Plantation St.\nBaytown, LA 30314\nUnited States of America
        /// EMAIL;TYPE=PREF,INTERNET:forrestgump@example.com
        /// REV:20080424T195243Z
        /// END:VCARD 
        /// 
        /// </example>
        public override string ToString()
        {
            StringBuilder sbContact = new StringBuilder();
            sbContact.AppendLine("BEGIN:VCARD");
            sbContact.AppendLine("VERSION:3.0");

            /*
            sbContact.AppendLine(string.Format("N:{0};{1};{2};{4};{5}",
                this.Nom,
                this.Prenoms,
                this.NomComplementaire,
                this.Titre,
                this.Suffixe); 
            */

            sbContact.AppendLine("END:VCARD");

            return sbContact.ToString();
        }


        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
