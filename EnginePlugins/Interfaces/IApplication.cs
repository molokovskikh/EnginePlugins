using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnginePlugins.Interfaces
{    
    /// <summary>
    /// контракт взаимодействия с приложением из плагина
    /// </summary>
    public interface IApplication
    {        
        /// <summary>    
        /// Основное Меню приложения для доступа из плагина
        /// </summary>
        MenuStrip MainMenu { get; }
        /// <summary>
        /// Строка состояния приложения для доступа из плагина
        /// </summary>
        StatusStrip StatusBar { get;} 
        /// <summary>
        /// Основная форма приложения
        /// </summary>
        Form MainForm { get;}
    }
}
