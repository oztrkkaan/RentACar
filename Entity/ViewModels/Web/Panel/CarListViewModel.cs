using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels.Web.Panel
{
    public class CarListViewModel : IViewModel
    {
        public IList<CarDto> CarDtos { get; set; }
    }
}
