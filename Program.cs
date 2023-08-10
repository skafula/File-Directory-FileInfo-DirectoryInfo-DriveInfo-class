using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        //string filePath1 = @"c:\FileTest\firstCreate.txt", filePath2 = @"c:\FileTest\secondCopy.txt", filePath3 = @"c:\FileTest\thirdMove.txt", filePath4 = @"c:\FileTest2\fourthAnotherMove.txt";
        //File.Create(filePath1).Close();

        //bool exists = File.Exists(filePath1);
        //if (exists)
        //{
        //    File.Copy(filePath1, filePath2);
        //    File.Move(filePath1, filePath3);
        //    File.Move(filePath3, filePath4);
        //}

        #region File Class
        //Console.WriteLine("\n        ******** File Class ********        \n");

        //string writeReadPath = @"c:\FileTest\Dog.txt";
        //string content = "Samu is the best dog in the";
        //File.WriteAllText(writeReadPath, content); //Makes the file and add the content string to it. It overwrites the whole file content!
        //Console.WriteLine("Dog.txt created and content added to the file.");

        //string readedFromFile = File.ReadAllText(writeReadPath);
        //Console.WriteLine("\nWith ReadAllText: " + readedFromFile);

        //Console.WriteLine("\nWriteAllLines and ReadAllLines: "); //Write overwrites the whole file content and needs the filepath + a collection of strings, while ReadAllLines need a filepath to return with a string array.

        //List<string> dogs = new List<string>() { "Samu", "Kormos", "Tekergo" };
        //File.WriteAllLines(writeReadPath, dogs);

        //Console.WriteLine("Dog names added to dog.txt.");
        //string[] dogArray = File.ReadAllLines(writeReadPath);
        //foreach (string dog in dogArray)
        //{
        //    Console.WriteLine(dog);
        //}
        #endregion

        #region FileInfo Class
        //Console.WriteLine("\n        ******** FileInfo Class ********        \n");

        ////FileInfo class is a better choice when want to make more change on the actual file. FileInfo is an instance object which stores the filepath.
        //FileInfo fileFileInfo = new FileInfo(@"c:\FileTest\fileInfoTest.txt");
        //fileFileInfo.Create().Close(); //the instance already has the path

        //FileInfo copiedFile = fileFileInfo.CopyTo(@"c:\FileTest\copiedFileInfoTest.txt");

        //Console.WriteLine($"{fileFileInfo.Name} created then copied to: {copiedFile.FullName}");

        //fileFileInfo.MoveTo(@"c:\FileTest\moved_fileInfoTest.txt");

        //Console.WriteLine(fileFileInfo.FullName + " created and fileInfoText.txt removed.");

        ////Properties
        //FileInfo fileInfoProps = new(@"C:\FileTest\program.txt");

        //Console.WriteLine("Exists: " + fileInfoProps.Exists);
        //Console.WriteLine("Name: " + fileInfoProps.Name);
        //Console.WriteLine("FullName: " + fileInfoProps.FullName);
        //Console.WriteLine("Directory: " + fileInfoProps.Directory);
        //Console.WriteLine("Extension: " + fileInfoProps.Extension);
        //Console.WriteLine("Length: " + fileInfoProps.Length + " bytes");
        //Console.WriteLine("LastAccessTime: " + fileInfoProps.LastAccessTime);
        //Console.WriteLine("LastWriteTime: " + fileInfoProps.LastWriteTime);
        //Console.WriteLine("CreationTime: " + fileInfoProps.CreationTime);
        #endregion

        #region Directory Class
        //Console.WriteLine("\n        ******** Directory Class ********        \n");

        //string dirPath = @"C:\DirectoryTest\Contries";
        //Directory.CreateDirectory(dirPath);
        //Console.WriteLine("New folder has been created.");
        //string hunPath = dirPath + @"\Hungary";
        //string ukPath = dirPath + @"\UK";
        //string usaPath = dirPath + @"\USA";
        //Directory.CreateDirectory(hunPath);
        //Directory.CreateDirectory(ukPath);
        //Directory.CreateDirectory(usaPath);
        //Console.WriteLine("Subdirectories created.");
        //File.Create(dirPath + @"\capitals.txt").Close();
        //File.Create(dirPath + @"\sports.txt").Close();
        //File.Create(dirPath + @"\restaurants.txt").Close();
        //Console.WriteLine("Files created.");
        //string newDirPath = @"C:\DirectoryTest\World";
        //Directory.Move(dirPath, newDirPath);

        //string[] files = Directory.GetFiles(newDirPath);
        //foreach (string file in files )
        //{
        //    Console.WriteLine(file);
        //}

        //string[] dirs = Directory.GetDirectories(newDirPath);
        //foreach (string dir in dirs)
        //{
        //    Console.WriteLine(dir);
        //}
        //Directory.Delete(newDirPath, true);
        #endregion

        #region DirectoryInfo Class
        Console.WriteLine("\n        ******** DirectoryInfo Class ********        \n");

        //making a path string variable with the path. make the DirectoryInfo instance which store the path in itself. Creating the folder.
        string practicePath = @"c:\DirectoryTest\contries";
        DirectoryInfo practiceFolder = new DirectoryInfo(practicePath);
        practiceFolder.Create();

        //add subdireactories withon concatenation
        practiceFolder.CreateSubdirectory("Asia");
        practiceFolder.CreateSubdirectory("UK");
        practiceFolder.CreateSubdirectory("USA");

        //makes the files but variable to store objects doesn't required
        new FileInfo(practicePath + @"\sports.txt").Create().Close();
        new FileInfo(practicePath + @"\restaurants.txt").Create().Close();
        new FileInfo(practicePath + @"\capitals.txt").Create().Close();

        //save a new path
        string worldPath = @"c:\DirectoryTest\world";

        //move the whole folder with its subdirectories to a new dir
        practiceFolder.MoveTo(worldPath);

        //GetFiles method returns a FileInfo array
        FileInfo[] files = practiceFolder.GetFiles();
        foreach (FileInfo file in files)
        {
            Console.WriteLine(file.FullName);
        }

        //GetDirectories returns a DirectoryInfo array
        DirectoryInfo[] dirs = practiceFolder.GetDirectories();
        foreach (DirectoryInfo dir in dirs)
        {
            Console.WriteLine(dir.FullName);
        }

        Console.WriteLine("Exists: " + practiceFolder.Exists);
        Console.WriteLine("Name: " + practiceFolder.Name);
        Console.WriteLine("Full Name: " + practiceFolder.FullName);
        Console.WriteLine("Root: " + practiceFolder.Root);
        Console.WriteLine("Parent: " + practiceFolder.Parent);
        Console.WriteLine("Creation Time:" + practiceFolder.CreationTime);
        Console.WriteLine("Last Access Time: " + practiceFolder.LastAccessTime);
        Console.WriteLine("Last Write Time: " + practiceFolder.LastWriteTime);

        //finally delete the whole dir (setting argument true to not care about if the folder is empty or not)
        practiceFolder.Delete(true);
        #endregion

        Console.WriteLine("\n        ******** DriveInfo Class ********        \n");

        #region DriveInfo
        DriveInfo driveInfo = new DriveInfo("c:");
        Console.WriteLine("Name: " + driveInfo.Name);
        Console.WriteLine("Drive Type: " + driveInfo.DriveType);
        Console.WriteLine("Volume Label: " + driveInfo.VolumeLabel);
        Console.WriteLine("Root: " + driveInfo.RootDirectory);
        Console.WriteLine("Total Size: " + driveInfo.TotalSize /1024 /1024 /1024 + " gb");
        Console.WriteLine("Free space: " + driveInfo.TotalFreeSpace /1024 /1024 /1024 + " gb");
        #endregion
    }
}