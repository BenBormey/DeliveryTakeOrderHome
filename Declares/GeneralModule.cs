using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using Microsoft.VisualBasic.CompilerServices;

namespace DeliveryTakeOrder
{

    static class GeneralModule
    {
        public static List<string> getMacAddress()
        {
            var lsMac = new List<string>();
            string str = "";
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface s in nics)
            {
                // Dim st As String = "'{0}:{1}:{2}:{3}:{4}:{5}'"
                string st = "{0}:{1}:{2}:{3}:{4}:{5}";
                string st2 = s.GetPhysicalAddress().ToString();
                try
                {
                    if (!string.IsNullOrEmpty(st2))
                    {
                        str = string.Format(st, st2.Substring(0, 2), st2.Substring(2, 2), st2.Substring(4, 2), st2.Substring(6, 2), st2.Substring(8, 2), st2.Substring(10, 2));
                        lsMac.Add(str);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            // If str <> "" Then
            // str = str.Replace(",'00:00:00:00:00:00'", "")
            // str = str.Remove(0, 1)

            // End If

            if (lsMac.Count == 0)
            {
                lsMac.Add("00:00:00:00:00:00");
            }
            return lsMac;
        }
        public static string GetIPv4Address()
        {
            string GetIPv4AddressRet = default;
            GetIPv4AddressRet = "";
            string strHostName = System.Net.Dns.GetHostName();
            var iphe = System.Net.Dns.GetHostEntry(strHostName);

            foreach (System.Net.IPAddress ipheal in iphe.AddressList)
            {
                if (ipheal.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    GetIPv4AddressRet = ipheal.ToString();
                }
            }

            return GetIPv4AddressRet;
        }

        public static List<T> GetDataTableToObject<T>(DataTable pDataTable)
        {
            var ls = new List<T>();
            T o;

            foreach (DataRow dr in pDataTable.Rows)
            {
                o = Conversions.ToGenericParameter<T>(Activator.CreateInstance(typeof(T)));
                object value;
                foreach (PropertyInfo p in typeof(T).GetProperties())
                {
                    try
                    {
                        if (pDataTable.Columns.Contains(p.Name))
                        {
                            var propType = p.PropertyType;
                            value = dr[p.Name] is DBNull ? null : Convert.ChangeType(dr[p.Name], propType);
                            p.SetValue(o, value, null);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                ls.Add(o);
            }
            return ls;
        }

        //public static void _BindCombo(ComboBox pCombo, BindingSource pDataSource, string pValueMember, string pDisplayMember, bool pIsAutoComplete = false)
        //{
        //    pCombo.DataSource = pDataSource;
        //    pCombo.ValueMember = pValueMember;
        //    pCombo.DisplayMember = pDisplayMember;
        //    if (pIsAutoComplete)
        //    {
        //        pCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        pCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
        //    }
        //}
        public static void _BindCombo(ComboBox pCombo, BindingSource pDataSource, string pValueMember, string pDisplayMember, bool pIsAutoComplete = false)
        {
            {
                var withBlock = pCombo;
                withBlock.DataSource = pDataSource;
                withBlock.ValueMember = pValueMember;
                withBlock.DisplayMember = pDisplayMember;
                if (pIsAutoComplete)
                {
                    withBlock.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    withBlock.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
        }


        public static void GeneratePropertiesFromDataTable(DataTable pDatatable)
        {
            string text = string.Empty;
            string tmp = "Public Property {0} As {1}";
            var dt = pDatatable;
            if (dt is null)
                return;
            foreach (DataColumn col in dt.Columns)
                text += string.Format(tmp, col.ColumnName, col.DataType.Name) + Environment.NewLine;

            try
            {
                using (var sw = new StreamWriter(string.Format(@"{0}\TempText.txt", Path.GetTempPath()), false))
                {
                    sw.Write(text);
                    Process.Start(string.Format(@"{0}\TempText.txt", Path.GetTempPath()));
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Binding combobox with datasource
        /// </summary>
        /// <param name="pCombo"></param>
        /// <param name="pDataSource"></param>
        /// <param name="pValueMember"></param>
        /// <param name="pDisplayMember"></param>
        /// <param name="pIsAutoComplete">Optional parameter by default False</param>
        /// <remarks></remarks>
        public static void BindCombo(ComboBox pCombo, BindingSource pDataSource, string pValueMember, string pDisplayMember, bool pIsAutoComplete = false)
        {
            pCombo.DataSource = pDataSource;
            pCombo.ValueMember = pValueMember;
            pCombo.DisplayMember = pDisplayMember;
            if (pIsAutoComplete)
            {
                pCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                pCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
    }
}