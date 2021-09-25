using System;

namespace Common
{
    public class GradesReaderFactory
    {
        public static IGradesReader GetReader(string path)
        {
            if (path.EndsWith(".json"))
            {
                return new JsonGradesReader();
            }

            if (path.EndsWith(".txt"))
            {
                return new TextGradesReader();
            }

            throw new NotImplementedException();
        }
    }
}