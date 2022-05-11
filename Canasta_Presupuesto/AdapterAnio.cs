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
    class AdapterAnio : BaseAdapter
    {
        Activity context;
        List<Anios> lista;

        public AdapterAnio(Activity context, List<Anios> lista)
        {
            this.context = context;
            this.lista = lista;
        }

        public override int Count => lista.Count;

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
            //elemento devuelto
            var item = lista[position];
            //Definimos el formato fila
            View view = convertView;
            if(view == null)
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2,null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Anio.ToString();
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = GlobalClass.Meses.Where(x => x.Id_anio == item.Id).Count().ToString();

            return view;
        }
    }
}
