﻿using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FlmWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            //Config for DependencyInjection (01)
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(typeof(IRankingRepository), typeof(RankingRepository));
            services.AddSingleton<RankingWindow>();
            services.AddSingleton(typeof(IMatchRepository), typeof(MatchRepository));
            services.AddSingleton<MatchWindow>();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var windowFLM = serviceProvider.GetService<MatchWindow>();
            windowFLM.Show();
        }
    }
}