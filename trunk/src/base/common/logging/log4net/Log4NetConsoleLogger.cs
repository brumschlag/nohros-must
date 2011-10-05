using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using log4net;
using log4net.Core;
using log4net.Config;
using log4net.Appender;
using log4net.Layout;
using log4net.Layout.Pattern;
using log4net.Repository;
using log4net.Repository.Hierarchy;

namespace Nohros.Logging
{
    /// <summary>
    /// A generic logger that uses the third party log4net logging library.
    /// </summary>
    /// <remarks>
    /// This is a generic logger that loads automatically and configures itself through the code. The messages
    /// are logged to the console window.
    /// <para>
    /// The pattern used to log message are:
    ///     . "[%date %-5level/%thread] %message%newline %exception" for the non-debug messages.
    /// </para>
    /// <para>
    /// The default threshold level is INFO and could be overloaded on the nohros configuration file.
    /// </para>
    /// </remarks>
    internal class Log4NetConsoleLogger : Log4NetLogger
    {
        const string kErrorLogMessagePattern = "[%date %-5level/%thread] %message%newline %exception";
        const string kCommonLogMessagePattern = "[%date %-5level/%thread] %message%newline";

        #region .ctor
        /// <summary>
        /// Initializes a new instance of the ConsoleLogger class.
        /// </summary>
        public Log4NetConsoleLogger() { }
        #endregion

        /// <summary>
        /// Configures the <see cref="FileLogger"/> logger adding the appenders to the root repository.
        /// </summary>
        public void Configure() {
            // create a new logger into the repository of the current assembly.
            ILoggerRepository root_repository = LogManager.GetRepository(Assembly.GetExecutingAssembly());
            Logger nohros_console_logger = root_repository.GetLogger("NohrosConsoleAppender") as Logger;

            // create the layout
            PatternLayout error_layout = new PatternLayout();
            error_layout.ConversionPattern = kErrorLogMessagePattern;
            error_layout.ActivateOptions();

            // create the appender
            ConsoleAppender error_appender = new ConsoleAppender();
            error_appender.Name = "NohrosErrorConsoleAppender";
            error_appender.Layout = error_layout;
            error_appender.Target = "Console.Out";
            error_appender.Threshold = Level.Info;
            error_appender.ActivateOptions();

            // create the layout and appender for on error messages.
            PatternLayout common_layout = new PatternLayout();
            common_layout.ConversionPattern = kCommonLogMessagePattern;
            common_layout.ActivateOptions();

            // create the appender
            ConsoleAppender common_appender = new ConsoleAppender();
            common_appender.Name = "NohrosCommonConsoleAppender";
            common_appender.Layout = common_layout;
            common_appender.Target = "Console.Out";
            common_appender.Threshold = Level.Info;
            common_appender.ActivateOptions();

            nohros_console_logger.AddAppender(error_appender);
            nohros_console_logger.AddAppender(common_appender);

            logger_ = LogManager.GetLogger("NohrosConsoleAppender");
        }
    }
}
