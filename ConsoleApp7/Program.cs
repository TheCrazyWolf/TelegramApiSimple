using Microsoft.VisualBasic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml.Linq;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableTypes;
using Telegram.BotAPI.GettingUpdates;
using static System.Net.Mime.MediaTypeNames;
using File = System.IO.File;

internal class Program
{
    private static void Main(string[] args)
    {
        var botToken = "5913469802:AAF8iychRQ-NOxL2V8Y41yNIlAW0OWX80rQ";
        var api = new BotClient(botToken);


        var updates = api.GetUpdates();
        while (true)
        {
            if (updates.Any())
            {
                foreach (var update in updates)
                {
                    switch (update.Message.Text)
                    {
                        case "text":
                            api.SendMessage(update.Message.Chat.Id, GetLessons());
                            break;
                    }

                }
                var offset = updates.Last().UpdateId + 1;
                updates = api.GetUpdates(offset);
            }
            else
            {
                updates = api.GetUpdates();
            }
        }

        //Console.WriteLine("Hello, World!");


        //var temp = File.ReadAllText("les.json");

        //Root r = JsonSerializer.Deserialize<Root>(temp);

        //foreach (var item in r.lessons)
        //{
        //    Console.WriteLine($"{item.title}");

        Console.WriteLine("Hello, World!");


        //var temp = File.ReadAllText("les.json");

        //Root r = JsonSerializer.Deserialize<Root>(temp);

        //var text = "";
        //foreach (var item in r.lessons)
        //{
        //    text += $"{item.title}";
        //}

        //api.SendMessage(update.Message.Chat.Id, text);

    } 

    public static string GetLessons()
    {
        var temp1 = File.ReadAllText("les.json");

        Root r1 = JsonSerializer.Deserialize<Root>(temp1);

        var text1 = "";
        foreach (var item in r1.lessons)
        {
            text1 += $"{item.title}\n";
        }

        return text1;
    }
}
public class Lesson
{
    public string title { get; set; }
    public string num { get; set; }
    public string teachername { get; set; }
    public object nameGroup { get; set; }
    public string cab { get; set; }
    public string resource { get; set; }
}

public class Root
{
    public string date { get; set; }
    public List<Lesson> lessons { get; set; }
}


