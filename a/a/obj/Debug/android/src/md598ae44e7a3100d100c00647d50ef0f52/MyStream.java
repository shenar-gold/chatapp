package md598ae44e7a3100d100c00647d50ef0f52;


public class MyStream
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.firebase.storage.StreamDownloadTask.StreamProcessor
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_doInBackground:(Lcom/google/firebase/storage/StreamDownloadTask$TaskSnapshot;Ljava/io/InputStream;)V:GetDoInBackground_Lcom_google_firebase_storage_StreamDownloadTask_TaskSnapshot_Ljava_io_InputStream_Handler:Firebase.Storage.StreamDownloadTask/IStreamProcessorInvoker, Xamarin.Firebase.Storage\n" +
			"";
		mono.android.Runtime.register ("a.MyStream, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyStream.class, __md_methods);
	}


	public MyStream ()
	{
		super ();
		if (getClass () == MyStream.class)
			mono.android.TypeManager.Activate ("a.MyStream, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public MyStream (md5eae3ad6ed1b7f6713979aa7524906105.CircleImageView p0)
	{
		super ();
		if (getClass () == MyStream.class)
			mono.android.TypeManager.Activate ("a.MyStream, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Refractored.Controls.CircleImageView, Refractored.Controls.CircleImageView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void doInBackground (com.google.firebase.storage.StreamDownloadTask.TaskSnapshot p0, java.io.InputStream p1)
	{
		n_doInBackground (p0, p1);
	}

	private native void n_doInBackground (com.google.firebase.storage.StreamDownloadTask.TaskSnapshot p0, java.io.InputStream p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
