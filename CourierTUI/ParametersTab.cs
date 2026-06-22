using System;
using System.Collections.Generic;
using System.Data;
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

        public TextField keyfield;
        public TextField valuefield;

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

            var table = new DataTable();
            table.Columns.Add("Key");
            table.Columns.Add("Value");

            var container = new TableView(table)
            {
                X = 0,
                Y = 5,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
                AutoSize = true,
                Style = {AlwaysShowHeaders = true}
            };

            Label keyLabel = new Label() { Y = 4, X = 0, Text = "Key: " };
            TextField keyField = new TextField() { X = 4, Y = 4, Width = 15 };
            this.keyfield = keyField;
            Label valueLabel = new Label() { Y = 4, X = 20, Text = "Value: " };
            TextField valueField = new TextField() { X = 26, Y = 4, Width = 15 };
            this.valuefield = valueField;

            view.Add(keyLabel);
            view.Add(keyField);
            view.Add(valueLabel);
            view.Add(valueField);


            addButton.Clicked += () =>
            {
                addRow(table);
            };

            view.Add(addButton);
            view.Add(container);
            view.Add(parametersLabel);
            view.Add(contentTypeLabel);
            view.Add(contentTypeSelector);

            this.tab = new TabView.Tab("Params", this.view);
            this.handler = handler;
        }

        public void addRow(DataTable datatable)
        {
            datatable.Rows.Add(this.keyfield.Text.ToString(), this.valuefield.Text.ToString());
        }
    }
}
