// * ==========================================================================
// Application : Master.Classes 
// Classe : Divers 
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
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace Master.Classes.Divers
{
    /// <summary>
    ///	Classe de traitements divers.
    ///	</summary>	
    public class Divers
    {
        #region Attributs

        #endregion

        #region Constantes

        #endregion

        #region Propriétés

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Ajouters the zero.
        /// </summary>
        /// <param name="nombre">The nombre.</param>
        /// <returns></returns>
        public int AjouterZero(int nombre)
        {
            return nombre * 10;
        }

        /// <summary>
        /// Couleurs the long to HTML.
        /// </summary>
        /// <param name="CouleurLong">The couleur long.</param>
        /// <returns></returns>
        public string CouleurLongToHtml(int CouleurLong)
        {
            Color MaCouleur = ColorTranslator.FromOle(CouleurLong);
            string CouleurHTML = ColorTranslator.ToHtml(MaCouleur);
            return CouleurHTML;
        }

        /// <summary>
        /// Couleurs the HTML to long.
        /// </summary>
        /// <param name="CouleurHtml">The couleur HTML.</param>
        /// <returns></returns>
        public int CouleurHtmlToLong(string CouleurHtml)
        {
            Color MaCouleur = ColorTranslator.FromHtml(CouleurHtml);
            int CouleurOle = ColorTranslator.ToOle(MaCouleur);
            return CouleurOle;
        }

        #endregion

        #region Méthodes protégées

        #endregion

        #region Méthodes privées

        #endregion

        #region Initialisation, finalisation

        #region Constructeurs

        /// <summary>
        ///	Initialise une nouvelle instance de la classe <see cref="Divers"/>.	
        /// </summary>
        public Divers()
        {
            // TODO: Constructeur de la classe Divers
        }

        /// <summary>
        /// Retourne une valeur <see cref="System.String"/> représentant cette instance.
        /// </summary>
        /// <returns>
        /// Valeur <see cref="System.String"/> représentant cette instance.
        /// </returns> 
        public override string ToString()
        {
            return "Divers";
        }

        #endregion

        #endregion
    }
}