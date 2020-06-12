using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using TestDrive.Data;
using TestDrive.Droid;
using Path = System.IO.Path;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_android))]
namespace TestDrive.Droid
{
    class SQLite_android : ISQLite
    {
        private const string NOME_ARQUIVO_DB = "Agendamento.db3";

        public SQLiteConnection PegarConexao()
        {
            var caminhoDB = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, NOME_ARQUIVO_DB);
            return new SQLite.SQLiteConnection(caminhoDB);
        }
    }
}