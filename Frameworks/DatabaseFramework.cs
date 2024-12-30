using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MySql.Data.MySqlClient;


namespace DeliveryTakeOrder.DatabaseFrameworks
{

    public class DatabaseFramework_MySQL : DeliveryTakeOrder.Configurations, IDisposable
    {
        private string strconnection = "host=192.168.1.22;port=3306;user id=root;password=!$%2m2O8mkn6iG5v2or!@#$#@678;database=untapp;pooling=false;";
        private DeliveryTakeOrder.ApplicationFrameworks.ApplicationFramework App = new DeliveryTakeOrder.ApplicationFrameworks.ApplicationFramework();
        private MySqlConnection Connection;
        private MySqlCommand Command;

        public string MysqlConnectionString
        {
            set
            {
                strconnection = value;
            }
            get
            {
                return strconnection;
            }
        }

        public DatabaseFramework_MySQL()
        {

        }

        public DatabaseFramework_MySQL(DeliveryTakeOrder.Configurations.ConnectionType Type)
        {
            try
            {
                Connection = new MySqlConnection(strconnection);
                Connection.Open();
                Connection.Close();
                Connection = null;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The database connection fail! The application will be closed." + Constants.vbCrLf + " Please check with your support!", "Error database connection", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(0);
            }
        }

        public DatabaseFramework_MySQL(DeliveryTakeOrder.Configurations.ConnectionType Type, bool IsPrefixDatabase)
        {
            try
            {
                Connection = new MySqlConnection(strconnection);
                Connection.Open();
                Connection.Close();
                Connection = null;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The database connection fail! The application will be closed." + Constants.vbCrLf + " Please check with your support!", "Error database connection", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(0);
            }
        }

        public DateTime Get_CURRENT_DATE()
        {
            var R_CurrentDate = default(DateTime);
            DataTable DtData;
            try
            {
                Connection = new MySqlConnection(strconnection);
                Command = new MySqlCommand("select NOW() as `date`;", Connection);
                Command.CommandTimeout = 180;
                Connection.Open();
                DtData = new DataTable();
                DtData.Load(Command.ExecuteReader());
                Connection.Close();
                Connection = null;
                Command = null;
                if (DtData.Rows.Count > 0)
                {
                    R_CurrentDate = Conversions.ToDate(Interaction.IIf(DtData.Rows[0][0] is DBNull == true, DateTime.Now, DtData.Rows[0][0]));
                }
                else
                {
                    R_CurrentDate = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return R_CurrentDate;
        }

        public object Execute(string CommandText)
        {
            var DtData = new DataTable();
            try
            {
                Connection = new MySqlConnection(strconnection);
                Connection.Open();
                Command = new MySqlCommand(CommandText, Connection);
                Command.CommandTimeout = 180;
                Command.ExecuteNonQuery();
                Connection.Close();
                Connection = null;
                Command = null;
                return true;
            }
            catch (Exception ex)
            {
                return "Sql: " + ex.Message.ToString();
            }
        }

        public object Selects(string CommandText)
        {
            var DtData = new DataTable();
            try
            {
                Connection = new MySqlConnection(strconnection);
                Connection.Open();
                Command = new MySqlCommand(CommandText, Connection);
                Command.CommandTimeout = 180;
                DtData = new DataTable();
                DtData.Load(Command.ExecuteReader());
                Connection.Close();
                Connection = null;
                Command = null;
                return DtData;
            }
            catch (Exception ex)
            {
                return "Sql: " + ex.Message.ToString();
            }
        }

        #region IDisposable Support
        private bool disposedValue; // To detect redundant calls

        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                // TODO: set large fields to null.
            }
            disposedValue = true;
        }

        // TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        // Protected Overrides Sub Finalize()
        // ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        // Dispose(False)
        // MyBase.Finalize()
        // End Sub

        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }

    public class DatabaseFramework : DeliveryTakeOrder.Configurations, IDisposable
    {
        private DeliveryTakeOrder.ApplicationFrameworks.ApplicationFramework App = new DeliveryTakeOrder.ApplicationFrameworks.ApplicationFramework();
        private SqlConnection Connection;
        private SqlCommand Command;

        public DatabaseFramework()
        {

        }

        public DatabaseFramework(DeliveryTakeOrder.Configurations.ConnectionType Type)
        {
            try
            {
                Connection = new SqlConnection(this.ConnectionString(Type));
                Connection.Open();
                Connection.Close();
                Connection = null;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The database connection fail! The application will be closed." + Constants.vbCrLf + " Please check with your support!", "Error database connection", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(0);
            }
        }

        public DatabaseFramework(DeliveryTakeOrder.Configurations.ConnectionType Type, bool IsPrefixDatabase)
        {
            try
            {
                Connection = new SqlConnection(this.ConnectionString(Type, IsPrefixDatabase));
                Connection.Open();
                Connection.Close();
                Connection = null;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The database connection fail! The application will be closed." + Constants.vbCrLf + " Please check with your support!", "Error database connection", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(0);
            }
        }

