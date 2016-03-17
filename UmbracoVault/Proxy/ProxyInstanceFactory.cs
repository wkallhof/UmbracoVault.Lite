﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Castle.DynamicProxy;

using Umbraco.Core.Models;

using UmbracoVault.Extensions;
using UmbracoVault.Reflection;

namespace UmbracoVault.Proxy
{
    public class ProxyInstanceFactory : IInstanceFactory
    {
        private static readonly ProxyGenerator _generator = new ProxyGenerator();
        private static readonly ProxyInterceptor _interceptor = new ProxyInterceptor();

        private static object BuildProxy<T>(IPublishedContent node)
        {
            var ops = new ProxyGenerationOptions();
            ops.AddMixinInstance(new LazyResolverMixin(node));

            var classToProxy = typeof(T);

            // Determine whether to use constructor that takes IPublishedContent
            var useContentConstructor = classToProxy.GetConstructors().Any(c => c.GetParameters().Any(p => p.ParameterType == typeof(IPublishedContent)));

            return useContentConstructor
                ? _generator.CreateClassProxy(classToProxy, ops, new[] { node }, _interceptor)
                : _generator.CreateClassProxy(classToProxy, ops, _interceptor);
        }

        public T CreateInstance<T>(IPublishedContent content)
        {
            return (T)BuildProxy<T>(content);
        }

        public IList<PropertyInfo> GetPropertiesToFill<T>()
        {
            return GetPropertiesToFill(typeof(T));
        }

        public IList<PropertyInfo> GetPropertiesToFill(Type type)
        {
            return type.GetDefaultPropertiesToFill().Where(p => p.GetMethod != null && !p.GetMethod.IsVirtual).ToList();
        }
    }
}