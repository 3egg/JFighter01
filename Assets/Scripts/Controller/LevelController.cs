using System;
using Const;
using UnityEngine;

namespace Controller
{
    public class LevelController : MonoBehaviour
    {
        public LevelDifficult levelDifficult
        {
            set => PlayerPrefs.SetString(Constant.DIFFICULT_LEVEL, value.ToString());
            get
            {
                var value = PlayerPrefs.GetString(Constant.DIFFICULT_LEVEL, LevelDifficult.None.ToString());
                bool tryParse = Enum.TryParse(value, out LevelDifficult level);
                if (!tryParse)
                {
                    Debug.LogError("parse difficult level failed");
                    return LevelDifficult.None;
                }

                return level;
            }
        }
        public void ifLevelIndexExist(Transform trs)
        {
            trs.gameObject.SetActive(levelDifficult != LevelDifficult.None);
        }
        
        /// <summary>
        /// 关卡数据标记 默认是1
        /// </summary>
        public LevelID levelIndex
        {
            set
            {
                if (value <= 0)
                    return;
                PlayerPrefs.SetInt(Constant.LEVEL_INDEX,(int)value);
            }
            get { return (LevelID)PlayerPrefs.GetInt(Constant.LEVEL_INDEX, 1); }
        }

        /// <summary>
        /// 关卡的第几部分的标记 默认是1
        /// </summary>
        public LevelGamePartID levelGamePartIndex
        {
            set
            {
                if (value <= 0)
                    return;
                PlayerPrefs.SetInt(Constant.LEVEL_GAME_PART_INDEX, (int)value);
            }
            get { return (LevelGamePartID)PlayerPrefs.GetInt(Constant.LEVEL_GAME_PART_INDEX, 1); }
        }

        /// <summary>
        /// 关卡的第几部分的标记 默认是1
        /// </summary>
        public LevelPartID levelPartIndex
        {
            set
            {
                if (value <= 0)
                    return;
                PlayerPrefs.SetInt(Constant.LEVEL_PART_INDEX, (int)value);
            }
            get { return (LevelPartID)PlayerPrefs.GetInt(Constant.LEVEL_PART_INDEX, 1); }
        }

        public void ResetData()
        {
            levelIndex = LevelID.ONE;
            levelGamePartIndex = LevelGamePartID.ONE;
            levelPartIndex = LevelPartID.ONE;
        }
        
    }
}