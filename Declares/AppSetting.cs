using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.VisualBasic.Devices;


namespace DeliveryTakeOrder.Declares
{
    public class AppSetting
    {
        public static DataTable DTAllPaymentTables { get; set; }
        public static DataTable DTAllStatementTables { get; set; }
        public static DataTable DTAllDivisionTables { get; set; }

        private static string _connectionstring;
        private static SqlConnectionStringBuilder _connectionstringbuilder;

        public static int SaleManagerID { get; set; } = 0;

        public static string AppName
        {
            get
            {
                return "Delivery Take Order (UNT Wholesale)";
            }
        }

        public static string AppNameSpace
        {
            get
            {
                return "untwholesale";
            }
        }

        public static int AppNumber
        {
            get
            {
                return -1;
            }
        }

        public static string ApplicationVersion
        {
            get
            {
                return "2020.09.21";
            }
        }

        private static string _signalrserver = "192.168.1.99";
        public static string SignalRClientServer
        {
            get
            {
                return _signalrserver;
            }
            set
            {
                _signalrserver = value;
            }
        }

        private static RMDB _db;
        public static RMDB DBMain
        {
            get
            {
                if (_db is null)
                    _db = new RMDB(ConnectionString);
                return _db;
            }
        }

        private static RMDB _db_local;
        public static RMDB DBLOCAL
        {
            get
            {
                if (_db_local is null)
                {
                    var conBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder()
                    {
                        DataSource = "192.168.1.58",
                        InitialCatalog = "DBUNTWHOLESALECOLTD",
                        UserID = "UserConnection",
                        Password = "123"
                    };
                    _db_local = new RMDB(conBuilder.ConnectionString);
                }
                return _db_local;
            }
        }

        public static string ConnectionString
        {
            get
            {

                if (_connectionstring is null)
                    InitialCompany();
                return _connectionstring;
            }
            set
            {
                if (value is null)
                    return;
                _connectionstring = value;
                _connectionstringbuilder.ConnectionString = _connectionstring;
            }
        }

