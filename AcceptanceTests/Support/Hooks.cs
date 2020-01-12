using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;
using WireMock.Server;
using WireMock.Settings;

namespace AcceptanceTests
{
    [Binding]
    public static class Hooks
    {
        public static FluentMockServer StubSlackServer;
        private static Process functionRuntime;

        [BeforeTestRun]
        private static void BeforeTestRun()
        {
            StartMockServers();
            StartFunctionHost();
        }
        private static void StartMockServers()
        {
            StubSlackServer = FluentMockServer.Start(new FluentMockServerSettings
            {
                Urls = new[] { "http://localhost:5002" },
                StartAdminInterface = true
            });
        }

        private static void StartFunctionHost()
        {
            string assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string functionDirectory = Path.Combine(assemblyDir, $"../../../../EmoticonPublisher/bin/Release/netcoreapp3.0/");
            ProcessStartInfo functionInfo = new ProcessStartInfo()
            {
                FileName = "func",
                Arguments = "host start",
                UseShellExecute = false,
                WorkingDirectory = functionDirectory
            };
            functionRuntime = new Process
            {
                StartInfo = functionInfo
            };
            functionRuntime.Start();
            Thread.Sleep(5000);
        }

        [BeforeScenario]
        private static void BeforeScenarioAsync()
        {
            StubSlackServer.Reset();
        }
                
        [AfterTestRun]
        private static void AfterTestRun()
        {
            StubSlackServer.Stop();
            functionRuntime.Kill();
        }
    }
}