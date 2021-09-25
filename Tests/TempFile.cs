using System;
using System.IO;

namespace Tests
{
    public class TempFile : IDisposable
    {
        private readonly FileInfo file;
        public FileInfo FileInfo => file;

        public TempFile() : this(Path.GetTempFileName())
        {
        }

        public TempFile(string fileName) : this(new FileInfo(fileName))
        {
        }

        public TempFile(FileInfo temporaryFile)
        {
            file = temporaryFile;
        }

        public static implicit operator FileInfo(TempFile temporaryFile) => temporaryFile.file;

        public static implicit operator string(TempFile temporaryFile) => temporaryFile.file.FullName;

        public static explicit operator TempFile(FileInfo temporaryFile) => new(temporaryFile);

        private volatile bool _disposed;

        public void Dispose()
        {
            try
            {
                file.Delete();
                _disposed = true;
            }
            catch (Exception)
            {
            } // Ignore
        }

        ~TempFile()
        {
            if (!_disposed) Dispose();
        }
    }
}