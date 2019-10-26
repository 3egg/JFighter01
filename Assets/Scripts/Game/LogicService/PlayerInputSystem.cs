using System;
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

        public int getSkillCode(string skillName, string prefix, string posfix)
        {
            string skillCode = "";
            //移除动画名称的attack
            if (!string.IsNullOrEmpty(prefix))
            {
                skillCode = skillName.Remove(0, prefix.Length);
            }

            if (!string.IsNullOrEmpty(posfix))
            {
                skillCode = skillName.Remove(skillName.Length - posfix.Length, posfix.Length);
            }

            return convertStringToInt(skillCode);
        }

        //转换string到int
        public int convertStringToInt(string codeString)
        {
            var chars = codeString.ToCharArray();
            string code = "";
            foreach (var c in chars)
            {
                if (c == 'X')
                {
                    code += "1";
                }
                else
                {
                    code += "2";
                }
            }

            return Int32.Parse(code);
        }

        public string convertIntToString(int code)
        {
            var array = code.ToString().ToCharArray();
            var returnStr = "";
            foreach (var c in array)
            {
                if (c == '1')
                {
                    returnStr += "X";
                }
                else
                {
                    returnStr += "O";
                }
            }

            return returnStr;
        }

        private int getCodeLength(int currentCode)
        {
            return currentCode.ToString().Length;
        }
    }
}