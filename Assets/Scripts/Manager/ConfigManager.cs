using System.IO;
using Const;
using UnityEngine;
using Utils;

namespace Manager
{
    /// <summary>
    /// 配置管理器
    /// </summary>
    public class ConfigManager : SingletonUtil<ConfigManager>
    {
        public T loadJson<T>()
        {
            string json = null;
            if (File.Exists(Constant.PLAYER_CONFIG))
            {
                json = File.ReadAllText(Constant.PLAYER_CONFIG);
            }

            return JsonUtility.FromJson<T>(json);
        }
    }
}