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
                    return Assembly.Load(GetBytes("DllAsResource.Lib.Newtonsoft.Json.dll"));
                }

                return null;
            };

            base.OnStartup(e);
        }

        private static byte[] GetBytes(string name)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
            {
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                return bytes;
            }
        }
    }
}
