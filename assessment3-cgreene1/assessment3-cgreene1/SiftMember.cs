using System;
using System.Collections.Generic;
using System.Text;

namespace assessment3_cgreene1
{
    public class SiftMember
    {
        //Properties
        public string Name { get; set; }
        public DateTime AnniversaryDate { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public List<string> Skills { get; set; }


        //Constructor
        public SiftMember(string name, DateTime anniversarydate, string jobtitle, string email)
        {
            Name = name;
            AnniversaryDate = anniversarydate;
            JobTitle = jobtitle;
            Email = email;
            Skills = new List<string>();
      
        }


        //Methods

        public bool AddSkill(string userAddedSkill)
        {
            foreach(var skill in Skills)
            {
                if (userAddedSkill == skill)
                {
                    return false;
                    
                } 
          
            }

            Skills.Add(userAddedSkill);
            
            return true;           
        }

        public override string ToString()
        {

            string output = $"Name: {Name}\nJob Title: {JobTitle}\nAnniversary: {AnniversaryDate}\nEmail: {Email}\nSkills: {string.Join(",",Skills)}";

            return output;
        }

    }
}
