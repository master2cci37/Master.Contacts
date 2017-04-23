// * ==========================================================================
// Application : Master.Classes 
// Classe : Chaine 
// Fonctions : Classe de gestion des Chaines 
// License:  License LGPL 
// Version :  0.02 du 17/02/2010 
// Lien : http://masterclasses.codeplex.com 
// Auteur(s) : Fuchsia, Coral
// CopyLeft  :  CopyRight (C) 2010 Master 2 CCI Tours <master2cci@laposte.net>
// Création : 17/02/2010 
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
using System.Collections;

#endregion

namespace Master.Classes.Chaine
{
    /// <summary>
    ///	Classe de gestion des Chaines.
    ///	</summary>	
    public class Chaine
    {
        #region Attributs

        /// <summary>
        /// Liste d'entiers.
        /// </summary>
        protected List<int> tab_Bin = new List<int>();

        /// <summary>
        /// Liste d'entiers.
        /// </summary>
        protected List<int> tab_Dec = new List<int>();

        /// <summary>
        /// Liste d'entiers.
        /// </summary>
        protected List<int> quatre_Bits = new List<int>();

        /// <summary>
        /// Liste d'entiers.
        /// </summary>
        protected List<string> tab_Hex = new List<string>();

        #endregion

        #region Constantes

        #endregion

        #region Propriétés

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Bins to hex.
        /// </summary>
        /// <param name="binaire">The binaire.</param>
        /// <returns></returns>
        public string BinToHex(string binaire)
        {
            #region conversion string en entiers dans la liste tabBin

            //permet de convertir notre string en tableau d'entiers ordonnés!

            #region Variables Locales
            int mon_Ent = 0;//variable locale intermediaire de conversion en entier --> table des entiers
            string mon_Hex = "";//variable locale intermediaire de conversion en hexadecimal
            string convertHexa = "";
            #endregion

            foreach ( var car in binaire )
            {
                switch ( car )
                {
                    case '0':
                        mon_Ent = 0;
                        break;
                    case '1':
                        mon_Ent = 1;
                        break;
                    default:
                        break;
                }
                tab_Bin.Add(mon_Ent);//remplissage de la table des entier composants du binaire
            }

            #endregion

            while ( tab_Bin.Count != 0 )//action repetée tant que le binaire n'est pas etierement traité
            {
                quatre_Bits.Clear();
                if ( tab_Bin.Count >= 4 )//si le nombre binaire est >= 4, on a un groupe de 4 bits pret à etre traité
                {
                    for ( int index = 0; index < 4; index++ )
                    {
                        //ex: n = 111000; on prends les 4 bits 1000 --> traduits en Hexadecimal, reste 11 n vaut donc 0011 1000
                        quatre_Bits.Insert(0, tab_Bin[tab_Bin.Count - 1]);
                        tab_Bin.RemoveAt(tab_Bin.Count - 1);
                    }
                }
                else//le binaire contient moins de 4 bits --> il faut completer
                {
                    for ( int index = 0; index <= (tab_Bin.Count); index++ )
                    {
                        //suivant l'exemple precedent, il reste à traiter 11; completé par des zero, il donne 0011
                        quatre_Bits.Insert(0, tab_Bin[tab_Bin.Count - 1]);
                        tab_Bin.RemoveAt(tab_Bin.Count - 1);
                    }

                    #region completer les 4 bits par des zero

                    int compteur = 4 - quatre_Bits.Count;//permet de savoir combien de zero rajouter pour atteindre nos 4 bits

                    for ( int index2 = 0; index2 < compteur; index2++ )
                    {
                        quatre_Bits.Insert(0, 0);
                    }

                    #endregion
                }

                #region 4 bits to hex equivalent

                string mon_Nbr = Convert.ToString((quatre_Bits[3] * (int)Math.Pow(2, 0)) + (quatre_Bits[2] * (int)Math.Pow(2, 1)) + (quatre_Bits[1] * (int)Math.Pow(2, 2)) + (quatre_Bits[0] * (int)Math.Pow(2, 3)));

                #region transformer mon nombre convertit en equivalent Hexadecimal

                switch ( mon_Nbr )
                {
                    case "0":
                        mon_Hex = "0";
                        break;
                    case "1":
                        mon_Hex = "1";
                        break;
                    case "2":
                        mon_Hex = "2";
                        break;
                    case "3":
                        mon_Hex = "3";
                        break;
                    case "4":
                        mon_Hex = "4";
                        break;
                    case "5":
                        mon_Hex = "5";
                        break;
                    case "6":
                        mon_Hex = "6";
                        break;
                    case "7":
                        mon_Hex = "7";
                        break;
                    case "8":
                        mon_Hex = "8";
                        break;
                    case "9":
                        mon_Hex = "9";
                        break;
                    case "10":
                        mon_Hex = "A";
                        break;
                    case "11":
                        mon_Hex = "B";
                        break;
                    case "12":
                        mon_Hex = "C";
                        break;
                    case "13":
                        mon_Hex = "D";
                        break;
                    case "14":
                        mon_Hex = "E";
                        break;
                    case "15":
                        mon_Hex = "F";
                        break;
                    default:
                        break;
                }
                #endregion

                tab_Hex.Insert(0, mon_Hex);

                #endregion
            }

            #region concaténation du résultat et retour


            foreach ( var h in tab_Hex )
            {
                convertHexa += h;
            }

            return convertHexa;
            #endregion
        }

