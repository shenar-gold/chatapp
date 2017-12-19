using System;

namespace a
{
    public class MessageContent
    {
        public string user_email { set; get; }
        public string user_msg { set; get; }
        public string date_and_time { set; get; }
        public string recipient_mail { set; get; }

        public MessageContent(string user_email, string user_msg){
            this.user_email = user_email;
            this.user_msg = user_msg;
            this.date_and_time = DateTime.Now.ToString("yyyy-MM-dd MM:mm:ss");
        }
    }
}