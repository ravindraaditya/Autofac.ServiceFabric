﻿using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace Autofac.Integration.ServiceFabric.Test
{
    public sealed class RegistrationExtensionsTests
    {
        [Fact]
        public void RegisterServiceFabricSupportOnlyAddsModuleOnce()
        {
            var builder = new ContainerBuilder();
            builder.RegisterServiceFabricSupport();
            builder.RegisterServiceFabricSupport();

            var container = builder.Build();

            var actorInterceptors = container.Resolve<IEnumerable<ActorInterceptor>>().ToArray();
            Assert.Single(actorInterceptors);

            var serviceInterceptors = container.Resolve<IEnumerable<ServiceInterceptor>>().ToArray();
            Assert.Single(serviceInterceptors);
        }

        [Fact]
        public void RegisterServiceFabricSupportThrowsWhenContainerBuilderIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => RegistrationExtensions.RegisterServiceFabricSupport(null));

            Assert.Equal("builder", exception.ParamName);
        }
    }
}