        /// <summary>
        /// Hexes to bin.
        /// </summary>
        /// <param name="hexadecimal">The hexadecimal.</param>
        /// <returns></returns>
        public string HexToBin(string hexadecimal)
        {
            #region Variables Locales
            //convertir la string en tableaux decimaux
            int mon_Dec = 0;
            string conversion_Bin = "";

            #endregion
            foreach ( var elt_Hex in hexadecimal )
            {
                #region hex --> dec
                switch ( elt_Hex )
                {
                    case '0':
                        mon_Dec = 0;
                        break;
                    case '1':
                        mon_Dec = 1;
                        break;
                    case '2':
                        mon_Dec = 2;
                        break;
                    case '3':
                        mon_Dec = 3;
                        break;
                    case '4':
                        mon_Dec = 4;
                        break;
                    case '5':
                        mon_Dec = 5;
                        break;
                    case '6':
                        mon_Dec = 6;
                        break;
                    case '7':
                        mon_Dec = 7;
                        break;
                    case '8':
                        mon_Dec = 8;
                        break;
                    case '9':
                        mon_Dec = 9;
                        break;
                    case 'A':
                        mon_Dec = 10;
                        break;
                    case 'B':
                        mon_Dec = 11;
                        break;
                    case 'C':
                        mon_Dec = 12;
                        break;
                    case 'D':
                        mon_Dec = 13;
                        break;
                    case 'E':
                        mon_Dec = 14;
                        break;
                    case 'F':
                        mon_Dec = 15;
                        break;
                    default:
                        break;
                }
                #endregion

                #region conversion en binaire

                string mon_bin = "";//variable locale de résultat binaire en string
                while ( mon_Dec > 0 )
                {

                    //etape 1: test du rang 3
                    if ( mon_Dec >= Math.Pow(2, 3) )//mon élément hexadecimal est supérieur ou égale à 8
                    {
                        mon_Dec -= 8;
                        mon_bin += "1";
                    }
                    else//mon élément hexadecimal est inférieur à 8
                    {
                        mon_bin += "0";
                    }
                    //etape 2: test du rang 2
                    if ( mon_Dec >= Math.Pow(2, 2) )//mon élément hexadecimal est supérieur ou égale à 4
                    {
                        mon_Dec -= 4;
                        mon_bin += "1";
                    }
                    else//mon élément hexadecimal est inférieur à 4
                    {
                        mon_bin += "0";
                    }
                    //etape 3: test du rang 1
                    if ( mon_Dec >= Math.Pow(2, 1) )//mon élément hexadecimal est supérieur ou égale à 2
                    {
                        mon_Dec -= 2;
                        mon_bin += "1";
                    }
                    else//mon élément hexadecimal est inférieur à 2
                    {
                        mon_bin += "0";
                    }
                    //etape 4: test du rang 0
                    if ( mon_Dec >= Math.Pow(2, 0) )//mon élément hexadecimal est supérieur ou égale à 1
                    {
                        mon_Dec -= 1;
                        mon_bin += "1";
                    }
                    else//mon élément hexadecimal est inférieur à 1
                    {
                        mon_bin += "0";
                    }

                    conversion_Bin += mon_bin;

                #endregion

                }
            }
            return conversion_Bin;//on retourne la concatenation finale des conversions successives d'hexadecimaux vers binaires
        }

        /// <summary>
        /// Inversers the string.
        /// </summary>
        /// <param name="chaine">The chaine.</param>
        /// <returns></returns>
        public string InverserString(string chaine)
        {

            #region Variables Locales
            string invert_Chaine = null;
            var tab_Car = chaine.ToCharArray();     //convertir la string en tableau de caractères pour avoir accès à la methode Reverse();
            var tab_CarInv = tab_Car.Reverse();   //copier la version inversée du tableau précédent dans un nouveau tableau        
            #endregion

            foreach ( var car in tab_CarInv )
            {
                invert_Chaine += car;//concaténation du tableau de caractères inversé
            }
            return invert_Chaine;
        }

