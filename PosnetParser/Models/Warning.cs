using Newtonsoft.Json;

namespace PosnetParser.Models
{
    public class Warning
    {
        public Warning(object objectRelatedToWarning, int warningCode)
        {
            ObjectRelatedToWarning = objectRelatedToWarning;
            WarningCode = warningCode;
        }

        public object ObjectRelatedToWarning { get; }
        public int WarningCode { get; }

        public override string ToString()
        {
            if (ObjectRelatedToWarning is string)
            {
                return (string)ObjectRelatedToWarning;
            }
            else
            {
                return JsonConvert.SerializeObject(ObjectRelatedToWarning);
            }
            //TODO: add additional info depending on warning code
        }
    }
}