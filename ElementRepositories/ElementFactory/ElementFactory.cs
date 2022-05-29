using ElementRepositories.ElementFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using WebAutomation.ITestStartupandTearDown;
using WebAutomation.TestStartupandTearDown;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ElementRepositories.ElementFactory
{
    public class ElementFactory
    {
        private static Dictionary<Type, Type> interfaceImplementationMap = new Dictionary<Type, Type>();
        private static List<Assembly> pluginAssemblies = new List<Assembly>();
        private static List<Type> allImplementingTypes = new List<Type>();

        static ElementFactory()
        {
            AddPluginAssembly(Assembly.GetExecutingAssembly());
        }

        public T FindElementByXpath<T>(string className, IWebDriver webdriver) where T : IElementBase
        {
            try
            {
                var type = typeof(T);
                return this.Find<T>(By.XPath(className), webdriver);
            }
            catch (Exception E)
            {
                throw;
            }
        }
        public T FindElementByID<T>(string className, IWebDriver webdriver) where T : IElementBase
        {
            try
            {
                var type = typeof(T);
                return this.Find<T>(By.Id(className), webdriver);
            }

            catch (Exception E)
            {
                throw;
            }
        }


        private T Find<T>(By elementlocator, IWebDriver webdriver, IElementBase parentElement = null)
    where T : IElementBase
        {
            return CreateElement<T>((WebElement)webdriver.FindElement(elementlocator), parentElement);
        }

        internal static T CreateElement<T>(WebElement element, IElementBase parentElement)
                        where T : IElementBase
        {

            var instance = (T)CreateInstanceUsingInterface<T>();
            instance.webElement = element;
            return instance;
        }

        private static object CreateInstanceUsingInterface<T>()
        {
            string interfaceName = typeof(T).Name;

            // Ensure interface name is not null
            if (interfaceName != string.Empty && interfaceName != null && interfaceName.Length > 0)
            {
                Type pluginType = null;

                if (ElementFactory.interfaceImplementationMap.ContainsKey(typeof(T)))
                {
                    pluginType = ElementFactory.interfaceImplementationMap[typeof(T)];
                }
                else
                {
                    var implementingTypes = allImplementingTypes.Where(type => !type.IsAbstract && typeof(T).IsAssignableFrom(type)).ToList();

                    if (implementingTypes.Count == 0)
                    {
                        /// Console.Writeline("None of the plugin assemblies implement the interface " + interfaceName);
                    }
                    else if (implementingTypes.Count > 1)
                    {
                        List<Type> immediateTypes = implementingTypes.ToList();
                        foreach (var type in implementingTypes)
                        {
                            immediateTypes.RemoveAll(immediatetype => immediatetype.IsSubclassOf(type));
                        }

                        if (immediateTypes.Count > 1)
                        {
                            string joinedTypes = string.Join(", ", immediateTypes.Select(t => t.Name));
                            /// Console.Writeline("More than one types (" + joinedTypes + ") directly implement the interface " + interfaceName);
                        }
                        else
                        {
                            pluginType = immediateTypes.FirstOrDefault();
                            ElementFactory.interfaceImplementationMap.Add(typeof(T), pluginType);
                        }
                    }
                    else
                    {
                        pluginType = implementingTypes.First();
                        ElementFactory.interfaceImplementationMap.Add(typeof(T), pluginType);
                    }
                }

                if (pluginType != null)
                {
                    return Activator.CreateInstance(pluginType);
                }
            }

            return null;
        }


        public static void AddPluginAssembly(Assembly pluginAssembly)
        {
            if (!pluginAssemblies.Contains(pluginAssembly))
            {
                allImplementingTypes.Clear();

                pluginAssemblies.Add(pluginAssembly);

                pluginAssemblies.ForEach(assembly => allImplementingTypes.AddRange(assembly.GetTypes().Where(type => !type.IsAbstract && typeof(IElementBase).IsAssignableFrom(type)).ToList()));


            }
        }
    }
}
