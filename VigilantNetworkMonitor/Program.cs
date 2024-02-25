
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VigilantNetworkMonitor.PacketFilter.Factory;
using VigilantNetworkMonitor.PacketFilter.Base;
using VigilantNetworkMonitor.Comparison.Factory;

namespace VigilantNetworkMonitor
{
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            IHost host = Host
                .CreateDefaultBuilder()
                .ConfigureServices(
                    (context, services) => {
                        services.AddSingleton<INetworkOptions, NetworkOptions>();
                        services.AddTransient<OptionsForm>();
                        services.AddTransient<RootForm>();
                        services.AddSingleton<IPacketFilterService, PacketFilterService>();
                        services.AddSingleton<IPacketFilterFactory, PacketFilterFactory>();
                        services.AddSingleton<IComparisonFactory, ComparisonFactory>();
                    }
                )
                .Build();
            IPacketFilter? filter = host.Services.GetRequiredService<IPacketFilterFactory>().ParseString("udp and src_port<100");
            if (filter != null) {
                string stred = filter.GetFilterString();
                Console.Write(stred);
            }
            ApplicationConfiguration.Initialize();
            Application.Run(host.Services.GetRequiredService<RootForm>());
        }
    }
}