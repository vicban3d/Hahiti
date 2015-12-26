using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace REST_API
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class HahitiService : ServiceContract
    {
        Dictionary<String, User> users = new Dictionary<String, User>();
        public String AddUser(string id)
        {
            User newUser = new User(id, "Moshe", "moshe", "Moshe");
            users.Add(id, newUser);
            return "{" + string.Join(",", users.Select(kv => kv.Key.ToString() + "=" + kv.Value.ToString()).ToArray()) + "}"; 
        }

        public string GetUser(string id)
        {
            User user = users[id];
            return new JavaScriptSerializer().Serialize(user);
        }

        public string RemoveUser(string id)
        {
            users.Remove(id);
            return "{" + string.Join(",", users.Select(kv => kv.Key.ToString() + "=" + kv.Value.ToString()).ToArray()) + "}"; 
        }
    }
}