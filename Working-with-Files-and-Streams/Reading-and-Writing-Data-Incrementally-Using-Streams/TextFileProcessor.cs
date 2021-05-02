using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Reading_and_Writing_Data_Incrementally_Using_Streams
{
    public class TextFileProcessor
    {
        private string InputFileName { get; init; }
        private string OutputFileName { get; init; }

        public TextFileProcessor(string inputFileName, string outputFileName)
        {
            InputFileName = inputFileName;
            OutputFileName = outputFileName;
        }

        public async Task ProcessAsWholeString()
        {
            await File.WriteAllTextAsync(OutputFileName,
                (await File.ReadAllTextAsync(InputFileName)).ToUpper());
            File.Delete(InputFileName);
        }

        public async Task ProcessAsStringArrays()
        {
            await File.WriteAllLinesAsync(OutputFileName,
                (await File.ReadAllLinesAsync(InputFileName))
                .Select(x => x.ToUpper()));
            File.Delete(InputFileName);
        }

        public async Task ProcessAsByteArray()
        {
            await File.WriteAllBytesAsync(OutputFileName,
                (await File.ReadAllBytesAsync(InputFileName)).Reverse().ToArray());
            File.Delete(InputFileName);
        }
    }
}