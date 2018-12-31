using PosnetParser.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PosnetParser.Models
{
    public class GroupedDbString
    {
        public GroupedDbString(string db)
        {
            var match = Regex.Match(db, RegularExpressions.PUKDatabaseFileFilter);

            if (!match.Success)
            {
                throw new Exception();
            }

            Device = match.Groups[RegexGroupNames.DeviceName].Value;
            Products = match.Groups[RegexGroupNames.PluCodes].Value.Split("\r\n");
            Eans = match.Groups[RegexGroupNames.PluEans].Value.Split("\r\n");
            Sets = match.Groups[RegexGroupNames.PluSet].Value.Split("\r\n");
        }

        public string Device { get; }
        public string[] Products { get; }
        public string[] Eans { get; }
        public string[] Sets { get; }
    }
}
