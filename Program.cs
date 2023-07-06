using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "C:\\Users\\kurga\\Desktop\\texrr.txt";

        string text = File.ReadAllText(filePath);

        // Удаление знаков пунктуации
        var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

        // Разделение текста на отдельные слова
        string[] words = noPunctuationText.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        // Подсчет количества вхождений каждого слова
        var wordCount = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (wordCount.ContainsKey(word))
                wordCount[word]++;
            else
                wordCount[word] = 1;
        }

        // Получение 10 наиболее часто встречающихся слов
        var topWords = wordCount.OrderByDescending(pair => pair.Value)
                                .Take(10)
                                .Select(pair => pair.Key);

        // Вывод результатов
        Console.WriteLine("Топ 10 слов в тексте:");
        foreach (string word in topWords)
        {
            Console.WriteLine(word);
        }
    }
}
