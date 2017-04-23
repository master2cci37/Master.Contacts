// * ==========================================================================
// Application : Master.Classes 
// Classe : Systeme 
// Fonctions : Classe de gestion de Systeme 
// License:  License LGPL 
// Version :  0.01 du 04/02/2010 
// Lien : http://masterclasses.codeplex.com 
// Auteur(s) : Olivier
// CopyLeft  :  CopyRight (C) 2010 Master 2 CCI Tours <master2cci@laposte.net>
// Création : 04/02/2010
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Schema;
using Microsoft.Win32.SafeHandles;
using System.Management;

#endregion

namespace Master.Classes.Systeme
{
    /// <summary>
    ///	Classe de gestion de Systeme.
    ///	</summary>	
    public class Systeme
    {
 #region Importations

        ///<summary>
        /// Utilisé dans le code pour arreter et redmarrer l'ordinateur
        ///</summary>
        ///<param name="uFlags">parametres indiquand le type d'action (0x02 pour redemarrer, 0x01 pour arreter)</param>
        ///<param name="dwReason"></param>
        [DllImport("user32.dll")]
        static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        ///<summary>
        /// Utilisé pour gerer la barre des tâches Windows
        ///</summary>
        [DllImport("user32", EntryPoint = "FindWindowA")]
        public static extern int FindWindows(String lpClassName, String lpWindowsName);

        ///<summary>
        /// Utilisé pour gerer la barre des tâches Windows
        ///</summary>
        [DllImport("user32")]
        public static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        /// <summary>
        /// Chargement des informations clavier
        /// </summary>
        /// <param name="pwszKLID">identifiant local du clavier</param>
        /// <param name="Flags">options d'identifiant du clavier</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern long LoadKeyboardLayout(string pwszKLID, uint Flags);

        /// <summary>
        /// Retrouve le nom de l'arrangement du clavier a partir du code
        /// </summary>
        /// <param name="pwszKLID">Code clavier</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern long GetKeyboardLayoutName(System.Text.StringBuilder pwszKLID);

        /// <summary>
        /// 2 importations necessaires pour l'ouverture de console
        /// </summary>
        /// <param name="nStdHandle"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "GetStdHandle", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetStdHandle(int nStdHandle);
        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();

        #endregion
        #region Attributs

        #endregion

        #region Constantes


        ///<summary>
        /// Valeur correspondant à afficher la barre des taches windows
        ///</summary>
        private const int TASKBAR_SHOW = 64;

        ///<summary>
        /// Valeur correspondant à cacher la barre des taches windows
        ///</summary>
        private const int TASKBAR_HIDE = 128;

        private const uint KLF_ACTIVATE = 1; //activer l'azgencement du clavier
        private const int KL_NAMELENGTH = 9; // Taille du buffer clavier
        private const string LANG_EN_US = "00000409";
        private const string LANG_FR_FR = "0000040c";
        /// <summary>
        /// Champs utils pour l'ouverture d'une nouvelle console
        /// </summary>
        private const int STD_OUTPUT_HANDLE = -11;
        private const int MY_CODE_PAGE = 437;
        #endregion

        #region Propriétés

        #endregion

        #region Méthodes publiques
  ///<summary>
        /// Methode permettant l'arret du pc
        ///</summary>
        public static void ArretPc()
        {
            ArretRedemarre("8");//8=>arreter
        }

        ///<summary>
        /// Methodes permettant le redemarrage du pc
        ///</summary>
        public static void RedemarrerPc()
        {
            ArretRedemarre("2");//2=>redemarrer
        }

        /// <summary>
        /// Methode de redemarrage ou arret
        /// </summary>
        /// <param name="valeur">parametre d'arret("8") ou redemarrage("2")</param>
        private static void ArretRedemarre(string valeur)
        {
            ManagementBaseObject outParameters = null;
            ManagementClass sysOs = new ManagementClass("Win32_OperatingSystem");
            sysOs.Get();
            // enables required security privilege.
            sysOs.Scope.Options.EnablePrivileges = true;
            // get our in parameters
            ManagementBaseObject inParameters = sysOs.GetMethodParameters("Win32Shutdown");

            inParameters["Flags"] = "2";//redemarrage
            inParameters["Reserved"] = "0";
            foreach (ManagementObject manObj in sysOs.GetInstances())
            {
                outParameters = manObj.InvokeMethod("Win32Shutdown", inParameters, null);
            }
        }

        ///<summary>
        /// Affichage des variables d'environement dans une console
        ///</summary>
        public static void AfficherVariableEnv()
        {
            //ouverture d'une nouvelle console, et definition comme sortie standard pour Console.write...
            AllocConsole();
            IntPtr stdHandle = GetStdHandle(STD_OUTPUT_HANDLE);
            SafeFileHandle safeFileHandle = new SafeFileHandle(stdHandle, true);
            FileStream fileStream = new FileStream(safeFileHandle, FileAccess.Write);
            Encoding encoding = System.Text.Encoding.GetEncoding(MY_CODE_PAGE);
            StreamWriter standardOutput = new StreamWriter(fileStream, encoding);
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
            //fin definition nouvelle console

            IDictionary environmentVariables = Environment.GetEnvironmentVariables();
            foreach (DictionaryEntry variable in environmentVariables)
                Console.WriteLine(String.Format("{0} = {1}", variable.Key, variable.Value));
            Console.ReadLine();

        }

        ///<summary>
        /// Affichage de la barre des tâches
        ///</summary>
        public static void AfficherBarreDesTaches()
        {
            int taskBarHandle = FindWindows("Shell_traywnd", String.Empty);
            SetWindowPos(taskBarHandle, 0, 0, 0, 0, 0, TASKBAR_SHOW);
        }

        ///<summary>
        /// Cacher la barre des tâches
        ///</summary>
        public static void CacherBarreDesTaches()
        {
            int taskBarHandle = FindWindows("Shell_traywnd", String.Empty);
            SetWindowPos(taskBarHandle, 0, 0, 0, 0, 0, TASKBAR_HIDE);
        }

        /// <summary>
        /// Methode qui intervertit la langue entre francais et anglais
        /// </summary>
        public static void ChangerLangueClavier()
        {
            System.Text.StringBuilder name = new System.Text.StringBuilder(KL_NAMELENGTH);

            GetKeyboardLayoutName(name);
            string a = name.ToString();
            if (name.ToString() == LANG_EN_US)
            {
                LoadKeyboardLayout(LANG_FR_FR, KLF_ACTIVATE);
            }
            else
            {
                LoadKeyboardLayout(LANG_EN_US, KLF_ACTIVATE);
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
        ///	Initialise une nouvelle instance de la classe <see cref="Systeme"/>.	
        /// </summary>
        public Systeme()
        {
            // TODO: Constructeur de la classe Systeme
        }

        /// <summary>
        /// Retourne une valeur <see cref="System.String"/> représentant cette instance.
        /// </summary>
        /// <returns>
        /// Valeur <see cref="System.String"/> représentant cette instance.
        /// </returns> 
        public override string ToString()
        {
            return "Systeme";
        }

        #endregion

        #endregion
    }
}
