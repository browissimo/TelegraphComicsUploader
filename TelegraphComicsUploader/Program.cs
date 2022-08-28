using telegraph;
using telegraph.Node;
using TelegraphComicsUploader;

class Program
{
    public static string token = "b39105bee4a36ec7878dd41f0e13e846ed87e5f2381347d51d4cab33eb98";
    static async Task Main(string[] args)
    {

        Console.WriteLine("Путь к папке с комиксом");
        var comixPath = Console.ReadLine();

        FilesGetter filesGetter = new FilesGetter(comixPath);
        var imagerToUpload = filesGetter.GetFilesPaths();

        Console.WriteLine($"Количество страниц {imagerToUpload.Count}");

        NodeElement node = new NodeElement();

        node.AddText("Больше топовых комиксов в Новая папка (2)");
        node.AddLink("https://t.me/artporncom");

        var imgs = await ApiList.Upload(imagerToUpload);
        foreach (var img in imgs.Srcs)
        {
            node.AddImage(img.Src);
        }

        var resultPage = await ApiList.CreatePage(token, $"{filesGetter.GetFolderName()}", node.ToJson());
        Console.WriteLine(resultPage.Url.AbsoluteUri);
        Console.ReadLine();
    }
}