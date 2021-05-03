using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.AdoNet;
using DataAccess.Concrete.AdoNet.Contexts;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DependencyResolvers.Ninject
{
    public class NinjectBusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserDal>().To<AdoUserDal>().InTransientScope();
            Bind<ICarDal>().To<AdoCarDal>().InTransientScope();
            Bind<ICustomerDal>().To<AdoCustomerDal>().InTransientScope();

            Bind<ICustomerService>().To<CustomerManager>().InTransientScope();
            Bind<IUserService>().To<UserManager>().InTransientScope();
            Bind<IAuthService>().To<AuthManager>().InTransientScope();
            Bind<ICarService>().To<CarManager>().InTransientScope();

            Bind<IDatabaseContext>().To<DatabaseContext>().InTransientScope();
        }
    }
}
