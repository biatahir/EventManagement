using log4net;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace CommonHelpers
{
    public static class Helpers
    {
        private const string DefaultTimeFormat = @"hh:mm tt";
        private const string DefaultTimeFormatDisplay = @"hh:mmtt";
        private const string DefaultDateFormat = @"dd/MM/yyyy";
        private const string BcrypSalt = "terp";
        private static readonly ILog _logger =
              LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string Hash(string value)
        {
            return BCrypt.Net.BCrypt.HashPassword(value, BcrypSalt);            
        }

        public static bool ValidateHash(string value, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(value,hash);
        }

        public static void LogInfo(string message)
        {
            _logger.Info(message);
        }
        public static string FirstCharToUpper(string input)
        {
            if (!String.IsNullOrEmpty(input))
                return input.First().ToString().ToUpper() + input.Substring(1);
            else
                return input;
        }
        public static void LogError(string message, Exception ex = null)
        {
            if (ex != null)
                _logger.Error(message, ex);
            else
                _logger.Error(message);
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static async Task SendEmail(string to, string subject, string message, bool isBodyHtml = false)
        {
            var email = new MailMessage();
            email.To.Add(to);
            email.BodyEncoding = Encoding.UTF8;
            email.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            email.Body = message;
            email.IsBodyHtml = isBodyHtml;
            email.Subject = subject;
            var client = new SmtpClient();

            using (var cts = new CancellationTokenSource(10000))
            {
                await client.SendMailExAsync(email, cts.Token);
            }

        }

        public static Task SendMailExAsync(
       this System.Net.Mail.SmtpClient @this,
       System.Net.Mail.MailMessage message,
       CancellationToken token = default(CancellationToken))
        {
            // use Task.Run to negate SynchronizationContext
            return Task.Run(() => SendMailExImplAsync(@this, message, token));
        }

        private static async Task SendMailExImplAsync(
            System.Net.Mail.SmtpClient client,
            System.Net.Mail.MailMessage message,
            CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var tcs = new TaskCompletionSource<bool>();
            System.Net.Mail.SendCompletedEventHandler handler = null;
            Action unsubscribe = () => client.SendCompleted -= handler;

            handler = async (s, e) =>
            {
                unsubscribe();

                // a hack to complete the handler asynchronously
                await Task.Yield();

                if (e.UserState != tcs)
                    tcs.TrySetException(new InvalidOperationException("Unexpected UserState"));
                else if (e.Cancelled)
                    tcs.TrySetCanceled();
                else if (e.Error != null)
                    tcs.TrySetException(e.Error);
                else
                    tcs.TrySetResult(true);
            };

            client.SendCompleted += handler;
            try
            {
                client.SendAsync(message, tcs);
                using (token.Register(() => client.SendAsyncCancel(), useSynchronizationContext: false))
                {
                    await tcs.Task;
                }
            }
            finally
            {
                unsubscribe();
            }
        }

        private static double DegToRad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private static double RadToDeg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }

        public static double GetDistance(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(DegToRad(lat1)) * Math.Sin(DegToRad(lat2)) + Math.Cos(DegToRad(lat1)) * Math.Cos(DegToRad(lat2)) * Math.Cos(DegToRad(theta));
            dist = Math.Acos(dist);
            dist = RadToDeg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }

        public static string GetJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static T ParseJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string GetAppSetting(string settingKey)
        {
            return ConfigurationManager.AppSettings[settingKey];
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
                   new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
        }
        public static string GetUKDateFormat(DateTime dt)
        {
            return dt.ToString(DefaultDateFormat);
        }
        public static string GetUKDateTimeFormat(DateTime dt)
        {
            return string.Concat(dt.ToString(DefaultDateFormat), " ", dt.ToShortTimeString());
        }
        public static TimeSpan ParseTime(string time)
        {
            return DateTime.ParseExact(time, DefaultTimeFormat, CultureInfo.InvariantCulture).TimeOfDay;
        }
        public static string GetFormattedTime(string time)
        {

            var tsTime = TimeSpan.Parse(time);
            DateTime dt = DateTime.Today.Add(tsTime);
            string displayTime = dt.ToString(DefaultTimeFormatDisplay);
            return displayTime.ToLower();
        }
    }
}
