using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierTUI
{
    public class DataHandler
    {
        public string method;
        public string URL;
        public string body;
        public List<KeyValue> parameters = new List<KeyValue>();
        public string contentType;
        public bool isLoading = false;
    }
}
