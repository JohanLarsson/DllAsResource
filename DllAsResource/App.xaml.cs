namespace DllAsResource
{
    using System;
    using System.Reflection;
    using System.Windows;

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                if (args.Name.StartsWith("Newtonsoft.Json"))
                {
                    using (var stream = Assembly.GetExecutingAssembly()
                                                .GetManifestResourceStream("DllAsResource.Lib.Newtonsoft.Json.dll"))
                    {
                        var ba = new byte[(int)stream.Length];
                        stream.Read(ba, 0, (int)stream.Length);
                        return Assembly.Load(ba);
                    }
                }

                return null;
            };

            base.OnStartup(e);
        }
    }
}
