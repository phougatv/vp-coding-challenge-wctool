namespace VP.CodingChallenge.WCNet.Test.FileOperations;

public class FilesDirectoryFixture : IDisposable
{
    public string FilesDirectory { get; }

    public FilesDirectoryFixture()
    {
        FilesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");

        //Ensure the Files directory exists
        if (!Directory.Exists(FilesDirectory))
            Directory.CreateDirectory(FilesDirectory);
    }

    public void Dispose()
    {
        //Clean up the Files directory after all the tests have run
        if (!Directory.Exists(FilesDirectory))
            return;

        try
        {
            Directory.Delete(FilesDirectory, true);
            Console.WriteLine($"Deleted test directory and all contents: {FilesDirectory}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to delete test directory: {FilesDirectory}. Error: {ex.Message}");
        }
    }
}
