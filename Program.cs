using System;
using System.Text;

Console.WriteLine(Converter.ConvertToArticleCase("the clash of CLANS", "a an the of")); //"The Clash of Clans"
Console.WriteLine(Converter.ConvertToArticleCase("В шаге ОТ победы", "в от"));          //"В Шаге от Победы"
Console.WriteLine(Converter.ConvertToArticleCase("первый аргумент"));                   //"Первый Аргумент"


class Converter
{

    public static string ConvertToArticleCase(string stringToConvert, string exceptions)
    {
        var exc = exceptions.Split(" ");
        var convertableWords = stringToConvert.Split(" ");
        bool skipping = false;
        StringBuilder sb = new StringBuilder();

        for (int wordNum = 0; wordNum < convertableWords.Length; wordNum++)
        {
            if (wordNum == 0) 
            {
                sb.Append(ConvertToUpper(convertableWords[wordNum]));
                continue; 
            }
            skipping = false;
            string word = convertableWords[wordNum];
            foreach (var ex in exc)
            {
                if (ex == word)
                {
                    sb.Append($"{word} ");
                    skipping = true;
                    break;
                }
            }

            if (!skipping)
                sb.Append(ConvertToUpper(word));
        }

        return sb.ToString();
    }

    public static string ConvertToArticleCase(string stringToConvert)
    {
        var convertableWords = stringToConvert.Split(" ");
        StringBuilder sb = new StringBuilder();

        for (int wordNum = 0; wordNum < convertableWords.Length; wordNum++)
        {
            if (wordNum == 0)
            {
                sb.Append(ConvertToUpper(convertableWords[wordNum]));
                continue;
            }

            sb.Append(ConvertToUpper(convertableWords[wordNum]));
        }

        return sb.ToString();
    }

    private static string ConvertToUpper(string word)
    {   
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < word.Length; i++)
        {
            if (i == 0) sb.Append(word[i].ToString().ToUpper());
            else sb.Append(word[i].ToString().ToLower());
        }
        sb.Append(" ");
        return sb.ToString();
    }

}