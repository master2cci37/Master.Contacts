// * ==========================================================================
// Application : Master.Classes 
// Classe : MySql 
// Fonctions : Classe de gestion de Données 
// License:  License LGPL 
// Version :  0.01 du 99/99/2010 
// Lien : http://masterclasses.codeplex.com 
// Auteur(s) : Yoann Lorho
// CopyLeft  :  CopyRight (C) 2010 Master 2 CCI Tours <master2cci@laposte.net>
// Création : 11/02/2010
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
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

#endregion

namespace Master.Classes.Donnees
{
    /// <summary>
    /// Classe de gestion de Données.
    /// </summary>
    public class MySql
    {
        #region Attributs

        private String srv;
        private String db;
        private String host;
        private String pwd;
        private MySqlConnection cnx; 

        #endregion

        #region Constantes

        #endregion

        #region Propriétés

        #endregion

        #region Méthodes publiques

		//methode qui permet d'executer une requete sans retour d'info 
		public string executRqt(String uneRqt)
		{	
			try
			{
				if(cnx.State == System.Data.ConnectionState.Closed)
				{
					cnx.Open();
				}
				MySqlDataAdapter da = new MySqlDataAdapter();
				da.SelectCommand = new MySqlCommand(uneRqt,cnx);
				da.SelectCommand.ExecuteNonQuery();
				return "ok";
			}
			catch(Exception e)
			{
				return e.Message;
			}
		}
		public DataSet getDataSet(String uneRqt)
		{
			if(cnx.State == System.Data.ConnectionState.Closed)
			{
				cnx.Open();
			}
			DataSet ds = new DataSet();
			MySqlDataAdapter da = new MySqlDataAdapter(uneRqt,cnx);
			da.Fill(ds);
			return ds;
			
		}
		public void closeCnx()
		{
			
			cnx.Close();
		}
		
        #endregion

        #region Méthodes protégées

        #endregion

        #region Méthodes privées

        #endregion

        #region Initialisation, finalisation

        #region Constructeurs

        /// <summary>
        ///	Initialise une nouvelle instance de la classe <see cref="MySql"/>.	
        /// </summary>
        public MySql(String unSrv, String uneDb, String unHost, String unPwd)
        {
            srv = unSrv;
            db = uneDb;
            host = unHost;
            pwd = unPwd;
            //définition de la connection 
            string chaineCnx = "Database=" + db + ";Data Source=" + srv + ";User Id=" + host + ";Password=" + pwd + "";
            cnx = new MySqlConnection();
            cnx.ConnectionString = chaineCnx;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MySql"/> class.
        /// </summary>
        public MySql(String unSrv, String unHost, String unPwd)
        {
            srv = unSrv;
            host = unHost;
            pwd = unPwd;
            //définition de la connection 
            string chaineCnx = "Data Source=" + srv + ";User Id=" + host + ";Password=" + pwd + "";
            cnx = new MySqlConnection();
            cnx.ConnectionString = chaineCnx;
        }

        /// <summary>
        /// Retourne une valeur <see cref="System.String"/> représentant cette instance.
        /// </summary>
        /// <returns>
        /// Valeur <see cref="System.String"/> représentant cette instance.
        /// </returns> 
        public override string ToString()
        {
            return "MySql";
        }

        #endregion

        #endregion
    }
}