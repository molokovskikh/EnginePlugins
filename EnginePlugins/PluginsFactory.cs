using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EnginePlugins.Interfaces;


namespace EnginePlugins
{
    /// <summary>
    /// Коллекция плагинов приложения
    /// </summary>
    public class PluginsFactory : IEnumerable<IPlugin>
    {
        #region Singltone для разовой загрузки всех плагинов
        private static PluginsFactory _instance = null;
        private static readonly object syncRoot = new object();
        public static PluginsFactory Instance
        {
            get
            {
                if (_instance != null) return _instance;
                Monitor.Enter(syncRoot);               
                Interlocked.Exchange<PluginsFactory>(ref _instance, new PluginsFactory());
                Monitor.Exit(syncRoot);
                return _instance;
            }
        }
        #endregion

        public PluginsFactory()
        {
            load();
            _collection = _collection ?? create();
        }

        IPlugin this[int index]
        {
            get
            {
                return _collection[index];
            }
        }


        List<IPlugin> _collection;
        /// <summary>
        /// Загрузка сборок из каталога плагинов
        /// </summary>
        /// <returns></returns>
        private int load()
        {
            int cnt = 0; //Счетчик плагинов
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("file:///", "").Replace("/", @"\"), "Plugins");
            if (System.IO.Directory.Exists(path))
                System.IO.Directory.GetFiles(path, "*.dll", System.IO.SearchOption.AllDirectories).Aggregate(cnt, (z, f) =>
                    { AppDomain.CurrentDomain.Load(System.IO.File.ReadAllBytes(f)); return z++; });
            return cnt;
        }
        /// <summary>
        /// Создание коллекции плагинов
        /// </summary>
        /// <returns></returns>
        private List<IPlugin> create()
        {
            return System.AppDomain.CurrentDomain.GetAssemblies().Aggregate(new List<IPlugin>(), (p, i) =>
            {
                i.GetTypes().Where(t => t.GetInterfaces().Where(tt => tt.Equals(typeof(IPlugin))).Count() > 0).Aggregate((Type)null, (zz, t_plugin) =>
                {
                    p.Add(Activator.CreateInstance(t_plugin) as IPlugin);
                    return null;
                }
                );
                return p;
            }
          );
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator<IPlugin> IEnumerable<IPlugin>.GetEnumerator()
        {
            return _collection.AsEnumerable<IPlugin>().GetEnumerator();
        }
    }
}
