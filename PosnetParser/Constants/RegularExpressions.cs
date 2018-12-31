namespace PosnetParser.Constants
{
    public class RegularExpressions
    {
        public const string PUKDatabaseFileFilter = @"\[@device\s(?<" + RegexGroupNames.DeviceName + @">.{2,})\]\r\n" + 
                                                    PluCodesTableHeader +
                                                    @"(?<" + RegexGroupNames.PluCodes + @">(?:.+\r\n{1})*)" + 
                                                    PluEanTableHeader +
                                                    @"(?<" + RegexGroupNames.PluEans + @">(?:(?:[\d,{1}.{1}]+\t){3}\r\n)*)" +
                                                    PluZestawTableHeader +
                                                    @"(?<" + RegexGroupNames.PluSet + @">(?:(?:.+)\r\n{1})*)";
                                                    

        private const string PluCodesTableHeader = @"\[@table\sPLUcodes\]\r\n\/\/Numer\tNazwa\tKod\skreskowy\tMin\.\smagazyn\tTyp\tVAT\tCena\tNr\sopak\.\tNr\sJM\tFormat\sIl\.\sSztywna\tNr\srabatu\tGrupa\tRabat\/Narzut\tIlość\tPLU\spowiązany\tNotatnik\t\r\n";
        private const string PluEanTableHeader = @"\[\@table PLUEAN\]\r\n\/\/Numer\sPLU\tKod\sKreskowy\tCena\t\r\n";
        private const string PluZestawTableHeader = @"\[@table\sPLUZestaw\]\r\n\/\/Numer\sPLU\sElem\.\tIlość\tCena\t\r\n";
    }
}
