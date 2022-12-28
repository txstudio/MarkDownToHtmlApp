using System.Text;

namespace ConsoleApp
{
    public sealed class Convert
    {
        public MarkDownToHtmlOption _setting;

        public Convert(MarkDownToHtmlOption setting)
        {
            _setting = setting;
        }


    }

    public sealed class FileInfo
    {
        public string FullPath { get; set; }
        public string FileNameWithoutExtension => Path.GetFileNameWithoutExtension(FullPath);
    }

    public sealed class MarkDownToHtmlOption
    {
        public MarkDownToHtmlOption()
        {
            this.TextEncodingName = "utf-8";
            this.SourcePath = Environment.CurrentDirectory;
            this.OutPath = Environment.CurrentDirectory;
            this.MarkdownExtension = "*.md";
            this.HtmlExtension = ".html";
            this.SkipTransformed = true;
        }

        public string TextEncodingName { get; set; }
        public string SourcePath { get; set; }
        public string OutPath { get; set; }
        public string MarkdownExtension { get; set; }
        public string HtmlExtension { get; set; }

        public bool SkipTransformed { get; set; }

        public Encoding GetEncoding => Encoding.GetEncoding(this.TextEncodingName);

        public string ToOutPath(string path)
        {
            var _fileName = Path.GetFileNameWithoutExtension(path);
            var _htmlFileName = $"{_fileName}{this.HtmlExtension}";
            var _outPath = Path.Combine(this.OutPath, _htmlFileName);
            return _outPath;
        }
    }
}
