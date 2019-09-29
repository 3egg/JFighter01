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
                if (Enum.TryParse(value, out LevelDifficult level))
                {
                    Debug.LogError("parse difficult level failed");
                    return LevelDifficult.None;
                }

                return level;
            }
        }
     
        
    }
}