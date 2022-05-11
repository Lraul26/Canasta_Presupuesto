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
    [Activity(Label = "ListaAniosActivity", MainLauncher = true)]
    public class ListaAniosActivity : Activity
    {
        ListView ListaV;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ActivityListaAnios);

            ListaV = FindViewById<ListView>(Resource.Id.listView1);

            ListaV.Adapter = new AdapterAnio(this, GlobalClass.Anios);
            ListaV.ItemClick += ListaV_ItemClick;
        }

        private void ListaV_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent i = new Intent(this, typeof(DetalleAniosActivity));

            //obtener el id del año seleccionado
            Anios anios = GlobalClass.Anios[e.Position];
            i.PutExtra("id", anios.Id);
            StartActivity(i);
        }
    }
}