using Game.Enums;
using UnityEngine;
using Utils;

namespace Game.LogicService
{
    public class PlayerInputSystem : SingletonUtil<PlayerInputSystem>
    {
        public int getCurrentSkillCode(int inputCode, int currentCode)
        {
            if (currentCode < 0)
            {
                Debug.LogError("skill code can not less than 0");
            }
            else if (currentCode == 0)
            {
                currentCode = inputCode;
            }
            else
            {
                currentCode = currentCode * 10 + inputCode;
            }


            return currentCode;
        }

        private int getCodeLength(int currentCode)
        {
            return currentCode.ToString().Length;
        }
    }
}