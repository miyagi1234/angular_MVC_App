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
        Dictionary<bool, Func<DBEntities,UserInfo,string>> handleInputErrors = new Dictionary<bool, Func<DBEntities,UserInfo,string>>()
        {
            { true, (myEntity,obj) => { myEntity.UserInfoes.Add(obj);
                                        myEntity.SaveChanges();
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
            } } },
            { false, (myEntity,obj) => { return "Please make sure all fields are filled in, did you leave something out ...\r\nor did you put words,dates, preferences in the wrong place ..."; } }
        };

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
            bool is_there_data = false;
            DateTime validDate;

            if (!string.IsNullOrEmpty(obj.Name) || 
                !string.IsNullOrEmpty(obj.Surname) || 
                (obj.BirthDate != null && !DateTime.TryParse(obj.BirthDate.ToString(), out validDate)) || 
                obj.CoffyPreference != null || obj.ColorPreference != null)
            {
                is_there_data = true;
            }

            return handleInputErrors[is_there_data].Invoke(myEntity,obj);
           
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
