using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.LoggerPluggable
{
    public class ParamPluginElement : ConfigurationElement
    {
        private const string KeyAttributeName = "Key";
        private const string ValueAttributeName = "Value";

        [ConfigurationProperty(KeyAttributeName, IsRequired = true)]
        public string Key
        {
            get { return base[KeyAttributeName] as string; }
            set { base[KeyAttributeName] = value; }
        }

        [ConfigurationProperty(ValueAttributeName, IsRequired = true)]
        public string Value
        {
            get { return base[ValueAttributeName] as string; }
            set { base[ValueAttributeName] = value; }
        }
    }

    public class ParamCollection : ConfigurationElementCollection
    {
        public ParamPluginElement this[int index]
        {
            get
            {
                return base.BaseGet(index) as ParamPluginElement;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public new ParamPluginElement this[string responseString]
        {
            get { return (ParamPluginElement)BaseGet(responseString); }
            set
            {
                if (BaseGet(responseString) != null)
                {
                    BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
                }
                BaseAdd(value);
            }
        }

        protected override System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new ParamPluginElement();
        }

        protected override object GetElementKey(System.Configuration.ConfigurationElement element)
        {
            return ((ParamPluginElement)element).Key;
        }
    }

    public class LoggerPluginElement : ConfigurationElement
    {
        private const string TypeAttributeName = "Type";
        private const string AssemblyAttributeName = "Assembly";
        //private const string ConnectionStringAttributeName = "ConnectionString";
        //private const string PathFileAttributeName = "PathFile";

        [ConfigurationProperty(TypeAttributeName, IsRequired = true)]
        public string Type
        {
            get { return base[TypeAttributeName] as string; }
            set { base[TypeAttributeName] = value; }
        }

        [ConfigurationProperty(AssemblyAttributeName, IsRequired = true)]
        public string Assembly
        {
            get { return base[AssemblyAttributeName] as string; }
            set { base[AssemblyAttributeName] = value; }
        }

        [ConfigurationProperty("Constructor")]
        [ConfigurationCollection(typeof(ParamCollection), AddItemName = "Param")]
        public ParamCollection Constructor
        {
            get
            {
                return base["Constructor"] as ParamCollection;
            }
        }

        //[ConfigurationProperty(ConnectionStringAttributeName, IsRequired = false)]
        //public string ConnectionString
        //{
        //    get { return base[ConnectionStringAttributeName] as string; }
        //    set { base[ConnectionStringAttributeName] = value; }
        //}

        //[ConfigurationProperty(PathFileAttributeName, IsRequired = false)]
        //public string PathFile
        //{
        //    get { return base[PathFileAttributeName] as string; }
        //    set { base[PathFileAttributeName] = value; }
        //}
    }

    public class LoggerManagerCollection : ConfigurationElementCollection
    {
        public LoggerPluginElement this[int index]
        {
            get
            {
                return base.BaseGet(index) as LoggerPluginElement;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public new LoggerPluginElement this[string responseString]
        {
            get { return (LoggerPluginElement)BaseGet(responseString); }
            set
            {
                if (BaseGet(responseString) != null)
                {
                    BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
                }
                BaseAdd(value);
            }
        }

        protected override System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new LoggerPluginElement();
        }

        protected override object GetElementKey(System.Configuration.ConfigurationElement element)
        {
            return ((LoggerPluginElement)element).Type;
        }
    }

    public class RegisterLoggerConfig : ConfigurationSection
    {

        public static RegisterLoggerConfig GetConfig()
        {
            return (RegisterLoggerConfig)System.Configuration.ConfigurationManager.GetSection("RegisterLogger") ?? new RegisterLoggerConfig();
        }

        [System.Configuration.ConfigurationProperty("LoggerManager")]
        [ConfigurationCollection(typeof(LoggerManagerCollection), AddItemName = "LoggerPlugin")]
        public LoggerManagerCollection LoggerManagers
        {
            get
            {
                object o = this["LoggerManager"];
                return o as LoggerManagerCollection;
            }
        }

    }
}
