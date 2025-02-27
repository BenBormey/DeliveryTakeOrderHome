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
    public static string SqlDateNull(DateTime pDate)
    {
        if (pDate.Year == 1)
        {
            return "NULL";
        }
        else
        {
            return string.Format("'{0:yyyy-MM-dd}'", pDate);
        }
    }

    public static string SqlDate(DateTime dt)
    {
        return string.Format("'{0:yyyy-MM-dd}'", dt);
    }
    public static string SqlDateTimeNull(DateTime? pDate)
    {
        if (!pDate.HasValue)
        {
            return "NULL";
        }

        if (pDate.Value.Year == 1)
        {
            return "NULL";
        }
        else
        {
            return string.Format("'{0:yyyy-MM-dd hh:mm:ss}'", pDate);
        }
    }

    public static string SqlDateTime(DateTime dt)
    {
        return string.Format("'{0:yyyy-MM-dd HH:mm:ss:fff}'", dt);
    }

    public static string SqlInt(string num)
    {
        try
        {
            int nums = Convert.ToInt32(num);
            return num;
        }
        catch (Exception)
        {
            return "NULL";
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
        List<T> ls = new List<T>();
        T o;

        foreach (DataRow dr in pDataTable.Rows)
        {
            o = Activator.CreateInstance<T>();
            object value;

            foreach (PropertyInfo p in typeof(T).GetProperties())
            {
                try
                {
                    if (p.CanWrite)
                    {
                        if (pDataTable.Columns.Contains(p.Name))
                        {
                            Type propType = p.PropertyType;
                            value = dr[p.Name] == DBNull.Value ? null : Convert.ChangeType(dr[p.Name], propType);
                            p.SetValue(o, value);
                        }
                    }
                }
                catch (Exception)
                {
                    // Optionally handle exceptions here
                }
            }

            ls.Add(o);
        }

        return ls;
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
