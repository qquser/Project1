using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.Enums
{
    public sealed class ExceptionInfo
    {
        public int Code { get; private set; }
        public string Message { get; private set; }

        public static readonly ExceptionInfo EmailAlreadyExists = new ExceptionInfo(1, "Email already exists!");
        public static readonly ExceptionInfo WrongPasswordConfirmation = new ExceptionInfo(2, "Wrong password confirmation!");


        private ExceptionInfo(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
