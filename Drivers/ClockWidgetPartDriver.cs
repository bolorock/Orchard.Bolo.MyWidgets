using Bolo.MyWidgets.Models;
using Orchard.ContentManagement.Drivers;
using Orchard.Localization;

namespace Bolo.MyWidgets.Drivers
{
    public class ClockWidgetPartDriver:ContentPartDriver<ClockWidgetPart>
    {
        public Localizer T { get; set; }

        protected override string Prefix
        {
            get
            {
                return "Clock";
            }
        }
        protected override DriverResult Display(ClockWidgetPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_ClockWidget", () => shapeHelper.Parts_ClockWidget());
        }
    }
}