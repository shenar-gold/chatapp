using System;
namespace a
{
    public class DataWithPhoto
    {
        public string mPhotoPath { set; get; }
        public string mName { set; get; }
        public string mEmail { set; get; }
        public string mPhone { set; get; }

        public DataWithPhoto()
        {
            
        }
        public DataWithPhoto(String path, String name, String email, String phone_number)
        {
            this.mPhotoPath = path;
            this.mName = name;
            this.mEmail = email;
            this.mPhone = phone_number;
        }

    }
}
