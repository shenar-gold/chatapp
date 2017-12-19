using System;

namespace a
{
    public class Contact
    {

        public string mRecipientPhoto {set; get;}
        public string mRecipientName { set; get; }
        public string mRecipientMail { set; get; }
        public string mSenderName { set; get; }
        public string mSenderMail { set; get; }

       // public string mLastMsg { set; get; }
       // public string mDate_Time { set; get; }

        public Contact(String se_mail, String se_name, String re_name, String re_mail)
      {
            this.mRecipientName = re_name;
            this.mRecipientMail = re_mail;
            this.mSenderMail = se_mail;
            this.mSenderName = se_name;
            this.mRecipientPhoto = "";
      }
    }
}