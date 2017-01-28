using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Population_Simulation
{
    using System;

    class GameManager
    {
        static Dictionary<string, Population> cityList = new Dictionary<string, Population>();

        public static void Main()
        {
            GameManager Manager = new GameManager();
            Manager.getInput();
        }

        public void getInput()
        {
            Console.Clear();
            Console.WriteLine("Please type in your command");
            GameManager Manager = new GameManager();
            string command = Console.ReadLine();
            Console.Clear();
            if (command == "createCity")
            {
                Manager.createCity();
            }
            if (command == "viewCities")
            {
                Manager.viewCities();
            }
        }

        public void createCity()
        {
            char[] delimiterCharacters = { ',' };
            Console.WriteLine("Please write the name of the city, the population size, the POPs' education, affluence and health, all separated by commas. ");
            string instructions = Console.ReadLine();
            string[] instructionList = instructions.Split(delimiterCharacters);
            int cityPOPsize = Int32.Parse(instructionList[1]);
            int cityEducation = Int32.Parse(instructionList[2]);
            int cityAffluence = Int32.Parse(instructionList[3]);
            int cityHealth = Int32.Parse(instructionList[4]);
            if (cityEducation > 100)
            {
                cityEducation = 100;
            }
            if (cityAffluence > 100)
            {
                cityAffluence = 100;
            }
            if (cityHealth > 100)
            {
                cityHealth = 100;
            }

            cityList.Add(instructionList[0], new Population(cityPOPsize, cityEducation, cityAffluence, cityHealth));
            GameManager Manager = new GameManager();
            Manager.getInput();
        }

        public void viewCities()
        {
            Console.Clear();
            if (cityList.Count == 0)
            {
                Console.Write("There are no cities!");
                Console.Read();
            }
            else
            {
                foreach (var item in GameManager.cityList)
                {
                    Console.WriteLine(item.Key + "(" + item.Value.POPsize + " people)");
                    Console.WriteLine(item.Value.Education + " Education, " + item.Value.Affluence + " Affluence, " + item.Value.Health + " Health, " + item.Value.Prosperity + " Prosperity");
                    Console.WriteLine("\n");
                }
                Console.Read();
            }
            GameManager Manager = new GameManager();
            Manager.getInput();
        }
    }

    class Population
    {
        static int numberOfPOPs = 0;
        public int Education;
        public int Affluence;
        public int Health;
        public int Prosperity;
        int foodNeeded;
        public int POPsize;

        int intellectuals;
        int fincancers;
        int ableMen;

        public Population(int sizeofPOP, int education, int affluence, int health)
        {
            Education = education;
            Affluence = affluence;
            Health = health;
            POPsize = sizeofPOP;
            Prosperity = Population.calculateProsperity(Education, Affluence, Health);
            foodNeeded = Population.calculateFoodNeeded(Affluence, POPsize);
            numberOfPOPs++;
        }

        public static int calculateProsperity(int education, int affluence, int health)
        {
            return (education + affluence + health) / 3;
        }

        public static int calculateFoodNeeded(int affluence, int POPsize)
        {
            return ((affluence / 5) + 3) * POPsize;
        }
    }
}
