using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Reading_and_Writing_Data_Incrementally_Using_Streams
{
    public class TextFileProcessor
    {
        private string InputFileName { get; }
        private string OutputFileName { get; }

        public TextFileProcessor(string inputFileName, string outputFileName)
        {
            InputFileName = inputFileName;
            OutputFileName = outputFileName;
        }
        
        public async Task ProcessFileStream()
        {
            await using var inputFileStream = new FileStream(InputFileName, FileMode.Open);
            using var streamReader = new StreamReader(inputFileStream);
            await using var outputFileStream = new FileStream(OutputFileName, FileMode.Create);
            await using var streamWriter = new StreamWriter(outputFileStream);

            var content = await streamReader.ReadToEndAsync();
            await streamWriter.WriteAsync(content.ToUpper());
            File.Delete(InputFileName);
        }
        
        public async Task ProcessFileStreamLines()
        {
            await using var inputFileStream = new FileStream(InputFileName, FileMode.Open);
            using var streamReader = new StreamReader(inputFileStream);
            await using var outputFileStream = new FileStream(OutputFileName, FileMode.Create);
            await using var streamWriter = new StreamWriter(outputFileStream);
            
            try
            {
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
            finally
            { 
                File.Delete(InputFileName);
            }
        }
        
        

        public async Task ProcessByteFileStream()
        {
            await using var inputFileStream = File.Open(InputFileName, FileMode.Open, FileAccess.Read);
            await using var outputFileStream = File.Create(OutputFileName);

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
            
            File.Delete(InputFileName);
        }
    }
}