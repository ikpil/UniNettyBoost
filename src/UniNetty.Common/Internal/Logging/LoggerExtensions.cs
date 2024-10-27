using System;
using UniNetty.Logging;

namespace UniNetty.Common.Internal.Logging
{
    public static class LoggerExtensions
    {
        public static void LogDebug(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            logger.Log(LogLevel.Debug, eventId, exception, message, args);
        }

        public static void LogDebug(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            logger.Log(LogLevel.Debug, eventId, message, args);
        }

        public static void LogDebug(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(LogLevel.Debug, exception, message, args);
        }

        public static void LogDebug(this ILogger logger, string message, params object[] args)
        {
            logger.Log(LogLevel.Debug, message, args);
        }

        public static void LogTrace(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            logger.Log(LogLevel.Trace, eventId, exception, message, args);
        }


        public static void LogTrace(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            logger.Log(LogLevel.Trace, eventId, message, args);
        }


        public static void LogTrace(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(LogLevel.Trace, exception, message, args);
        }


        public static void LogTrace(this ILogger logger, string message, params object[] args)
        {
            logger.Log(LogLevel.Trace, message, args);
        }


        public static void LogInformation(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            logger.Log(LogLevel.Information, eventId, exception, message, args);
        }


        public static void LogInformation(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            logger.Log(LogLevel.Information, eventId, message, args);
        }


        public static void LogInformation(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(LogLevel.Information, exception, message, args);
        }


        public static void LogInformation(this ILogger logger, string message, params object[] args)
        {
            logger.Log(LogLevel.Information, message, args);
        }


        public static void LogWarning(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            logger.Log(LogLevel.Warning, eventId, exception, message, args);
        }


        public static void LogWarning(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            logger.Log(LogLevel.Warning, eventId, message, args);
        }


        public static void LogWarning(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(LogLevel.Warning, exception, message, args);
        }


        public static void LogWarning(this ILogger logger, string message, params object[] args)
        {
            logger.Log(LogLevel.Warning, message, args);
        }


        public static void LogError(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            logger.Log(LogLevel.Error, eventId, exception, message, args);
        }


        public static void LogError(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            logger.Log(LogLevel.Error, eventId, message, args);
        }


        public static void LogError(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(LogLevel.Error, exception, message, args);
        }


        public static void LogError(this ILogger logger, string message, params object[] args)
        {
            logger.Log(LogLevel.Error, message, args);
        }


        public static void LogCritical(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            logger.Log(LogLevel.Critical, eventId, exception, message, args);
        }


        public static void LogCritical(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            logger.Log(LogLevel.Critical, eventId, message, args);
        }


        public static void LogCritical(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(LogLevel.Critical, exception, message, args);
        }


        public static void LogCritical(this ILogger logger, string message, params object[] args)
        {
            logger.Log(LogLevel.Critical, message, args);
        }


        public static void Log(this ILogger logger, LogLevel logLevel, string message, params object[] args)
        {
            logger.Log(logLevel, 0, null, message, args);
        }


        public static void Log(this ILogger logger, LogLevel logLevel, EventId eventId, string message, params object[] args)
        {
            logger.Log(logLevel, eventId, null, message, args);
        }


        public static void Log(this ILogger logger, LogLevel logLevel, Exception exception, string message, params object[] args)
        {
            logger.Log(logLevel, 0, exception, message, args);
        }


        public static void Log(this ILogger logger, LogLevel logLevel, EventId eventId, Exception exception, string message, params object[] args)
        {
            logger.Log(logLevel, eventId, MessageFormatter.ArrayFormat(message, args), exception, Message);
        }

        private static string Message(FormattingTuple state, Exception error)
        {
            return state.Message;
        }
    }
}