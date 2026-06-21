using System.ComponentModel;
using Terminal.Gui;
using static Terminal.Gui.TabView;
using CourierTUI;
using System.Net.Http;

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
            Height = Dim.Percent(50)
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


        var tabView2 = new TabView()
        {
            X = 0,
            Y = 10,
            Width = Dim.Percent(100),
            Height = Dim.Percent(50)
        };

        DataHandler dataHandler = new DataHandler();

        ParametersTab paramsTab = new ParametersTab(dataHandler);
        BodyTab bodyTab = new BodyTab(dataHandler);

        tabView.AddTab(paramsTab.tab, true);
        tabView.AddTab(bodyTab.tab, true);

        tabView.SelectedTab = tabView.Tabs.First();

        win.Add(methodComboBox);
        win.Add(methodLabel);
        win.Add(URLlabel);
        win.Add(URLinput);

        win.Add(tabView);
        //win.Add(tabView2);

        

        top.Add(win);

        Application.Run();
    }
}