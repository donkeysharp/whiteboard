using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Whiteboard.Common {
    public class Constants {
        public const string SMTP_SERVER = "SmtpServer";
        public const string SMTP_PORT = "SmtpPort";
        public const string SMTP_SENDER = "SmtpSender";
        public const string SMTP_PASSWORD = "SmtpPassword";

        public const int HTTP_OK = 200;
        public const int HTTP_BAD_REQUEST = 400;
        public const int HTTP_NOT_AUTHORIZED = 403;
        public const int HTTP_INTERNAL_ERRROR = 500;

        public const string SESSION_USER = "WhiteboardUser";

        public const string UPLOADS_PATH = "~/Content/uploads";
    }

    public class Messages {
    }
}