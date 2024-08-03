namespace NguyenHung.Common.Helpers;

public class LoggingHelper
{
    public static void LogInsideTheBox(string text)
    {  
        const int boxWidth = 80; 
        var border = new string('*', boxWidth);
        var padding = new string(' ', boxWidth - 2);
        var content = $"Application is running in environment: {text}";
        var paddedContent = content.Length > (boxWidth - 4) 
            ? content.Substring(0, boxWidth - 4) 
            : content.PadRight(boxWidth - 4); 

        Console.WriteLine($"\n{border}");
        Console.WriteLine($"*{padding}*");
        Console.WriteLine($"* {paddedContent} *");
        Console.WriteLine($"*{padding}*");
        Console.WriteLine($"{border}\n");
    }
}