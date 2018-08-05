#addin nuget:?package=Cake.FileHelpers

var COMMON_PROJ = "../../CommonUtils/CommonUtils/CommonUtils.csproj";
var PROJ_SLN_PATH = "../SafeAuthenticator.sln";

 
Func <System.Net.IPAddress, int, string, Task> DownloadTcpTextAsync = (System.Net.IPAddress TCP_LISTEN_HOST,int TCP_LISTEN_PORT,string RESULTS_PATH)=> System.Threading.Tasks.Task.Run (() => 
{
    System.Net.Sockets.TcpListener server = null;
    try
        { 
            server = new System.Net.Sockets.TcpListener(TCP_LISTEN_HOST, TCP_LISTEN_PORT);
            server.Start();
            while (true)
            {
                System.Net.Sockets.TcpClient client = server.AcceptTcpClient();
                System.Net.Sockets.NetworkStream stream = client.GetStream();
                StreamReader data_in = new StreamReader(client.GetStream());
                var result = data_in.ReadToEnd();
                System.IO.File.AppendAllText(RESULTS_PATH, result);
                client.Close();
                break;
            }
        }
        catch (System.Net.Sockets.SocketException e)
        {
            Information("SocketException: {0}", e);
        }
        finally
        {
            server.Stop();
        }
});


Task("Restore-NuGet-Packages")
    .Does(() =>
{
    NuGetRestore(COMMON_PROJ);
    NuGetRestore(PROJ_SLN_PATH);
});


