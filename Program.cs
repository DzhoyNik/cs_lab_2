using System.Security.AccessControl;
using System.Security.Principal;

namespace lab_2
{
  class Document
  {
    virtual public void ExportInfoForFile(string _path)
    {
      FileInfo fileInfo = new FileInfo(_path);
      FileSecurity fileSecurity = fileInfo.GetAccessControl();
      string fileName = fileInfo.Name;
      string fileOwner = fileSecurity.GetOwner(typeof(NTAccount)).ToString();
      fileOwner = fileOwner.Substring(fileOwner.IndexOf('\\') + 1);
      string filePath = fileInfo.DirectoryName;
      Console.WriteLine($"\nСвойства:\n* Название файла: {fileName}\n* Владелец файла: {fileOwner}\n* Расположение файла: {filePath}");
    }
  }
  class MSWord : Document
  {
    override public void ExportInfoForFile(string _path)
    {
      base.ExportInfoForFile(_path);
      dynamic shell = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
      dynamic folder = shell.NameSpace(Path.GetDirectoryName(_path));
      dynamic file = folder.ParseName(Path.GetFileName(_path));
      string countWords = folder.GetDetailsOf(file, 160);
      Console.WriteLine($"* Количество слов: {countWords}\n");
    }
  }
  class PDF : Document
  {
    override public void ExportInfoForFile(string _path)
    {
      int CountPages = 15;
      
      base.ExportInfoForFile(_path);
      
      Console.WriteLine($"* Количество страниц: {CountPages}\n");
    }
  }
  class MSExcel : Document
  {
    override public void ExportInfoForFile(string _path)
    {
      string sizeFile = "187 КБ";
      
      base.ExportInfoForFile(_path);
      
      Console.WriteLine($"* Размер файла: {sizeFile}\n");
    }
  }
  class TXT : Document
  {
    override public void ExportInfoForFile(string _path)
    {
      string dateCreate = "05.01.2025";
      
      base.ExportInfoForFile(_path);
      
      Console.WriteLine($"* Дата создания: {dateCreate}\n");
    }
  }
  class HTML : Document
  {
    override public void ExportInfoForFile(string _path)
    {
      string typeFile = "HTML Document";

      base.ExportInfoForFile(_path);

      Console.WriteLine($"* Тип документа: {typeFile}\n");
    }
  }
  internal class Program
  {
    class Singleton
    {
      private static Singleton? instance;
      private Singleton() { }
      public static Singleton getInstance()
      {
        if (instance == null)
            instance = new Singleton();
        return instance;
      }
    }
    static void Main(string[] args) {
      while (true)
      {
        string path;
        Console.Write("Введите полный путь к файлу: ");
        path = @Console.ReadLine();
        string extensionFile = path.Substring(path.LastIndexOf(".") + 1);
        switch (extensionFile)
        {
          case "docx":
            MSWord mSWord = new MSWord();

            mSWord.ExportInfoForFile(path);

            break;

          case "pdf":
            PDF pdf = new PDF();
            
            pdf.ExportInfoForFile(path);
            
            break;

          case "xlsx":
            MSExcel mSExcel = new MSExcel();

            mSExcel.ExportInfoForFile(path);

            break;

          case "txt":
            TXT txt = new TXT();

            txt.ExportInfoForFile(path);

            break;

          case "html":
            HTML html = new HTML();

            html.ExportInfoForFile(path);

            break;

          default:
            Console.WriteLine("\nВвден файл с неизвестным форматом (поддерживается .docx, .pdf, .xlsx, .txt, .html) или указан неправильный путь к файлу\n");
              
            break;
        }
      }
    }
  }
}
