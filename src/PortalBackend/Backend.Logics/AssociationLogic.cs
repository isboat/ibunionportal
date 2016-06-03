using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Interfaces;
using Backend.ViewModels;
using Backend.ViewModels.Demo;
using Portal.DataAccess.Interfaces;

namespace Backend.Logics
{
    public class AssociationLogic : IAssociationLogic
    {
        private readonly IAssociationRepository associationRepository;

        public AssociationLogic(IAssociationRepository associationRepository)
        {
            this.associationRepository = associationRepository;
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
            return assoc == null
                ? new AssociationViewModel { Name = "Association Name", Address = "Association Address", Telephone = "123456789" }
                : new AssociationViewModel
                {
                    Address = assoc.Address,
                    Id = assoc.Id,
                    Name = assoc.Name
                };
        }
    }
}
