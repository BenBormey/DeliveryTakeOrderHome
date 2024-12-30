using DeliveryTakeOrder.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryTakeOrder.Controller
{
    public class APIsController
    {
        public string Name { get; set; }
        public string Token { get; set; }
        private const string xclient_ = "d36v43w";
        public APIsController(string Name)
        {
            this.Name = Name;
        }
        public void Login(string url, string username, string password)
        {
            try
            {
                var loginVM = new LoginModel { username = username, password = password };
                var jsonString = JsonConvert.SerializeObject(loginVM);

                var jsonDataBytes = Encoding.UTF8.GetBytes(jsonString);

                var req = WebRequest.Create(url);
                req.ContentType = "application/json";
                req.Method = "POST";
                req.ContentLength = jsonDataBytes.Length;
                req.Headers.Add("X-Client", xclient_);

                using (var stream = req.GetRequestStream())
                {
                    stream.Write(jsonDataBytes, 0, jsonDataBytes.Length);
                }

                var response = req.GetResponse();

                using (var resStream = response.GetResponseStream())
                using (var reader = new StreamReader(resStream))
                {
                    var res = reader.ReadToEnd();
                    var jsonResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(res);
                    Token = "Bearer " + jsonResult["accessToken"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public List<SDModel> GetAllSD(string url)
        {
            try
            {
                var req = WebRequest.Create(url);
                req.Method = "GET";
                req.PreAuthenticate = true;
                req.Headers.Add("Authorization", Token);
                req.Headers.Add("X-Client", xclient_);

                var response = req.GetResponse();

                using (var resStream = response.GetResponseStream())
                using (var reader = new StreamReader(resStream))
                {
                    var res = reader.ReadToEnd();
                    var jsonResult = JsonConvert.DeserializeObject<List<SDModel>>(res);
                    return jsonResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool ChangePasswordSD(string url, string id, string password)
        {
            try
            {
                if (Token == null) return false;

                var jsonString = JsonConvert.SerializeObject(new { password });
                var jsonDataBytes = Encoding.UTF8.GetBytes(jsonString);

                var req = WebRequest.Create(string.Format(url, id));
                req.ContentType = "application/json";
                req.Method = "PUT";
                req.PreAuthenticate = true;
                req.Headers.Add("Authorization", Token);
                req.Headers.Add("X-Client", xclient_);

                req.ContentLength = jsonDataBytes.Length;

                using (var stream = req.GetRequestStream())
                {
                    stream.Write(jsonDataBytes, 0, jsonDataBytes.Length);
                }

                var response = req.GetResponse();
                using (var resStream = response.GetResponseStream())
                using (var reader = new StreamReader(resStream))
                {
                    var res = reader.ReadToEnd();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void DeleteSD(string url, string id)
        {
            try
            {
                if (Token == null) return;

                var req = WebRequest.Create(string.Format(url, id));
                req.ContentType = "application/json";
                req.Method = "DELETE";
                req.PreAuthenticate = true;
                req.Headers.Add("Authorization", Token);
                req.Headers.Add("X-Client", xclient_);

                var response = req.GetResponse();

                using (var resStream = response.GetResponseStream())
                using (var reader = new StreamReader(resStream))
                {
                    var res = reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
            }
        }
        public List<T> GetAll<T>(string url)
        {
            try
            {
                var req = WebRequest.Create(url);
                req.Method = "GET";
                req.PreAuthenticate = true;
                req.Headers.Add("Authorization", Token);
                req.Headers.Add("X-Client", xclient_);

                var response = req.GetResponse();

                using (var resStream = response.GetResponseStream())
                using (var reader = new StreamReader(resStream))
                {
                    var res = reader.ReadToEnd();
                    var jsonResult = JsonConvert.DeserializeObject<List<T>>(res);
                    return jsonResult;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public T GetFirstOrDefault<T>(string url)
        {
            try
            {
                var req = WebRequest.Create(url);
                req.Method = "GET";
                req.PreAuthenticate = true;
                req.Headers.Add("Authorization", Token);
                req.Headers.Add("X-Client", xclient_);

                var response = req.GetResponse();

                using (var resStream = response.GetResponseStream())
                using (var reader = new StreamReader(resStream))
                {
                    var res = reader.ReadToEnd();
                    var jsonResult = JsonConvert.DeserializeObject<T>(res);
                    return jsonResult;
                }
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public SupervisorModel CreateSupervisor(string url, string sdId, string cusNum, string fullname, string address, string username, string password, string[] phones, string classstore)
        {
            try
            {
                if (Token == null) return null;

                var loginVM = new SupervisorModel
                {
                    sdId = sdId,
                    cusNum = cusNum,
                    fullname = fullname,
                    address = address,
                    username = username,
                    password = password,
                    phones = phones,
                    sdClassStore = classstore
                };
                var jsonString = JsonConvert.SerializeObject(loginVM);
                var jsonDataBytes = Encoding.UTF8.GetBytes(jsonString);

                var req = WebRequest.Create(url);
                req.ContentType = "application/json";
                req.Method = "POST";
                req.PreAuthenticate = true;
                req.Headers.Add("Authorization", Token);
                req.Headers.Add("X-Client", xclient_);

                req.ContentLength = jsonDataBytes.Length;

                using (var stream = req.GetRequestStream())
                {
                    stream.Write(jsonDataBytes, 0, jsonDataBytes.Length);
                }

                var response = req.GetResponse();

                using (var resStream = response.GetResponseStream())
                using (var reader = new StreamReader(resStream))
                {
                    var res = reader.ReadToEnd();
                }

                return loginVM;
            }
            catch (Exception)
            {
                return null;
            }
        }

     

        public SupervisorModel UpdateSupervisor(string url, string id, string sdId, string cusNum, string fullname, string address, string username, string password, string[] phones, string classstore)
        {
            try
            {
                if (Token == null) return null;

                var loginVM = new SupervisorModel
                {
                    sdId = sdId,
                    cusNum = cusNum,
                    fullname = fullname,
                    address = address,
                    username = username,
                    password = password,
                    phones = phones,
                    sdClassStore = classstore
                };
                var jsonString = JsonConvert.SerializeObject(loginVM);
                var jsonDataBytes = Encoding.UTF8.GetBytes(jsonString);

                var req = WebRequest.Create(string.Format(url, id));
                req.ContentType = "application/json";
                req.Method = "PUT";
                req.PreAuthenticate = true;
                req.Headers.Add("Authorization", Token);
                req.Headers.Add("X-Client", xclient_);

                req.ContentLength = jsonDataBytes.Length;

                using (var stream = req.GetRequestStream())
                {
                    stream.Write(jsonDataBytes, 0, jsonDataBytes.Length);
                }

                var response = req.GetResponse();

                using (var resStream = response.GetResponseStream())
                using (var reader = new StreamReader(resStream))
                {
                    var res = reader.ReadToEnd();
                }

                return loginVM;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ClassstoreModel CreateClass(string url, string id, string name, string abbr, string remark)
        {
            try
            {
                if (Token == null) return null;

                var loginVM = new ClassstoreModel
                {
                    id = id,
                    name = name,
                    abbr = abbr,
                    remark = remark,
                    isActive = true
                };
                var jsonString = JsonConvert.SerializeObject(loginVM);
                var jsonDataBytes = Encoding.UTF8.GetBytes(jsonString);

                var req = WebRequest.Create(url);
                req.ContentType = "application/json";
                req.Method = "POST";
                req.PreAuthenticate = true;
                req.Headers.Add("Authorization", Token);
                req.Headers.Add("X-Client", xclient_);

                req.ContentLength = jsonDataBytes.Length;

                using (var stream = req.GetRequestStream())
                {
                    stream.Write(jsonDataBytes, 0, jsonDataBytes.Length);
                }

                var response = req.GetResponse();

                using (var resStream = response.GetResponseStream())
                using (var reader = new StreamReader(resStream))
                {
                    var res = reader.ReadToEnd();
                }

                return loginVM;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void UpdateStatusClass(string url, string id, bool status)
        {
            try
            {
                if (Token == null) return;

                var jsonString = JsonConvert.SerializeObject(new { isActive = status });
                var jsonDataBytes = Encoding.UTF8.GetBytes(jsonString);

                var req = WebRequest.Create(string.Format(url, id));
                req.ContentType = "application/json";
                req.Method = "PUT";
                req.PreAuthenticate = true;
                req.Headers.Add("Authorization", Token);
                req.Headers.Add("X-Client", xclient_);

                req.ContentLength = jsonDataBytes.Length;

                using (var stream = req.GetRequestStream())
                {
                    stream.Write(jsonDataBytes, 0, jsonDataBytes.Length);
                }

                var response = req.GetResponse();

                using (var resStream = response.GetResponseStream())
                using (var reader = new StreamReader(resStream))
                {
                    var res = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<T> GetLists<T>(string url)
        {
            try
            {
                if (Token == null) return null;

                var req = WebRequest.Create(url);
                req.ContentType = "application/json";
                req.Method = "GET";
                req.PreAuthenticate = true;
                req.Headers.Add("Authorization", Token);
                req.Headers.Add("X-Client", xclient_);
                req.Credentials = System.Net.CredentialCache.DefaultCredentials;

                var response = req.GetResponse();

                using (var resStream = response.GetResponseStream())
                using (var reader = new StreamReader(resStream))
                {
                    var res = reader.ReadToEnd();
                    var jsonResult = JsonConvert.DeserializeObject<List<T>>(res);
                    return jsonResult;
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool Update<T>(string url, string id, T lst)
        {
            try
            {
                if (Token == null) return false;

                var jsonString = JsonConvert.SerializeObject(lst);
                var jsonDataBytes = Encoding.UTF8.GetBytes(jsonString);

                var req = WebRequest.Create(string.Format(url, id));
                req.ContentType = "application/json";
                req.Method = "PUT";
                req.PreAuthenticate = true;
                req.Headers.Add("Authorization", Token);
                req.Headers.Add("X-Client", xclient_);
                req.Credentials = System.Net.CredentialCache.DefaultCredentials;
                req.ContentLength = jsonDataBytes.Length;

                using (var stream = req.GetRequestStream())
                {
                    stream.Write(jsonDataBytes, 0, jsonDataBytes.Length);
                }

                var response = req.GetResponse();

                using (var resStream = response.GetResponseStream())
                using (var reader = new StreamReader(resStream))
                {
                    var res = reader.ReadToEnd();
                }

                return true;
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool Create<T>(string url, T lst)
        {
            try
            {
                if (Token == null) return false;

                var jsonString = JsonConvert.SerializeObject(lst);
                var jsonDataBytes = Encoding.UTF8.GetBytes(jsonString);
                var req = WebRequest.Create(url);
                req.ContentType = "application/json";
                req.Method = "POST";
                req.PreAuthenticate = true;
                req.Headers.Add("Authorization", Token);
                req.Headers.Add("X-Client", xclient_);
                req.Credentials = System.Net.CredentialCache.DefaultCredentials;
                req.ContentLength = jsonDataBytes.Length;

                using (var stream = req.GetRequestStream())
                {
                    stream.Write(jsonDataBytes, 0, jsonDataBytes.Length);
                }

                var response = req.GetResponse();

                using (var resStream = response.GetResponseStream())
                using (var reader = new StreamReader(resStream))
                {
                    var res = reader.ReadToEnd();
                }

                return true;
            }
            catch (WebException exception)
            {
                var response = exception.Response;
                if (response != null)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var responseText = reader.ReadToEnd();
                        Debug.Write(responseText);
                    }
                    response.Close();
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public T UploadImage<T>(string url, string path_)
        {
            T jsonResult;
            if (Token == null) return default(T);

            string contentType;
            switch (Path.GetExtension(path_).ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".gif":
                    contentType = "image/gif";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                case ".bmp":
                    contentType = "image/bmp";
                    break;
                case ".tif":
                case ".tiff":
                    contentType = "image/tiff";
                    break;
                default:
                    contentType = "image/unknown";
                    break;
            }

            var boundary = DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
            var dataBoundary = "--" + boundary;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.Headers.Add("Authorization", Token);
            request.Headers.Add("X-Client", xclient_);
            request.KeepAlive = true;

            using (var requestStream = request.GetRequestStream())
            {
                var preAttachment = dataBoundary + "\r\n" +
                                    "Content-Disposition: form-data; name=\"file\"; filename=\"" + Path.GetFileName(path_) + "\"\r\n" +
                                    "Content-Type: " + contentType + "\r\n\r\n";
                var preAttachmentBytes = Encoding.UTF8.GetBytes(preAttachment);
                requestStream.Write(preAttachmentBytes, 0, preAttachmentBytes.Length);

                using (var fileStream = new FileStream(path_, FileMode.Open, FileAccess.Read))
                {
                    var buffer = new byte[4096];
                    int bytesRead;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        requestStream.Write(buffer, 0, bytesRead);
                    }
                }

                var postAttachment = "\r\n" + dataBoundary + "\r\n" +
                                     "Content-Disposition: form-data; name=\"content\"\r\n\r\n" +
                                     "Action: comment\n" +
                                     "Attachment: " + Path.GetFileName(path_) + "\r\n" +
                                     "Text: Some description\r\n\r\n" +
                                     "--" + boundary + "--";
                var postAttachmentBytes = Encoding.UTF8.GetBytes(postAttachment);
                requestStream.Write(postAttachmentBytes, 0, postAttachmentBytes.Length);
            }

            try
            {
                var response = request.GetResponse();
                using (var responseStream = response.GetResponseStream())
                using (var responseReader = new StreamReader(responseStream))
                {
                    var responseText = responseReader.ReadToEnd();
                    Debug.Write(responseText);
                    jsonResult = JsonConvert.DeserializeObject<T>(responseText);
                }
            }
            catch (WebException exception)
            {
                var response = exception.Response;
                if (response != null)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var responseText = reader.ReadToEnd();
                        Debug.Write(responseText);
                    }
                }
                jsonResult = default(T);
            }

            return jsonResult;
        }

    }
}
