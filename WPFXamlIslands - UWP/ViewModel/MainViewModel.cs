using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WPFXamlIslands.Model;

namespace WPFXamlIslands.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Photos = JsonConvert.DeserializeObject<Dictionary<string, PhotoData>>(
                File.ReadAllText("Photos\\__credits.json"),
                new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }
                }).Select(p => new PhotoData() {PhotoUrl = $".\\Photos\\{p.Key}.jpg", UserName = p.Value.UserName});
        }

        public IEnumerable<PhotoData> Photos { get; private set; }

    }
}