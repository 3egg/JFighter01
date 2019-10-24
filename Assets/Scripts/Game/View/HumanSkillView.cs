using System;
using System.Collections.Generic;
using Const;
using Manager;
using UnityEngine;
using Constant = Game.Enums.Constant;

namespace Game.View
{
    public class HumanSkillView : MonoBehaviour
    {
        private List<HumanSkillSprite> _itemList = new List<HumanSkillSprite>();

        //xxoo 生成xxoo图片到HumanSkill底下
        private void showItem(string code)
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
            var item = obj.AddComponent<HumanSkillSprite>();
            _itemList.Add(item);
        }

        private void showItemCode(string code)
        {
            for (int i = 0; i < _itemList.Count; i++)
            {
                if (_itemList.Count <= code.ToCharArray().Length)
                {
                    _itemList[i].changeSprite(code.ToCharArray()[i]);
                }
                else
                {
                    _itemList[i].setActive(false);
                }
            }
        }
    }
}