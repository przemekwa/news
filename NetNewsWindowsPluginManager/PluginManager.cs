﻿using NetNewsWindowsPluginDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetNewsWindowsPluginManager
{
    public class PluginManager 
    {
        public IEnumerable<Message> GetNews()
        {
            foreach (var plugin in this.GetNewsPlugins())
            {
                foreach (var news in plugin.GetNews())
                {
                    yield return news;
                }
            }
        }

        public IEnumerable<INewsPlugin> GetNewsPlugins()
        {
            DirectoryCatalog dir = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory + @"\plugins");

            var builder = new PluginInterfaceBuilder();

            CompositionContainer container = new CompositionContainer(dir);

            container.ComposeParts(builder);

            return builder.Plugins;
        }


        
    }
}
