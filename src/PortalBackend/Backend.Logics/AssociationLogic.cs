using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Interfaces;
using Backend.ViewModels;
using Backend.ViewModels.Demo;
using Portal.DataAccess.Interfaces;
using Portal.DataObjects;

namespace Backend.Logics
{
    public class AssociationLogic : IAssociationLogic
    {
        private readonly IAssociationRepository associationRepository;
        private readonly ISubscriptionLogic subscriptionLogic;

        public AssociationLogic(IAssociationRepository associationRepository, ISubscriptionLogic subscriptionLogic)
        {
            this.associationRepository = associationRepository;
            this.subscriptionLogic = subscriptionLogic;
        }

        public List<AssociationViewModel> GetAllAssociations()
        {
            var associations = associationRepository.GetAllAssociations();
            
            var response = new List<AssociationViewModel>();

            if (associations != null)
            {
                response.AddRange(associations.Select(association => new AssociationViewModel
                {
                    Address = association.Address, Id = association.Id, Name = association.Name
                }));
            }

            return new List<AssociationViewModel> {new AssociationViewModel{Name = "Association Name", Address = "Association Address", Telephone = "123456789"}};
        }

        public AssociationViewModel GetAssociation(int id)
        {
            var assoc = associationRepository.GetAssociation(id);
            if (assoc == null)
            {
                return new AssociationViewModel
                {
                    Name = "Association Name",
                    Address = "Association Address",
                    Telephone = "123456789",
                    PaymentType = "Monthly"
                };
            }

            var subscriptions = this.subscriptionLogic.GetSubscriptions(id);

            return new AssociationViewModel
                {
                    Address = assoc.Address,
                    Id = assoc.Id,
                    Name = assoc.Name,
                    IsActive = subscriptions.Any(x => x.IsActive)
                };
        }

        public BaseResponse SaveAssociation(AssociationViewModel viewModel)
        {
            var response = new BaseResponse();

            var result = associationRepository.SaveAssociation(new Association());

            return response;
        }
    }
}
