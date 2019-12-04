using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Advent2019.DI
{
    public class ProviderBuilder
    {
        private ServiceCollection container;
        
        public ProviderBuilder()
        {
            this.container = new ServiceCollection();
        }

        public ProviderBuilder WithAutowire()
        {
            // register everything as a singleton
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if(type.IsInterface) {
                    continue;
                }

                this.container.AddSingleton(type);
            }

            return this;
        }

        public IServiceProvider Build()
        {
            return this.container.BuildServiceProvider();
        }
    }
}