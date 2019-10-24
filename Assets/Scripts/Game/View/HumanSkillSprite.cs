using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    /// <summary>
    /// 携带人物技能数据组件
    /// </summary>
    public class HumanSkillSprite : MonoBehaviour
    {
        public Sprite o;
        public Sprite x;

        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
        }

        public void changeSprite(char code)
        {
            if (code == 'O')
            {
                setActive(true);
                _image.sprite = o;
            }
            else if (code == 'X')
            {
                setActive(true);
                _image.sprite = x;
            }
        }

        public void setActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}