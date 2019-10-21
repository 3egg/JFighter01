using Game.Enums;
using UnityEngine;
using Utils;

namespace Game.LogicService
{
    public class PlayerInputSystem : SingletonUtil<PlayerInputSystem>
    {
        public int getCurrentSkillCode(int btnCode, int currentCode)
        {
            if (currentCode < 0)
            {
                Debug.LogError("skill code can not less than 0");
            }
            else if (currentCode == 0)
            {
                currentCode = btnCode;
            }
            else
            {
                currentCode = (int) (btnCode * Mathf.Pow(10, getCodeLength(currentCode))) + currentCode;
            }


            return currentCode;
        }

        private int getCodeLength(int currentCode)
        {
            return currentCode.ToString().Length;
        }
    }
}