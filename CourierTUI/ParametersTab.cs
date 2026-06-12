using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace CourierTUI
{
    public class ParametersTab
    {
        public List<keyValue> keyValues = new();
        public View view = new View();
        public TabView.Tab tab;

        public ParametersTab()
        {
            var addButton = new Button("Add keyVal")
            {
                X = 0,
                Y = 0
            };

            var getDataButton = new Button("Print data")
            {
                X = 15,
                Y = 0
            };

            var container = new View
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill() - 3
            };

            addButton.Clicked += () =>
            {
                addRow(container);
            };

            view.Add(addButton);
            view.Add(container);
            this.tab = new TabView.Tab("Params", this.view);
        }

        public void addRow(View container)
        {
            var keyval = new keyValue();
            keyValues.Add(keyval);

            View row = new View() { X = 0, Y = keyValues.Count - 1, Width = Dim.Fill(), Height = 1 };

            Label keyLabel = new Label() { Y = 0, X = 0, Text = "Key: " };
            TextField keyField = new TextField() { X = 4, Y = 0, Width = 15 };
            Label valueLabel = new Label() { Y = 0, X = 20, Text = "Value: " };
            TextField valueField = new TextField() { X = 26, Y = 0, Width = 15 };

            keyField.TextChanged += (e) =>
            {
                keyval.value = keyField.Text.ToString();
            };

            row.Add(keyLabel);
            row.Add(keyField);
            row.Add(valueLabel);
            row.Add(valueField);

            container.Add(row);
        }
    }

    public class keyValue
    {
        public string key;
        public string value;
    }
}
