using System;
using System.Collections.Generic;

namespace Generic.Framework.Helpers.Randomness
{
    public class RandomCodeGenerator
    {
        public enum CharacterTypes
        {
            AlphabeticalOnly,
            NumericOnly,
            Alphanumeric,
            AllAscii
        }

        private static List<int> _alphabeticalOnlyCodes = null;

        private static List<int> AlphabeticalOnlyCodes
        {
            get
            {
                if (_alphabeticalOnlyCodes != null) return _alphabeticalOnlyCodes;

                _alphabeticalOnlyCodes = new List<int>();

                for (var i = 65; i <= 90; i++)
                    _alphabeticalOnlyCodes.Add(i);

                for (var i = 97; i <= 122; i++)
                    _alphabeticalOnlyCodes.Add(i);

                return _alphabeticalOnlyCodes;
            }
        }

        private static List<int> _numericOnlyCodes = null;

        private static List<int> NumericOnlyCodes
        {
            get
            {
                if (_numericOnlyCodes != null) return _numericOnlyCodes;

                _numericOnlyCodes = new List<int>();

                for (var i = 48; i <= 57; i++)
                    _numericOnlyCodes.Add(i);

                return _numericOnlyCodes;
            }
        }

        private static List<int> _punctuationCodes = null;

        private static IEnumerable<int> PunctuationCodes
        {
            get
            {
                if (_punctuationCodes != null) return _punctuationCodes;

                _punctuationCodes = new List<int>();

                for (var i = 33; i <= 47; i++)
                    _punctuationCodes.Add(i);

                for (var i = 58; i <= 64; i++)
                    _punctuationCodes.Add(i);

                for (var i = 123; i <= 126; i++)
                    _punctuationCodes.Add(i);

                return _punctuationCodes;
            }
        }

        public static List<int> GetOptionsForCharacterTypes(CharacterTypes characterTypes)
        {
            switch (characterTypes)
            {
                case CharacterTypes.AlphabeticalOnly:
                    return AlphabeticalOnlyCodes;
                case CharacterTypes.NumericOnly:
                    return NumericOnlyCodes;
                case CharacterTypes.Alphanumeric:
                    var builder = new List<int>();
                    builder.AddRange(AlphabeticalOnlyCodes);
                    builder.AddRange(NumericOnlyCodes);
                    return builder;
                case CharacterTypes.AllAscii:
                    var builder2 = new List<int>();
                    builder2.AddRange(AlphabeticalOnlyCodes);
                    builder2.AddRange(NumericOnlyCodes);
                    builder2.AddRange(PunctuationCodes);
                    return builder2;
                default:
                    throw new System.NotImplementedException();
            }
        }

        public static string GenerateRandomCode(int length, CharacterTypes characterTypes)
        {
            var builder = new List<char>();

            var options = GetOptionsForCharacterTypes(characterTypes);

            var random = new Random();

            for (var i = 0; i < length; i++)
            {
                var nextIndex = random.Next(options.Count);
                var charCode = options[nextIndex];
                builder.Add((char)charCode);
            }

            return new string(builder.ToArray());
        }
    }
}