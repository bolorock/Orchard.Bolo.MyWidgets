using Orchard.UI.Resources;

namespace Bolo.MyWidgets
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            // Create and add a new manifest
            var manifest = builder.Add();

            // Define a "common" style sheet
           // manifest.DefineStyle("Bolo.MyWidget.Common").SetUrl("common.css");

            // Define the "shoppingcart" style sheet
            manifest.DefineStyle("Bolo.MyWidget.Slide").SetUrl("slide.css");//.SetDependencies("Bolo.WebShop.Common");

            // Define the "shoppingcart" script and set a dependency on the "jQuery" resource
            manifest.DefineScript("Bolo.MyWidget.Slide").SetUrl("slide.js").SetDependencies("jQuery");
            manifest.DefineScript("Bolo.MyWidget.Clock").SetUrl("clock.js");
            manifest.DefineScript("Bolo.MyWidget.Excanvas").SetUrl("excanvas.js");
        }
    }
}