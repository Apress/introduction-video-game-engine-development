using System;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    public class KeyMap
    {
        public char c;
        public int code;
        public int extCode;

        public KeyMap(char C, int Code, int ExtCode)
        {
            c = C;
            code = Code;
            extCode = ExtCode;
        }
    }
}