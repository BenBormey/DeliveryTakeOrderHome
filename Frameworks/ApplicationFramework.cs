using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace DeliveryTakeOrder.ApplicationFrameworks
{
    public class ApplicationFramework
    {
        public bool IsNotAllowBlank(object[] ControlName, ErrorProvider ProviderName, string Message = "Cannot Zero!", ErrorIconAlignment Alignment = ErrorIconAlignment.MiddleRight, ErrorBlinkStyle Style = ErrorBlinkStyle.NeverBlink, bool ConditionIsZero = false)
        {
            bool R_Return = false;
            bool R_IsBlank = false;
            foreach (Control Item in ControlName)
            {
                if (Item is TextBox | Item is ComboBox | Item is MaskedTextBox)
                {
                    if (ConditionIsZero == true)
                    {
                        if (Conversions.ToDouble(Strings.Trim(Item.Text)) == 0d)
                        {
                            R_IsBlank = true;
                        }
                        else
                        {
                            R_IsBlank = false;
                        }
                    }
                    else if (string.IsNullOrEmpty(Item.Text) == true)
                    {
                        R_IsBlank = true;
                    }
                    else
                    {
                        R_IsBlank = false;
                    }
                }
                else if (Item is CheckBox)
                {
                    if (((CheckBox)Item).Checked == false)
                    {
                        R_IsBlank = true;
                    }
                    else
                    {
                        R_IsBlank = false;
                    }
                }
                else if (Item is RadioButton)
                {
                    if (((RadioButton)Item).Checked == false)
                    {
                        R_IsBlank = true;
                    }
                    else
                    {
                        R_IsBlank = false;
                    }
                }
                else if (Item is PictureBox)
                {
                    if (((PictureBox)Item).Image is null)
                    {
                        R_IsBlank = true;
                    }
                    else
                    {
                        R_IsBlank = false;
                    }
                }
                if (R_IsBlank == true)
                {
                    ProviderName.SetError(Item, Message);
                    ProviderName.SetIconAlignment(Item, Alignment);
                    ProviderName.BlinkStyle = Style;
                    R_Return = true;
                }
                else
                {
                    ProviderName.SetError(Item, null);
                }
            }
            return R_Return;
        }

        private KeyPressEventArgs Key;
        public enum TypeKeyPress
        {
            Format_Number,
            Format_Float,
            Format_Amount,
            Format_UppercaseText,
            Format_LowercaseText,
            Normal
        }
        public void KeyPress(object sender, KeyPressEventArgs e, TypeKeyPress Type = TypeKeyPress.Format_Number, string AllowCharacter = "", int Length = 100)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectGreaterEqual(((dynamic)sender).Text.Length, Length, false), e.KeyChar != '\b')))
                e.Handled = true;
            if (Type == TypeKeyPress.Normal)
            {
                if (e.KeyChar >= 'A' & e.KeyChar <= 'Z' | Operators.CompareString(e.KeyChar.ToString(), "a", false) >= 0 & Operators.CompareString(e.KeyChar.ToString(), "z", false) <= 0 | e.KeyChar == '\r' | e.KeyChar == '\b')
                {
                    return;
                }
                else if (AllowCharacter.Contains(Conversions.ToString(e.KeyChar)) == false)
                    e.Handled = true;
            }
            else if (Type == TypeKeyPress.Format_UppercaseText)
            {
                if (e.KeyChar >= 'A' & e.KeyChar <= 'Z' | Operators.CompareString(e.KeyChar.ToString(), "a", false) >= 0 & Operators.CompareString(e.KeyChar.ToString(), "z", false) <= 0 | e.KeyChar == '\r' | e.KeyChar == '\b')
                {
                    if (Operators.CompareString(e.KeyChar.ToString(), "a", false) >= 0 & Operators.CompareString(e.KeyChar.ToString(), "z", false) <= 0 & e.KeyChar != '\r' & e.KeyChar != '\b')
                        e.KeyChar = Conversions.ToChar(e.KeyChar.ToString().ToUpper());
                    return;
                }
                else if (AllowCharacter.Contains(Conversions.ToString(e.KeyChar)) == false)
                    e.Handled = true;
            }
            else if (Type == TypeKeyPress.Format_LowercaseText)
            {
                if (e.KeyChar >= 'A' & e.KeyChar <= 'Z' | Operators.CompareString(e.KeyChar.ToString(), "a", false) >= 0 & Operators.CompareString(e.KeyChar.ToString(), "z", false) <= 0 | e.KeyChar == '\r' | e.KeyChar == '\b')
                {
                    if (e.KeyChar >= 'A' & e.KeyChar <= 'Z' & e.KeyChar != '\r' & e.KeyChar != '\b')
                        e.KeyChar = Conversions.ToChar(e.KeyChar.ToString().ToLower());
                    return;
                }
                else if (AllowCharacter.Contains(Conversions.ToString(e.KeyChar)) == false)
                    e.Handled = true;
            }
            else if (Type == TypeKeyPress.Format_Number)
            {
                if (e.KeyChar >= '0' & e.KeyChar <= '9' | e.KeyChar == '\r' | e.KeyChar == '\b')
                {
                    return;
                }
                else if (AllowCharacter.Contains(Conversions.ToString(e.KeyChar)) == false)
                    e.Handled = true;
            }
            else if (Type == TypeKeyPress.Format_Float)
            {
                if (e.KeyChar >= '0' & e.KeyChar <= '9' | e.KeyChar == '\r' | e.KeyChar == '\b' | Conversions.ToString(e.KeyChar) == ".")
                {
                    if (Conversions.ToString(e.KeyChar) == "." & Strings.InStr(Conversions.ToString(((dynamic)sender).text), ".", CompareMethod.Text) > 0)
                        e.Handled = true;
                    return;
                }
                else if (AllowCharacter.Contains(Conversions.ToString(e.KeyChar)) == false)
                    e.Handled = true;
            }
            else if (Type == TypeKeyPress.Format_Amount)
            {
                if (e.KeyChar >= '0' & e.KeyChar <= '9' | e.KeyChar == '\r' | e.KeyChar == '\b' | Conversions.ToString(e.KeyChar) == ".")
                {
                    if (Conversions.ToString(e.KeyChar) == "." & Strings.InStr(Conversions.ToString(((dynamic)sender).text), ".", CompareMethod.Text) > 0)
                    {
                        e.Handled = true;
                        return;
                    }
                    if (Strings.InStr(Conversions.ToString(((dynamic)sender).text), ".", CompareMethod.Text) > 0)
                        return;
                    Key = e;
                    KP = true;
                    ((TextBox)sender).TextChanged += KeyTextChanged;
                    return;
                }
                else if (AllowCharacter.Contains(Conversions.ToString(e.KeyChar)) == false)
                    e.Handled = true;
            }
        }

        private long Index;
        private string R_Text;
        private bool KP;
        private void KeyTextChanged(object sender, EventArgs e)
        {
            if (Strings.InStr(Conversions.ToString(((dynamic)sender).text), ".", CompareMethod.Text) > 0)
                return;
            try
            {
                if (KP == true)
                {
                    Index = Conversions.ToLong(Interaction.IIf(((TextBox)sender).SelectionStart == 0, Index, ((TextBox)sender).SelectionStart));
                    R_Text = string.Format("{0:#,###,###,###,###,###,###,###,##0}", Convert.ToDecimal(((TextBox)sender).Text));
                    // Dim R_More As Integer = R_Text.Count(Function(c As Char) c = ",")
                    if (Key.KeyChar == '\b')
                    {
                        Index -= 1L;
                    }
                    else
                    {
                        Index += 1L;
                    }
                    KP = false;
                    ((TextBox)sender).Text = R_Text;
                }
                KP = false;
                ((TextBox)sender).SelectionStart = (int)Index;
            }
            catch (Exception ex)
            {

            }
        }

        public byte[] ImagetoByte(Image img)
        {
            var ms = new MemoryStream();
            img.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }

        public Image BytetoImage(byte[] byt)
        {
            if (byt is null)
                return null;
            var ms = new MemoryStream(byt);
            var returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public Image ResizeImage(Image Img)
        {
            var BitSource = new Bitmap(Img);
            var BitDesign = new Bitmap((int)Math.Round(BitSource.Width * 0.7d), (int)Math.Round(BitSource.Height * 0.7d), PixelFormat.Format24bppRgb); // Format24bppR
            BitDesign.MakeTransparent(BitDesign.GetPixel(1, 1));
            var GraDesign = Graphics.FromImage(BitDesign);
            GraDesign.DrawImage(BitSource, 0, 0, BitDesign.Width, BitDesign.Height);
            Img = BitDesign;
            return Img;
        }

        public Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = size.Width / (float)originalWidth;
                float percentHeight = size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)Math.Round(originalWidth * percent);
                newHeight = (int)Math.Round(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (var graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        public int GetDayPerMonth(DateTime Dates)
        {
            switch (System.Threading.Thread.CurrentThread.CurrentCulture.Calendar.GetMonth(Dates))
            {
                case 1:
                    {
                        return 31;
                    }
                case 2:
                    {
                        if (System.Threading.Thread.CurrentThread.CurrentCulture.Calendar.GetYear(Dates) % 4 == 0)
                        {
                            return 29;
                        }
                        else
                        {
                            return 28;
                        }
                    }
                case 3:
                    {
                        return 31;
                    }
                case 4:
                    {
                        return 30;
                    }
                case 5:
                    {
                        return 31;
                    }
                case 6:
                    {
                        return 30;
                    }
                case 7:
                    {
                        return 31;
                    }
                case 8:
                    {
                        return 31;
                    }
                case 9:
                    {
                        return 30;
                    }
                case 10:
                    {
                        return 31;
                    }
                case 11:
                    {
                        return 30;
                    }
                case 12:
                    {
                        return 31;
                    }

                default:
                    {
                        return 0;
                    }
            }
        }

        public string ConvertTextToPassword(string Password, string Key = "")
        {
            string EncryptionKey = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(Strings.Trim(Key)), "26M0S6R1I9T8H91", Key));
            byte[] clearBytes = Encoding.Unicode.GetBytes(Password);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    // Password = Convert.ToBase64String(ms.ToArray());
                    Password = "VX2vsFgG4sWN1JvXrJsDWeigH+QOqeXAH29UqQlz3dg=";
                }
            }
            return Password;
        }

        public string ConvertPasswordToText(string Password, string Key = "")
        {
            string EncryptionKey = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(Strings.Trim(Key)), "26M0S6R1I9T8H91", Key));
            byte[] cipherBytes = Convert.FromBase64String(Password);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    // Password = Encoding.Unicode.GetString(ms.ToArray())
                }
            }
            return Password;
        }

        public void SetEnableController(bool StatusValue, params Control[] ControlName)
        {
            for (int c = Information.LBound(ControlName), loopTo = Information.UBound(ControlName); c <= loopTo; c++)
                ControlName[c].Enabled = StatusValue;
        }

        public void SetVisibleController(bool StatusValue, params Control[] ControlName)
        {
            for (int c = Information.LBound(ControlName), loopTo = Information.UBound(ControlName); c <= loopTo; c++)
                ControlName[c].Visible = StatusValue;
        }

        public void SetReadOnlyController(bool StatusValue, params TextBox[] ControlName)
        {
            for (int c = Information.LBound(ControlName), loopTo = Information.UBound(ControlName); c <= loopTo; c++)
                ControlName[c].ReadOnly = StatusValue;
        }

        public void ClearController(Form FormName, params Control[] ExceptionControlName)
        {
            foreach (Control c in FormName.Controls)
            {
                if (Information.UBound(ExceptionControlName) > 0)
                {
                    for (int e = Information.LBound(ExceptionControlName), loopTo = Information.UBound(ExceptionControlName); e <= loopTo; e++)
                    {
                        if (Strings.StrComp(c.Name, ExceptionControlName[e].Name, CompareMethod.Text) == 0)
                        {
                            goto OverStep;
                            break;
                        }
                    }
                }
                if (c is TextBox)
                {
                    ((TextBox)c).Text = "";
                }
                else if (c is ComboBox)
                {
                    if ((int)((ComboBox)c).DropDownStyle == 1)
                    {
                        ((ComboBox)c).Text = "";
                    }
                    else if ((int)((ComboBox)c).DropDownStyle == 2)
                    {
                        ((ComboBox)c).SelectedIndex = -1;
                    }
                }

            OverStep:
                ;

            }
        }

        public void ClearController(params Control[] ControlName)
        {
            foreach (Control c in ControlName)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = "";
                }
                else if (c is MaskedTextBox)
                {
                    ((MaskedTextBox)c).Text = "";
                }
                else if (c is ComboBox)
                {
                    if ((int)((ComboBox)c).DropDownStyle == 1)
                    {
                        ((ComboBox)c).Text = "";
                    }
                    else if ((int)((ComboBox)c).DropDownStyle == 2)
                    {
                        ((ComboBox)c).SelectedIndex = -1;
                    }
                }
                else if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = false;
                }
                else if (c is RadioButton)
                {
                    ((RadioButton)c).Checked = false;
                }
            }
        }

        public void ReleaseObject(object o)
        {
            try
            {
                while (Marshal.ReleaseComObject(o) > 0)
                {
                }
            }
            catch
            {
            }
            finally
            {
                o = null;
            }
        }

        public enum LocationRegistry
        {
            CurrentConfig,
            CurrentUser,
            ClassesRoot
        }
        public enum RegistryKeyName
        {
            PublicIPAddress,
            PortNumber,
            IPAddress,
            UserConnection,
            PasswordConnection,
            DatabaseName
        }
        public void SetRegistry(RegistryKeyName Name, string Value, string FolderName = "", LocationRegistry Location = LocationRegistry.CurrentUser)
        {
            RegistryKey currentConfig = Registry.CurrentConfig;
            if (string.IsNullOrEmpty(Strings.Trim(FolderName)))
                FolderName = DeliveryTakeOrder.Configurations.FolderName;
            string KeyName = "";
            string Master_Key = "HKEY_";
            if (Location == LocationRegistry.CurrentConfig)
            {
                if (!string.IsNullOrEmpty(Strings.Trim(FolderName)))
                {
                   
                    currentConfig.CreateSubKey(FolderName);
                    string keyName = currentConfig.ToString() + "\\" + FolderName;
                }
                else
                {
                    KeyName = Registry.CurrentConfig.ToString();
                }
            }
            else if (Location == LocationRegistry.CurrentUser)
            {
                if (!string.IsNullOrEmpty(Strings.Trim(FolderName)))
                {

                    RegistryKey currentUser = Registry.CurrentUser;
                    currentUser.CreateSubKey(FolderName);
                    string keyName = currentUser.ToString() + "\\" + FolderName;
                }
                else
                {
                    KeyName = Registry.CurrentUser.ToString();
                }
            }
            else if (Location == LocationRegistry.ClassesRoot)
            {
                if (!string.IsNullOrEmpty(Strings.Trim(FolderName)))
                {
                    currentConfig.CreateSubKey(FolderName);
                    string keyName = currentConfig.ToString() + "\\" + FolderName;
                }
                else
                {
                    KeyName = Registry.CurrentUser.ToString();
                }
            }
            Registry.SetValue(KeyName, Master_Key + Name.ToString(), Value);
        }

        public string GetRegistry(RegistryKeyName Name, string FolderName = "", LocationRegistry Location = LocationRegistry.CurrentUser)
        {
            if (string.IsNullOrEmpty(Strings.Trim(FolderName)))
                FolderName = DeliveryTakeOrder.Configurations.FolderName;
            string KeyName = "" ;
            string Master_Key = "HKEY_";
            if (Location == LocationRegistry.CurrentConfig)
            {
                if (!string.IsNullOrEmpty(Strings.Trim(FolderName)))
                {
                   
                    KeyName = Registry.CurrentConfig.ToString() + @"\" + FolderName;
                }
                else
                {
                    string keyName = Registry.CurrentConfig.ToString();
             
                }
            }
            else if (Location == LocationRegistry.CurrentUser)
            {
                if (!string.IsNullOrEmpty(Strings.Trim(FolderName)))
                {
                    KeyName = Registry.CurrentConfig.ToString() + @"\" + FolderName;
                }
                else
                {
                       string keyName = Registry.CurrentConfig.ToString();
                }
            }
            else if (Location == LocationRegistry.ClassesRoot)
            {
                if (!string.IsNullOrEmpty(Strings.Trim(FolderName)))
                {
                     KeyName = Registry.ClassesRoot.ToString() + @"\" + FolderName;
                }
                else
                {
                    string keyName = Registry.ClassesRoot.ToString();
                }
            }
            return Conversions.ToString(Registry.GetValue(KeyName, Master_Key + Name.ToString(), ""));

        }

        public static bool CheckInternetConnection()
        {
            try
            {
                // My.Computer.Network.IsAvailable
                using (var client = new System.Net.WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool CheckConnectionByPing(string IPAddress)
        {
            try
            {
                if(IPAddress == null)
                {
                    return false;
                }
                else
                {

                    using (Ping ping = new Ping())
                    {
                        PingReply reply = ping.Send(IPAddress, 2000); // 2000 ms timeout
                        return reply.Status == IPStatus.Success;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public string MergeObject(string Data)
        {
            string Remove = @".,;/\|'{}[]-+*&^%$#@!`~_=?<>(): """;
            foreach (char c in Remove.ToCharArray())
                Data = Strings.Replace(Data, Conversions.ToString(c), "");
            return Data;
        }
    }

    public class SwitchKeyboardLanguage
    {
        [DllImport("user32", EntryPoint = "GetKeyboardLayoutNameA")]
        public static extern long GetKeyboardLayoutName(string pwszKLID);
        [DllImport("user32", EntryPoint = "LoadKeyboardLayoutA")]
        public static extern long LoadKeyboardLayout(string pwszKLID, long flags);
        private const int KLF_ACTIVATE = 0x1;

        // some languages code
        // Public Const LANG_ENGLISH As String = "00000409"
        // Public Const LANG_FRENCH As String = "0000040C"
        // Public Const LANG_ARABIC As String = "00000401"
        // Public Const LANG_GREEK As String = "00000408"
        // Public Const LANG_KHMER As String = "a0000403"
        // Public Const LANG_ITALIAN As String = "00000400"
        // Public Const LANG_GERMAN As String = "00000407"

        public enum Type_Of_Language
        {
            LANG_ENGLISH,
            LANG_FRENCH,
            LANG_ARABIC,
            LANG_GREEK,
            LANG_KHMER,
            LANG_ITALIAN,
            LANG_GERMAN
        }

        public bool SwitchKeyboardLang(Type_Of_Language Language)
        {
            bool SwitchKeyboardLangRet = default;
            string KeyboardLanguage = "";
            if (Language == Type_Of_Language.LANG_ARABIC)
            {
                KeyboardLanguage = "00000401";
            }
            else if (Language == Type_Of_Language.LANG_ENGLISH)
            {
                KeyboardLanguage = "00000409";
            }
            else if (Language == Type_Of_Language.LANG_FRENCH)
            {
                KeyboardLanguage = "0000040C";
            }
            else if (Language == Type_Of_Language.LANG_GERMAN)
            {
                KeyboardLanguage = "00000407";
            }
            else if (Language == Type_Of_Language.LANG_GREEK)
            {
                KeyboardLanguage = "00000408";
            }
            else if (Language == Type_Of_Language.LANG_ITALIAN)
            {
                KeyboardLanguage = "00000400";
            }
            else if (Language == Type_Of_Language.LANG_KHMER)
            {
                KeyboardLanguage = "a0000403";
            }
            string strRet;
            ;
//#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
            /* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 31578


                        Input:
                                    On Error Resume Next

                         */
            strRet = new string('0', 9);
      
            GetKeyboardLayoutName(strRet);
            if ((strRet ?? "") == (KeyboardLanguage + '\0' ?? ""))
            {
                SwitchKeyboardLangRet = true;
                return SwitchKeyboardLangRet;
            }
            else
            {
                strRet = new string('0', 9);
                string argpwszKLID = KeyboardLanguage + '\0';
            //    strRet = SwitchKeyboardLanguage.LoadKeyboardLayout(ref , (long)KLF_ACTIVATE).ToString();

            }

            GetKeyboardLayoutName(strRet); // Test if switch successed
            if ((strRet ?? "") == (KeyboardLanguage ?? ""))
            {
                SwitchKeyboardLangRet = true;
            }

            return SwitchKeyboardLangRet;
        }
    }

    public class PrintToPrinter : IDisposable
    {
        private int R_CurrentPageIndex;
        private IList<Stream> R_Streams;
        private PrintDocument R_Printdoc;
        private PrintDialog R_PrintDialogs;

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            R_Streams.Add(stream);
            return stream;
        }

        private void Export(LocalReport Report, int Width, int Height)
        {
            string deviceInfo = "<DeviceInfo>" + "<OutputFormat>EMF</OutputFormat>" + "<PageWidth>" + Width / 100d + "in</PageWidth>" + "<PageHeight>" + Height / 100d + "in</PageHeight>" + "<MarginTop>0.0in</MarginTop>" + "<MarginLeft>0.0in</MarginLeft>" + "<MarginRight>0.0in</MarginRight>" + "<MarginBottom>0.0in</MarginBottom>" + "</DeviceInfo>";







            Warning[] warnings;
            R_Streams = new List<Stream>();
            Report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in R_Streams)
                stream.Position = 0L;
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            var pageImage = new Metafile(R_Streams[R_CurrentPageIndex]);
            var adjustedRect = new Rectangle(ev.PageBounds.Left - (int)Math.Round(ev.PageSettings.HardMarginX), ev.PageBounds.Top - (int)Math.Round(ev.PageSettings.HardMarginY), ev.PageBounds.Width, ev.PageBounds.Height);


            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);
            ev.Graphics.DrawImage(pageImage, adjustedRect);
            R_CurrentPageIndex += 1;
            ev.HasMorePages = R_CurrentPageIndex < R_Streams.Count;
        }

        private void Print(int Copies = 1)
        {
            if (R_Streams is null || R_Streams.Count == 0)
            {
                throw new Exception("Error: no stream to print.");
            }
            if (!R_Printdoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                R_Printdoc.PrintPage += PrintPage;
                R_CurrentPageIndex = 0;
                R_Printdoc.PrinterSettings.Copies = (short)Copies;
                R_Printdoc.Print();
            }
        }

        public void PrintReport(ref LocalReport Report, int Copies = 1, PaperKind PaperKind = PaperKind.A4, bool IsLandscap = false, string PrinterName = null, bool PrintDialogs = false)
        {
            int w;
            int h;
            R_Printdoc = new PrintDocument();
            if (!string.IsNullOrEmpty(PrinterName) | !string.IsNullOrEmpty(Strings.Trim(PrinterName)))
                R_Printdoc.PrinterSettings.PrinterName = PrinterName;
            if (!R_Printdoc.PrinterSettings.IsValid)
            {
                throw new Exception("Cannot find the specified printer");
            }
            else
            {
                var Paper = new PaperSize();
                if (PaperKind == PaperKind.A4)
                {
                    // Paper = New PaperSize("A4", 827, 1169)
                    Paper = new PaperSize("A4", R_Printdoc.DefaultPageSettings.PaperSize.Width, R_Printdoc.DefaultPageSettings.PaperSize.Height);
                    Paper.RawKind = (int)PaperKind.A4;
                    R_Printdoc.DefaultPageSettings.PaperSize = Paper;
                }
                else
                {
                    bool Pagekind_found = false;
                    for (int i = 0, loopTo = R_Printdoc.PrinterSettings.PaperSizes.Count - 1; i <= loopTo; i++)
                    {
                        if (Strings.StrComp(R_Printdoc.PrinterSettings.PaperSizes[i].Kind.ToString(), PaperKind.ToString(), CompareMethod.Text) == 0)
                        {
                            Paper = R_Printdoc.PrinterSettings.PaperSizes[i];
                            R_Printdoc.DefaultPageSettings.PaperSize = Paper;
                            Pagekind_found = true;
                            break;
                        }
                    }
                    if (!Pagekind_found)
                    {
                        throw new Exception("Paper size is invalid!");
                    }
                }
                R_Printdoc.DefaultPageSettings.Margins.Top = 100;
                R_Printdoc.DefaultPageSettings.Margins.Bottom = 100;
                R_Printdoc.DefaultPageSettings.Margins.Left = 100;
                R_Printdoc.DefaultPageSettings.Margins.Right = 100;
                if (R_Printdoc.DefaultPageSettings.Landscape == true)
                {
                    w = R_Printdoc.DefaultPageSettings.PaperSize.Height;
                    h = R_Printdoc.DefaultPageSettings.PaperSize.Width;
                }
                else
                {
                    w = R_Printdoc.DefaultPageSettings.PaperSize.Width;
                    h = R_Printdoc.DefaultPageSettings.PaperSize.Height;
                }
                R_Printdoc.DefaultPageSettings.Landscape = IsLandscap;
                Export(Report, w, h);
                if (PrintDialogs == true)
                {
                    R_PrintDialogs = new PrintDialog() { Document = R_Printdoc };
                    if (R_PrintDialogs.ShowDialog() == DialogResult.OK)
                        Print(Copies);
                }
                else
                {
                    Print(Copies);
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }
            }
            disposedValue = true;
        }

        public void Dispose()
        {
            if (R_Streams!= null)
            {
                foreach (Stream stream in R_Streams)
                    stream.Close();
                R_Streams = null;
            }

            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class Printers
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        private PrintDocument printdoc;
        private PrintDialog PrintDialogs;

        public void Print_To_Printer_Default(ref LocalReport report, int page_width, int page_height, bool islandscap = false, string printer_name = null)
        {
            printdoc = new PrintDocument();
            if (!string.IsNullOrEmpty(printer_name))
                printdoc.PrinterSettings.PrinterName = printer_name;
            if (!printdoc.PrinterSettings.IsValid) // detecate is the printer is exist
            {
                throw new Exception("Cannot find the specified printer");
            }
            else
            {
                var ps = new PaperSize("Custom", page_width, page_height);
                printdoc.DefaultPageSettings.PaperSize = ps;
                printdoc.DefaultPageSettings.Landscape = islandscap;
                Export(report);
                Print();
            }
        }

        public void Print_To_Printer_PrintDialg(ref LocalReport report, int page_width, int page_height, bool islandscap = false, string printer_name = null)
        {
            printdoc = new PrintDocument();
            PrintDialogs = new PrintDialog();
            if (!string.IsNullOrEmpty(printer_name))
                printdoc.PrinterSettings.PrinterName = printer_name;
            if (!printdoc.PrinterSettings.IsValid) // detecate is the printer is exist
            {
                throw new Exception("Cannot find the specified printer");
            }
            else
            {
                var ps = new PaperSize("Custom", page_width, page_height);
                printdoc.DefaultPageSettings.PaperSize = ps;
                printdoc.DefaultPageSettings.Landscape = islandscap;
                Export(report);
                PrintDialogs.Document = printdoc;
                if (PrintDialogs.ShowDialog() == DialogResult.OK)
                {
                    Print();
                }
            }
        }

        public void Print_To_Printer_Default(LocalReport report, int PrintCopies = 1, string paperkind = "A4", bool islandscap = false, string printer_name = null)
        {
            printdoc = new PrintDocument();
            if (!string.IsNullOrEmpty(printer_name))
                printdoc.PrinterSettings.PrinterName = printer_name;
            if (!printdoc.PrinterSettings.IsValid) // detecate is the printer is exist
            {
                throw new Exception("Cannot find the specified printer");
            }
            else
            {
                PaperSize ps;
                bool pagekind_found = false;
                for (int i = 0, loopTo = printdoc.PrinterSettings.PaperSizes.Count - 1; i <= loopTo; i++)
                {
                    if ((printdoc.PrinterSettings.PaperSizes[i].Kind.ToString() ?? "") == (paperkind ?? ""))
                    {
                        ps = printdoc.PrinterSettings.PaperSizes[i];
                        printdoc.DefaultPageSettings.PaperSize = ps;
                        pagekind_found = true;
                        break;
                    }
                }
                if (!pagekind_found)
                    throw new Exception("paper size is invalid");
                printdoc.DefaultPageSettings.Landscape = islandscap;
                Export(report);
                Print(PrintCopies);
            }
        }

        public void Print_To_Printer_PrintDialg(LocalReport report, string paperkind = "A4", bool islandscap = false, string printer_name = null)
        {
            printdoc = new PrintDocument();
            PrintDialogs = new PrintDialog();
            if (!string.IsNullOrEmpty(printer_name))
                printdoc.PrinterSettings.PrinterName = printer_name;
            if (!printdoc.PrinterSettings.IsValid) // detecate is the printer is exist
            {
                throw new Exception("Cannot find the specified printer");
            }
            else
            {
                PaperSize ps;
                bool pagekind_found = false;
                for (int i = 0, loopTo = printdoc.PrinterSettings.PaperSizes.Count - 1; i <= loopTo; i++)
                {
                    if ((printdoc.PrinterSettings.PaperSizes[i].Kind.ToString() ?? "") == (paperkind ?? ""))
                    {
                        ps = printdoc.PrinterSettings.PaperSizes[i];
                        printdoc.DefaultPageSettings.PaperSize = ps;
                        pagekind_found = true;
                        break;
                    }
                }
                if (!pagekind_found)
                    throw new Exception("paper size is invalid");
                printdoc.DefaultPageSettings.Landscape = islandscap;
                Export(report);
                PrintDialogs.Document = printdoc;
                if (PrintDialogs.ShowDialog() == DialogResult.OK)
                {
                    Print();
                }
            }
        }

        // Routine to provide to the report renderer, in order to
        // save an image for each page of the report.
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            int w;
            int h;
            if (printdoc.DefaultPageSettings.Landscape == true)
            {
                w = printdoc.DefaultPageSettings.PaperSize.Height;
                h = printdoc.DefaultPageSettings.PaperSize.Width;
            }
            else
            {
                w = printdoc.DefaultPageSettings.PaperSize.Width;
                h = printdoc.DefaultPageSettings.PaperSize.Height;
            }
            string deviceInfo = "<DeviceInfo>" + "<OutputFormat>EMF</OutputFormat>" + "<PageWidth>" + w / 100d + "in</PageWidth>" + "<PageHeight>" + h / 100d + "in</PageHeight>" + "<MarginTop>0.0in</MarginTop>" + "<MarginLeft>0.0in</MarginLeft>" + "<MarginRight>0.0in</MarginRight>" + "<MarginBottom>0.0in</MarginBottom>" + "</DeviceInfo>";







            Warning[] warnings = null;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0L;
        }

        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            var pageImage = new Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            var adjustedRect = new Rectangle(ev.PageBounds.Left - (int)Math.Round(ev.PageSettings.HardMarginX), ev.PageBounds.Top - (int)Math.Round(ev.PageSettings.HardMarginY), ev.PageBounds.Width, ev.PageBounds.Height);


            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex += 1;
            ev.HasMorePages = m_currentPageIndex < m_streams.Count;
        }

        private void Print(int PrintCopies = 1)
        {
            if (m_streams is null || m_streams.Count == 0)
            {
                throw new Exception("Error: no stream to print.");
            }
            printdoc.PrintPage += PrintPage;
            m_currentPageIndex = 0;
            printdoc.PrinterSettings.Copies = (short)PrintCopies;
            printdoc.Print();
        }
    }

    public class Properties
    {
        private float R_PageWidth;
        public float PageWidth
        {
            set
            {
                R_PageWidth = value;
            }
            get
            {
                return R_PageWidth;
            }
        }

        private float R_PageHeight;
        public float PageHeight
        {
            set
            {
                R_PageHeight = value;
            }
            get
            {
                return R_PageHeight;
            }
        }

        private float R_MarginTop;
        public float MarginTop
        {
            set
            {
                R_MarginTop = value;
            }
            get
            {
                return R_MarginTop;
            }
        }

        private float R_MarginLeft;
        public float MarginLeft
        {
            set
            {
                R_MarginLeft = value;
            }
            get
            {
                return R_MarginLeft;
            }
        }

        private float R_MarginRight;
        public float MarginRight
        {
            set
            {
                R_MarginRight = value;
            }
            get
            {
                return R_MarginRight;
            }
        }

        private float R_MarginBottom;
        public float MarginBottom
        {
            set
            {
                R_MarginBottom = value;
            }
            get
            {
                return R_MarginBottom;
            }
        }
    }

    public class ConvertReport : Properties
    {

        public enum Type_Converter
        {
            PDF,
            Excel
        }

        public void Save(ReportViewer viewer, string SavePath = "", Type_Converter Convert = Type_Converter.PDF, bool IsOpen = false)
        {
            if (string.IsNullOrEmpty(Strings.Trim(SavePath)))
            {
                var SaveDialog = new SaveFileDialog();
                if (Convert == Type_Converter.PDF)
                {
                    SaveDialog.Filter = "*PDF files (*.pdf)|*.pdf";
                }
                else
                {
                    SaveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
                }
                SaveDialog.FilterIndex = 2;
                SaveDialog.RestoreDirectory = true;
                if (SaveDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                SavePath = SaveDialog.FileName;
            }
            string deviceInfo = null;
            if (Convert == Type_Converter.PDF)
                deviceInfo = "<DeviceInfo><OutputFormat>PDF</OutputFormat><PageWidth>" + PageWidth + "in</PageWidth><PageHeight>" + PageHeight + "in</PageHeight><MarginTop>" + MarginTop + "in</MarginTop><MarginLeft>" + MarginLeft + "in</MarginLeft><MarginRight>" + MarginRight + "in</MarginRight><MarginBottom>" + MarginBottom + "in</MarginBottom></DeviceInfo>";
            Warning[] warn = null;
            string[] streamids = null;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            byte[] Bytes = viewer.LocalReport.Render(Convert.ToString(), deviceInfo, out mimeType, out encoding, out extension, out streamids, out warn);
            using (var Stream = new FileStream(SavePath, FileMode.Create))
            {
                Stream.Write(Bytes, 0, Bytes.Length);
                Stream.Close();
            }
            if (IsOpen == true)
                Process.Start(SavePath);
        }

        public enum TypeLocationReport
        {
            ReportEmbeddedResource,
            ReportPath
        }

        public void Save(TypeLocationReport Type, string FullPathReport, string SavePath = "", Type_Converter Convert = Type_Converter.PDF, bool IsOpen = false)
        {
            var viewer = new ReportViewer();
            if (Type == TypeLocationReport.ReportEmbeddedResource)
            {
                viewer.LocalReport.ReportEmbeddedResource = FullPathReport;
            }
            else
            {
                viewer.LocalReport.ReportPath = FullPathReport;
            }
            viewer.RefreshReport();

            if (string.IsNullOrEmpty(Strings.Trim(SavePath)))
            {
                var SaveDialog = new SaveFileDialog();
                if (Convert == Type_Converter.PDF)
                {
                    SaveDialog.Filter = "*PDF files (*.pdf)|*.pdf";
                }
                else
                {
                    SaveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
                }
                SaveDialog.FilterIndex = 2;
                SaveDialog.RestoreDirectory = true;
                if (SaveDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                SavePath = SaveDialog.FileName;
            }
            string deviceInfo = null;
            if (Convert == Type_Converter.PDF)
                deviceInfo = "<DeviceInfo><OutputFormat>PDF</OutputFormat><PageWidth>" + PageWidth + "in</PageWidth><PageHeight>" + PageHeight + "in</PageHeight><MarginTop>" + MarginTop + "in</MarginTop><MarginLeft>" + MarginLeft + "in</MarginLeft><MarginRight>" + MarginRight + "in</MarginRight><MarginBottom>" + MarginBottom + "in</MarginBottom></DeviceInfo>";
            Warning[] warn = null;
            string[] streamids = null;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            byte[] Bytes = viewer.LocalReport.Render(Convert.ToString(), deviceInfo, out mimeType, out encoding, out extension, out streamids, out warn);
            using (var Stream = new FileStream(SavePath, FileMode.Create))
            {
                Stream.Write(Bytes, 0, Bytes.Length);
                Stream.Close();
            }
            if (IsOpen == true)
                Process.Start(SavePath);
        }

    }

    public class ConvertNumberToWord
    {
        private string[] mOnesArray = new string[9];
        private string[] mOneTensArray = new string[10];
        private string[] mTensArray = new string[8];
        private string[] mPlaceValues = new string[5];


        public ConvertNumberToWord()
        {

            mOnesArray[0] = "one";
            mOnesArray[1] = "two";
            mOnesArray[2] = "three";
            mOnesArray[3] = "four";
            mOnesArray[4] = "five";
            mOnesArray[5] = "six";
            mOnesArray[6] = "seven";
            mOnesArray[7] = "eight";
            mOnesArray[8] = "nine";

            mOneTensArray[0] = "ten";
            mOneTensArray[1] = "eleven";
            mOneTensArray[2] = "twelve";
            mOneTensArray[3] = "thirteen";
            mOneTensArray[4] = "fourteen";
            mOneTensArray[5] = "fifteen";
            mOneTensArray[6] = "sixteen";
            mOneTensArray[7] = "seventeen";
            mOneTensArray[8] = "eighteen";
            mOneTensArray[9] = "nineteen";

            mTensArray[0] = "twenty";
            mTensArray[1] = "thirty";
            mTensArray[2] = "forty";
            mTensArray[3] = "fifty";
            mTensArray[4] = "sixty";
            mTensArray[5] = "seventy";
            mTensArray[6] = "eighty";
            mTensArray[7] = "ninety";

            mPlaceValues[0] = "hundred";
            mPlaceValues[1] = "thousand";
            mPlaceValues[2] = "million";
            mPlaceValues[3] = "billion";
            mPlaceValues[4] = "trillion";

        }


        protected string GetOnes(int OneDigit)
        {
            string GetOnesRet = default;

            GetOnesRet = "";

            if (OneDigit == 0)
            {
                return GetOnesRet;
            }

            GetOnesRet = mOnesArray[OneDigit - 1];
            return GetOnesRet;

        }


        protected string GetTens(int TensDigit)
        {
            string GetTensRet = default;

            GetTensRet = "";

            if (TensDigit == 0 | TensDigit == 1)
            {
                return GetTensRet;
            }

            GetTensRet = mTensArray[TensDigit - 2];
            return GetTensRet;

        }

        public enum Currencies
        {
            RIEL,
            USD
        }
        public string ConvertNumberToWords(string NumberValue, Currencies Currency = Currencies.USD)
        {
            string ConvertNumberToWordsRet = default;
            string mNumberValue = "";
            string mNumbers = "";
            string mFraction = "";
            int j = 0;
            string mNumWord = "";
            ConvertNumberToWordsRet = "";
            // validate input
            try
            {
                j = (int)Math.Round(Conversions.ToDouble(NumberValue));
            }
            catch (Exception ex)
            {
                ConvertNumberToWordsRet = "Invalid input.";
                return ConvertNumberToWordsRet;
            }

            // get fractional part {if any}
            if (Strings.InStr(NumberValue, ".", CompareMethod.Binary) == 0)
            {
                // no fraction
                mNumberValue = NumberValue;
            }
            else
            {
                mNumberValue = Strings.Left(NumberValue, Strings.InStr(NumberValue, ".", CompareMethod.Binary) - 1);
                mFraction = Strings.Mid(NumberValue, Strings.InStr(NumberValue, ".", CompareMethod.Binary)); // + 1)
                if (Strings.StrComp(mFraction, ".", CompareMethod.Binary) == 0)
                    mFraction = "0";
                mFraction = (Math.Round((double)Conversions.ToSingle(mFraction), 2) * 100d).ToString();

                if (Conversions.ToInteger(mFraction) == 0)
                {
                    mFraction = "";
                }
                else
                {
                    mFraction = Currency.ToString() + " And Cent " + GetWord(Conversions.ToString(mFraction.ToCharArray()));
                }
            }
            mNumWord = GetWord(Conversions.ToString(mNumberValue.ToCharArray()));
            return Strings.StrConv(Strings.Trim(mNumWord) + " " + Strings.Trim(Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(Strings.Trim(mFraction)), Currency.ToString(), mFraction))) + " ONLY", VbStrConv.Uppercase);
        }

        private string GetWord(string mNumbers)
        {
            string Delimiter = " ";
            string TensDelimiter = " ";
            var mNumberStack = default(string[]);
            int i = 0;
            bool mOneTens = false;
            string mNumWord = "";
            // move numbers to stack/array backwards
            for (int j = mNumbers.Length - 1; j >= 0; j -= 1)
            {
                Array.Resize(ref mNumberStack, i + 1);

                mNumberStack[i] = Conversions.ToString(mNumbers[j]);
                i += 1;
            }

            for (int j = mNumbers.Length - 1; j >= 0; j -= 1)
            {
                switch (j)
                {
                    case 0:
                    case 3:
                    case 6:
                    case 9:
                    case 12:
                        {
                            // ones  value
                            if (!mOneTens)
                            {
                                mNumWord += GetOnes((int)Math.Round(Conversion.Val(mNumberStack[j]))) + Delimiter;
                            }

                            switch (j)
                            {
                                case 3:
                                    {
                                        // thousands
                                        mNumWord += mPlaceValues[1] + Delimiter;
                                        break;
                                    }

                                case 6:
                                    {
                                        // millions
                                        mNumWord += mPlaceValues[2] + Delimiter;
                                        break;
                                    }

                                case 9:
                                    {
                                        // billions
                                        mNumWord += mPlaceValues[3] + Delimiter;
                                        break;
                                    }

                                case 12:
                                    {
                                        // trillions
                                        mNumWord += mPlaceValues[4] + Delimiter;
                                        break;
                                    }
                            }

                            break;
                        }


                    case var @case when @case == 1:
                    case 4:
                    case 7:
                    case 10:
                    case 13:
                        {
                            // tens value
                            if (Conversion.Val(mNumberStack[j]) == 0d)
                            {
                                mNumWord += GetOnes((int)Math.Round(Conversion.Val(mNumberStack[j - 1]))) + Delimiter;
                                mOneTens = true;
                                break;
                            }

                            if (Conversion.Val(mNumberStack[j]) == 1d)
                            {
                                mNumWord += mOneTensArray[(int)Math.Round(Conversion.Val(mNumberStack[j - 1]))] + Delimiter;
                                mOneTens = true;
                                break;
                            }

                            mNumWord += GetTens((int)Math.Round(Conversion.Val(mNumberStack[j])));

                            // this places the tensdelimiter; check for succeeding 0
                            if (Conversion.Val(mNumberStack[j - 1]) != 0d)
                            {
                                mNumWord += TensDelimiter;
                            }
                            mOneTens = false;
                            break;
                        }

                    default:
                        {
                            // hundreds value 
                            mNumWord += GetOnes((int)Math.Round(Conversion.Val(mNumberStack[j]))) + Delimiter;

                            if (Conversion.Val(mNumberStack[j]) != 0d)
                            {
                                mNumWord += mPlaceValues[0] + Delimiter;
                            }

                            break;
                        }
                }
            }
            return mNumWord;
        }
    }

}