        public static System.Data.SqlClient.SqlConnectionStringBuilder ConnectionStringBuilder
        {
            get
            {
                if (_connectionstring is null)
                    InitialCompany();
                return _connectionstringbuilder;
            }
            set
            {
                if (value is null)
                    return;
                _connectionstringbuilder = value;
                _connectionstring = _connectionstringbuilder.ConnectionString;
            }
        }
        public static bool IsHostReachable(string ipAddress)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send(ipAddress);
                    return reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                return false;
            }
        }

        private static List<Company> _lscompany = new List<Company>();
        public static void InitialCompany()
        {
            string primary_ip = "192.168.1.111";
            string secondary_ip = "192.168.100.49";

      
            if (!IsHostReachable( primary_ip))
            {
                primary_ip = secondary_ip;
            }
            

            var conBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder()
            {
                DataSource = primary_ip,
                InitialCatalog = "DBUNTWHOLESALECOLTD",
                UserID = "UserConnection",
                Password = "123"
            };

            // Dim conBuilder As New SqlClient.SqlConnectionStringBuilder With {.DataSource = ".",
            // .InitialCatalog = "DBCompanySetup",
            // .IntegratedSecurity = True}
            ConnectionStringBuilder = conBuilder;
            var oCompany = new Company();
            oCompany.ComName = "UNT WHOLESALE CO., LTD";
            oCompany.ComAddress = (string)new XElement("String", new XCData(@"
Land Lot No. 891, 
Sangkat Chorm Chao, Khan Por Sen Chey, 
Phnom Penh, Cambodia
Tel: (855) 023 995 900 / 012 702 000
Fax: (855) 203 995 589
"));
            oCompany.ComCity = "Phnom Penh";
            oCompany.ComCountry = "Cambodia";
            oCompany.CompanyCode = Convert.ToInt32("10001");
            oCompany.ComVATNumber = "L001-100050409";
            oCompany.ComTelephone = "(855)012 702 000";
            oCompany.DatabaseName = "DBUNTWHOLESALECOLTD";
            oCompany.SecondaryDB = "Stock";
            oCompany.MinBalanceDate = DateTimePicker.MinimumDateTime; // New Date(2016, 8, 2)
            oCompany.MinDownloadDate = new DateTime(2017, 2, 1); // 
            oCompany.ConnectionBuilder = conBuilder;
            oCompany.IsStock = true;

            _lscompany.Add(oCompany);
            BSCompany = new BindingSource(_lscompany, null);
        }

        public static List<Company> Companies
        {
            get
            {
                return _lscompany;
            }
        }

        public static DataRow DRCurrentUser { get; set; }
        public static BindingSource BSCompany { get; set; }

        public static Company CurrentCompany
        {
            get
            {
             Company curCompany = (Company)BSCompany.Current;
                return curCompany;
            }
        }

        public static int get_GetCurrentServerYear(string pConnectionString)
        {
            var db = new RMDB(pConnectionString);
            var dt = db.GetDataTable("SELECT DATEPART(YEAR, GETDATE()) AS yyyy");
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public static DateTime get_GetCurrentServerDate(string pConnectionString)
        {
            var db = new RMDB(pConnectionString);
            var dt = db.GetDataTable("SELECT GETDATE() AS dddd");
            return Convert.ToDateTime(dt.Rows[0][0]);
        }

        public static DateTime GetCurrentServerDate
        {
            get
            {
                return get_GetCurrentServerDate(ConnectionString);
            }
        }

        public static DataTable SaleManager_Supplier { get; set; }
        public static DataTable DtArCustomer { get; set; }

        // Public Shared ReadOnly Property SqlGetCompany() As String
        // Get
        // Dim sqlGet As String = String.Empty

        // sqlGet = _
        // <SQL><![CDATA[
        // ;
        // WITH    vCompany
        // AS ( SELECT   0 AS Id ,
        // GETDATE() ComDateOperate ,
        // N'' ComNumber ,
        // N'(Select Company)' ComName ,
        // N'' ComAddress ,
        // N'' ComCity ,
        // N'' ComCountry ,
        // N'' ComVATNumber ,
        // N'' ComTelephone ,
        // N'' ComMobilePhone ,
        // N'' ComFaxNumber ,
        // N'' ComEmail ,
        // N'' ComWebsite ,
        // N'' ComRemark ,
        // GETDATE() CreatedDate ,
        // 0 CompanyCode ,
        // N'' RegistrationNumber ,
        // N'' DatabaseName ,
        // N'' ConnectionString ,
        // N'' SecondaryDB ,
        // N'' TablePrefix ,
        // NULL IsDeleted ,
        // NULL IsAvailable ,
        // NULL IsSql2000 ,
        // NULL IsStock ,
        // 1 MenuValue ,
        // GETDATE() MinBalanceDate ,
        // GETDATE() MinDownloadDate
        // UNION ALL
        // SELECT   Id ,
        // ComDateOperate ,
        // ComNumber ,
        // ComName ,
        // ComAddress ,
        // ComCity ,
        // ComCountry ,
        // ComVATNumber ,
        // ComTelephone ,
        // ComMobilePhone ,
        // ComFaxNumber ,
        // ComEmail ,
        // ComWebsite ,
        // ComRemark ,
        // CreatedDate ,
        // CompanyCode ,
        // RegistrationNumber ,
        // DatabaseName ,
        // ConnectionString ,
        // SecondaryDB ,
        // TablePrefix ,
        // IsDeleted ,
        // IsAvailable ,
        // IsSql2000 ,
        // IsStock ,
        // MenuValue ,
        // MinBalanceDate ,
        // MinDownloadDate
        // FROM     dbo.TblCompanies
        // WHERE    IsAvailable = 1
        // AND IsDeleted = 0 
        // AND IsDeleted = 0 AND (CompanyCode IN ({0}))
        // )
        // SELECT  *
        // FROM    vCompany
        // ORDER BY vCompany.ComName;
        // ]]></SQL>
        // Return sqlGet
        // End Get
        // End Property
    }
}
