namespace SetAndDictionaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetAndDict
    {
        public static void Main()
        {


        }

        public static void LegendaryFarmingNotMine()
        {
            Dictionary<string, int> junkItems = new Dictionary<string, int>();
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials["fragments"] = 0;
            keyMaterials["motes"] = 0;
            keyMaterials["shards"] = 0;
            bool itemObtained = false;

            while (!itemObtained)
            {
                string[] data = Console.ReadLine()
                    .ToLower()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < data.Length; i += 2)
                {
                    int quantity = int.Parse(data[i]);
                    string material = data[i + 1];

                    if (!keyMaterials.ContainsKey(material)) // junk items
                    {
                        if (!junkItems.ContainsKey(material))
                            junkItems[material] = 0;
                        junkItems[material] += quantity;
                    }
                    else // key materials
                    {
                        keyMaterials[material] += quantity;
                        if (keyMaterials[material] >= 250)
                        {
                            switch (material)
                            {
                                case "fragments":
                                    Console.WriteLine("Valanyr obtained!");
                                    break;
                                case "shards":
                                    Console.WriteLine("Shadowmourne obtained!");
                                    break;
                                case "motes":
                                    Console.WriteLine("Dragonwrath obtained!");
                                    break;
                            }
                            keyMaterials[material] -= 250;
                            itemObtained = true;

                            // print remaining key materials
                            var keyMaterialsDescOrder = keyMaterials
                                .OrderBy(x => x.Key)
                                .OrderByDescending(x => x.Value);
                            foreach (var item in keyMaterialsDescOrder)
                                Console.WriteLine("{0}: {1}", item.Key, item.Value);

                            // print remaining junk items
                            var junkDescOrder = junkItems
                                .OrderBy(x => x.Key);
                            foreach (var item in junkDescOrder)
                                Console.WriteLine("{0}: {1}", item.Key, item.Value);
                            break;
                        }
                    }
                }
            }
        }

        public static void LogsAgregators()
        {
            int lines = int.Parse(Console.ReadLine());

            var usersInfo = new SortedDictionary<string, SortedDictionary<string, int>>();
            for (int i = 0; i < lines; i++)
            {

                string[] input = Console.ReadLine().Split().ToArray();
                string ip = input[0];
                string user = input[1];
                int duration = int.Parse(input[2]);

                var ipsDurations = new SortedDictionary<string, int>();

                if (usersInfo.ContainsKey(user))
                {
                    ipsDurations = usersInfo[user];
                }

                if (!ipsDurations.ContainsKey(ip))
                {
                    ipsDurations.Add(ip, duration);
                }
                else
                {
                    ipsDurations[ip] += duration;
                }

                usersInfo[user] = ipsDurations;

            }
            //"{user}: {duration} [{IP1}, {IP2}, …]". 

            foreach (var userInfo in usersInfo)
            {
                Console.Write($"{userInfo.Key}: {userInfo.Value.Values.Sum()} ");
                Console.Write('[');
                foreach (var ip in userInfo.Value)
                {
                    Console.Write($"{ip.Key}");
                    if (!ip.Equals(userInfo.Value.Last()))
                    {
                        Console.Write(", ");
                    }

                }
                Console.WriteLine(']');
            }

        }

        public static void PopulationCounter()
        {
            string input = Console.ReadLine();
            var populationInfo = new Dictionary<string, Dictionary<string, long>>();

            while (!input.Equals("report"))
            {
                var currentInfo = input.Split('|').ToArray();
                var city = currentInfo[0];
                var country = currentInfo[1];
                var population = long.Parse(currentInfo[2]);
                var citiesInfo = new Dictionary<string, long>();

                if (populationInfo.ContainsKey(country))
                {
                    citiesInfo = populationInfo[country];
                }

                if (!citiesInfo.ContainsKey(city))
                {
                    citiesInfo.Add(city, population);
                }
                else
                {
                    citiesInfo[city] += population;
                }

                populationInfo[country] = citiesInfo;

                input = Console.ReadLine();
            }

            // population in desc.order, by country & city
            foreach (var countryStats in populationInfo.OrderBy(x => -x.Value.Values.Sum()))
            {
                Console.WriteLine("{0} (total population: {1})",
                    countryStats.Key,
                    countryStats.Value.Values.Sum());

                foreach (var cityStats in countryStats.Value.OrderBy(x => -x.Value))
                    Console.WriteLine("=>{0}: {1}",
                        cityStats.Key, cityStats.Value);
            }
        }

        public static void UserLogs()
        {
            string input = Console.ReadLine();
            var usersInfo = new SortedDictionary<string, Dictionary<string, int>>();

            while (!input.Equals("end"))
            {
                //IP=192.23.30.40 message='Hello&derps.' user=destroyer
                var userIPs = new Dictionary<string, int>();
                var currentInfo = input.Split().ToArray();
                var ip = currentInfo[0].Split('=').ToArray()[1];
                var user = currentInfo[2].Split('=').ToArray()[1];
                if (usersInfo.ContainsKey(user))
                {
                    userIPs = usersInfo[user];
                }

                if (!userIPs.ContainsKey(ip))
                {
                    userIPs.Add(ip, 1);
                }
                else
                {
                    userIPs[ip] += 1;
                }

                usersInfo[user] = userIPs;
                input = Console.ReadLine();
            }

            //print

            foreach (var user in usersInfo)
            {
                Console.WriteLine($"{user.Key}: ");

                foreach (var ip in user.Value)
                {
                    Console.Write($"{ip.Key} => {ip.Value}");
                    if (ip.Equals(user.Value.Last()))
                    {
                        Console.WriteLine(".");
                    }
                    else
                    {
                        Console.Write(", ");
                    }

                }
            }
        }

        public static void HandOfCards()
        {
            Dictionary<string, HashSet<string>> playersInfo = new Dictionary<string, HashSet<string>>();

            string input = Console.ReadLine();
            string name = string.Empty;
            List<string> cards = new List<string>();


            while (!input.Equals("JOKER"))
            {
                HashSet<string> uniqueCards = new HashSet<string>();
                string[] playerInfo = input.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                name = playerInfo[0];
                cards = playerInfo[1].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (playersInfo.ContainsKey(name))
                {
                    uniqueCards = playersInfo[name];
                }
                foreach (var card in cards)
                {
                    uniqueCards.Add(card);
                }

                playersInfo[name] = uniqueCards;
                input = Console.ReadLine();
            }


            foreach (var player in playersInfo)
            {
                GetCardsValue(player);
            }
        }

        private static void GetCardsValue(KeyValuePair<string, HashSet<string>> player)
        {
            long cardsValue = 0;

            Dictionary<string, int> cardPowers = new Dictionary<string, int>();
            for (int i = 2; i <= 10; i++)
                cardPowers[i.ToString()] = i;
            cardPowers["J"] = 11;
            cardPowers["Q"] = 12;
            cardPowers["K"] = 13;
            cardPowers["A"] = 14;

            Dictionary<char, int> cardTypes = new Dictionary<char, int>();
            cardTypes['S'] = 4;
            cardTypes['H'] = 3;
            cardTypes['D'] = 2;
            cardTypes['C'] = 1;


            foreach (var card in player.Value)
            {
                string power = card.Substring(0, card.Length - 1);
                char type = card[card.Length - 1];

                cardsValue += cardPowers[power] * cardTypes[type];
            }

            Console.WriteLine($"{player.Key}: {cardsValue}");
        }

        public static void FixEmails()
        {
            Dictionary<string, string> emailsInfo = new Dictionary<string, string>();
            string input = Console.ReadLine();
            long count = 1;
            string name = String.Empty;
            string email;
            while (!input.Equals("stop"))
            {
                if (count % 2 == 1)
                {
                    name = input;
                }
                else
                {
                    email = input;
                    if (!(email.EndsWith("us")) && !(email.EndsWith("uk")))
                    {
                        emailsInfo[name] = email;
                    }
                }
                count++;
                input = Console.ReadLine();
            }

            foreach (var info in emailsInfo)
            {
                Console.WriteLine($"{info.Key} -> {info.Value}");
            }

        }

        public static void MinerTask()
        {
            string input = Console.ReadLine();
            Dictionary<string, long> mineInfo = new Dictionary<string, long>();

            int count = 1;
            string resource = String.Empty;
            long quantity;
            while (!input.Equals("stop"))
            {
                if (count % 2 == 1)
                {
                    resource = input;
                }
                else
                {
                    quantity = long.Parse(input);
                    if (!mineInfo.ContainsKey(resource))
                    {
                        mineInfo.Add(resource, quantity);
                    }
                    else
                    {
                        mineInfo[resource] += quantity;
                    }
                }
                count++;
                input = Console.ReadLine();
            }

            foreach (var mine in mineInfo)
            {
                Console.WriteLine($"{mine.Key} -> {mine.Value}");
            }
        }

        public static void PhoneBook()
        {
            string input = Console.ReadLine();
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            //create dict phonebook

            while ((input = Console.ReadLine()) != "search")
            {
                string[] data = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                string phonenumber = data[1];
                phonebook[name] = phonenumber;
            }

            //search in dict phonebook
            input = Console.ReadLine();
            while (!input.Equals("stop"))
            {
                if (phonebook.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {phonebook[input]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }
                input = Console.ReadLine();
            }
        }

        public static void CountSymbols()
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> charsOccureInString = new SortedDictionary<char, int>();
            foreach (var ch in input)
            {
                if (!charsOccureInString.ContainsKey(ch))
                {
                    charsOccureInString.Add(ch, 1);
                }
                else
                {
                    charsOccureInString[ch] += 1;
                }
            }

            foreach (var charOccure in charsOccureInString)
            {
                Console.WriteLine($"{charOccure.Key}: {charOccure.Value} time/s");
            }

        }

        public static void PeriodicTableHAshSet()
        {
            //гърми за време !!!0.318
            long lines = long.Parse(Console.ReadLine());
            var periodicTable = new HashSet<string>();
            for (long i = 0; i < lines; i++)
            {
                string[] elements = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                foreach (var element in elements)
                {
                    periodicTable.Add(element);
                }
            }
            Console.WriteLine(string.Join(" ", periodicTable.OrderBy(x => x)));
        }

        public static void PeriodicTableSortedSet()
        {
            //гърми за време !!!0.390
            long lines = long.Parse(Console.ReadLine());
            SortedSet<string> periodicTable = new SortedSet<string>();
            for (long i = 0; i < lines; i++)
            {
                string[] elements = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                foreach (var element in elements)
                {
                    periodicTable.Add(element);
                }
            }
            // Console.WriteLine(string.Join(" ",periodicTable));

            foreach (var item in periodicTable)
            {
                Console.Write($"{item} ");
            }
        }

        public static void RepeatingSet()
        {
            string[] lines = Console.ReadLine().Split(new[] { ' ' }).ToArray();
            int linesN = int.Parse(lines[0]);
            int linesM = int.Parse(lines[1]);
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            HashSet<int> repeatingSet = new HashSet<int>();

            for (int i = 0; i < linesN; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < linesM; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            if (linesM > linesN)
            {
                CreateRepeatingSet(secondSet, firstSet, repeatingSet);
            }
            else
            {
                CreateRepeatingSet(firstSet, secondSet, repeatingSet);
            }

            Console.WriteLine(string.Join(" ", repeatingSet));
        }

        private static void CreateRepeatingSet(HashSet<int> firstSet, HashSet<int> secondSet, HashSet<int> repeatingSet)
        {
            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    repeatingSet.Add(number);
                }
            }
        }

        public static void UniqueUsernames()
        {
            int lines = int.Parse(Console.ReadLine());
            HashSet<string> usersnames = new HashSet<string>();
            for (int i = 0; i < lines; i++)
            {
                usersnames.Add(Console.ReadLine());
            }

            foreach (var usersname in usersnames)
            {
                Console.WriteLine(usersname);
            }
        }

    }
}
