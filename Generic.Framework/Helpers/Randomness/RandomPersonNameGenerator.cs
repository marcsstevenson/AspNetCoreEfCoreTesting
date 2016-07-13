using System;
using System.Collections.Generic;

namespace Generic.Framework.Helpers.Randomness
{
    public class RandomPersonNameGenerator
    {
        Random _random = new Random();

        #region FirstFemaleNames
        private List<string> _firstFemaleNames;
        private List<string> FirstFemaleNames
        {
            get
            {
                if (_firstFemaleNames == null)
                    _firstFemaleNames = this.GetFirstFemaleNames();

                return _firstFemaleNames;
            }
        }

        private List<string> GetFirstFemaleNames()
        {
            return new List<string>
                {
                    "Hermione", 
                    "Imogene", 
                    "Iola", 
                    "Josephine", 
                    "Adara", 
                    "Imogene", 
                    "Germane", 
                    "Veronica", 
                    "Kessie", 
                    "Jasmine", 
                    "Moana", 
                    "Emerald", 
                    "Delilah", 
                    "Skyler", 
                    "Kim", 
                    "Maxine", 
                    "Iona", 
                    "Nevada", 
                    "Rhiannon", 
                    "Kessie", 
                    "Adena", 
                    "Claire", 
                    "Martena", 
                    "Kameko", 
                    "Eve", 
                    "Leigh", 
                    "Susan", 
                    "Alice", 
                    "Mallory", 
                    "Keiko", 
                    "Kiayada", 
                    "Adele", 
                    "Cassandra", 
                    "Orla", 
                    "Shelley", 
                    "Penelope", 
                    "Cailin", 
                    "Chelsea", 
                    "Ariel", 
                    "Tara", 
                    "Lilah", 
                    "Frances", 
                    "Felicia", 
                    "Lillian", 
                    "Cynthia", 
                    "Althea", 
                    "Courtney", 
                    "Megan", 
                    "Paula", 
                    "Gisela", 
                    "Maggy", 
                    "Jessica", 
                    "Abra", 
                    "Kelly", 
                    "Flavia", 
                    "Jada", 
                    "Sloane", 
                    "Gloria", 
                    "Amela", 
                    "Aphrodite", 
                    "Yoshi", 
                    "Yvette", 
                    "Cally", 
                    "Leilani", 
                    "Jacqueline", 
                    "Judith", 
                    "Willa", 
                    "Hanna", 
                    "Lara", 
                    "Alexis", 
                    "Diana", 
                    "Octavia", 
                    "Cassady", 
                    "Ella", 
                    "Vivien", 
                    "Jordan", 
                    "Jana", 
                    "Breanna", 
                    "Aspen", 
                    "Jenna", 
                    "Leigh", 
                    "Montana", 
                    "Sarah", 
                    "Judith", 
                    "Sloane", 
                    "Courtney", 
                    "Vera", 
                    "Dara", 
                    "Xandra", 
                    "Fiona", 
                    "Savannah", 
                    "Sasha", 
                    "Claire", 
                    "Sandra", 
                    "Maite", 
                    "Haley", 
                    "Chanda", 
                    "Nayda", 
                    "Allegra", 
                    "Hillary", 
                    "Gaylord"
                };
        }

        public string GetFirstFemaleName(bool preventDuplication = false)
        {
            var firstFemaleName = this.FirstFemaleNames.GetRandomItem(this._random);

            if (preventDuplication)
                this.FirstFemaleNames.Remove(firstFemaleName); //Remove the used item

            return firstFemaleName;
        }
        #endregion

        #region FirstMaleNames
        private List<string> _firstMaleNames;
        private List<string> FirstMaleNames
        {
            get
            {
                if (_firstMaleNames == null)
                    _firstMaleNames = this.GetFirstMaleNames();

                return _firstMaleNames;
            }
        }

