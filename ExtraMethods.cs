using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace IE11Test
{
    /// <summary>
    /// Содержит методы для упрощения написания ожиданий элементов.
    /// </summary>
    public class Wait
    {
        public IWebDriver driver;

        /// <summary>
        /// Конструктор принимает драйвер браузера, для работы.
        /// </summary>
        /// <param name="driver"></param>
        public Wait(ref IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Ожидание по тегу name.
        /// </summary>
        /// <param name="id">Содержимое тега.</param>
        /// <param name="time">Макс. время ожидания элемента.</param>
        /// <returns></returns>
        public IWebElement WaitByName(string id, int time = 30)
        {

            return WaitBy(By.Id(id), time);
        }

        /// <summary>
        /// Ожидание по тегу id.
        /// </summary>
        /// <param name="id">Содержимое тега.</param>
        /// <param name="time">Макс. время ожидания элемента.</param>
        /// <returns></returns>
        public IWebElement WaitById(string id, int time = 30)
        {
            return WaitBy(By.Id(id), time);
        }

        /// <summary>
        /// Ожидание элемента.
        /// </summary>
        /// <param name="locator">Принимает объект By. Пример: By.Id("x").</param>
        /// <param name="time">Макс. время ожидания элемента.</param>
        /// <returns></returns>
        public IWebElement WaitBy(By locator, int time = 30)
        {
  
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, time));

            IWebElement element = wait.Until<IWebElement>(d =>
            {
                return d.FindElement(locator);
            });

            return element;

        }

        /// <summary>
        /// Ожидание полной загрузки страницы
        /// </summary>
        public void WaitForPageLoaded()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            long loadEventEnd = 0;
            do
            {
                loadEventEnd = (long)js.ExecuteScript("return window.performance.timing.loadEventEnd");
            } while (loadEventEnd == 0);
        }

       
    }

 
  
}

