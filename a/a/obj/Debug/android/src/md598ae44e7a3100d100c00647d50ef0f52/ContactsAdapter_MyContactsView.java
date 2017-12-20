package md598ae44e7a3100d100c00647d50ef0f52;


public class ContactsAdapter_MyContactsView
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("a.ContactsAdapter+MyContactsView, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ContactsAdapter_MyContactsView.class, __md_methods);
	}


	public ContactsAdapter_MyContactsView (android.view.View p0)
	{
		super (p0);
		if (getClass () == ContactsAdapter_MyContactsView.class)
			mono.android.TypeManager.Activate ("a.ContactsAdapter+MyContactsView, a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
