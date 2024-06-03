using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.viewComponents
{
    public class Menu : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View("Perfil", "Home");
        }
        
    }
}