        /// <summary>
        /// Extensions the URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public string ExtensionURL(string url)
        {
            #region variables locales
            int rang = 0;
            string extension = null;
            var inv_Url = InverserString(url);
            #endregion

            for ( int index = 0; index < inv_Url.Length; index++ )
            {
                if ( (inv_Url[index] == '.') && (rang == 0) )
                {
                    rang = index;
                }
            }
            for ( int index2 = 0; index2 < rang; index2++ )
            {
                extension += inv_Url[index2];
            }
            return extension;
        }

        #region  Raccourcir une chaine.

        /// <summary>
        /// Raccourcir une chaine de plus de 8 caractères en
        /// placant entre les 4 caractères de début et de fin,
        /// la chaine "[...]".
        /// </summary>
        /// <param name="chaine">Chaine à raccourcir.</param>
        /// <returns>Chaine raccourcie.</returns>
        /// <Auteur>Coral</Auteur>
        /// <Creation>17/02/2010</Creation>
        /// <Maj></Maj>
        public string RetourneChaineRaccourcie(string chaine)
        {
            #region Variables Locales

            //sauvegarde de la chaine entiere au cas ou
            var backupChaine = chaine;
            var chaineCourte = string.Empty;

            #endregion

            if ( chaine.Length > 8 )
            {
                chaineCourte = chaine.Substring(0, 4) + "[...]" + chaine.Substring(chaine.Length - 5, 4);
            }
            else
            {
                chaineCourte = chaine;
            }

            return chaineCourte;
        }

        #endregion

        /// <summary>
        /// Domaines the URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public string domaineURL(string url)
        {
            #region Variables Locales
            string domaine = null;
            int debutDomaine = 0;
            #endregion

            if ( url.Contains("//") )//test pour savoir si on est bien dans un url
            {
                debutDomaine = url.IndexOf('.') + 1;
                domaine = url.Substring(debutDomaine, url.Length - debutDomaine);
            }
            return domaine;
        }

        /// <summary>
        /// Souses the domaine URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public string sousDomaineURL(string url)
        {
            #region Variables Locales
            var domaine = domaineURL(url);
            var debutSousDomaine = url.IndexOf("//") + 2;
            var finSousDomaine = url.IndexOf(domaine);
            var longueurSousDomaine = url.Length - ((debutSousDomaine + 1) + (url.Length - finSousDomaine));
            string sousDomaine = null;
            #endregion

            if ( url.Contains("www") )//l'url contient www
            {
                if ( url.IndexOf("www") < finSousDomaine )//les www se trouvent avant le nom de domaine
                {
                    return "Aucun sous domaine n'est accessible depuis l'Url précisé";//on n'est pas dans un sous domaine
                }
            }

            return sousDomaine = url.Substring(debutSousDomaine, longueurSousDomaine);
        }

        /// <summary>
        /// procédure qui met une phrase au pluriel. La phrase est donnée en paramètre.C'est un
        /// début d'algorythme qui demandera surement plusieurs mois pour une grammaire complète de
        /// la langue française.
        /// </summary>
        /// <param name="phrase">The phrase.</param>
        /// <returns></returns>
        public string Pluriel(string phrase)
        {
            string[] separateurs = new string[] { " ", "," };
            string[] pluriel = phrase.Split(separateurs, StringSplitOptions.None);
            string resultat = "";
            for ( int i = 0; i < pluriel.Length; i++ )
            {
                //Le switch devra comprendre tous les cas à mettre au pluriel
                switch ( pluriel[i] )
                {
                    case "je":
                        resultat = resultat + "nous" + " ";
                        break;
                    case "j'ai":
                        resultat = resultat + "nous avons" + " ";
                        break;
                    case "tu":
                        resultat = resultat + " vous" + " ";
                        break;
                    case "il":
                        resultat = resultat + "ils" + " ";
                        break;
                    case "elle":
                        resultat = resultat + "elles" + " ";
                        break;
                    case "on":
                        resultat = resultat + "nous" + " ";
                        break;
                    case "un":
                        resultat = resultat + "des" + " ";
                        break;
                    case "une":
                        resultat = resultat + "des" + " ";
                        break;
                    case "le":
                        resultat = resultat + "les" + " ";
                        break;
                    case "la":
                        resultat = resultat + "les" + " ";

                        break;

                    case "suis":
                        resultat = resultat + "sommes" + " ";
                        break;
                    case "es":
                        resultat = resultat + "êtes" + " ";
                        break;
                    case "est":
                        resultat = resultat + "sont" + " ";
                        break;

                    case "as":
                        resultat = resultat + "avez" + " ";
                        break;
                    case "a":
                        resultat = resultat + "ont" + " ";
                        break;

                    // si aucun des cas n'est trouvé le défault met un "s" à la fin du mot.
                    default:
                        resultat = resultat + " " + pluriel[i] + "s" + " ";
                        break;

                }

            }

            return resultat;
        }

