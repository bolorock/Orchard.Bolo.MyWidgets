using Bolo.MyWidgets.Models;
using Orchard.ContentManagement.Drivers;
using Orchard.Localization;

namespace Bolo.MyWidgets.Drivers
{
    public class AboutMeWidgetPartDriver : ContentPartDriver<AboutMeWidgetPart>
    {

        public Localizer T { get; set; }

        protected override string Prefix
        {
            get
            {
                return "AboutMe";
            }
        }
        protected override DriverResult Display(AboutMeWidgetPart part, string displayType, dynamic shapeHelper)
        {
           // return ContentShape("Parts_AboutMeWidget", () => { return shapeHelper; });
             return ContentShape("Parts_AboutMeWidget", () => shapeHelper.Parts_AboutMeWidget(
                ItemCount: 1
            ));
        }
    }
}