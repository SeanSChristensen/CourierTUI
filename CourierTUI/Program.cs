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
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };

        DataHandler dataHandler = new DataHandler();

        ParametersTab paramsTab = new ParametersTab(dataHandler);
        DetailsTab detailsTab = new DetailsTab(dataHandler);
        BodyTab bodyTab = new BodyTab(dataHandler);

        tabView.AddTab(detailsTab.tab, true);
        tabView.AddTab(paramsTab.tab, true);
        tabView.AddTab(bodyTab.tab, true);

        tabView.SelectedTab = tabView.Tabs.First();

        win.Add(tabView);
        top.Add(win);

        Application.Run();
    }
}