using Mixer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TelaLoginMixer.Models;

namespace TelaLoginMixer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> AutenticaMixer()
        {
            string clientID = "99990b9fd538c315a4487dfb15bccfe37eacc2a94313c10b";
            return Redirect(await MixerConnection.GetAuthorizationCodeURLForOAuthBrowser(clientID, UserScopes, "https://www.paganini.live/dayone/Home/Sucesso", false));
        }

        public async Task<ActionResult> Sucesso(string code, string state)
        {
            string clientID = "99990b9fd538c315a4487dfb15bccfe37eacc2a94313c10b";
            var channel = await MixerConnection.ConnectViaAuthorizationCode(clientID, "29619213f3b2b4acc5c8d93c7844f77b0636b2a7fa936247bb78570c9e4d4fa6", code, "https://www.paganini.live/dayone/Home/Sucesso");
            Session["channel"] = channel;
            Session["user"] = await channel.Users.GetCurrentUser();
            return RedirectToAction("Autenticado", "Home");
           
        }

        public ActionResult Autenticado()
        {
            MixerData data = new MixerData();
            data.Connection = (MixerConnection)Session["channel"];
            data.User = (Mixer.Base.Model.User.PrivatePopulatedUserModel)Session["user"];
            return View(data);
        }

        public String Magica()
        {
            return Session["code"].ToString();
        }

        public static readonly List<OAuthClientScopeEnum> UserScopes = new List<OAuthClientScopeEnum>()
        {
            //OAuthClientScopeEnum.user__details__self,
            OAuthClientScopeEnum.chat__chat,
            OAuthClientScopeEnum.chat__connect,
            OAuthClientScopeEnum.user__act_as,
        };


    }
}