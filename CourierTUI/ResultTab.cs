using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Terminal.Gui;

namespace CourierTUI
{
    public class ResultTab
    {
        public View view = new View();
        public TabView.Tab tab;
        public DataHandler dataHandler;

        public TextView resultText;

        public ResultTab(DataHandler dataHandler, TextView textView)
        {
            this.dataHandler = dataHandler;

            this.resultText = textView;

            var progressBar = new ProgressBar()
            {
                X = 0,
                Y = 8,
                Width = Dim.Fill(),
                Height = 1
            };

            var timer = Application.MainLoop.AddTimeout(TimeSpan.FromMilliseconds(100), _ =>
            {
                if (dataHandler.isLoading)
                {
                    progressBar.Pulse();
                }
                return true;
            });


            view.Add(resultText);
            view.Add(progressBar);

            this.tab = new TabView.Tab("Results", view);
        }
    }
}
