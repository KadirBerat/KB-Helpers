# KB-Helpers
 In this class library project, there are four basic classes that you can use for hashing, logging, sending mail and uploading files to the server.

> There are four different classes for four different operations in this project.

# LogHelper
> Logging operations
```csharp
public static class LogHelper {...}
```
- Folder path where log files are stored
```csharp
private static string source = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
private const string folderName = "Log Records";
private static string folderPath = $@"{source}\{folderName}";
```
- Checking the folder where the log files will be stored
```csharp
private static void DirectoryControl()
{
    bool folderCheck = File.Exists(folderPath);
    if (folderCheck == false)
        Directory.CreateDirectory(folderPath);
}
```
- Checking the log file of the current day
```csharp
private static string LogFileControl()
{
    string date = DateTime.Now.ToString("dd-MM-yyyy");
    string filePath = $@"{folderPath}\{date}.log";
    bool fileCheck = File.Exists(filePath);
    if (fileCheck == false)
    {
        using (FileStream fs = File.Create(filePath))
        {
            fs.Dispose();
            fs.Close();
        }
    }
    return filePath;
}
```
- Types of log records to add
```csharp
public enum LogTypes
{
    Information,
    Warning,
    Error,
    Success_Audit, //Security Log
    Failure_Audit //Security Log
}
```
- Adding log record
```csharp
public static void AddLog(LogTypes type, string data)
{
    DirectoryControl();
    string filePath = LogFileControl();
    StreamWriter sw = File.AppendText(filePath);
    string log = $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} : {type.ToString()} : {data}";
    sw.WriteLine(log);
    sw.Dispose();
    sw.Close();
}
```

# HashHelper
> Hashing operations
```csharp
public static class HashHelper {...}
```
- UnicodeEncoding class used to convert string data into byte array
```csharp
private static UnicodeEncoding ue = new UnicodeEncoding();
```
- Static method for hashing with MD5
```csharp
public static string Hash_MD5(string str)
{
    if (!String.IsNullOrEmpty(str))
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        byte[] strBytes = ue.GetBytes(str);
        byte[] hashBytes = md5.ComputeHash(strBytes);
        return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
    }
    return "";
}
```
- Extension method for hashing with MD5
```csharp
public static string HashMD5(this string str)
{
    if (!String.IsNullOrEmpty(str))
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        byte[] strBytes = ue.GetBytes(str);
        byte[] hashBytes = md5.ComputeHash(strBytes);
        return BitConverter.ToString(hashBytes).ToUpper().Replace("-","");
    }
    return "";
}
```
- Static method for hashing with SHA1
```csharp
public static string Hash_SHA1(string str)
{
    if (!String.IsNullOrEmpty(str))
    {
        SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
        byte[] strBytes = ue.GetBytes(str);
        byte[] hashBytes = sha1.ComputeHash(strBytes);
        return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
    }
    return "";
}
```
- Extension method for hashing with SHA1
```csharp
public static string HashSHA1(this string str)
{
    if (!String.IsNullOrEmpty(str))
    {
        SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
        byte[] strBytes = ue.GetBytes(str);
        byte[] hashBytes = sha1.ComputeHash(strBytes);
        return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
            }
    return "";
}
```
- Static method for hashing with SHA256
```csharp
public static string Hash_SHA256(string str)
{
    if (!String.IsNullOrEmpty(str))
    {
        SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
        byte[] strBytes = ue.GetBytes(str);
        byte[] hashBytes = sha256.ComputeHash(strBytes);
        return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
    }
    return "";
}
```
- Extension method for hashing with SHA256
```csharp
public static string HashSHA256(this string str)
{
    if (!String.IsNullOrEmpty(str))
    {
        SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
        byte[] strBytes = ue.GetBytes(str);
        byte[] hashBytes = sha256.ComputeHash(strBytes);
        return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
    }
    return "";
}
```
- Static method for hashing with SHA384
```csharp
 public static string Hash_SHA384(string str)
{
    if (!String.IsNullOrEmpty(str))
    {
        SHA384CryptoServiceProvider sha384 = new SHA384CryptoServiceProvider();
        byte[] strBytes = ue.GetBytes(str);
        byte[] hashBytes = sha384.ComputeHash(strBytes);
        return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
    }
    return "";
}
```
- Extension method for hashing with SHA384
```csharp
public static string HashSHA384(this string str)
{
    if (!String.IsNullOrEmpty(str))
    {
        SHA384CryptoServiceProvider sha384 = new SHA384CryptoServiceProvider();
        byte[] strBytes = ue.GetBytes(str);
        byte[] hashBytes = sha384.ComputeHash(strBytes);
        return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
    }
    return "";
}
```
- Static method for hashing with SHA512
```csharp
public static string Hash_SHA512(string str)
{
    if (!String.IsNullOrEmpty(str))
    {
        SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();
        byte[] strBytes = ue.GetBytes(str);
        byte[] hashBytes = sha512.ComputeHash(strBytes);
        return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
    }
    return "";
}
```
- Extension method for hashing with SHA512
```csharp
 public static string HashSHA512(this string str)
{
    if (!String.IsNullOrEmpty(str))
    {
        SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();
        byte[] strBytes = ue.GetBytes(str);
        byte[] hashBytes = sha512.ComputeHash(strBytes);
        return BitConverter.ToString(hashBytes).ToUpper().Replace("-", "");
    }
    return "";
}
```

