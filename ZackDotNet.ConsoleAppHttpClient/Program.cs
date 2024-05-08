using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

string jsonstr = await File.ReadAllTextAsync("data.json");
var model = JsonConvert.DeserializeObject<MainDto>(jsonstr);

Console.WriteLine(jsonstr);

foreach (var question in model.questions)
{
    Console.WriteLine(question.questionNo);
}

//JSON to C## Need Package 
//C## to JSON

Console.ReadLine();

static string ToNumber (string num)
{
    num.Replace ('၃', '3');
    return num;
}

public class MainDto
{
    public Question[] questions { get; set; }
    public Answer[] answers { get; set; }
    public string[] numberList { get; set; }
}

public class Question
{
    public int questionNo { get; set; }
    public string questionName { get; set; }
}

public class Answer
{
    public int questionNo { get; set; }
    public int answerNo { get; set; }
    public string answerResult { get; set; }
}