        public DateTime Get_CURRENT_DATE(DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            var R_CurrentDate = default(DateTime);
            DataTable DtData;
            try
            {
                Connection = new SqlConnection(this.ConnectionString(Type));
                Command = new SqlCommand("SELECT GETDATE()", Connection);
                Command.CommandTimeout = 180;
                Connection.Open();
                DtData = new DataTable();
                DtData.Load(Command.ExecuteReader());
                Connection.Close();
                Connection = null;
                Command = null;
                if (DtData.Rows.Count > 0)
                {
                    R_CurrentDate = Conversions.ToDate(Interaction.IIf(DtData.Rows[0][0] is DBNull == true, DateTime.Now, DtData.Rows[0][0]));
                }
                else
                {
                    R_CurrentDate = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return R_CurrentDate;
        }

        public long Get_IDENT_CURRENT(string TableName, DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            bool R_Existed = false;
            long R_IDENTCURRENT = 1L;
            TableName = string.Format("[{0}{1}].[dbo].[{2}{3}]", this.PrefixDatabase, this.DatabaseName, this.PrefixTable, TableName);
            string CommandText = string.Format("SELECT  IDENT_CURRENT('{0}')", TableName);
            DataTable DtData;
            try
            {
                Connection = new SqlConnection(this.ConnectionString(Type));
                Command = new SqlCommand(string.Format("SELECT * FROM {0}", TableName), Connection);
                Command.CommandTimeout = 180;
                Connection.Open();
                DtData = new DataTable();
                DtData.Load(Command.ExecuteReader());
                Connection.Close();
                Command = null;
                if (DtData.Rows.Count > 0)
                {
                    R_Existed = true;
                }
                else
                {
                    R_Existed = false;
                }
                DtData = null;

                Command = new SqlCommand(CommandText, Connection);
                Command.CommandTimeout = 180;
                Connection.Open();
                DtData = new DataTable();
                DtData.Load(Command.ExecuteReader());
                Connection.Close();
                Connection = null;
                Command = null;
                if (DtData.Rows.Count > 0)
                {
                    if (R_Existed == false & Conversions.ToLong(Interaction.IIf(DtData.Rows[0][0] is DBNull == true, 0, DtData.Rows[0][0])) == 1L)
                    {
                        R_IDENTCURRENT = 1L;
                    }
                    else
                    {
                        R_IDENTCURRENT = Conversions.ToLong(Interaction.IIf(DtData.Rows[0][0] is DBNull == true, 0, DtData.Rows[0][0])) + 1L;
                    }
                }

                else
                {
                    R_IDENTCURRENT = 1L;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return R_IDENTCURRENT;
        }

        public object ExecuteCommand(string CommandText, DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            var DtData = new DataTable();
            // If InStr(LTrim(CommandText).ToUpper(), "SELECT", CompareMethod.Text) > 0 Then
            // Try
            // Connection = New SqlConnection(ConnectionString(Type))
            // Connection.Open()
            // Command = New SqlCommand(CommandText, Connection)
            // DtData = New DataTable
            // DtData.Load(Command.ExecuteReader())
            // Connection.Close()
            // Connection = Nothing
            // Command = Nothing
            // Return DtData
            // Catch ex As Exception
            // Return "Sql: " & ex.Message.ToString
            // End Try
            // Else
            try
            {
                Connection = new SqlConnection(this.ConnectionString(Type));
                Connection.Open();
                Command = new SqlCommand(CommandText, Connection);
                Command.CommandTimeout = 180;
                Command.ExecuteNonQuery();
                Connection.Close();
                Connection = null;
                Command = null;
                return true;
            }
            catch (Exception ex)
            {
                return "Sql: " + ex.Message.ToString();
            }
            // Else
            // Return "Incorrect Sql Command String. You can use with command SELECT, INSERT, or UPDATE only."
            // End If
        }

        public object ExecuteStoredProc(string StoreProcName, DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {

        var DtData = new DataTable();
            try
            {
                Connection = new SqlConnection(this.ConnectionString(Type));
                Connection.Open();
                Command = new SqlCommand();
                Command.CommandTimeout = 180;
                Command.Connection = Connection;
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = StoreProcName;
                DtData = new DataTable();
                DtData.Load(Command.ExecuteReader());
                Connection.Close();
                Connection = null;
                Command = null;
                return DtData;
            }
            catch (Exception ex)
            {
                return "Sql: " + ex.Message.ToString();
            }
        }

        public  enum SeparatorList
        {
            Is_And,
            Is_Or
        }
        public DataTable Selects(string SQLCommand, DeliveryTakeOrder.Configurations.ConnectionType Type)
        {
            var DtData = new DataTable();
            try
            {
                using (SqlConnection Connection = new SqlConnection(this.ConnectionString(Type)))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand(SQLCommand, Connection))
                    {
                        Command.CommandTimeout = 180;
                        DtData.Load(Command.ExecuteReader());
                    }
                }
            }
            catch (Exception ex)
            {
                DtData = null;
                MessageBox.Show(ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return DtData;
        }

        public DataTable LoaderData(string strSql)
        {
            SqlConnection cnn;
            SqlDataAdapter dad;

            var dtb = new DataTable();
            cnn = new SqlConnection(this.ConnectionString());
            try
            {
                cnn.Open();
                dad = new SqlDataAdapter(strSql, cnn);
                dad.Fill(dtb);
                cnn.Close();
                dad.Dispose();
            }
            catch (Exception ex)
            {
                cnn.Close();
                Interaction.MsgBox(ex.Message);
            }
            return dtb;
        }
  

        public object Selects(string TableName, ArrayList FieldLists = null, Dictionary<string, object> WhereLists = null, bool IsConditionIN = false, SeparatorList Separator = SeparatorList.Is_And, ArrayList GroupByLists = null, ArrayList OrderByLists = null, DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            TableName = string.Format("[{0}{1}].[dbo].[{2}{3}]", this.PrefixDatabase, this.DatabaseName, this.PrefixTable, TableName);
            var DtData = new DataTable();
            string ConditionWhere = "";
            string FieldList = "";
            if (FieldLists != null)
            {
                foreach (object GroupBy in FieldLists)
                    FieldList += string.Format("{0},", GroupBy);
                if (!string.IsNullOrEmpty(Strings.Trim(FieldList)))
                    FieldList = string.Format("{0}", Strings.Mid(FieldList, 1, FieldList.Length - 1));
            }
            else
            {
                FieldList = "*";
            }
            string CommandText = string.Format("SELECT {0} FROM {1}", FieldList, TableName);
            string RSeparator = Conversions.ToString(Interaction.IIf(Separator == SeparatorList.Is_And, "AND", "OR "));
            if (WhereLists != null)
            {
                foreach (KeyValuePair<string, object> @field in WhereLists)
                {
                    if (IsConditionIN == false)
                    {
                        if (Strings.StrComp(Conversions.ToString(@field.Value), "GETDATE()", CompareMethod.Text) == 0)
                        {
                            ConditionWhere += string.Format("[{0}] = {1}", @field.Key, @field.Value) + " " + RSeparator + " ";
                        }
                        else if (@field.Value is string | @field.Value is DateTime)
                        {
                            ConditionWhere += string.Format("[{0}] = '{1}'", @field.Key, @field.Value) + " " + RSeparator + " ";
                        }
                        else
                        {
                            ConditionWhere += string.Format("[{0}] = {1}", @field.Key, @field.Value) + " " + RSeparator + " ";
                        }
                    }
                    else
                    {
                        ConditionWhere += string.Format("[{0}] IN ({1})", @field.Key, @field.Value) + " " + RSeparator + " ";
                    }
                }
                if (!string.IsNullOrEmpty(Strings.Trim(ConditionWhere)))
                    ConditionWhere = Strings.Mid(ConditionWhere, 1, ConditionWhere.Length - 4);
                CommandText = string.Format("{0} WHERE {1}", CommandText, ConditionWhere);
            }
            string GroupByList = "";    
            if (GroupByLists != null)
            {
                foreach (object GroupBy in GroupByLists)
                    GroupByList += string.Format("{0},", GroupBy);
                if (!string.IsNullOrEmpty(Strings.Trim(GroupByList)))
                    GroupByList = string.Format("GROUP BY {0}", Strings.Mid(GroupByList, 1, GroupByList.Length - 1));
            }

            string OrderByList = "";
            if (OrderByLists != null)
            {
                foreach (object Orderby in OrderByLists)
                    OrderByList += string.Format("{0},", Orderby);
                if (!string.IsNullOrEmpty(Strings.Trim(OrderByList)))
                    OrderByList = string.Format("ORDER BY {0}", Strings.Mid(OrderByList, 1, OrderByList.Length - 1));
            }
            CommandText = string.Format("{0} {1} {2}", CommandText, GroupByList, OrderByList);
            try
            {
                Connection = new SqlConnection(this.ConnectionString(Type));
                Connection.Open();
                Command = new SqlCommand(CommandText, Connection);
                Command.CommandTimeout = 180;
                DtData.Load(Command.ExecuteReader());
                Connection.Close();
                Connection = null;
                Command = null;
            }
            catch (Exception ex)
            {
                DtData = null;
                MessageBox.Show(ex.Message.ToString(), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return DtData;
        }

        public bool Inserts(string TableName, Dictionary<string, object> FieldLists_ValueLists, DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            TableName = string.Format("[{0}{1}].[dbo].[{2}{3}]", this.PrefixDatabase, this.DatabaseName, this.PrefixTable, TableName);
            bool IsCompleted = false;
            string FieldList = "";
            string ValueList = "";
            var ImageList = new Dictionary<string, object>();
            if (FieldLists_ValueLists !=     null)
            {
                foreach (KeyValuePair<string, object> @field in FieldLists_ValueLists)
                {
                    FieldList += string.Format("[{0}],", @field.Key);
                    if (@field.Value is byte[])
                    {
                        ValueList += string.Format("@{0},", @field.Key);
                        ImageList.Add(@field.Key, @field.Value);
                    }
                    else if (Strings.StrComp(Conversions.ToString(@field.Value), "GETDATE()", CompareMethod.Text) == 0)
                    {
                        ValueList += string.Format("{0},", @field.Value);
                    }
                    else if (@field.Value is string | @field.Value is DateTime | @field.Value is null)
                    {
                        if (@field.Value is null)
                        {
                            ValueList += string.Format("N'{0}',", "");
                        }
                        else
                        {
                            ValueList += string.Format("N'{0}',", @field.Value);
                        }
                    }
                    else
                    {
                        ValueList += string.Format("{0},", @field.Value);
                    }
                }
                if (!string.IsNullOrEmpty(Strings.Trim(FieldList)))
                    FieldList = string.Format("{0}", Strings.Mid(FieldList, 1, FieldList.Length - 1));
                if (!string.IsNullOrEmpty(Strings.Trim(ValueList)))
                    ValueList = string.Format("{0}", Strings.Mid(ValueList, 1, ValueList.Length - 1));
            }
            try
            {
                Connection = new SqlConnection(this.ConnectionString(Type));
                Connection.Open();
                Command = new SqlCommand(string.Format("INSERT INTO {0} ({1}) VALUES ({2})", TableName, FieldList, ValueList), Connection);
                Command.CommandTimeout = 180;
                if (ImageList.Count > 0)
                {
                    foreach (KeyValuePair<string, object> @field in ImageList)
                    {
                        if (@field.Value is byte[])
                        {
                            var ImageBytes = new byte[1];
                            ImageBytes = (byte[])@field.Value;
                            {
                                var withBlock = Command.Parameters.Add(new SqlParameter(string.Format("@{0}", @field.Key), SqlDbType.Image));
                                withBlock.Value = ImageBytes;
                                withBlock.Size = ImageBytes.Length;
                            }
                        }
                    }
                }
                Command.ExecuteNonQuery();
                Connection.Close();
                Connection = null;
                Command = null;
                IsCompleted = true;
            }
            catch (SqlException ex)
            {
                IsCompleted = false;
                MessageBox.Show(ex.Message.ToString(), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                IsCompleted = false;
                MessageBox.Show(ex.Message.ToString(), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return IsCompleted;
        }

        public bool Updates(string TableName, Dictionary<string, object> FieldLists_ValueLists, Dictionary<string, object> WhereLists, SeparatorList Separator = SeparatorList.Is_And, DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            TableName = string.Format("[{0}{1}].[dbo].[{2}{3}]", this.PrefixDatabase, this.DatabaseName, this.PrefixTable, TableName);
            bool IsCompleted = false;
            string FieldList_ValueList = "";
            var ImageList = new Dictionary<string, object>();
            if (FieldLists_ValueLists != null)
            {
                foreach (KeyValuePair<string, object> @field in FieldLists_ValueLists)
                {
                    if (@field.Value is byte[])
                    {
                        FieldList_ValueList += string.Format("[{0}] = @{1},", @field.Key, @field.Key);
                        ImageList.Add(@field.Key, @field.Value);
                    }
                    else if (Strings.StrComp(Conversions.ToString(@field.Value), "GETDATE()", CompareMethod.Text) == 0)
                    {
                        FieldList_ValueList += string.Format("[{0}] = {1},", @field.Key, @field.Value);
                    }
                    else if (@field.Value is string | @field.Value is DateTime | @field.Value is null)
                    {
                        if (@field.Value is null)
                        {
                            FieldList_ValueList += string.Format("[{0}] = N'{1}',", @field.Key, "");
                        }
                        else
                        {
                            FieldList_ValueList += string.Format("[{0}] = N'{1}',", @field.Key, @field.Value);
                        }
                    }
                    else
                    {
                        FieldList_ValueList += string.Format("[{0}] = {1},", @field.Key, @field.Value);
                    }
                }
                if (!string.IsNullOrEmpty(Strings.Trim(FieldList_ValueList)))
                    FieldList_ValueList = string.Format("{0}", Strings.Mid(FieldList_ValueList, 1, FieldList_ValueList.Length - 1));
            }
            string SelectedSeparator = Conversions.ToString(Interaction.IIf(Separator == SeparatorList.Is_And, "AND", "OR"));
            string WhereList = "";
            if (WhereLists != null)
            {
                foreach (KeyValuePair<string, object> @field in WhereLists)
                {
                    if (@field.Value is byte[])
                    {
                        WhereList += string.Format("[{0}] = {1} {2}", @field.Key, @field.Value, SelectedSeparator);
                    }
                    else if (Strings.StrComp(Conversions.ToString(@field.Value), "GETDATE()", CompareMethod.Text) == 0)
                    {
                        WhereList += string.Format("[{0}] = {1} {2}", @field.Key, @field.Value, SelectedSeparator);
                    }
                    else if (@field.Value is string | @field.Value is DateTime | @field.Value is null)
                    {
                        if (@field.Value is null)
                        {
                            WhereList += string.Format("[{0}] = '{1}' {2}", @field.Key, "", SelectedSeparator);
                        }
                        else
                        {
                            WhereList += string.Format("[{0}] = '{1}' {2}", @field.Key, @field.Value, SelectedSeparator);
                        }
                    }
                    else
                    {
                        WhereList += string.Format("[{0}] = {1} {2}", @field.Key, @field.Value, SelectedSeparator);
                    }
                }
                if (!string.IsNullOrEmpty(Strings.Trim(WhereList)))
                    WhereList = string.Format("{0}", Strings.Mid(WhereList, 1, WhereList.Length - SelectedSeparator.Length));
            }
            try
            {
                Connection = new SqlConnection(this.ConnectionString(Type));
                Connection.Open();
                Command = new SqlCommand(string.Format("UPDATE {0} SET {1} WHERE {2}", TableName, FieldList_ValueList, WhereList), Connection);
                Command.CommandTimeout = 180;
                if (ImageList.Count > 0)
                {
                    foreach (KeyValuePair<string, object> @field in ImageList)
                    {
                        if (@field.Value is byte[])
                        {
                            var ImageBytes = new byte[1];
                            ImageBytes = (byte[])@field.Value;
                            {
                                var withBlock = Command.Parameters.Add(new SqlParameter(string.Format("@{0}", @field.Key), SqlDbType.Image));
                                withBlock.Value = ImageBytes;
                                withBlock.Size = ImageBytes.Length;
                            }
                        }
                    }
                }
                Command.ExecuteNonQuery();
                Connection.Close();
                Connection = null;
                Command = null;
                IsCompleted = true;
            }
            catch (Exception ex)
            {
                IsCompleted = false;
                MessageBox.Show(ex.Message.ToString(), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return IsCompleted;
        }

        public bool Updates(string TableName, Dictionary<string, object> FieldLists_ValueLists, string WhereLists, DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            TableName = string.Format("[{0}{1}].[dbo].[{2}{3}]", this.PrefixDatabase, this.DatabaseName, this.PrefixTable, TableName);
            bool IsCompleted = false;
            string FieldList_ValueList = "";
            var ImageList = new Dictionary<string, object>();
            if (FieldLists_ValueLists != null)
            {
                foreach (KeyValuePair<string, object> @field in FieldLists_ValueLists)
                {
                    if (@field.Value is byte[])
                    {
                        FieldList_ValueList += string.Format("[{0}] = @{1},", @field.Key, @field.Key);
                        ImageList.Add(@field.Key, @field.Value);
                    }
                    else if (Strings.StrComp(Conversions.ToString(@field.Value), "GETDATE()", CompareMethod.Text) == 0)
                    {
                        FieldList_ValueList += string.Format("[{0}] = {1},", @field.Key, @field.Value);
                    }
                    else if (@field.Value is string | @field.Value is DateTime | @field.Value is null)
                    {
                        if (@field.Value is null)
                        {
                            FieldList_ValueList += string.Format("[{0}] = N'{1}',", @field.Key, "");
                        }
                        else
                        {
                            FieldList_ValueList += string.Format("[{0}] = N'{1}',", @field.Key, @field.Value);
                        }
                    }
                    else
                    {
                        FieldList_ValueList += string.Format("[{0}] = {1},", @field.Key, @field.Value);
                    }
                }
                if (!string.IsNullOrEmpty(Strings.Trim(FieldList_ValueList)))
                    FieldList_ValueList = string.Format("{0}", Strings.Mid(FieldList_ValueList, 1, FieldList_ValueList.Length - 1));
            }
            try
            {
                Connection = new SqlConnection(this.ConnectionString(Type));
                Connection.Open();
                Command = new SqlCommand(string.Format("UPDATE {0} SET {1} WHERE {2}", TableName, FieldList_ValueList, WhereLists), Connection);
                Command.CommandTimeout = 180;
                if (ImageList.Count > 0)
                {
                    foreach (KeyValuePair<string, object> @field in ImageList)
                    {
                        if (@field.Value is byte[])
                        {
                            var ImageBytes = new byte[1];
                            ImageBytes = (byte[])@field.Value;
                            {
                                var withBlock = Command.Parameters.Add(new SqlParameter(string.Format("@{0}", @field.Key), SqlDbType.Image));
                                withBlock.Value = ImageBytes;
                                withBlock.Size = ImageBytes.Length;
                            }
                        }
                    }
                }
                Command.ExecuteNonQuery();
                Connection.Close();
                Connection = null;
                Command = null;
                IsCompleted = true;
            }
            catch (Exception ex)
            {
                IsCompleted = false;
                MessageBox.Show(ex.Message.ToString(), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return IsCompleted;
        }

        public bool Deletes(string TableName, Dictionary<string, object> WhereLists, SeparatorList Separator = SeparatorList.Is_And, DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            TableName = string.Format("[{0}{1}].[dbo].[{2}{3}]", this.PrefixDatabase, this.DatabaseName, this.PrefixTable, TableName);
            bool IsCompleted = false;
            string SelectedSeparator = Conversions.ToString(Interaction.IIf(Separator == SeparatorList.Is_And, "AND", "OR"));
            string WhereList = "";
            if (WhereLists != null)
            {
                foreach (KeyValuePair<string, object> @field in WhereLists)
                {
                    if (Strings.StrComp(Conversions.ToString(@field.Value), "GETDATE()", CompareMethod.Text) == 0)
                    {
                        WhereList += string.Format("[{0}] = {1} {2}", @field.Key, @field.Value, SelectedSeparator);
                    }
                    else if (@field.Value is string | @field.Value is DateTime)
                    {
                        WhereList += string.Format("[{0}] = N'{1}' {2}", @field.Key, @field.Value, SelectedSeparator);
                    }
                    else
                    {
                        WhereList += string.Format("[{0}] = {1} {2}", @field.Key, @field.Value, SelectedSeparator);
                    }
                }
                if (!string.IsNullOrEmpty(Strings.Trim(WhereList)))
                    WhereList = string.Format("{0}", Strings.Mid(WhereList, 1, WhereList.Length - SelectedSeparator.Length));
            }
            try
            {
                Connection = new SqlConnection(this.ConnectionString(Type));
                Connection.Open();
                Command = new SqlCommand(string.Format("DELETE FROM {0} WHERE {1}", TableName, WhereList), Connection);
                Command.CommandTimeout = 180;
                Command.ExecuteNonQuery();
                Connection.Close();
                Connection = null;
                Command = null;
                IsCompleted = true;
            }
            catch (Exception ex)
            {
                IsCompleted = false;
                MessageBox.Show(ex.Message.ToString(), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return IsCompleted;
        }

        public bool Deletes(string TableName, string WhereLists, DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            TableName = string.Format("[{0}{1}].[dbo].[{2}{3}]", this.PrefixDatabase, this.DatabaseName, this.PrefixTable, TableName);
            bool IsCompleted = false;
            try
            {
                Connection = new SqlConnection(this.ConnectionString(Type));
                Connection.Open();
                Command = new SqlCommand(string.Format("DELETE FROM {0} WHERE {1}", TableName, WhereLists), Connection);
                Command.CommandTimeout = 180;
                Command.ExecuteNonQuery();
                Connection.Close();
                Connection = null;
                Command = null;
                IsCompleted = true;
            }
            catch (Exception ex)
            {
                IsCompleted = false;
                MessageBox.Show(ex.Message.ToString(), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return IsCompleted;
        }

        public enum TypeOfCheck
        {
            Database,
            Table,
            Data
        }
        public bool CheckInDatabaseIsExistOrNot(string DatabaseName, string TableName = "", TypeOfCheck Checker = TypeOfCheck.Data, DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            DatabaseName = string.Format("{0}{1}", this.PrefixDatabase, App.MergeObject(DatabaseName));
            TableName = string.Format("{0}{1}", this.PrefixTable, TableName);
            string CommandString = "";
            if (Checker == TypeOfCheck.Database)
            {
                CommandString = "SELECT * FROM master.dbo.sysdatabases WHERE (name = '{0}')";
            }
            else if (Checker == TypeOfCheck.Table)
            {
                CommandString = "USE {0}; SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE (Table_Name IN({1}))";
            }
            else if (Checker == TypeOfCheck.Data)
            {
                CommandString = "USE {0}; SELECT * FROM [dbo].[{1}]";
            }
            var DtData = new DataTable();
            bool IsExisted = false;
            try
            {
                Connection = new SqlConnection(this.ConnectionString(Type));
                Connection.Open();
                Command = new SqlCommand(string.Format(CommandString, DatabaseName, TableName), Connection);
                Command.CommandTimeout = 180;
                DtData.Load(Command.ExecuteReader());
                Connection.Close();
                Connection = null;
                Command = null;
                if (DtData != null)
                {
                    if (DtData.Rows.Count > 0)
                    {
                        IsExisted = true;
                    }
                    else
                    {
                        IsExisted = false;
                    }
                }
                else
                {
                    IsExisted = false;
                }
            }
            catch (SqlException ex)
            {
                DtData = null;
                IsExisted = false;
            }
            catch (Exception ex)
            {
                DtData = null;
                IsExisted = false;
            }
            return IsExisted;
        }

        public bool CreateDatabase(string DatabaseName, string Path = "", DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            string CurrentDatabaseName = DatabaseName;
            DatabaseName = string.Format("{0}{1}", this.PrefixDatabase, App.MergeObject(DatabaseName));
            if (string.IsNullOrEmpty(Strings.Trim(Path)))
                Path = GetCurrentPathSQLServer(Type);
            string CommandString = "USE [master]; ";
            CommandString += "CREATE DATABASE " + DatabaseName + " ";
            CommandString = Conversions.ToString(CommandString + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("ON PRIMARY (NAME = '" + DatabaseName + "_DATA', FILENAME =N'", Interaction.IIf(Strings.StrComp(Strings.Right(Path, 1), @"\", CompareMethod.Text) == 0, Path, Path + @"\")), DatabaseName), "_DATA.MDF' ,SIZE = 20MB ,MAXSIZE = UNLIMITED ,FILEGROWTH = 10MB) "));
            CommandString = Conversions.ToString(CommandString + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("LOG ON (NAME = '" + DatabaseName + "_LOG', FILENAME = N'", Interaction.IIf(Strings.StrComp(Strings.Right(Path, 1), @"\", CompareMethod.Text) == 0, Path, Path + @"\")), DatabaseName), "_LOG.LDF' ,SIZE=20MB ,MAXSIZE = UNLIMITED ,FILEGROWTH = 10MB) "));
            bool IsExisted = false;
            if (CheckInDatabaseIsExistOrNot(CurrentDatabaseName, Checker: TypeOfCheck.Database, Type: Type) == false)
            {
                try
                {
                    Connection = new SqlConnection(this.ConnectionString(Type));
                    Connection.Open();
                    Command = new SqlCommand(CommandString, Connection);
                    Command.CommandTimeout = 180;
                    Command.ExecuteNonQuery();
                    Connection.Close();
                    Connection = null;
                    Command = null;
                    IsExisted = true;
                }
                catch (SqlException ex)
                {
                    IsExisted = false;
                }
                catch (Exception ex)
                {
                    IsExisted = false;
                }
            }
            else
            {
                IsExisted = false;
            }
            return IsExisted;
        }

        public bool DropDatabase(string DatabaseName, DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            string CurrentDatabaseName = DatabaseName;
            DatabaseName = string.Format("{0}{1}", this.PrefixDatabase, App.MergeObject(DatabaseName));
            string CommandString = "USE [master]; ";
            CommandString += "DROP DATABASE " + DatabaseName + "; ";
            bool IsExisted = false;
            if (CheckInDatabaseIsExistOrNot(CurrentDatabaseName, Checker: TypeOfCheck.Database, Type: Type) == true)
            {
                try
                {
                    Connection = new SqlConnection(this.ConnectionString(Type));
                    Connection.Open();
                    Command = new SqlCommand(CommandString, Connection);
                    Command.CommandTimeout = 180;
                    Command.ExecuteNonQuery();
                    Connection.Close();
                    Connection = null;
                    Command = null;
                    IsExisted = true;
                }
                catch (SqlException ex)
                {
                    IsExisted = false;
                }
                catch (Exception ex)
                {
                    IsExisted = false;
                }
            }
            else
            {
                IsExisted = false;
            }
            return IsExisted;
        }

        public string GetCurrentPathSQLServer(DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            string Path = "";
            string CommandString = "USE master; exec sp_helpfile;";
            var DtData = new DataTable();
            try
            {
                Connection = new SqlConnection(this.ConnectionString(Type));
                Connection.Open();
                Command = new SqlCommand(CommandString, Connection);
                Command.CommandTimeout = 180;
                DtData.Load(Command.ExecuteReader());
                Connection.Close();
                Connection = null;
                Command = null;
                if (DtData != null)
                {
                    if (DtData.Rows.Count > 0)
                    {
                        Path = Strings.Trim(Conversions.ToString(Interaction.IIf(DtData.Rows[0][2] is DBNull == true, @"C:\Microsoft SQL Server\Data\master.mdf", DtData.Rows[0][2])));
                        Path = Strings.Trim(Strings.Mid(Path, 1, Strings.Len(Path) - 10));
                    }
                    else
                    {
                        Path = @"C:\Microsoft SQL Server\Data";
                    }
                }
                else
                {
                    Path = @"C:\Microsoft SQL Server\Data";
                }
                DtData = null;
            }
            catch (SqlException ex)
            {
                DtData = null;
                Path = "";
            }
            catch (Exception ex)
            {
                DtData = null;
                Path = "";
            }
            return Path;
        }

        public DataTable GetAllDatabaseNames(string FieldName = "*", DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            if (string.IsNullOrEmpty(Strings.Trim(FieldName)))
                FieldName = "*";
            DataTable DatabaseNameList = null;
            bool IsCompleted = false;
            try
            {
                Connection = new SqlConnection(this.ConnectionString(Type));
                Connection.Open();
                Command = new SqlCommand(string.Format("select {0} from sysdatabases", FieldName), Connection);
                Command.CommandTimeout = 180;
                DatabaseNameList.Load(Command.ExecuteReader());
                Connection.Close();
                Connection = null;
                Command = null;
                IsCompleted = true;
            }
            catch (Exception ex)
            {
                IsCompleted = false;
                DatabaseNameList = null;
                MessageBox.Show(ex.Message.ToString(), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return DatabaseNameList;
        }

        public DataTable GetAllSQLServerNames(string FieldName = "*", DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            if (string.IsNullOrEmpty(Strings.Trim(FieldName)))
                FieldName = "*";
            DataTable SQLServerNameList = null;
            bool IsCompleted = false;
            try
            {
                Connection = new SqlConnection(this.ConnectionString(Type));
                Connection.Open();
                Command = new SqlCommand(string.Format("select {0} from sysservers  where srvproduct='SQL Server'", FieldName), Connection);
                Command.CommandTimeout = 180;
                SQLServerNameList.Load(Command.ExecuteReader());
                Connection.Close();
                Connection = null;
                Command = null;
                IsCompleted = true;
            }
            catch (Exception ex)
            {
                IsCompleted = false;
                SQLServerNameList = null;
                MessageBox.Show(ex.Message.ToString(), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return SQLServerNameList;
        }

        public bool BackupDatabase(string DatabaseName, string PathName = "", DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            string CurrentDatabaseName = DatabaseName;
            DatabaseName = string.Format("{0}{1}", this.PrefixDatabase, App.MergeObject(DatabaseName));
            if (string.IsNullOrEmpty(Strings.Trim(PathName)))
                PathName = GetCurrentPathSQLServer(Type);
            if (Strings.Right(PathName, 1) == @"\")
            {
                PathName += DatabaseName + ".BAK";
            }
            else if (Strings.Mid(PathName, PathName.Length - 3, 1) != ".")
                PathName += @"\" + DatabaseName + ".BAK";
            bool IsCompleted = false;
            if (CheckInDatabaseIsExistOrNot(CurrentDatabaseName, Checker: TypeOfCheck.Database, Type: Type) == true)
            {
                try
                {
                    Connection = new SqlConnection(this.ConnectionString(Type));
                    Connection.Open();
                    Command = new SqlCommand(string.Format("BACKUP DATABASE {0} TO DISK='{1}'", DatabaseName, PathName), Connection);
                    Command.CommandTimeout = 180;
                    Command.ExecuteNonQuery();
                    Connection.Close();
                    Connection = null;
                    Command = null;
                    IsCompleted = true;
                }
                catch (SqlException ex)
                {
                    IsCompleted = false;
                }
                catch (Exception ex)
                {
                    IsCompleted = false;
                }
            }
            else
            {
                IsCompleted = false;
            }
            return IsCompleted;
        }

        public bool RestoreDatabase(string DatabaseName, string PathName = "", DeliveryTakeOrder.Configurations.ConnectionType Type = DeliveryTakeOrder.Configurations.ConnectionType.NETWORK)
        {
            string CurrentDatabaseName = DatabaseName;
            DatabaseName = string.Format("{0}{1}", this.PrefixDatabase, App.MergeObject(DatabaseName));
            if (string.IsNullOrEmpty(Strings.Trim(PathName)))
                PathName = GetCurrentPathSQLServer(Type);
            if (Strings.Right(PathName, 1) == @"\")
            {
                PathName += DatabaseName + ".BAK";
            }
            else if (Strings.Mid(PathName, PathName.Length - 3, 1) != ".")
                PathName += @"\" + DatabaseName + ".BAK";
            bool IsCompleted = false;
            if (CheckInDatabaseIsExistOrNot(CurrentDatabaseName, Checker: TypeOfCheck.Database, Type: Type) == true)
            {
                try
                {
                    Connection = new SqlConnection(this.ConnectionString(Type));
                    Connection.Open();
                    Command = new SqlCommand(string.Format("RESTORE DATABASE {0} FROM DISK='{1}'", DatabaseName, PathName), Connection);
                    Command.CommandTimeout = 180;
                    Command.ExecuteNonQuery();
                    Connection.Close();
                    Connection = null;
                    Command = null;
                    IsCompleted = true;
                }
                catch (SqlException ex)
                {
                    IsCompleted = false;
                }
                catch (Exception ex)
                {
                    IsCompleted = false;
                }
            }
            else
            {
                IsCompleted = false;
            }
            return IsCompleted;
        }
        #region IDisposable Support
        private bool disposedValue; // To detect redundant calls

        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                // TODO: set large fields to null.
            }
            disposedValue = true;
        }

        // TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        // Protected Overrides Sub Finalize()
        // ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        // Dispose(False)
        // MyBase.Finalize()
        // End Sub

        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}