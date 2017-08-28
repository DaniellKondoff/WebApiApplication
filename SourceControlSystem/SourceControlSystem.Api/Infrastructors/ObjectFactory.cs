using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SourceControlSystem.Api.Infrastructors
{
    public static class ObjectFactory
    {
        private static IKernel savedKernel;
        public static void Initialize(IKernel kernel)
        {
            savedKernel = kernel;
        }

        public static T Get<T>()
        {
            return savedKernel.Get<T>();
        }
    }
}