        private List<string> GetFirstMaleNames()
        {
            return new List<string>
                {
                    "Dane", 
                    "Quamar", 
                    "Reuben", 
                    "Perry", 
                    "Nash", 
                    "Seth", 
                    "Graiden", 
                    "Octavius", 
                    "Cadman", 
                    "Cade", 
                    "Hamilton", 
                    "Wylie", 
                    "Austin", 
                    "Quentin", 
                    "Galvin", 
                    "Lester", 
                    "Sylvester", 
                    "Alan", 
                    "Reece", 
                    "Cadman", 
                    "Raja", 
                    "Thor", 
                    "Elmo", 
                    "Brent", 
                    "Brody", 
                    "Trevor", 
                    "Walker", 
                    "Roth", 
                    "Branden", 
                    "Tate", 
                    "Brennan", 
                    "Brian", 
                    "Tucker", 
                    "Murphy", 
                    "Walker", 
                    "Conan", 
                    "Simon", 
                    "Vaughan", 
                    "Peter", 
                    "Mannix", 
                    "Ezra", 
                    "Honorato", 
                    "Hilel", 
                    "Elmo", 
                    "Timothy", 
                    "Austin", 
                    "Nolan", 
                    "Allistair", 
                    "Fulton", 
                    "Fuller", 
                    "Kevin", 
                    "Armando", 
                    "Omar", 
                    "Lewis", 
                    "Asher", 
                    "Grady", 
                    "Steven", 
                    "Nigel", 
                    "Caesar", 
                    "Timon", 
                    "Damon", 
                    "Beck", 
                    "Chancellor", 
                    "Levi", 
                    "Stuart", 
                    "Tanner", 
                    "Lamar", 
                    "Troy", 
                    "Walter", 
                    "Sawyer", 
                    "Samson", 
                    "Hayden", 
                    "Blaze", 
                    "Allen", 
                    "Christian", 
                    "Emerson", 
                    "Tyrone", 
                    "Hayden", 
                    "Kato", 
                    "Mason", 
                    "Asher", 
                    "Todd", 
                    "Jason", 
                    "Ahmed", 
                    "Fuller", 
                    "Ishmael", 
                    "Blaze", 
                    "Ulric", 
                    "Basil", 
                    "Jack", 
                    "Timon", 
                    "Palmer", 
                    "Damian", 
                    "Vance", 
                    "David", 
                    "Daquan", 
                    "Carl", 
                    "Adam", 
                    "Zeph", 
                    "Byron"
                };
        }

        public string GetFirstMaleName(bool preventDuplication = false)
        {
            var firstMaleName = this.FirstMaleNames.GetRandomItem(this._random);

            if (preventDuplication)
                this.FirstMaleNames.Remove(firstMaleName); //Remove the used item

            return firstMaleName;
        }
        #endregion

        #region LastNames
        private List<string> _lastNames;
        private List<string> LastNames
        {
            get
            {
                if (_lastNames == null)
                    _lastNames = this.GetLastNames();

                return _lastNames;
            }
        }

        private List<string> GetLastNames()
        {
            return new List<string>
            {
                "Woods", 
"Nicholson", 
"Warner", 
"Thomas", 
"Mosley", 
"Sanders", 
"Bright", 
"Burch", 
"Sosa", 
"Hubbard", 
"Richardson", 
"Herman", 
"Mann", 
"Dalton", 
"Guthrie", 
"Bird", 
"Moore", 
"Luna", 
"Perez", 
"Fields", 
"Garrison", 
"Dunlap", 
"Whitley", 
"Ford", 
"Rojas", 
"Massey", 
"Bernard", 
"Padilla", 
"Mclaughlin", 
"Sandoval", 
"Rosales", 
"Mcfadden", 
"Jordan", 
"Powers", 
"Keller", 
"Caldwell", 
"Lynn", 
"Mcfarland", 
"Dotson", 
"Hensley", 
"Bartlett", 
"Andrews", 
"Schneider", 
"Mclaughlin", 
"Delgado", 
"Conner", 
"Norman", 
"Stevens", 
"Puckett", 
"Harris", 
"Castro", 
"Black", 
"Moses", 
"Burton", 
"Guzman", 
"Hood", 
"Osborn", 
"Hopkins", 
"Campbell", 
"Flynn", 
"Duke", 
"Vinson", 
"Sykes", 
"Powell", 
"Nielsen", 
"Hampton", 
"Stanton", 
"Dale", 
"Wilkinson", 
"Burgess", 
"Miranda", 
"Armstrong", 
"Calhoun", 
"Hudson", 
"Meyers", 
"Guerrero", 
"Morse", 
"Flynn", 
"Dodson", 
"Harrell", 
"Orr", 
"Hays", 
"Hutchinson", 
"Gill", 
"Leach", 
"Shelton", 
"Roberson", 
"Dalton", 
"Farrell", 
"Valentine", 
"Lane", 
"Lewis", 
"Simmons", 
"Hendricks", 
"Erickson", 
"Lamb", 
"Rogers", 
"Cannon", 
"Pope", 
"Reynolds"
            };
        }

        public string GetLastName(bool preventDuplication = false)
        {
            var lastName = this.LastNames.GetRandomItem(this._random);

            if (preventDuplication)
                this.LastNames.Remove(lastName); //Remove the used item

            return lastName;
        }

        #endregion

        public enum Gender
        {
            Female,
            Male
        }

        public string GetPersonName(Gender? FirstNameGeneder = null)
        {
            bool femaleFirstName;

            if (FirstNameGeneder == null)
                femaleFirstName = this._random.Next() % 2 == 0;
            else
                femaleFirstName = FirstNameGeneder == Gender.Female;

            var firstName = femaleFirstName
                                ? this.FirstFemaleNames.GetRandomItem(this._random)
                                : this.FirstMaleNames.GetRandomItem(this._random);

            return firstName + " " + this.LastNames.GetRandomItem(this._random);
        }
    }
}