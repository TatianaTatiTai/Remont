using System;
using System.Diagnostics;
using Castle.DynamicProxy;
using LAMS.DataAccess.Common.Repositories;
using LAMS.DataAccess.Contexts;
using LAMS.DataAccess.Repositories;
using LAMS.Logic.Common.Services.Logs;
using LAMS.Logic.Interceptors;
using LAMS.Logic.Services.Logs;
using Ninject;
using NUnit.Framework;

namespace LAMS.Logic.Tests.ErrorLog
{
    [TestFixture]
    public class ErrorLogUnitTest
    {
        public interface ITest
        {
            void MethodThrowsException1(string param);
            void MethodThrowsException2(string param);
            void MethodThrowsException3();
            void MethodThrowsException4(string param);
        }

        public class Test : ITest
        {
            public void MethodThrowsException1(string param)
            {
                throw new NotImplementedException();
            }

            public void MethodThrowsException2(string param)
            {
                throw new NullReferenceException();
            }

            public void MethodThrowsException3()
            {
                throw new StackOverflowException();
            }

            public void MethodThrowsException4(string param)
            {
                throw new TimeoutException();
            }
        }


        [Test]
        public void InterceptError_LogIntoDB()
        {
            var kernel = new StandardKernel();
            kernel.Load(new DataAccess.InjectorModule(), new Logic.InjectorModule());
            kernel.Bind<ITest>().ToMethod(ctx =>
            {
                var builder = new ProxyGenerator();
                var test = new Test();
                return builder.CreateInterfaceProxyWithTarget<ITest>(
                    test,
                    new ErrorLogInterceptor(ctx.Kernel.Get<IErrorLogService>()));
            });

            Assert.Throws<StackOverflowException>(() => kernel.Get<ITest>().MethodThrowsException3());
        }
    }
}
