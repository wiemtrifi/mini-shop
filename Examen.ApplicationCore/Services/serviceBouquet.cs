using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;

namespace Examen.ApplicationCore.Services
{
    public class ServiceBouquet : Service<Bouquet>, IServiceBouquet
    {
        public ServiceBouquet(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
           

        }
     
    }
}