# MailHelper
> Mail sending process
```csharp
public static class MailHelper {...}
```
- Sends e-mail according to the data receive
```csharp
public static async Task MailSend(string senderMail, List<string> recipients, string subject, string message, string senderPassword, int port, string host, bool ssl)
{
    MailMessage eMail = new MailMessage();
    if (!String.IsNullOrEmpty(senderMail))
        eMail.From = new MailAddress(senderMail);
    if (recipients.Count > 0)
    {
        foreach (var recipient in recipients)
        {
            string rcp = recipient.ToString();
            if (rcp.Contains("@") == true && (rcp.Contains(".com") || rcp.Contains(".net")))
                eMail.To.Add(rcp);
        }
    }
    if (!String.IsNullOrEmpty(subject))
        eMail.Subject = subject;
    if (!String.IsNullOrEmpty(message))
        eMail.Body = message;
    SmtpClient smtp = new SmtpClient();
    if (!String.IsNullOrEmpty(senderMail) && !String.IsNullOrEmpty(senderPassword))
        smtp.Credentials = new System.Net.NetworkCredential(senderMail, senderPassword);
    smtp.Port = port;
    if (!String.IsNullOrEmpty(host))
        smtp.Host = host;
    smtp.EnableSsl = ssl;
    try
    {
        await Task.Run(() => smtp.SendAsync(eMail, null));
    }
    catch (Exception ex_1)
    {
        Console.WriteLine(ex_1.Message);
        try
        {
            await Task.Run(() => smtp.SendAsync(eMail, null));
        }
        catch (Exception ex_2)
        {
            Console.WriteLine(ex_2.Message);
        }
    }
}
```

