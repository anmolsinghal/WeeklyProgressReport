using Newtonsoft.Json;
using PartnerView.Entities;
using PartnerView.Repository.Interface;
using PartnerView.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Security;

namespace PartnerView.WebAPI.Controllers
{
    public class BaseController : ApiController
    {
        protected IClientMatterRepository cmRepository;
        public BaseController(IClientMatterRepository repository)
        {
            cmRepository = repository;
        }
        protected IQueryable<CoreMatter> GetMatters(string userName)
        {
            var roles = GetRoles(userName);
            var isAdmin = false;
            foreach (var role in roles)
            {
                if (role.Name.ToLower() == "discouser" && role.ApplicationName.ToLower() == "global") { isAdmin = true; break; }
            }


            MembershipUser user = Membership.GetUser(userName);
            if (user == null) throw new UnauthorizedAccessException(string.Format("User {0} has no access to the PartnerView application.", userName));
            Guid guidUserId = new Guid(Convert.ToString(user.ProviderUserKey));

            if (isAdmin)
            {
                return cmRepository.GetMatters().GroupJoin(
                        cmRepository.GetEthicalWalls(),
                        m => m.Id,
                        e => e.MatterId,
                        (x, y) => new { Matters = x, EthicalWalls = y })
                    .SelectMany(
                        x => x.EthicalWalls.DefaultIfEmpty(),
                        (x, y) => new { Matters = x.Matters, EthicalWalls = y })
                    .Where(j => j.EthicalWalls.UserName != userName)
                    .Select(j => j.Matters);

            }
            else
            {
                var userMatters = cmRepository.GetUserMatters().Where(u => u.UserName == userName).Select(m => m.Matter);
                return userMatters.GroupJoin(
                        cmRepository.GetEthicalWalls(),
                        m => m.Id,
                        e => e.MatterId,
                        (x, y) => new { Matters = x, EthicalWalls = y })
                    .SelectMany(
                        x => x.EthicalWalls.DefaultIfEmpty(),
                        (x, y) => new { Matters = x.Matters, EthicalWalls = y })
                    .Where(j => j.EthicalWalls.UserName != userName)
                    .Select(j => j.Matters);
            }

        }

        private IEnumerable<Role> GetRoles(string userName)
        {
            var token = Request.Headers.Authorization;
            if (token != null)
            {
                using (var client = new HttpClient())
                {
                    string URI = ConfigurationManager.AppSettings["AuthenticationAPI"];
                    client.BaseAddress = new Uri(URI);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = token;

                    // HTTP GET
                    var response = client.GetAsync("api/roles/getroles?userName=" + userName).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().Result.ToString();
                        return JsonConvert.DeserializeObject<List<Role>>(json);
                    }
                }
            }
            return new List<Role>();
        }
    }
}
