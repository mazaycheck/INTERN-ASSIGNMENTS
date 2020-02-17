using System;

namespace OCP
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }        
    }

    public class Report
    {
        private string _data;

        public Report(string data) { _data = data; }

        public string parseRawData(string dataType)
        {
            string preparedData = "";
            if(dataType == "json")
            {
                // .. some logic
                preparedData = "@Json" + _data;
            }
            else if(dataType == "XML")
            {
                // .. some logic
                preparedData = "@XML" + _data;
            }
            return preparedData;
        }            
    }

    public abstract class AbstractReport
    {

        private string Data { get; set; }

        public AbstractReport(string data) { Data = data; }
        public abstract string parseRawData();

    }

    public class JsonReport : AbstractReport
    {
        public JsonReport(string data) : base(data) { }
        public override string parseRawData()
        {
            string parsedData = "";
            // .. some logic for Json
            return parsedData;
        }
    }

    public class XMLReport : AbstractReport
    {

        public XMLReport(string data) : base(data) { }
        public override string parseRawData()
        {
            string parsedData = "";
            // .. some logic for XML
            return parsedData;
        }
    }

}
