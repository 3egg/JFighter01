using System;
using System.Collections.Generic;
using Const;
using DG.Tweening;
using Manager;
using UnityEngine;
using UnityEngine.UI;
using Constant = Game.Enums.Constant;

namespace Game.View
{
    public class HumanSkillView : MonoBehaviour
    {
        private List<GameObject> _itemList = new List<GameObject>();
        public Sprite o;
        public Sprite x;
        private Timer _imageTimer;
        private Timer _imageInnerTimer;


        //xxoo 生成xxoo图片到HumanSkill底下
        public void showItem(string code)
        {
            spawnItem(code);
            //修改以有item数据
            showItemCode(code);
        }

        private void spawnItem(string code)
        {
            if (_itemList.Count < code.ToCharArray().Length)
            {
                GameObject go = null;
                foreach (var c in code)
                {
                    spawnNewItem();
                }
            }
        }

        private void spawnNewItem()
        {
            var obj = LoadManager.single.loadAndInstaniate(Constant.HumanSkillItemPrefabPath, transform);
            //var item = obj.AddComponent<HumanSkillSprite>();
            _itemList.Add(obj);
        }

        private void showItemCode(string code)
        {
            for (int i = 0; i < _itemList.Count; i++)
            {
                if (i < code.ToCharArray().Length)
                {
                    changeSprite(code.ToCharArray()[i], _itemList[i]);
                }
                else
                {
                    _itemList[i].SetActive(false);
                }
            }
        }

        private void changeSprite(char code, GameObject item)
        {
            var image = item.GetComponent<Image>();
            image.DOKill();
            image.DOFade(1, .2f);
            if (code == '1')
            {
                //setActive(true);
                item.SetActive(true);
                image.sprite = o;
            }
            else if (code == '2')
            {
                //setActive(true);
                item.SetActive(true);
                image.sprite = x;
            }

            _imageTimer = Timer.Register(1f, () =>
            {
                image.DOFade(0, .2f);
                _imageInnerTimer = Timer.Register(.2f, () => { image.gameObject.SetActive(false); });
            });
        }
    }
}