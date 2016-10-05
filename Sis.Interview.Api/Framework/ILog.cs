using System;
using NLog;

namespace Sis.Interview.Api.Framework
{
    public interface ILog
    {
        void Debug(object value);
        void Error(Exception exception);
    } 
}