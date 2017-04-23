// * ==========================================================================
// Application : Master.Classes 
// Classe : Journal 
// Fonctions : Classe de journalisation de traitements et exceptions 
// License:  License LGPL 
// Version :  0.01 du 99/99/2010 
// Lien : http://masterclasses.codeplex.com 
// Auteur(s) : Aqua
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
#define TRACE
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
    ///	Classe de journalisation de traitements et exceptions.
    ///	</summary>	
 /// <Auteur>JFP</Auteur>
    /// <Creation>22/02/2010</Creation>
    /// <Maj></Maj>
    /// <remarks>
    /// Code à placer dans app.config :
    ///  <system.diagnostics>
    ///    <trace autoflush="true" indentsize="4">
    ///      <listeners>
    ///        <add name="Journal" type="System.Diagnostics.TextWriterTraceListener"
    ///             initializeData="Master.GestTaches.log" />
    ///        <remove name="Default" />
    ///      </listeners>
    ///    </trace>
    ///  </system.diagnostics>
    ///  Code à placer dans les membres privés des classes à journaliser :
    ///  Journal journal = new Journal(typeof(nomDeLaClasse));
    ///  Version Log4Net : 
    ///   private static readonly ILog journal =  LogManager.GetLogger(typeof(nomDeLaClasse));
    /// </remarks>
    public class Journal
    {
        /// <summary>
        /// Nom de la classe journalisée.
        /// </summary>
        private string classe = string.Empty;

        private const string fmtTraceQuatreValeurs = "{0:dd/MM/yyyy HH:mm:ss.fff} {1} {2} : {3}";
        private const string fmtTraceCinqValeurs = "{0:dd/MM/yyyy HH:mm:ss.fff} {1} {2} : {3} {4}";

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Journal"/> class.
        /// </summary>
        /// <Auteur>JFP</Auteur>
        /// <Creation>22/02/2010</Creation>
        /// <Maj></Maj>
        public Journal(Type type)
        {
            this.classe = type.Name;
        }

        /// <summary>
        /// Debug sur le message spécifié.
        /// </summary>
        /// <param name="message">Le message.</param>
        /// <Auteur>JFP</Auteur>
        /// <Creation>22/02/2010</Creation>
        /// <Maj></Maj>
        public void Debug(string message)
        {
            Trace.WriteLine(string.Format(fmtTraceQuatreValeurs, "DEBUG", DateTime.Now, this.classe, message));
        }

        /// <summary>
        /// Informations sur le message spécifié.
        /// </summary>
        /// <param name="message">Le message.</param>
        /// <Auteur>JFP</Auteur>
        /// <Creation>22/02/2010</Creation>
        /// <Maj></Maj>
        public void Info(string message)
        {
            Trace.WriteLine(string.Format(fmtTraceQuatreValeurs, "INFO", DateTime.Now, this.classe, message));
        }

        /// <summary>
        /// Warnings sur le message spécifié.
        /// </summary>
        /// <param name="message">Le message.</param>
        /// <Auteur>JFP</Auteur>
        /// <Creation>22/02/2010</Creation>
        /// <Maj></Maj>
        public void Warn(string message)
        {
            Trace.WriteLine(string.Format(fmtTraceQuatreValeurs, "WARN", DateTime.Now, this.classe, message));
        }

        /// <summary>
        /// Erreurs sur le message spécifié.
        /// </summary>
        /// <param name="message">Le message.</param>
        /// <param name="exception">Une exception.</param>
        /// <Auteur>JFP</Auteur>
        /// <Creation>22/02/2010</Creation>
        /// <Maj></Maj>
        public void Error(string message, Exception exception)
        {
            Trace.WriteLine(string.Format(fmtTraceCinqValeurs, "ERROR", DateTime.Now, this.classe, message, exception.Message));
        }

        /// <summary>
        /// Fatal sur le message spécifié.
        /// </summary>
        /// <param name="message">Le message.</param>
        /// <param name="exception">Une exception.</param>
        /// <Auteur>JFP</Auteur>
        /// <Creation>22/02/2010</Creation>
        /// <Maj></Maj>
        public void Fatal(string message, Exception exception)
        {
            Trace.WriteLine(string.Format(fmtTraceCinqValeurs, "FATAL", DateTime.Now, this.classe, message, exception.Message));
        }

    }
}
