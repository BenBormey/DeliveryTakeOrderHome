using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTakeOrder.Controller
{
    internal class ImageShackUploader
    {
        public struct ReturnedURLs
        {
            public string DirectLinkURL;
            public string ShowToFriendsURL;
            public string ThumbnailURL;
            public bool Exitoso;
        }
        private ReturnedURLs GetReturnedURLsFromHTMLRta(string HTML)
        {
            var RtaURLs = new ReturnedURLs { Exitoso = true };
            string ValueMatchString = "value=\"(?<val>.*?)\"";

            foreach (System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(HTML, "<input type=\"text\".*?/>", System.Text.RegularExpressions.RegexOptions.Singleline))
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(m.Value, ValueMatchString))
                {
                    var valuematch = System.Text.RegularExpressions.Regex.Match(m.Value, ValueMatchString);
                    var URLIMGMatch = System.Text.RegularExpressions.Regex.Match(valuematch.Groups["val"].Value, "\\\"");

                    if (URLIMGMatch.Value != "")
                    {
                        if (URLIMGMatch.Groups["url"].Value.ToLower() == "http://imageshack.us")
                        {
                            RtaURLs.DirectLinkURL = URLIMGMatch.Groups["img"].Value;
                        }
                        else
                        {
                            RtaURLs.ThumbnailURL = URLIMGMatch.Groups["img"].Value;
                            RtaURLs.ShowToFriendsURL = URLIMGMatch.Groups["url"].Value;
                        }
                    }
                }
            }

            return RtaURLs;
        }
        public object UploadFileToImageShack(string URL, string FileName, string Token, string keys, bool ReturnListClass = false)
{
    bool OldValue = System.Net.ServicePointManager.Expect100Continue;

    try
    {
        System.Net.ServicePointManager.Expect100Continue = false;

        // 1. Cookie
        var Cookie = new System.Net.CookieContainer();

        // 2. Arguments
        var QueryStringArguments = new Dictionary<string, string>
        {
            { "height", "350" }
        };

                string ContentType = "";
                switch (Path.GetExtension(FileName).ToLower())
                {
                    case ".jpg":
                    case ".jpeg":
                        ContentType = "image/jpeg";
                        break;
                    case ".gif":
                        ContentType = "image/gif";
                        break;
                    case ".png":
                        ContentType = "image/png";
                        break;
                    case ".bmp":
                        ContentType = "image/bmp";
                        break;
                    case ".tif":
                    case ".tiff":
                        ContentType = "image/tiff";
                        break;
                    default:
                        ContentType = "image/unknown";
                        break;
                }

                // 4. Upload and return Rta
                if (ReturnListClass)
        {
            return UploadFileEx(FileName, URL, "fileupload", ContentType, QueryStringArguments, Cookie, Token, keys);
        }
        else
        {
            return GetReturnedURLsFromHTMLRta(UploadFileEx(FileName, URL, "fileupload", ContentType, QueryStringArguments, Cookie, Token, keys));
        }
    }
    catch (Exception ex)
    {
        if (ReturnListClass)
        {
            return ex.Message;
        }
        else
        {
            var Rta = new ReturnedURLs { Exitoso = false };
            return Rta;
        }
    }
    finally
    {
        System.Net.ServicePointManager.Expect100Continue = OldValue;
    }
}
        private string UploadFileEx(string FileName, string URL, string FileFormName, string ContentType, Dictionary<string, string> QueryStringArguments, System.Net.CookieContainer Cookies, string Token, string keys)
        {
            if (string.IsNullOrEmpty(FileFormName)) FileFormName = "file";
            if (string.IsNullOrEmpty(ContentType)) ContentType = "application/octet-stream";

            string PostData = "?";
            if (QueryStringArguments != null)
            {
                foreach (var kvp in QueryStringArguments)
                {
                    PostData += $"{kvp.Key}={kvp.Value}&";
                }
            }

            var URI = new Uri(URL + PostData.Remove(PostData.Length - 1));
            string Boundary = "----------" + DateTime.Now.Ticks.ToString("x");
            var WReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URI);
            WReq.CookieContainer = Cookies;
            WReq.ContentType = "multipart/form-data; boundary=" + Boundary;
            WReq.Method = "POST";
            WReq.Headers.Add("Authorization", Token);
            WReq.Headers.Add("X-Client", keys);
            WReq.PreAuthenticate = true;

            string PostHeader = $"--{Boundary}\r\nContent-Disposition: form-data; name=\"{FileFormName}\"; filename=\"{Path.GetFileName(FileName)}\"\r\nContent-Type: {ContentType}\r\n\r\n";
            byte[] PostHeaderBytes = System.Text.Encoding.UTF8.GetBytes(PostHeader);
            byte[] BoundaryBytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + Boundary + "\r\n");

            using (var FileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            {
                WReq.ContentLength = PostHeaderBytes.Length + FileStream.Length + BoundaryBytes.Length;

                using (var RequestStream = WReq.GetRequestStream())
                {
                    RequestStream.Write(PostHeaderBytes, 0, PostHeaderBytes.Length);

                    byte[] buffer = new byte[Math.Min(4096, (int)FileStream.Length)];
                    int bytesRead;
                    while ((bytesRead = FileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        RequestStream.Write(buffer, 0, bytesRead);
                    }

                    RequestStream.Write(BoundaryBytes, 0, BoundaryBytes.Length);
                }
            }

            using (var Rta = WReq.GetResponse())
            using (var s = Rta.GetResponseStream())
            using (var sr = new StreamReader(s))
            {
                return sr.ReadToEnd();
            }
        }


    }
}
