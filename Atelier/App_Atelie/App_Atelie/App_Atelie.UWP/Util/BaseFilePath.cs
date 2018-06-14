using App_Atelie.UWP.Util;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseFilePath))]
namespace App_Atelie.UWP.Util
{
    public class BaseFilePath : IBaseFilePath
    {
        public string GetBaseFilePath(string fileName)
        {
            string folderPath = ApplicationData.Current.LocalFolder.Path;
            return Path.Combine(folderPath, fileName);
        }
    }
}
