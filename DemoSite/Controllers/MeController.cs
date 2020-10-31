using DemoSite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RestConsumer;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DemoSite.Controllers
{
    [Authorize]
    public class MeController : ApiController
    {
        private ApplicationUserManager _userManager;

        public MeController()
        {
        }

        public MeController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET api/Me
        public GetViewModel Get()
        {            
            var user = UserManager.FindById(User.Identity.GetUserId());
            Testar();
            return new GetViewModel() { Hometown = user.Hometown };
        }

        private async Task Testar()
        {
            try
            {
                var consumidor = new ApiConsumer<FiltroDeck, Deck>();
                var resposta = await consumidor.ConsumirApiAsync("deck/new/shuffle/", new FiltroDeck { deck_count = 1 });
                var deckId = resposta.deck_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }
    }
}