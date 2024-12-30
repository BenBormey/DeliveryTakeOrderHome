using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

public class RMDB
{
    private string _connectionstring;

    public string ConnectionString
    {
        get => _connectionstring;
        set => _connectionstring = value;
    }

    public RMDB(string pConnectionString = null)
    {
        _connectionstring = pConnectionString;
    }

    public void ExecuteNonQuery(string pSql, Dictionary<string, object> pParam = null)
    {
        using (SqlConnection con = new SqlConnection(_connectionstring))
        {
            con.Open();
            using (SqlTransaction tran = con.BeginTransaction())
            using (SqlCommand cmd = BuildCommand(con, pSql, pParam))
            {
                try
                {
                    cmd.Transaction = tran;
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    tran.Rollback();
                    throw;
                }
            }
        }
    }

    public object ExecuteScalar(string pSql, Dictionary<string, object> pParam = null)
    {
        using (SqlConnection con = new SqlConnection(_connectionstring))
        {
            con.Open();
            using (SqlCommand cmd = BuildCommand(con, pSql, pParam))
            {
                try
                {
                    return cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }
            }
        }
    }

    public DataTable GetDataTable(string pSql, Dictionary<string, object> pParam = null)
    {
        using (SqlConnection con = new SqlConnection(_connectionstring))
        {
            con.Open();
            using (SqlCommand cmd = BuildCommand(con, pSql, pParam))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                try
                {
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return null;
                }
            }
        }
    }
    public DataTable GetDataTable(string pSql)
{
    return GetDataTable(pSql, new Dictionary<string, object>());
}


    public List<T> GetDataTableToObject<T>(DataTable pDataTable)
    {
        List<T> list = new List<T>();
        foreach (DataRow dr in pDataTable.Rows)
        {
            T obj = Activator.CreateInstance<T>();
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                if (pDataTable.Columns.Contains(prop.Name) && prop.CanWrite)
                {
                    object value = dr[prop.Name] == DBNull.Value ? null : Convert.ChangeType(dr[prop.Name], prop.PropertyType);
                    prop.SetValue(obj, value, null);
                }
            }
            list.Add(obj);
        }
        return list;
    }

    public List<T> GetDataTableToObject<T>(string pSql)
    {
        DataTable dt = GetDataTable(pSql);
        return GetDataTableToObject<T>(dt);
    }

    private SqlCommand BuildCommand(SqlConnection pConnection, string pSql, Dictionary<string, object> pParams)
    {
        SqlCommand cmd = pConnection.CreateCommand();
        cmd.CommandText = pSql;
        cmd.CommandType = CommandType.Text;

        if (pParams != null)
        {
            foreach (var param in pParams)
            {
                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            }
        }

        return cmd;
    }

    public static string SqlStringNull(string pString)
    {
        return string.IsNullOrEmpty(pString) ? "NULL" : $"N'{pString.Replace("'", "''")}'";
    }

    public static string SqlDateTime(DateTime? dt)
    {
        return dt == null || dt.Value.Year == 1 ? "NULL" : $"'{dt:yyyy-MM-dd HH:mm:ss}'";
    }

    public void GeneratePropertiesFromQuery(string pQuery)
    {
        string output = "";
        DataTable dt = GetDataTable(pQuery);
        foreach (DataColumn col in dt.Columns)
        {
            output += $"public {col.DataType.Name} {col.ColumnName} {{ get; set; }}{Environment.NewLine}";
        }

        try
        {
            string filePath = Path.Combine(Path.GetTempPath(), "TempText.txt");
            File.WriteAllText(filePath, output);
            Console.WriteLine($"File generated at: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error generating file: {ex.Message}");
        }
    }
}
