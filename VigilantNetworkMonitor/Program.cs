
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VigilantNetworkMonitor.Model.Comparison.Factory;
using VigilantNetworkMonitor.Packet.Filter.Factory;
using VigilantNetworkMonitor.Packet.Filter.Service;
using VigilantNetworkMonitor.Packet.Filter.VariableComparison.Factory;
using VigilantNetworkMonitor.Packet.Variable.Factory;
using VigilantNetworkMonitor.Service;

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
                        services.AddSingleton<IPacketVariableFactory, PacketVariableFactory>();
                        services.AddSingleton<IPacketVariableComparisonFilterFactory, PacketVariableComparisonFilterFactory>();
                        services.AddSingleton<IGeneralOptions, GeneralOptions>();
                        services.AddSingleton<IColumnOptions, ColumnOptions>();
                        services.AddSingleton<IPacketSnifferService, PacketSnifferService>();
                        services.AddTransient<SaveFilterForm>();
                    }
                )
                .Build();
            ApplicationConfiguration.Initialize();
            Application.Run(host.Services.GetRequiredService<RootForm>());
        }
    }
}