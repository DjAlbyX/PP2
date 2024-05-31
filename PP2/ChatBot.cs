using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace PP2
{
    internal class ChatBot
    {
        bool remember = false;
        string name;
        bool condition = true;
        private Random random = new();
        public void menu()
        {
            while (condition)
            {
                Console.WriteLine("Welcome to ChatBot!\n");
                Console.WriteLine("Menu:\n1.Talk with Kompis\n2.Leave ChatBot");
                var goTo = Console.ReadLine();
                switch (goTo)
                {
                    case "1":
                        if (remember == true)
                        {
                            Kompis();
                        }
                        else
                        {
                            Console.WriteLine("What's your name?");
                            nameCheck();
                            Kompis();
                        }
                        break;

                    case "2":
                        Leave();
                        break;

                    default:
                        Console.Clear();
                        menu();
                        break;
                }
            }
        }
        public void Kompis()
        {
            Console.Clear();
            Console.WriteLine($"Hello {name}, this is Kompis. How can i help you today?");
            options();

        }

        public void Leave()
        {
            Console.Clear();
            Console.WriteLine("Have a day!");
            condition = false;
        }

        private void nameCheck()
        {
            name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please type in your name.");
                nameCheck();
            }
        }

        private void options()
        {
            Console.WriteLine("\n1. Ask a question\n2. Tell a joke\n3. Give a fun fact\n4. Generate Haiku\n5. Exit to main menu");
            var choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {

                case 1:
                    Console.WriteLine("What's your question? Write <go back> if you want to exit.");
                    chatting();
                    break;

                case 2:
                    TellAJoke();
                    options();
                    break;

                case 3:
                    GiveFunFact();
                    options();
                    break;


                case 4:
                    GenerateHaiku();
                    options();
                    break;


                case 5:
                    remember = true;
                    Console.Clear();
                    menu();
                    break;
            }
        }
        private void TellAJoke()
        {
            List<string> jokes = new List<string>
            {
                "The chicken asked the goat.\nHow was they party yesterday?\nThe goat replied:\nMæææd fun.",
                "I just broke up with my ex and stole her wheelchair, guess who was the one crawling back to me.",
                "Funny joke haha",
            };
            int index = random.Next(jokes.Count);
            Console.WriteLine(jokes[index]);
        }
        public void GiveFunFact()
        {
          List<string> funFact = new List<string>
          {
           "Did you know that all the clocks in Pulp Fiction are set to 4:20 ",
           "Did you know that Japan has over 200 flavours of Kit Kats ",
           "Dreamt is the only english word that ends in the letters mt ",
          
          };
           int index = random.Next(funFact.Count); 
           Console.WriteLine(funFact[index]);
        
        }
           
            
        public void chatting() 
        {
            var now = DateTime.Now.TimeOfDay;
            DateTime today = DateTime.Today;
            var question = Convert.ToString(Console.ReadLine());
            
            List<string> answer = new List<string>
            {
                $"This is the time and date right now: {today}, {now}",
            };

            if (question.Contains("time") || question.Contains("date"))
            {
                Console.WriteLine(answer[0]);
                chatting();
            }
            else if (question == "go back")
            {
                Console.Clear();
                options();
            }
            else 
            {
                Console.WriteLine("Too dumb to understand, try something else:)");
                chatting();
            }
        }


        public void GenerateHaiku()
        {
            List<string> line1 = new List<string>
            {
                "An old silent pond ",
                "Autum moonlight ",
                "In the calm drizzel "

            };

            List<string> line2 = new List<string>
            {
                "A frog jumps into the pond- ",
                "A wormd digs silently ",
                "Theese brilliant-hued hibiscus "

            };

            List<string> line3 = new List<string>
            {
                "Splash! silence again. ",
                "Into the chestnut. ",
                "A lovely sunset. "
            };

            string haiku = $"{line1[random.Next(line1.Count)]}\n{line2[random.Next(line2.Count)]}\n{line3[random.Next(line3.Count)]}\n";
            Console.WriteLine("\nHere's a haiku for you: ");
            Console.WriteLine(haiku);

        }

    }

}

