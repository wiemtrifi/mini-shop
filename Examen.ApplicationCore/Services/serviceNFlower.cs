using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;

  namespace Examen.ApplicationCore.Services
{
    public class serviceNFlower : Service<NaturalFlower>, IserviceNFlower
    {
        public serviceNFlower(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
 