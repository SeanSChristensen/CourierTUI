using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace CourierTUI
{
    public class BodyTab
    {
        public View view = new View();
        public TabView.Tab tab;
        public DataHandler dataHandler;

        public BodyTab(DataHandler dataHandler)
        {
            var bodyLabel = new Label()
            {
                X = 0,
                Y = 0,
                Width = 30,
                Text = "Body: "
            };

            var bodyTextField = new TextView()
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            bodyTextField.ContentsChanged += (e) =>
            {
                dataHandler.body = bodyTextField.Text.ToString();
            };

            view.Add(bodyLabel);
            view.Add(bodyTextField);

            this.tab = new TabView.Tab("Body", view);
            this.dataHandler = dataHandler;
        }
    }
}