# UploadHelper
> File uploads to server
```csharp
public static class UploadHelper {...}
```
- Server folder paths
```csharp
public const string FileMapPath = "/Content/FileStore";
public const string ImageMapPath = "/Content/imgUpload";
public static string ServerFileMapPath { get => HttpContext.Current.Server.MapPath(FileMapPath); }
public static string ServerImgMapPath { get => HttpContext.Current.Server.MapPath(ImageMapPath); }
```
- File save process
```csharp
public static string SaveFile(HttpPostedFileBase file)
{
    CreatePath(true);
    string filePath = Path.GetFileName(file.FileName);
    var uploadPath = Path.Combine(ServerFileMapPath, filePath);
    file.SaveAs(uploadPath);
    return FileMapPath + "/" + filePath;
}
```
- Image save process
```csharp
public static string SaveImage(HttpPostedFileBase file)
{
    CreatePath(false);
    string date = DateTime.Now.ToString().Replace('/', '-').Replace('.', '-').Replace(@"\", "-").Replace(':', '-').Replace(' ', '-');
    string ImagePath = Path.GetFileName(date + file.FileName.ToLower().Trim());
    var uploadPath = Path.Combine(ServerImgMapPath, ImagePath);
    file.SaveAs(uploadPath);
    return ImageMapPath + "/" + ImagePath;
}
```
- Save image by resizing
```csharp
public static string SaveImage(HttpPostedFileBase file, int width, int height, bool preserveAspect = false)
{
    CreatePath(false);
    string date = DateTime.Now.ToString().Replace('/', '-').Replace('.', '-').Replace(@"\", "-").Replace(':', '-').Replace(' ', '-');
    string ImagePath = Path.GetFileName(date + file.FileName.ToLower().Trim());
    var uploadPath = Path.Combine(ServerImgMapPath, ImagePath);
    var fileFormat = file.ContentType.Split('/')[1];
    Bitmap bmp = ImageResize(file.InputStream, width, height, preserveAspect);
    ImageCodecInfo jgpEncoder = GetEncoder(fileFormat == "png" ? ImageFormat.Png : ImageFormat.Jpeg);
    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
    EncoderParameters myEncoderParameters = new EncoderParameters(1);
    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
    myEncoderParameter = new EncoderParameter(myEncoder, 100L);
    myEncoderParameters.Param[0] = myEncoderParameter;
    using (FileStream stream = File.Create(uploadPath))
    {
        bmp.Save(stream, jgpEncoder, myEncoderParameters);
    }
    return ImageMapPath + "/" + ImagePath;
}
```
- Convert image to Base64
```csharp
public static string ImageToBase64(HttpPostedFileBase file, int width, int height, bool preserveAspect = false)
{
    Bitmap bmp = ImageResize(file.InputStream, width, height, preserveAspect);
    ImageCodecInfo jgpEncoder = GetEncoder(bmp.RawFormat.Equals(ImageFormat.Png) ? ImageFormat.Png : ImageFormat.Jpeg);
    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
    EncoderParameters myEncoderParameters = new EncoderParameters(1);
    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
    myEncoderParameter = new EncoderParameter(myEncoder, 100L);
    myEncoderParameters.Param[0] = myEncoderParameter;
    return ToBase64(file.FileName);
}
```
- Server folder check
```csharp
 static void CreatePath(bool fileMapControl)
{
    if (!Directory.Exists(ServerFileMapPath) && fileMapControl == true)
        Directory.CreateDirectory(ServerFileMapPath);
    if (!Directory.Exists(ServerImgMapPath) && fileMapControl == false)
        Directory.CreateDirectory(ServerImgMapPath);
}
```
- File extension control
```csharp
public static bool? FileExtensionControl(HttpPostedFileBase file)
{
    if (file != null)
    {
        string[] extension = new string[] { ".jpg", ".jpeg", ".png", ".docx", ".pdf", ".mp4" };
        string fileExtension = Path.GetExtension(file.FileName).ToLower();
        if (!extension.Contains(fileExtension))
        {
            return false;
        }
        return true;
    }
    return null;
}
```
- Image resizing
```csharp
static Bitmap ImageResize(Stream image, int width, int height, bool preserveAspect)
{
    Bitmap orjinalimage = new Bitmap(image);
    int newWidth = 0;
    int newHeight = 0;
    if (orjinalimage.Width == width && orjinalimage.Height == height)
        return orjinalimage;
    else if (preserveAspect)
    {
        newWidth = orjinalimage.Width;
        newHeight = orjinalimage.Height;
        double enboyorani = Convert.ToDouble(orjinalimage.Width) / Convert.ToDouble(orjinalimage.Height);
        newWidth = width;
        newHeight = Convert.ToInt32(Math.Round(newWidth / enboyorani));
        newHeight = height;
        newWidth = Convert.ToInt32(Math.Round(newHeight * enboyorani));
    }
    else
    {
        newWidth = width;
        newHeight = height;
    }
    return new Bitmap(orjinalimage, newWidth, newHeight);
}
```
- get `ImageCodecInfo` data for image
```csharp
static ImageCodecInfo GetEncoder(ImageFormat format)
{
    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
    foreach (ImageCodecInfo codec in codecs)
    {
        if (codec.FormatID == format.Guid)
        {
            return codec;
        }
    }
    return null;
}
```
- Convert image to Base64 based on file path
```csharp
public static string ToBase64(string uploadFileName)
{
    using (Image img = Image.FromFile(uploadFileName))
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            img.Save(memoryStream, img.RawFormat);
            byte[] imageBytes = memoryStream.ToArray();
            return Convert.ToBase64String(imageBytes);
        }
    }
}
```
- Converting base64 data to image
```csharp
public static Image ToImage(string base64String)
{
    byte[] imageBytes = Convert.FromBase64String(base64String);
    using (MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length))
    {
        return Image.FromStream(memoryStream, true);
    }
}
```
- Data deletion from server
```csharp
public static bool DeleteFileOrImage(string path)
{
    try
    {
        if (path != null || path != "")
        {
            FileInfo fileInfo = new FileInfo(HttpContext.Current.Server.MapPath(path));
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
                return true;
            }
        }
        return false;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return false;
    }
}
```