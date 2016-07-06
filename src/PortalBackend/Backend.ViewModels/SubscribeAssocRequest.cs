using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ViewModels
{
    public class SubscribeAssocRequest
    {
        public string Start { get; set; }

        public string End { get; set; }

        public int AssocId { get; set; }
    }
}
