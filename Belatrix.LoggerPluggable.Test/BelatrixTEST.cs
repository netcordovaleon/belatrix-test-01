using System;
using System.Linq;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Belatrix.LoggerPluggable.Interfaces;
using System.Collections.Generic;
using Belatrix.LoggerPluggable.Types;

namespace Belatrix.LoggerPluggable.Test
{
    [TestClass]
    public class BelatrixTest
    {
        [TestMethod]
        public void TEST_ExecuteOperationLog()
        {
            try
            {
                var log = new LoggerBelatrix();
                log.Message("BELATRIX NET - TEST", Types.EventType.Success);
            }
            catch (Exception)
            {
                Assert.Fail("No se pudo completar la operacion - TEST_ExecuteOperationLog");
            }
        }

        [TestMethod]
        public void TEST_ReadConfigSection()
        {
            try
            {
                Dictionary<string, string> Parameters = new Dictionary<string, string>();
                var loggerSection = RegisterLoggerConfig.GetConfig();
                foreach (LoggerPluginElement element in loggerSection.LoggerManagers)
                {
                    //Dictionary<string, string> Parameters = new Dictionary<string, string>();
                    foreach (ParamPluginElement subelement in element.Constructor)
                    {
                        Parameters.Add(subelement.Key, subelement.Value);
                    }
                }

                Assert.IsTrue(Parameters.Count > 1, "Lectura de configSections correcto");
            }
            catch (Exception)
            {
                Assert.Fail("No se pudo completar la operacion - TEST_ReadConfigSection");
            }
        }

        [TestMethod]
        public void TEST_ExecuteLoggerFile()
        {
            try
            {
                Dictionary<string, string> Parameters = new Dictionary<string, string>();
                var loggerSection = RegisterLoggerConfig.GetConfig();
                foreach (LoggerPluginElement element in loggerSection.LoggerManagers)
                {
                    //Dictionary<string, string> Parameters = new Dictionary<string, string>();
                    foreach (ParamPluginElement subelement in element.Constructor)
                    {
                        Parameters.Add(subelement.Key, subelement.Value);
                    }
                }
                MessageLog log = new MessageLog("Mensaje UNIT TEST - FILE", EventType.Error.GetHashCode());
                ILogRepository logRepository = new Belatrix.LoggerPluggable.LogManagerFile.LogRepository(Parameters);
                logRepository.SaveMessage(log);
            }
            catch (Exception)
            {
                Assert.Fail("No se pudo completar la operacion - TEST_ExecuteLoggerFile");
            }
        }


        [TestMethod]
        public void TEST_ExecuteLoggerDataBase()
        {
            try
            {
                Dictionary<string, string> Parameters = new Dictionary<string, string>();
                var loggerSection = RegisterLoggerConfig.GetConfig();
                foreach (LoggerPluginElement element in loggerSection.LoggerManagers)
                {
                    //Dictionary<string, string> Parameters = new Dictionary<string, string>();
                    foreach (ParamPluginElement subelement in element.Constructor)
                    {
                        Parameters.Add(subelement.Key, subelement.Value);
                    }
                }
                MessageLog log = new MessageLog("Mensaje UNIT TEST - DATA BASE", EventType.Success.GetHashCode());
                ILogRepository logRepository = new Belatrix.LoggerPluggable.LogManagerDataBase.LogRepository(Parameters);
                logRepository.SaveMessage(log);
            }
            catch (Exception)
            {
                Assert.Fail("No se pudo completar la operacion - TEST_ExecuteLoggerDataBase");
            }
        }

    }
}
