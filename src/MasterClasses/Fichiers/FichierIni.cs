// * ==========================================================================
// Application : Master.Classes 
// Classe : FichierIni 
// Fonctions : Classe de gestion des FichierIni 
// License:  License LGPL 
// Version :  0.01 du 03/02/2010 
// Lien : http://masterclasses.codeplex.com 
// Auteur(s) : Turquoise
// CopyLeft  :  CopyRight (C) 2010 Master 2 CCI Tours <master2cci@laposte.net>
// Création : 03/02/2010
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

namespace Master.Classes.Fichiers
{
    /// <summary>
    ///	Classe de gestion des FichierIni.
    ///	</summary>	
    public class FichierIni
    {
        #region Attributs

        #endregion

        #region Constantes

        #endregion

        #region Propriétés

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Fusionne 2 fichiers INI en le stockant dans le 1er
        /// </summary>
        /// <param name="chemin1">Chemin du 1er fichier INI qui serra aussi la sortie</param>
        /// <param name="chemin2">Chemin du 2eme fichier INI</param>
        public void FusionnerFichiers(string chemin1, string chemin2)
        {
            List<string> fichier = new List<string>();

            using ( StreamReader SR = new StreamReader(chemin1) )
            {
                string ligne;
                while ( (ligne = SR.ReadLine()) != null )
                {
                    fichier.Add(ligne);
                }
            }

            using ( StreamReader SR = new StreamReader(chemin2) )
            {

                string ligne;
                while ( (ligne = SR.ReadLine()) != null )
                {
                    fichier.Add(ligne);

                }
            }

            using ( StreamWriter SW = new StreamWriter(chemin1) )
            {
                foreach ( string s in fichier )
                {
                    SW.WriteLine(s);
                }
            }
        }

        #endregion

        #region Méthodes protégées

        #endregion

        #region Méthodes privées

        #endregion

        #region Initialisation, finalisation

        #region Constructeurs

        /// <summary>
        ///	Initialise une nouvelle instance de la classe <see cref="FichierIni"/>.	
        /// </summary>
        public FichierIni()
        {
            // TODO: Constructeur de la classe FichierIni
        }

        /// <summary>
        /// Retourne une valeur <see cref="System.String"/> représentant cette instance.
        /// </summary>
        /// <returns>
        /// Valeur <see cref="System.String"/> représentant cette instance.
        /// </returns> 
        public override string ToString()
        {
            return "FichierIni";
        }

        #endregion

        #endregion
    }
}
