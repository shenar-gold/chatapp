package md598ae44e7a3100d100c00647d50ef0f52;


public class MyOnSuccessListener2
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.tasks.OnSuccessListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSuccess:(Ljava/lang/Object;)V:GetOnSuccess_Ljava_lang_Object_Handler:Android.Gms.Tasks.IOnSuccessListenerInvoker, Xamarin.GooglePlayServices.Tasks\n" +
			"";
		mono.android.Runtime.register ("a.MyOnSuccessListener2, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyOnSuccessListener2.class, __md_methods);
	}


	public MyOnSuccessListener2 ()
	{
		super ();
		if (getClass () == MyOnSuccessListener2.class)
			mono.android.TypeManager.Activate ("a.MyOnSuccessListener2, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public MyOnSuccessListener2 (android.content.Context p0, md5eae3ad6ed1b7f6713979aa7524906105.CircleImageView p1)
	{
		super ();
		if (getClass () == MyOnSuccessListener2.class)
			mono.android.TypeManager.Activate ("a.MyOnSuccessListener2, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Refractored.Controls.CircleImageView, Refractored.Controls.CircleImageView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0, p1 });
	}


	public void onSuccess (java.lang.Object p0)
	{
		n_onSuccess (p0);
	}

	private native void n_onSuccess (java.lang.Object p0);

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
