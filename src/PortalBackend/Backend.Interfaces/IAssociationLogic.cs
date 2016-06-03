using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.ViewModels;

namespace Backend.Interfaces
{
    public interface IAssociationLogic
    {
        List<AssociationViewModel> GetAllAssociations();

        AssociationViewModel GetAssociation(int id);
    }
}
