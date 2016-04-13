using System;
using WebKit;
using System.IO;
using ToDo.iOS;

[assembly:Xamarin.Forms.Dependency(typeof(SQLite_iOS))]
namespace ToDo.iOS
{
	public class SQLite_iOS : ISQLite
	{
		public SQLite_iOS()
		{
		}

		public SQLite.SQLiteConnection GetConnection() {
			//path for iOS here
			//var sqliteFilename = "ToDo.db";
			//string documentsPath = Environment.GetFolderPath (
			//Environment.SpecialFolder.Personal);
			//string libraryPath = Path.Combine(
			//documentsPath, "..", "Library");
			//var path = Path.Combine(libraryPath,
			//	sqliteFileName);
			var path = "/users/christianrodriguez/Data/ToDo.db";
			File.Open(path, FileMode.OpenOrCreate);
			var conn = new SQLite.SQLiteConnection(path);
			return conn;
		}
	}
}

