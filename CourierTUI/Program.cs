using CourierTUI;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using Terminal.Gui;
using static Terminal.Gui.TabView;

class Program
{
    static void Main()
    {
        Application.Init();

        var top = Application.Top;

        var win = new Window("CourierTUI")
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };

        var tabView = new TabView()
        {
            X = 0,
            Y = 1,
            Width = Dim.Percent(100),
            Height = Dim.Percent(65)
        };

        var tabView2 = new TabView()
        {
            X = 0,
            Y = 18,
            Width = Dim.Percent(100),
            Height = Dim.Percent(45),
        };

        var methodComboBox = new ComboBox()
        {
            X = 8,
            Y = 0,
            Width = 15,
            Height = 5
        };

        methodComboBox.SetSource(new string[] { "GET", "POST" });

        var methodLabel = new Label()
        {
            X = 1,
            Y = 0,
            Width = 0,
            Height = 0,
            Text = "Method:"
        };


        var URLlabel = new Label()
        {
            X = 25,
            Y = 0,
            Width = 30,
            Text = "URL: "
        };

        var URLinput = new TextField()
        {
            X = 29,
            Y = 0,
            Width = 60
        };

        var getDataButton = new Button("Print data")
        {
            X = 103,
            Y = 0,
            Width = 5,
            Height = 1
        };

        TextView resultText = new TextView()
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = 7
        };



        DataHandler dataHandler = new DataHandler();
        ParametersTab paramsTab = new ParametersTab(dataHandler);
        ResultTab resultTab = new ResultTab(dataHandler, resultText);
        BodyTab bodyTab = new BodyTab(dataHandler);

        methodComboBox.SelectedItemChanged += (x) =>
        {
            dataHandler.method = methodComboBox.Text.ToString();
        };

        URLinput.TextChanged += (x) =>
        {
            dataHandler.URL = URLinput.Text.ToString();
        };


        getDataButton.Clicked += () =>
        {
            sendRequest(dataHandler, resultText);
        };

        tabView.AddTab(paramsTab.tab, true);
        tabView.AddTab(bodyTab.tab, true);
        tabView2.AddTab(resultTab.tab, true);


        tabView.SelectedTab = tabView.Tabs.First();

        win.Add(methodComboBox);
        win.Add(methodLabel);
        win.Add(URLlabel);
        win.Add(URLinput);
        win.Add(getDataButton);
        win.Add(tabView);
        win.Add(tabView2);
        top.Add(win);

        Application.Run();
    }

    public static async void sendRequest(DataHandler dataHandler, View view)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(getRequestMethod(dataHandler.method), dataHandler.URL);

        if (dataHandler.parameters != null)
        {
            foreach (KeyValue keyval in dataHandler.parameters)
            {
                request.Headers.Add(keyval.key, keyval.value);
            }
        }

        StringContent requestContent;

        if (dataHandler.body != null)
        {
            requestContent = new StringContent(dataHandler.body);
        }
        else
        {
            requestContent = new StringContent("");
        }

        requestContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(dataHandler.contentType);
        request.Content = requestContent;

        var response = await client.SendAsync(request);
        string content = await response.Content.ReadAsStringAsync();

        string formattedJson = JsonSerializer.Serialize(
            JsonSerializer.Deserialize<JsonElement>(content),
            new JsonSerializerOptions
            {
                WriteIndented = true
            });


        view.Text = formattedJson;
    }

    public static HttpMethod getRequestMethod(string method)
    {
        switch (method)
        {
            case "GET":
                return HttpMethod.Get;
            case "POST":
                return HttpMethod.Post;
            default:
                return null;
        }
    }
}