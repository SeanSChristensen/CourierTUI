using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace CourierTUI
{
    public class DetailsTab
    {
        public View view = new View();
        public TabView.Tab tab;

        public DetailsTab() 
        {

            var methodSelectorLabel = new Label("Method:")
            {
                X = 0,
                Y = 2
            };

            var methodSelector = new ComboBox()
            {
                X = 8,
                Y = 2,
                Width = 15,
                Height = 5
            };

            methodSelector.SetSource(new string[] { "GET", "POST" });

            var URLlabel = new Label()
            {
                X = 0,
                Y = 0,
                Width = 30,
                Text = "URL: "
            };

            var URLinput = new TextField()
            {
                X = 5,
                Y = 0,
                Width = 60
            };

            view.Add(URLlabel);
            view.Add(URLinput);
            view.Add(methodSelectorLabel);
            view.Add(methodSelector);

            this.tab = new TabView.Tab("Details", view);
        }
    }
}
