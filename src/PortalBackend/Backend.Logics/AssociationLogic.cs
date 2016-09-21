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
                    Address = association.Address,
                    Id = association.Id,
                    Name = association.Name,
                    Telephone = association.Telephone
                }));
            }

            return response;
        }

        public AssociationViewModel GetAssociation(int id)
        {
            var assoc = associationRepository.GetAssociation(id);
            if (assoc == null)
            {
                return null;
            }

            var subscriptions = this.subscriptionLogic.GetSubscriptions(id);

            return new AssociationViewModel
                {
                    Address = assoc.Address,
                    Id = assoc.Id,
                    Name = assoc.Name,
                    IsActive = subscriptions.Any(x => x.IsActive),
                    PaymentType = assoc.PaymentType
                };
        }

        public BaseResponse SaveAssociation(AssociationViewModel viewModel)
        {
            var rowCount = associationRepository.SaveAssociation(new Association
            {
                Address = viewModel.Address,
                Country = viewModel.Country,
                Email = viewModel.Email,
                Id = viewModel.Id,
                JoinDate = viewModel.JoinDate,
                Name = viewModel.Name,
                PaymentType = viewModel.PaymentType,
                Telephone = viewModel.Telephone
            });

            return new BaseResponse
            {
                Success = rowCount == 1,
                Message = "Saved successfully"
            };
        }
    }
}
