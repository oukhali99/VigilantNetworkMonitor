
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VigilantNetworkMonitor.Condition.Service;
using VigilantNetworkMonitor.PacketFilter.Base;
using VigilantNetworkMonitor.PacketFilter.Factory;
using VigilantNetworkMonitor.PacketFilter.Service;
using VigilantNetworkMonitor.PacketFilter.VariableCondition.Factory;
using VigilantNetworkMonitor.PacketVariable.Factory;

namespace VigilantNetworkMonitor {
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
                        services.AddSingleton<IConditionFactory, ConditionFactory>();
                        services.AddSingleton<IPacketVariableFactory, PacketVariableFactory>();
                        services.AddSingleton<IPacketVariableConditionFilterFactory, PacketVariableConditionFilterFactory>();
                    }
                )
                .Build();
            ApplicationConfiguration.Initialize();
            Application.Run(host.Services.GetRequiredService<RootForm>());
        }
    }
}