
// Hadoop for .NET Developers: data load
// Launch Visual Studio and create a new C# console application.
// Using the NuGet package manager, add the Microsoft .NET API for Hadoop WebClient package to your project.
// If it is not already open, open the Program.cs file and add the following directive:

   using Microsoft.Hadoop.WebHDFS;
// In the main method add the following code:

//set variables
string srcFileName = "c:\\temp\\ufo_awesome.tsv";
string destFolderName = "/demo/ufo/in";
string destFileName = "ufo_awesome.tsv";

//connect to hadoop cluster
Uri myUri = new Uri("http://localhost:50070");
string userName = "hadoop";
WebHDFSClient myClient = new WebHDFSClient(myUri, userName);

//drop destination directory (if exists)
myClient.DeleteDirectory(destFolderName, true).Wait();
            
//create destination directory
myClient.CreateDirectory(destFolderName).Wait();

 
//load file to destination directory
myClient.CreateFile(srcFileName, destFolderName + "/" + destFileName).Wait(); 

//list file contents of destination directory
Console.WriteLine();
Console.WriteLine("Contents of " + destFolderName);

myClient.GetDirectoryStatus(destFolderName).ContinueWith(
     ds => ds.Result.Files.ToList().ForEach(
     f => Console.WriteLine("\t" + f.PathSuffix)
     ));

//keep command window open until user presses enter
Console.ReadLine();
