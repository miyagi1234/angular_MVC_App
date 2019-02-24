using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AngularJsApp.Models;

namespace AngularJsApp.Controllers
{
    public class SubscriberController : ApiController
    {
        private DBEntities myEntity = new DBEntities();

        // GET: api/Subscriber
        public IEnumerable<UserInfo> Get()
        {
            return myEntity.UserInfoes.AsEnumerable();
        }

        // GET: api/Subscriber/5
        public IEnumerable<UserInfo> Get(int id)
        {
            return myEntity.UserInfoes.AsEnumerable();
        }

        // POST: api/Subscriber
        public string Post(UserInfo obj)
        {
            if (ModelState.IsValid)
            {
                myEntity.UserInfoes.Add(obj);
                myEntity.SaveChanges();
            }
            DateTime birthDate = Convert.ToDateTime(obj.BirthDate);
            var timeDiff = DateTime.Today.Year - birthDate.Year;
            if(birthDate > DateTime.Today.AddYears(-timeDiff)) timeDiff--;
            var age = timeDiff;
            if (age > 30 && (bool)obj.CoffyPreference)
            {
                //send message "You Must Be In IT"
                //call popup here with our message
                return "You are probably in IT";
            }
            else if (age < 30 && !(bool)obj.CoffyPreference)
            {
                // send message "You Must Be Out There"
                //call popup here with our message
                return "You are probably out there!";
            }
            else
            {
                // send message "You Are A Person"
                //call popup here with our message
                return "You are a person...";
            }
        }

        // PUT: api/Subscriber/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Subscriber/5
        public void Delete(int id)
        {
        }
    }
}
