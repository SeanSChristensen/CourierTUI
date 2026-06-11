using System.ComponentModel;
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
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };

        var detailsTab = new TabView.Tab("Details", new Label("Hello from Tab 1"));
        var paramsTab = new TabView.Tab("Params", new View());
        var bodyTab = new TabView.Tab("Body", new Label("Hello from Tab 2"));
        var authTab = new TabView.Tab("Auth", new Label("Hello from Tab 2"));
        var headersTab = new TabView.Tab("Headers", new Label("Hello from Tab 2"));

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

        detailsTab.View.Add(URLlabel);
        detailsTab.View.Add(URLinput);
        detailsTab.View.Add(methodSelectorLabel);
        detailsTab.View.Add(methodSelector);

        for(int i = 0; i < 3; i++)
        {
            View row = new View() { X=0, Y=i, Width=Dim.Fill(), Height=1 };

            Label keyLabel = new Label() { Y = 0, X = 0, Text="Key: " };
            TextField keyField = new TextField() { X = 4,Y=0,Width=15 };
            Label valueLabel = new Label() { Y = 0, X = 20, Text="Value: " };
            TextField valueField = new TextField() { X = 26, Y = 0, Width = 15 };

            row.Add(keyLabel);
            row.Add(keyField);
            row.Add(valueLabel);
            row.Add(valueField);

            paramsTab.View.Add(row);
        }


        tabView.AddTab(detailsTab, true);
        tabView.AddTab(paramsTab, true);
        tabView.AddTab(bodyTab, true);
        tabView.AddTab(authTab, true);
        tabView.AddTab(headersTab, true);

        tabView.SelectedTab = tabView.Tabs.First();

        win.Add(tabView);
        top.Add(win);

        Application.Run();
    }
}