using System;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using DynamicMelt.Properties;
using Net.Common.Extensions;

namespace DynamicMelt.Providers
{
	public class MdbTable
	{
		private const string ConnectionStringFormat = "Provider=Microsoft.JET.OLEDB.4.0;data source={0};";

		public string MdbFile { get; private set; }

		protected string SubKey { get; private set; }

		protected OleDbConnection CreateConnection()
		{
			return new OleDbConnection(string.Format(ConnectionStringFormat, MdbFile));
		}

		private static void ValidatePath(string path)
		{
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(path);
			}
		}

		protected MdbTable(string file)
		{
			file = Path.Combine(Environment.CurrentDirectory, Settings.Default.DatabaseRelativePath, file);
			Trace.WriteLine("Opening '{0}'".FormatString(file));
			ValidatePath(file);
			MdbFile = file;
			SubKey = Path.GetFileName(MdbFile);
		}
	}
}