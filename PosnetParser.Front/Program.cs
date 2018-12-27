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

            _productsDatabase = await DeserializePUKDatabaseAsync();

            if (_productsDatabase.HasErrors)
            {
                WriteWarnings();
            }

            WriteAvailableParsersMessage();

            while (_chosenParser == null)
            {
                _chosenParser = GetChosenParser(ReadConsoleLine());
            }

            _parsedData = await ParseDatabaseAsync();

            while (!_isTargetPathValid)
            {
                WriteSpecifyTargetPathMessage();
                _targetPath = ReadConsoleLine();
                _isTargetPathValid = await WriteParsedDbToFileAsync(_targetPath);
            }

            WriteFinalMessage();
            GetKeyPress();
        }

        private static void WriteFinalMessage()
        {
            WriteLineToConsole("Operacja zakończona pomyślnie.");
            WriteLineToConsole("Kliknij dowolny przycisk by zakończyć działanie programu.");
        }

        private static void WriteWarnings()
        {
            WriteLineToConsole("Podczas wczytywania bazy z pliku wystąpiły błędy dla następujących pozycji: ", ConsoleColor.DarkYellow);
            foreach (var warning in _productsDatabase.Warnings)
            {
                WriteLineToConsole(warning.ToString(), ConsoleColor.Yellow);
            }

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
            catch (Exception ex)
            {
                if (ex is FormatException || ex is OverflowException)
                {
                    WriteLineToConsole("Nieprawidłowy format. Podaj wartość ponownie:", ConsoleColor.Red);
                }
                else
                {
                    WriteLineToConsole(ex.Message, ConsoleColor.Red);
                }

                return null;
            }
        }

        private static async Task<string> ParseDatabaseAsync()
        {
            try
            {
                return await Task.Run(() => _chosenParser.Parse(_productsDatabase));
            }
            catch (Exception ex)
            {
                WriteLineToConsole(ex.Message, ConsoleColor.Red);
                return string.Empty;
            }
        }

        private static async Task<bool> WriteParsedDbToFileAsync(string targetPath)
        {
            try
            {
                await _fileService.SaveFileAsync(targetPath, _parsedData);
                return true;
            }
            catch (Exception ex)
            {
                WriteLineToConsole(ex.Message, ConsoleColor.Red);
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
                WriteLineToConsole(ex.Message, ConsoleColor.Red);

                return Array.Empty<string>();
            }
        }

        private static async Task<PosnetProductsDatabase> DeserializePUKDatabaseAsync()
        {
            try
            {
                var dbDeserializator = new PUKDatabaseDeserializator();

                return await Task.Run(() => dbDeserializator.Deserialize(_dbLines));
            }
            catch (Exception ex)
            {
                WriteLineToConsole(ex.Message, ConsoleColor.Red);

                return PosnetProductsDatabase.Empty;
            }
        }

        private static void WriteLineToConsole(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.WriteLine(message);
        }

        private static string ReadConsoleLine() => Console.ReadLine();

        private static char GetKeyPress() => Console.ReadKey().KeyChar;

    }
}
