// See https://aka.ms/new-console-template for more information
using ConsoleApp;
using MarkdownSharp;

//Reference package: https://github.com/StackExchange/MarkdownSharp

MarkDownToHtmlOption _option = new MarkDownToHtmlOption();

var _encoding = _option.GetEncoding;
var _rootDirectory = Environment.CurrentDirectory;

//_rootDirectory = @"C:\Users\07592.william.wang\Desktop\2020-12th-ironman-master";
//_option.SourcePath = _rootDirectory;
//_option.OutPath = _rootDirectory;

//var _files = Directory.GetFiles(_rootDirectory, _option.MarkdownExtension, SearchOption.AllDirectories);
var _files = Directory.GetFiles(_rootDirectory, _option.MarkdownExtension);

var _markdown = new Markdown();

foreach (var file in _files)
{
    var _outPath = _option.ToOutPath(file);

    if (File.Exists(_outPath) == true)
        if (_option.SkipTransformed == true)
            continue;

    var _text = File.ReadAllText(file);
    var _htmlText = _markdown.Transform(_text);

    File.WriteAllText(_outPath, _htmlText);
}

//Console.WriteLine("press any key to exit");
//Console.ReadKey();