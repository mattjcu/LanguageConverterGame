
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageConverterGame.Services
{
    public class TranslateMessage : ITranslateMessages
    {

        private Dictionary<string, long> numberTable =
new Dictionary<string, long>
{{"zero",0},{"one",1}, { "won", 1 },{ "two", 2},{ "too", 2},{ "to", 2},{"three",3},{"four",4} ,{ "for", 4},
        {"five",5},{"six",6},{"seven",7},{"eight",8},{"nine",9},
        {"ten",10},{"eleven",11},{"twelve",12},{"thirteen",13},
        {"fourteen",14},{"fifteen",15},{"sixteen",16},
        {"seventeen",17},{"eighteen",18},{"nineteen",19},{"twenty",20},
        {"thirty",21},{"forty",22},{"fifty",23},{"sixty",24},
        {"seventy",25},{"eighty",26},{"ninety",27},{"hundred",28},
        {"thousand",29},{"million",30},{"billion",31},
        {"trillion",32},{"quadrillion",33},
        {"quintillion",34}};
        public async Task<string> Translate(string message)
        {
            return ConvertMessage(message);
        }

        public string ConvertMessage(string message)
        {
            var words = message.Split(' ');
            for (int index = 0; index < words.Length; index++)
            {
                string word = words[index].ToLower();
                string keyStr = FindStringMatch(word);
                if (string.IsNullOrEmpty(keyStr))
                {
                    continue;
                }
                words[index] = word.Replace(keyStr, FindNextHighestKey(keyStr));
            }

            return string.Join(' ', words);
        }


        private string FindKeyByValue(long num)
        {
            var result = numberTable.FirstOrDefault(x => x.Value == num);
            if(result.Key is null)
            {
                return "Infinity";
            }
            return result.Key;
        }

        private string FindNextHighestKey(string str)
        {
            var current = numberTable[str];
            var next = FindKeyByValue(current + 1);
            if (string.IsNullOrEmpty(next))
            {
                return string.Empty;
            }
            return next;
        }

        private string FindStringMatch(string s)
        {
            var keyString = numberTable.Keys.Where(x => s.Contains(x));
            if (keyString.Any() == false)
            {
                return string.Empty;
            }
            return keyString.First();
        }
    }
}
