using Orchard.Data.Migration;
using Orchard.ContentManagement.MetaData;

namespace Bolo.MyWidgets
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            // Define a new content type called "AboutMeWidget"
            ContentDefinitionManager.AlterTypeDefinition("AboutMeWidget", type => type

                // Attach the "AboutMeWidgetPart"
                .WithPart("AboutMeWidgetPart")

                // In order to turn this content type into a widget, it needs the WidgetPart
                .WithPart("WidgetPart")

                // It also needs a setting called "Stereotype" to be set to "Widget"
                .WithSetting("Stereotype", "Widget")
                );

            return 1;
        }

        public int UpdateFrom1()
        {
            // Update the ShoppingCartWidget so that it has a CommonPart attached, which is required for widgets (it's generally a good idea to have this part attached)
            ContentDefinitionManager.AlterTypeDefinition("AboutMeWidget", type => type
                .WithPart("CommonPart")
            );

            return 2;
        }

        public int UpdateFrom2()
        {
            ContentDefinitionManager.AlterTypeDefinition("SlideWidget", type => type
                .WithPart("SlideWidgetPart")
                .WithPart("CommonPart")
                .WithPart("WidgetPart")
                .WithSetting("Stereotype", "Widget")
                );

            return 3;
        }

        public int UpdateFrom3()
        {
            ContentDefinitionManager.AlterTypeDefinition("ClockWidget", type => type
                .WithPart("ClockWidgetPart")
                .WithPart("CommonPart")
                .WithPart("WidgetPart")
                .WithSetting("Stereotype", "Widget")
                );

            return 4;
        }

    }
}