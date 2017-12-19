package md598ae44e7a3100d100c00647d50ef0f52;


public class myViewListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onClick:(Landroid/view/View;)V:GetOnClick_Landroid_view_View_Handler:Android.Views.View/IOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("a.myViewListener, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", myViewListener.class, __md_methods);
	}


	public myViewListener ()
	{
		super ();
		if (getClass () == myViewListener.class)
			mono.android.TypeManager.Activate ("a.myViewListener, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public myViewListener (md598ae44e7a3100d100c00647d50ef0f52.AccountProfileFragment p0)
	{
		super ();
		if (getClass () == myViewListener.class)
			mono.android.TypeManager.Activate ("a.myViewListener, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "a.AccountProfileFragment, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void onClick (android.view.View p0)
	{
		n_onClick (p0);
	}

	private native void n_onClick (android.view.View p0);

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
