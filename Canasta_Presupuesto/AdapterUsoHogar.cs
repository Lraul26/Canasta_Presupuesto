using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Canasta_Presupuesto
{
    class AdapterUsoHogar : BaseAdapter
    {
        Activity context;
        List<Meses> list;

        public AdapterUsoHogar(Activity context, List<Meses> list)
        {
            this.context = context;
            this.list = list;
        }

        public override int Count => list.Count();

        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = list[position];
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2,null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = "Gastos de uso del Hogar";
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = "C$ "+ item.Uso_hogar.ToString();
            return view;
        }
    }
}