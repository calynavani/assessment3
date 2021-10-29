using System;
using System.Collections.Generic;

namespace assessment3_cgreene1
{
    class Program
    {
        static void Main(string[] args)
        {
            //intialize a list of SiftMemebrs and populate with atleast one member and a skill

            bool goOn = true;
            bool goOn2 = true;


            List<SiftMember> allSiftMembers = new List<SiftMember>();

            SiftMember member1 = new SiftMember("Calyn Greene", new DateTime(2021, 01, 23), "Associate Software Engineer in Training",
           "calyngreene@Rocketmortgage.com");
            SiftMember member2 = new SiftMember("Stone Capone", new DateTime(2016, 07, 07), "Associate Software Cat in Training",
          "stonecapone@Rocketmortgage.com");
            SiftMember member3 = new SiftMember("Avani Mami", new DateTime(2000, 06, 06), "HBIC",
          "avanimami@Rocketmortgage.com");

            member1.Skills.Add("cooking");
            member1.Skills.Add("communication");
            member2.Skills.Add("hunting");
            member2.Skills.Add("cleaning");
            member3.Skills.Add("Persuading");
            member3.Skills.Add("leading");

            allSiftMembers.Add(member1);
            allSiftMembers.Add(member2);
            allSiftMembers.Add(member3);








            while (goOn2)
            {


               
                //Give user options
                do
                {
                    Console.WriteLine("Welcome to simplfied version of Sift, what would you like to do?");
                    Console.WriteLine();
                    string[] menu = new string[4];
                    menu[0] = "Add a team member";
                    menu[1] = "Search for a team member and add skills";
                    menu[2] = "Print all team memebers";
                    menu[3] = "Exit";


                    for (int i = 0; i < menu.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}: {menu[i]}");
                    }
                    Console.WriteLine();
                    Console.Write("Select an option: ");

                    int userInput01 = int.Parse(Console.ReadLine());
                    while (userInput01 <= 0 || userInput01 > 4)
                    {
                        Console.WriteLine("That input was invalid");
                        Console.WriteLine("Lets try that again");
                        Console.Write("Selcet an option: ");
                        userInput01 = int.Parse(Console.ReadLine());
                    }


                    switch (userInput01)
                    {
                        case 1:

                            //add a team member

                            Console.Write("Enter the team member's name: ");
                            string addMemeberName = Console.ReadLine();
                            Console.Write("Enter their job title: ");
                            string addMemberJobTitle = Console.ReadLine();
                            Console.Write("Ente their email: ");
                            string addMemberEmail = Console.ReadLine();
                            Console.Write("Enter their anniversary (YYYY,MM,DD): ");
                            DateTime addMemberAnni = DateTime.Parse(Console.ReadLine());

                            SiftMember addMember = new SiftMember(addMemeberName, addMemberAnni, addMemberJobTitle, addMemberEmail);
                            allSiftMembers.Add(addMember);
                            Console.WriteLine($"User {addMemeberName} has been added :)");

                            Console.WriteLine();

                            break;
                        case 2:
                            Console.Write("Enter the full name of the team member you'd like to find: ");
                            string findTeamMember = Console.ReadLine();
                            //search for memeber then add skills

                            SiftMember returnMember = Search(allSiftMembers, findTeamMember);

                            if (returnMember != null)
                            {
                                while (true)
                                {
                                    Console.WriteLine($"What skill would you like to add to {findTeamMember}? Please enter [q] when adding of skillsis complete.");
                                    string skill = Console.ReadLine();

                                    if (skill == "q")
                                    {
                                        break;
                                    }
                                    bool isSuccessfull = returnMember.AddSkill(skill);

                                    if (isSuccessfull)
                                    {
                                        Console.WriteLine("Skill was added");
                                    }
                                    else
                                    {
                                        Console.WriteLine("That skill is already listed");
                                    }

                                }
                            }
                            else
                            {
                                Console.WriteLine($"{findTeamMember} was not found.");
                            }

                            break;

                        case 3:
                            //print all member list

                            foreach (var sm in allSiftMembers)
                            {
                                Console.WriteLine(sm);
                                Console.WriteLine();
                            }

                            break;
                        case 4:
                            //exit program
                            goOn = false;
                            break;

                    }

                    Console.WriteLine("Would you like to continue? Enter [yes] or [no]");
                    string answer = Console.ReadLine().ToLower();
                    switch (answer)
                    {
                        case "yes":
                            goOn2 = true;
                            break;
                        case "no":
                            goOn2 = false;
                            break;
                        default:
                            Console.WriteLine("That was an invalid answer");
                            Console.Write("Please Enter [yes] or [no]: ");
                            answer = Console.ReadLine().ToLower();
                            break;


                    }
                } while (goOn == true);
            }






        }
        
        public static SiftMember Search(List<SiftMember> listOfSiftMembers, string nameToSearch)
        {
            foreach(var member in listOfSiftMembers)
            {
                if(nameToSearch.ToLower() == member.Name.ToLower())
                {
                    return member;
                }
            }

            
            return null;
            
        }
    }
}
