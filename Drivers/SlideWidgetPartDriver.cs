using Bolo.MyWidgets.Models;
using Orchard.ContentManagement.Drivers;
using Orchard.Localization;

namespace Bolo.MyWidgets.Drivers
{
    public class SlideWidgetPartDriver:ContentPartDriver<SlideWidgetPart>
    {
        public Localizer T { get; set; }

        protected override string Prefix
        {
            get
            {
                return "Slide";
            }
        }
        protected override DriverResult Display(SlideWidgetPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_SlideWidget", () => shapeHelper.Parts_SlideWidget(
               Num: 1
           ));
        }
    }
}