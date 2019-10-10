using model;
using Utils;

namespace Manager
{
    public class ModelManager : SingletonUtil<ModelManager>
    {
        /// <summary>
        /// 玩家数据配置model
        /// </summary>
        public PlayerDataModel playerDataModel { get; private set; }

        public void init()
        {
            playerDataModel = ConfigManager.single.loadJson<PlayerDataModel>();
        }

    }
}