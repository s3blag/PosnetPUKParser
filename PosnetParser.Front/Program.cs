using PosnetParser.Interfaces;
using PosnetParser.Models;
using PosnetParser.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PosnetParser.Front
{
    class Program
    {
        private static string _sourcePath = string.Empty;
        private static string _targetPath = string.Empty;
        private static bool _isTargetPathValid = false;
        private static string[] _dbLines = Array.Empty<string>();
        private static PosnetProductsDatabase _productsDatabase;
        private static IParser _chosenParser;
        private static string _parsedData;
        private static IFileService _fileService = new FileService();

        static async Task Main(string[] args)
        {
            WriteHelloMessage();

            while (!_dbLines.Any())
            {
                _sourcePath = ReadConsoleLine();
                _dbLines = await GetDbLinesFromFileAsync();
            }

            _productsDatabase = DeserializePUKDatabaseAsync();

            WriteAvailableParsersMessage();

            while (_chosenParser == null)
            {
                _chosenParser = GetChosenParser(ReadConsoleLine());
            }

            _parsedData = ParseDatabase();

            while (!_isTargetPathValid)
            {
                WriteSpecifyTargetPathMessage();
                _targetPath = ReadConsoleLine();
                _isTargetPathValid = await WriteParsedDbToFile(_targetPath);
            }

            WriteFinalMessage();
            GetKeyPress();
        }

        private static void WriteFinalMessage()
        {
            WriteLineToConsole("Operacja zakończona pomyślnie.");
            WriteLineToConsole("Kliknij dowolny przycisk by zakończyć działanie programu.");
        }

        private static void WriteHelloMessage()
        {
            WriteLineToConsole("Witaj!");
            WriteLineToConsole("Podaj ścieżkę dla pliku txt z bazą danych Posnet PUK.");
            WriteLineToConsole(string.Empty);
        }

        private static void WriteSpecifyTargetPathMessage()
        {
            WriteLineToConsole("Podaj ścieżkę zapisu dla wygenerowanego pliku.");
            WriteLineToConsole(string.Empty);
        }

        private static void WriteAvailableParsersMessage()
        {
            WriteLineToConsole("Dostępne docelowe usługi to:");
            WriteLineToConsole("1. EliSoft Faktury");
            WriteLineToConsole(string.Empty);
            WriteLineToConsole("Dokonaj wyboru podając nr usługi: ");
        }

        private static void WriteLineToConsole(string message) => Console.WriteLine(message);

        private static string ReadConsoleLine() => Console.ReadLine();

        private static char GetKeyPress() => Console.ReadKey().KeyChar;

        private static IParser GetChosenParser(string option)
        {
            try
            {
                var optionNumber = Convert.ToInt32(option);

                switch (optionNumber)
                {
                    case 1:
                        return new EliSoftParser();
                    default:
                        throw new Exception("Nieprawidłowy wybór. Dokonaj wyboru ponownie:");
                }
            }
            catch ( Exception ex)
            {
                if (ex is FormatException || ex is OverflowException)
                {
                    WriteLineToConsole("Nieprawidłowy format. Podaj wartość ponownie:");
                }
                else
                {
                    WriteLineToConsole(ex.Message);
                }

                return null;
            }
        }

        private static string WriteParsedData()
        {
            try
            {
                return _chosenParser.Parse(_productsDatabase);
            }
            catch (Exception ex)
            {
                WriteLineToConsole(ex.Message);
                return string.Empty;
            }
        }

        private static string ParseDatabase()
        {
            try
            {
                return _chosenParser.Parse(_productsDatabase);
            }
            catch (Exception ex)
            {
                WriteLineToConsole(ex.Message);
                return string.Empty;
            }
        }

        private static async Task<bool> WriteParsedDbToFile(string targetPath)
        {
            try
            {
                await _fileService.SaveFileAsync(targetPath, _parsedData);
                return true;
            }
            catch (Exception ex)
            {
                WriteLineToConsole(ex.Message);
                return false;
            }
        }

        private static async Task<string[]> GetDbLinesFromFileAsync()
        {
            try
            {
                return await _fileService.ReadFileLinesAsync(_sourcePath);
            }
            catch (Exception ex)
            {
                WriteLineToConsole(ex.Message);

                return Array.Empty<string>();
            }
        }

        private static PosnetProductsDatabase DeserializePUKDatabaseAsync()
        {
            try
            {
                var dbDeserializator = new PUKDatabaseDeserializator();

                return dbDeserializator.Deserialize(_dbLines);
            }
            catch (Exception ex)
            {
                WriteLineToConsole(ex.Message);

                return PosnetProductsDatabase.Empty;
            }
        }
    }
}
