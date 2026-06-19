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
        public List<KeyValue> keyValues = new();
        public View view = new View();
        public TabView.Tab tab;
        public DataHandler handler;

        public ParametersTab(DataHandler handler)
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

            contentTypeSelector.SelectedItemChanged += (e) =>
            {
                handler.contentType = contentTypeSelector.Text.ToString();
            };

            var parametersLabel = new Label("Parameters:")
            {
                X = 0,
                Y = 1
            };

            var addButton = new Button("Add keyVal")
            {
                X = 0,
                Y = 2
            };

            var getDataButton = new Button("Print data")
            {
                X = 15,
                Y = 2
            };

            var container = new View
            {
                X = 0,
                Y = 3,
                Width = Dim.Fill(),
                Height = Dim.Fill() - 3
            };

            addButton.Clicked += () =>
            {
                addRow(container);
            };

            view.Add(addButton);
            view.Add(container);
            view.Add(parametersLabel);
            view.Add(contentTypeLabel);
            view.Add(contentTypeSelector);

            this.tab = new TabView.Tab("Params", this.view);
            this.handler = handler;
        }

        public void addRow(View container)
        {
            var keyval = new KeyValue();
            keyValues.Add(keyval);

            View row = new View() { X = 0, Y = keyValues.Count - 1, Width = Dim.Fill(), Height = 1 };

            Label keyLabel = new Label() { Y = 0, X = 0, Text = "Key: " };
            TextField keyField = new TextField() { X = 4, Y = 0, Width = 15 };
            Label valueLabel = new Label() { Y = 0, X = 20, Text = "Value: " };
            TextField valueField = new TextField() { X = 26, Y = 0, Width = 15 };

            keyField.TextChanged += (e) =>
            {
                keyval.key = keyField.Text.ToString();
                handler.parameters = keyValues;
            };

            valueField.TextChanged += (e) =>
            {
                keyval.value = valueField.Text.ToString();
                handler.parameters = keyValues;
            };

            row.Add(keyLabel);
            row.Add(keyField);
            row.Add(valueLabel);
            row.Add(valueField);

            container.Add(row);
        }
    }
}
