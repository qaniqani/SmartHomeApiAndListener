namespace Ninject.Web.Common
{
    using System;
    using System.Web;
    using Ninject.Infrastructure.Disposal;

    /// <summary>
    /// Initializes a <see cref="HttpApplication"/> instance
    /// </summary>
    public class HttpApplicationInitializationHttpModule : DisposableObject, IHttpModule
    {
        private readonly Func<IKernel> lazyKernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpApplicationInitializationHttpModule"/> class.
        /// </summary>
        /// <param name="lazyKernel">The kernel retriever.</param>
        public HttpApplicationInitializationHttpModule(Func<IKernel> lazyKernel)
        {
            this.lazyKernel = lazyKernel;
        }

        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpApplication"/> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application</param>
        public void Init(HttpApplication context)
        {
            this.lazyKernel().Inject(context);
        }
    }
}