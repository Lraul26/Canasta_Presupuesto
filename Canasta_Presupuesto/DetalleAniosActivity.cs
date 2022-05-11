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
    [Activity(Label = "DetalleAniosActivity")]
    public class DetalleAniosActivity : Activity
    {
        Anios anios;
        TextView Nombre;
        ListView Listav;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activityDetalleAnios);

            int id = Intent.GetIntExtra("id", 0);
            anios = GlobalClass.Anios.Where(x=> x.Id == id).FirstOrDefault();

            Nombre = FindViewById<TextView>(Resource.Id.textView1);
            Listav = FindViewById<ListView>(Resource.Id.listView1);

            Nombre.Text = anios.Anio.ToString();
            Listav.Adapter = new AdapterMes(this, GlobalClass.Meses.Where(x => x.Id_anio == anios.Id).ToList());
            Listav.ItemClick += Listav_ItemClick;
        }

        private void Listav_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent i = new Intent(this, typeof(DetalleMesActivity));
            Meses meses = GlobalClass.Meses[e.Position];
            i.PutExtra("id", meses.Id);
            StartActivity(i);
        }
    }
}