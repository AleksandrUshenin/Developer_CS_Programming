using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11
{
    internal class FindFile : Stream
    {
        private FileInfo _file;

        public byte[] Buffer { get; private set; }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return !_file.IsReadOnly; }
        }

        public override void Flush()
        {
            this._file = null;
        }

        private long _length;
        public override long Length
        {
            get { return _length; }
        }

        private long _position;
        public override long Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (value < _file.Length && value >= -1)
                    _position = value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int resRead = 0;
            byte[] resultByte;
            buffer = new byte[11];
            using (FileStream fs = new FileStream(_file.FullName, FileMode.Open, FileAccess.Read))
            {
                long len = fs.Length;
                resultByte = new byte[len];
                resRead = fs.Read(resultByte, offset, (int)len);
                this.Buffer = resultByte;
                return resRead;
            }
        }
        public string ReadAll()
        {
            string res = "";
            using (StreamReader sr = new StreamReader(_file.FullName, Encoding.UTF8))
            {
                res = sr.ReadToEnd();
            }
            return res;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            _length = value;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            using (FileStream fs = new FileStream(_file.FullName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(buffer, offset, count);
            }
        }
        public void Write(string text)
        {
            _Write(text, false);
        }
        public void Write(string text, bool append)
        {
            _Write(text, append);
        }
        private void _Write(string text, bool append)
        {
            using (StreamWriter sw = new StreamWriter(_file.FullName, append, Encoding.Default))
            {
                sw.Write(text);
                //sw.WriteLine(text);
            }
        }

        public FindFile(FileInfo file)
        {
            this._file = file;
            this._position = 0;
            this._length = _file.Length;
        }
        public FindFile(string file)
        {
            if (File.Exists(file))
            {
                FileInfo f = new FileInfo(file);
                this._file = f;
                this._position = 0;
            }
        }
    }
}
