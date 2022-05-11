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
    [Activity(Label = "DetalleMesActivity")]
    public class DetalleMesActivity : Activity
    {
        Meses meses;
        TextView Nombre;
        ListView ListaT;
        ListView ListaV;
        ListView ListaA;
        ListView ListaU;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activityDetallemes);
            int id = Intent.GetIntExtra("id", 0);
            meses = GlobalClass.Meses.Where(x => x.Id == id).FirstOrDefault();

            Nombre = FindViewById<TextView>(Resource.Id.textView1);
            ListaT = FindViewById<ListView>(Resource.Id.listView1);
            ListaV = FindViewById<ListView>(Resource.Id.listView2);
            ListaA = FindViewById<ListView>(Resource.Id.listView3);
            ListaU = FindViewById<ListView>(Resource.Id.listView4);

            Nombre.Text = meses.Nombre_mes;
            ListaT.Adapter = new AdapterTotal(this, GlobalClass.Meses.Where(x => x.Id == meses.Id).ToList());
            ListaV.Adapter = new AdapterVestuarios(this, GlobalClass.Meses.Where(x => x.Id == meses.Id).ToList());
            ListaA.Adapter = new AdapterAlimentos(this, GlobalClass.Meses.Where(x => x.Id == meses.Id).ToList());
            ListaU.Adapter = new AdapterUsoHogar(this, GlobalClass.Meses.Where(x => x.Id == meses.Id).ToList());
        }
    }
}