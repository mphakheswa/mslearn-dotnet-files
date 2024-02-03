// See https://aka.ms/new-console-template for more information
 using System.Linq;
using System.Net;

Console.WriteLine($"stores{Path.DirectorySeparatorChar}201");
// returns:
// stores\201 on Windows
//
// stores/201 on macOS

var currentDirectory = Directory.GetCurrentDirectory();

var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesFiles = FindFiles(storesDirectory);

foreach (var file in salesFiles)
{
    Console.WriteLine(file);
}


IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);
        
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }  

    return salesFiles;
}
