using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnginePlugins.Interfaces
{        
    /// <summary>
    /// Плагин приложения
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Уникальное имя
        /// </summary>
        string Name { get;}
        /// <summary>
        /// Описание 
        /// </summary>
        string Description { get;}
        /// <summary>
        /// Инициализация плагина
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        bool Init(IApplication app);
        /// <summary>
        /// Завершение работы плагина
        /// </summary>
        void Done();
    }
}
