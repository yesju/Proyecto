using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using System.IO;
using Proyecto.iOS;
using Xamarin.Forms;


[assembly: Dependency(typeof(ISQLite_IOS))]
namespace Proyecto.iOS
{
    public class ISQLite_IOS : ISQLite
    {
        public string GetLocalFilePath(string Filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, Filename);
        }
    }}