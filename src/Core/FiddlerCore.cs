using System.IO;
using Fiddler;

namespace Core
{
    class FiddlerCore
    {
        static public void Listen()
        {
            FiddlerApplication.Startup(0, FiddlerCoreStartupFlags.Default);
            FiddlerApplication.BeforeRequest += delegate (Session session)
            {
                if (session.uriContains("omegaloader14.swf"))
                {
                    session.utilCreateResponseAndBypassServer();
                    session.oFlags["x-replywithfile"] = Path.GetFullPath(session.url.Replace("epicduelstage.artix.com/", "C:/"));
                    FiddlerApplication.Shutdown();
                }
            };
        }
    }
}
