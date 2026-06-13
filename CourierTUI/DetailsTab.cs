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
        public DataHandler dataHandler;

        public DetailsTab(DataHandler dataHandler) 
        {
            this.dataHandler = dataHandler;

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

            var getDataButton = new Button("Print data")
            {
                X = 0,
                Y = 3
            };

            URLinput.TextChanged += (a) =>
            {
                dataHandler.URL = URLinput.Text.ToString();
            };

            methodSelector.SelectedItemChanged += (a) =>
            {
                dataHandler.method = methodSelector.SelectedItem.ToString();
            };

            var resultTextField = new TextView()
            {
                X = 0,
                Y = 4,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            getDataButton.Clicked += () =>
            {
                sendRequest(dataHandler, resultTextField);
            };



            view.Add(URLlabel);
            view.Add(URLinput);
            view.Add(methodSelectorLabel);
            view.Add(methodSelector);
            view.Add(getDataButton);
            view.Add(resultTextField);

            this.tab = new TabView.Tab("Details", view);
        }



        public static async void sendRequest(DataHandler datahander, View view)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(datahander.URL);
            string content = await response.Content.ReadAsStringAsync();
            view.Text = response.ToString();
        }
    }
}
