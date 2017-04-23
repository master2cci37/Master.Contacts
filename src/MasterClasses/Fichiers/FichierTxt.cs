// * ==========================================================================
// Application : Master.Classes 
// Classe : FichierTxt 
// Fonctions : Classe de gestion de FichierTxt 
// License:  License LGPL 
// Version :  0.01 du 18/02/2010 
// Lien : http://masterclasses.codeplex.com 
// Auteur(s) : Olivier
// CopyLeft  :  CopyRight (C) 2010 Master 2 CCI Tours <master2cci@laposte.net>
// Création : 18/02/2010
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
    ///	Classe de gestion de FichierTxt.
    ///	</summary>	
    public class FichierTxt
    {
        #region Attributs

        #endregion

        #region Constantes

        #endregion

        #region Propriétés

        #endregion

        #region Méthodes publiques
        /// <summary>
        /// Methode qui retourne le nombre de ligne d'un fichier txt
        /// </summary>
        /// <param name="chemin">Chemin du fichier txt</param>
        /// <returns>Nombre de ligne dans le fichier</returns>
        public int NombreLigne(string chemin)
        {
            int compteur = 0;
            using (StreamReader SR = new StreamReader(chemin))
            {

                while (SR.ReadLine() != null)
                {
                    compteur++;
                }

            }
            return compteur;
        }

        /// <summary>
        /// Lit un fichier txt et stocke le texte dans une List
        /// </summary>
        /// <param name="chemin">Chemin du fichier txt</param>
        /// <returns>List contenant le txt du fichier</returns>
        public List<String> LectureFichier(string chemin)
        {
            List<string> lignes = new List<string>();
            using (StreamReader SR = new StreamReader(chemin))
            {
                string ligne = null;
                while ((ligne = SR.ReadLine()) != null)
                {
                    lignes.Add(ligne);
                }
            }
            return lignes;
        }

        /// <summary>
        /// Methode qui trouve les differences entre 2 fichiers et qui stocke ces differences 
        /// dans une List contenant les 2 lignes contenant des differences
        /// </summary>
        /// <param name="chemin1">chemin du 1er fichier</param>
        /// <param name="chemin2">chemin du 2nd fichier</param>
        /// <returns>List de List de string (la 2eme liste contient 2 string correspondant à chaque fichier)</returns>
        public List<List<string>> difference(string chemin1, string chemin2)
        {
            List<List<string>> lignes = new List<List<string>>();
            using (StreamReader SR = new StreamReader(chemin1))
            {
                using (StreamReader SR2 = new StreamReader(chemin2))
                {
                    string ligne1 = null;
                    string ligne2 = null;
                    while (((ligne1 = SR.ReadLine()) != null) && ((ligne2 = SR2.ReadLine()) != null))
                    {
                        if (!ligne1.Equals(ligne2))
                        {
                            lignes.Add(new List<string>() { ligne1, ligne2 });
                        }
                    }
                }
            }
            return lignes;
        }

        /// <summary>
        /// Methode de suppression de ligne d'un fichier texte
        /// </summary>
        /// <param name="index">tableau d'index des lignes à supprimer</param>
        /// <param name="chemin">chemin du fichier à traiter</param>
        public void SupprimerLigne(int[] index, string chemin)
        {
            List<string> fichier = LectureFichier("chemin");
            List<string> aSupprimer = new List<string>();
            foreach (int a in index)
            {
                aSupprimer.Add(fichier[a]);
            }
            foreach (string ligne in aSupprimer)
            {
                fichier.Remove(ligne);
            }
            using (StreamWriter SW = new StreamWriter(chemin))
            {
                foreach (string s in fichier)
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
        ///	Initialise une nouvelle instance de la classe <see cref="FichierTxt"/>.	
        /// </summary>
        public FichierTxt()
        {
            // TODO: Constructeur de la classe FichierTxt
        }

        /// <summary>
        /// Retourne une valeur <see cref="System.String"/> représentant cette instance.
        /// </summary>
        /// <returns>
        /// Valeur <see cref="System.String"/> représentant cette instance.
        /// </returns> 
        public override string ToString()
        {
            return "FichierTxt";
        }

        #endregion

        #endregion
    }
}
