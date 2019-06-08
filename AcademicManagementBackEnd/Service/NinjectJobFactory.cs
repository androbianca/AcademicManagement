using Ninject;

namespace Service
{
    internal class NinjectJobFactory
    {
        private StandardKernel kernel;

        public NinjectJobFactory(StandardKernel kernel)
        {
            this.kernel = kernel;
        }
    }
}