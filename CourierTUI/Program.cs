using System.ComponentModel;
using Terminal.Gui;
using static Terminal.Gui.TabView;
using CourierTUI;

class Program
{
    static List<keyValue> keyvaluelist = new();
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
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };

        var authTab = new TabView.Tab("Auth", new Label("Hello from Tab 2"));

        ParametersTab paramsTab = new ParametersTab();
        DetailsTab detailsTab = new DetailsTab();
        BodyTab bodyTab = new BodyTab();
        HeadersTab headersTab = new HeadersTab();

        tabView.AddTab(detailsTab.tab, true);
        tabView.AddTab(paramsTab.tab, true);
        tabView.AddTab(bodyTab.tab, true);
        tabView.AddTab(authTab, true);
        tabView.AddTab(headersTab.tab, true);

        tabView.SelectedTab = tabView.Tabs.First();

        win.Add(tabView);
        top.Add(win);

        Application.Run();
    }
}

class keyValue
{
    public string key;
    public string value;
}