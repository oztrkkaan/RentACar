using Entity.Dtos;
using System.Collections.Generic;

namespace Entity.ViewModels.Web.Panel
{
    public class CarListViewModel : IViewModel
    {
        public IList<CarDto> CarDtos { get; set; }
    }
}