        /// <summary>
        /// Compter le nombre de sous-chaîne.
        /// </summary>
        /// <param name="phrase">The phrase.</param>
        /// <returns></returns>
        public string NombreSousChaines(string phrase)
        {
            string[] separateurs = new string[] { " ", "," };
            string[] souschaine = phrase.Split(separateurs, StringSplitOptions.None);
            int compteur = 0;
            foreach ( var mot in souschaine )
            {
                compteur++;
            }
            return "il y a " + compteur + " sous-chaines";
        }

        /// <summary>
        /// Occurenceses the chaine.
        /// </summary>
        /// <param name="chaine1">The chaine1.</param>
        /// <param name="chaine2">The chaine2.</param>
        /// <returns></returns>
        public string OccurencesChaine(string chaine1, string chaine2)
        {
            int compteur = 0;
            char[] separateurs = new char[] { ' ', ',', ':' };
            string[] souschaine = chaine1.Split(separateurs, StringSplitOptions.None);
            for ( int i = 0; i < souschaine.Length; i++ )
            {
                if ( souschaine[i] == chaine2 )
                    compteur++;
            }
            return "Il y a " + Convert.ToString(compteur) + " " + "fois " + chaine2 + " " + "dans " + chaine1;
        }

        /// <summary>
        /// Effacer le dernier caractère de la chaine.
        /// </summary>
        /// <param name="chaine">La chaine.</param>
        /// <returns>La chaine privé de son dernier caractère</returns>
        public string EffacerDernier(string chaine)
        {
            return chaine.Remove(chaine.Length - 1);
        }

        /// <summary>
        /// Effacer le dernier caractère de la chaine passée par référence.
        /// </summary>
        /// <param name="chaine">The chaine.</param>
        public void EffacerDernier(ref string chaine)
        {
            chaine = chaine.Remove(chaine.Length - 1);
        }

        /// <summary>
        /// Exclure les caracteres contenu dans le tableau passé dans le second paramètre, de la chaine passée en paramètre.
        /// </summary>
        /// <param name="chaine">chaine d'origine.</param>
        /// <param name="carac">Tableau des caractères à exclure de la chaine.</param>
        /// <returns></returns>
        public string ExclureCaracteres(string chaine, char[] carac)
        {
            string temp = "";
            for ( int i = 0; i < chaine.Length; i++ )
            {
                for ( int j = 0; j < carac.Length; j++ )
                {
                    if ( chaine[i].Equals(carac[j]) )
                    {
                        temp += carac[j];
                        break;
                    }
                }
            }

            return temp;
        }


        /// <summary>
        /// Supprime les doublons d'un tableau de strings.
        /// </summary>
        /// <param name="Tabl">Tableau de string.</param>
        /// <returns></returns>
        public string[] SupprimerDoublons(string[] Tabl)
        {
            List<string> temp = new List<string>();

            for ( int i = 0; i < Tabl.Length; i++ )
            {
                foreach ( string str in temp )
                {
                    if ( str.Equals(Tabl[i]) )
                    {
                        temp.Add(Tabl[i]);
                        break;
                    }
                }
            }

            string[] resultat = new string[temp.Count];

            for ( int i = 0; i < temp.Count; i++ )
            {
                resultat[i] = temp[i];
            }

            return resultat;
        }

        #endregion

        #region Méthodes protégées

        #endregion

        #region Méthodes privées

        #endregion

        #region Initialisation, finalisation

        #region Constructeurs

        /// <summary>
        ///	Initialise une nouvelle instance de la classe <see cref="Chaine"/>.	
        /// </summary>
        public Chaine()
        {
            // TODO: Constructeur de la classe Chaine
        }

        /// <summary>
        /// Retourne une valeur <see cref="System.String"/> représentant cette instance.
        /// </summary>
        /// <returns>
        /// Valeur <see cref="System.String"/> représentant cette instance.
        /// </returns> 
        public override string ToString()
        {
            return "Chaine";
        }

        #endregion

        #endregion
    }
}
