package md598ae44e7a3100d100c00647d50ef0f52;


public class CreateContactActivity_MyTestOnSuccessListener
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
		mono.android.Runtime.register ("a.CreateContactActivity+MyTestOnSuccessListener, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CreateContactActivity_MyTestOnSuccessListener.class, __md_methods);
	}


	public CreateContactActivity_MyTestOnSuccessListener ()
	{
		super ();
		if (getClass () == CreateContactActivity_MyTestOnSuccessListener.class)
			mono.android.TypeManager.Activate ("a.CreateContactActivity+MyTestOnSuccessListener, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public CreateContactActivity_MyTestOnSuccessListener (java.lang.String p0, java.lang.String p1, java.lang.String p2, java.lang.String p3)
	{
		super ();
		if (getClass () == CreateContactActivity_MyTestOnSuccessListener.class)
			mono.android.TypeManager.Activate ("a.CreateContactActivity+MyTestOnSuccessListener, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2, p3 });
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
