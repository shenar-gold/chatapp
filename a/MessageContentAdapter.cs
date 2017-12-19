using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace a
{
    internal class MsgContentAdapter : RecyclerView.Adapter
    {

        List<MessageContent> lstMessages;

        public MsgContentAdapter(List<MessageContent> lst_messages)
        {
            lstMessages = lst_messages;
            var xx = lst_messages;
            var yy = lst_messages;

        }

        public class MyView : RecyclerView.ViewHolder
        {
            public View mMainView { set; get; }
            public TextView userEmail { set; get; }
            public TextView userText { set; get; }
            public TextView date_and_time { set; get; }

            public MyView(View view): base(view){
                mMainView = view;
            }

        }

        public override int ItemCount => lstMessages.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyView vHolder = (a.MsgContentAdapter.MyView)holder;
            vHolder.userEmail.Text = lstMessages[position].user_email;
            vHolder.userText.Text = lstMessages[position].user_msg;
            vHolder.date_and_time.Text = lstMessages[position].date_and_time;

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            var row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.List_ItemLayout, null, false);
            MyView row_view = new MyView(row);

            row_view.userEmail = row.FindViewById<TextView>(Resource.Id.msg_user);
            row_view.userText = row.FindViewById<TextView>(Resource.Id.msg_text);
            row_view.date_and_time = row.FindViewById<TextView>(Resource.Id.msg_date_and_time);

            return row_view;
        }
    }
}