using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace CourierTUI
{
    public class HeadersTab
    {
        public View view = new View();
        public TabView.Tab tab;

        public HeadersTab()
        {
            var contentTypeLabel = new Label("Content Type:")
            {
                X = 0,
                Y = 0
            };

            var contentTypeSelector = new ComboBox()
            {
                X = 14,
                Y = 0,
                Width = 40,
                Height = 5
            };

            contentTypeSelector.SetSource(new string[] { "application/json", "application/x-www-form-urlencoded", "multipart/form-data", "text/plain", "application/xml" });

            view.Add(contentTypeLabel);
            view.Add(contentTypeSelector);

            this.tab = new TabView.Tab("Header", view);
        }
    }
}
