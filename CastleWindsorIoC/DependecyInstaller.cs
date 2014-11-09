﻿using System.Runtime.InteropServices.ComTypes;
using Castle.Core.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CastleWindsorIoC
{
    public class DependecyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Get current configuration = Web serivce call or somewhere perhaps.
            var currentConfig = new RegistrationConfig<IAnimal>();

            // Somewhere in the container.
            container.Register(Component.For<IFeatureConfig>()
                .ImplementedBy<FeatureConfig>());

            container.Register(Component.For<ILogger>()
                .ImplementedBy<Logger>()
                .LifestyleSingleton());

            // Register the types based on the configuration.
            container.Register(Classes
                .FromThisAssembly()
                .BasedOn<IAnimal>()
                .RegisterForFeature<IAnimal>(currentConfig, container)
                .WithService.AllInterfaces()
                .LifestyleSingleton());
        }
    }

    public class Registration<T>
    {
        public When When { get; set; }

        public Type Type { get; set; }

        public FeatureKey Key { get; set; }
    }

    public class RegistrationConfig<T>
    {
        public IEnumerable<Registration<T>> Registrations
        {
            get
            {
                yield return new Registration<T>() { When = When.Enabled, Type = typeof(Bat), Key = FeatureKey.BatFeature };
                yield return new Registration<T>() { When = When.Disabled, Type = typeof(Cat), Key = FeatureKey.BatFeature };
            }
        }
    }


    public enum When
    {
        Enabled = 1,

        Disabled = 0
    }

    public class Installer
    {
        public IWindsorContainer Install()
        {
            var container = new WindsorContainer();
            container.Install(new DependecyInstaller());

            return container;
        }
    }
}