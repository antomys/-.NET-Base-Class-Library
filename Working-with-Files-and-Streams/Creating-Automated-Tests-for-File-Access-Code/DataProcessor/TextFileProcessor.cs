using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;

namespace DataProcessor
{
    public class TextFileProcessor
    {
        private readonly IFileSystem _fileSystem;
        private string InputFileName { get; }
        private string OutputFileName { get; }

        public TextFileProcessor(string inputFileName, string outputFileName)
        :this(inputFileName,outputFileName,new FileSystem())
        {
            
        }

        public TextFileProcessor(string inputFileName, string outputFileName, IFileSystem fileSystem)
        {
            InputFileName = inputFileName;
            OutputFileName = outputFileName;
            _fileSystem = fileSystem;
        }
        
        public async Task ProcessFileStream()
        {
            
            using (var streamReader = _fileSystem.File.OpenText(InputFileName))
            {
                await using var streamWriter = _fileSystem.File.CreateText(OutputFileName);

                var content = await streamReader.ReadToEndAsync();
                await streamWriter.WriteAsync(content.ToUpper());
            }
           
            File.Delete(InputFileName);
        }
        
        public async Task ProcessFileStreamLines()
        {
            using (var streamReader = _fileSystem.File.OpenText(InputFileName))
            {
                await using var streamWriter = _fileSystem.File.CreateText(OutputFileName);
            
                var initialLine = 0;
                while (!streamReader.EndOfStream)
                {
                    var content = await streamReader.ReadLineAsync() ?? string.Empty;
                    if (initialLine % 2 == 0)
                        await streamWriter.WriteLineAsync(content.ToUpper());
                    else
                    {
                        await streamWriter.WriteLineAsync(content.ToLower());
                    }
                    initialLine++;
                }
            }
            File.Delete(InputFileName);
        }
        
        

        public async Task ProcessByteFileStream()
        {
            await using (var inputFileStream = _fileSystem.File.Open(InputFileName, FileMode.Open, FileAccess.Read))
            {
                await using var outputFileStream = _fileSystem.File.Create(OutputFileName);

                const int endOfStream = -1;
                var largest = 0;
                var block = inputFileStream.ReadByte();
                while(block != endOfStream)
                {
                    if (block > largest)
                        largest = block;
                    outputFileStream.WriteByte((byte) block);
                    
                    block = inputFileStream.ReadByte();
                }
                outputFileStream.WriteByte((byte) largest);
            }            
            File.Delete(InputFileName);
        }
    }
}