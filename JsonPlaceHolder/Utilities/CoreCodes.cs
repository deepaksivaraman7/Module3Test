using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using RestSharp;
using Serilog;

namespace JsonPlaceHolder.Utilities
{
    internal class CoreCodes
    {
        protected RestClient client; //initializing client
        protected ExtentReports extent; //initializing extent reports
        protected ExtentTest? test;
        ExtentSparkReporter sparkReporter;

        [OneTimeSetUp] //called once prior to executing any of the tests in a fixture.
        public void OneTimeSetUp()
        {
            string currDir = Directory.GetParent(@"../../../").FullName; //getting current directory
            extent = new ExtentReports(); //instantiating extent reports
            sparkReporter = new ExtentSparkReporter(currDir + "/ExtentReports/extent-report" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");
            extent.AttachReporter(sparkReporter);
            string logFilePath = currDir + "/Logs/Log_" + DateTime.Now.ToString("yyyyMMdd_Hmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
                    .CreateLogger(); //for creating logs
        }

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://jsonplaceholder.typicode.com/");
        }

        [OneTimeTearDown] //called once after executing all the tests in a fixture
        public void TearDown()
        {
            extent.Flush();
        }
    }
}
