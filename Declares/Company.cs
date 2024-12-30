using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Declares
{
    public class Company
    {
        public decimal Id { get; set; }
        public DateTime ComDateOperate { get; set; }
        public string ComNumber { get; set; }
        public string ComName { get; set; }
        public string ComAddress { get; set; }
        public string ComCity { get; set; }
        public string ComCountry { get; set; }
        public string ComVATNumber { get; set; }
        public string ComTelephone { get; set; }
        public string ComMobilePhone { get; set; }
        public string ComFaxNumber { get; set; }
        public string ComEmail { get; set; }
        public string ComWebsite { get; set; }
        public string ComRemark { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CompanyCode { get; set; }
        public string RegistrationNumber { get; set; }
        public string DatabaseName { get; set; }
        public string SecondaryDB { get; set; }
        public string TablePrefix { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsSql2000 { get; set; }
        public bool IsStock { get; set; }
        public long MenuValue { get; set; }
        public DateTime MinBalanceDate { get; set; }
        public DateTime MinDownloadDate { get; set; }


        private string _connectionstring;
        private System.Data.SqlClient.SqlConnectionStringBuilder _connectionbuilder;
        public System.Data.SqlClient.SqlConnectionStringBuilder ConnectionBuilder
        {
            get
            {
                return _connectionbuilder;
            }
            set
            {
                _connectionbuilder = value;
                _connectionstring = _connectionbuilder.ConnectionString;
            }
        }

        public string ConnectionString
        {
            get
            {
                return _connectionstring;
            }
            set
            {
                _connectionstring = value;
                _connectionbuilder.ConnectionString = _connectionstring;
            }
        }
    }
}
