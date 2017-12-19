using System;
using Android.OS;

namespace a
{
    public interface ActivityResultDispatcher
    {
        void DispatchResultData(Android.Content.Intent data, int requestCode);
    }
}
