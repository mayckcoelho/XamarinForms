using App_Atelie.Droid.Util;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseFilePath))]
namespace App_Atelie.Droid.Util
{
    public class BaseFilePath : IBaseFilePath
    {
        public string GetBaseFilePath(string fileName)
        {
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(folderPath, fileName);
        }
    }
}