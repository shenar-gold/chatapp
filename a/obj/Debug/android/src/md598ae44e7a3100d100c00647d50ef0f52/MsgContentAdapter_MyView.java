package md598ae44e7a3100d100c00647d50ef0f52;


public class MsgContentAdapter_MyView
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("a.MsgContentAdapter+MyView, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MsgContentAdapter_MyView.class, __md_methods);
	}


	public MsgContentAdapter_MyView (android.view.View p0)
	{
		super (p0);
		if (getClass () == MsgContentAdapter_MyView.class)
			mono.android.TypeManager.Activate ("a.MsgContentAdapter+MyView, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

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
