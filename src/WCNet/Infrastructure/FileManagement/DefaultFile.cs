namespace VP.CodingChallenge.WCNet.Infrastructure.FileManagement;

internal class DefaultFile : IFile
{
    public Boolean Exists(String path) => File.Exists(path);
}
