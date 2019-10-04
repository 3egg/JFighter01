using System;
using System.Collections.Generic;
using System.Linq;
using Const;
using Manager;
using model;
using UnityEngine;
using Utils;

namespace Controller
{
    public class ComicsController : MonoBehaviour
    {
        private readonly Dictionary<ComicsParentId, Transform> _parentDic = new Dictionary<ComicsParentId, Transform>();
        private readonly List<ComicsItem> _itemList = new List<ComicsItem>();

        private void Start()
        {
            initParent(); //初始化找到对应的父对象,以及他对应的子对象
            initBtns();
            //还要创建一个prefab来做展示图片的物体对象
            spawnItem(); //找到图片,并把图片放到他对应的位置
        }

        private void spawnItem()
        {
            ComicsItem item;
            foreach (var sprite in getSprites())
            {
                if (_itemList.Count == 0)
                {
                    item = instaniateItem(_parentDic[ComicsParentId.CurrentComics], sprite);
                }
                else
                {
                    item = instaniateItem(_parentDic[ComicsParentId.RightComics], sprite);
                }

                _itemList.Add(item);
            }
        }

        private ComicsItem instaniateItem(Transform parent, Sprite sprite)
        {
            var temp = LoadManager.single.loadAndInstaniate(Constant.COMICS_ITEM_PATH, parent);
            ComicsItem item = temp.AddComponent<ComicsItem>();
            item.init(sprite);
            return item;
        }

        private List<Sprite> getSprites()
        {
            //找到对应关卡下的所有图片
            var path = Constant.COMICS__PATH + ((int) LevelController.single.levelIndex).ToString("00");
            return LoadManager.single.loadAll<Sprite>(path).ToList();
        }

        public void initBtns()
        {
            transform.AddBtnListener("Back", () => { });
            transform.AddBtnListener("Left", () => { });
            transform.AddBtnListener("Right", () => { });
            transform.AddBtnListener("Done", () => { });
        }

        //找到parent底下名字叫做 LeftComics,CurrentComics,RightComics的物体
        private void initParent()
        {
            Transform parent = transform.GetByName("Parent");
            if (parent == null)
                return;

            Transform temp;
            foreach (ComicsParentId id in Enum.GetValues(typeof(ComicsParentId)))
            {
                var list = from Transform child in parent where child.name.Contains(id.ToString()) select child;
                temp = list.FirstOrDefault();
                if (temp == null)
                {
                    Debug.LogError("can not find child name:" + id);
                    continue;
                }
                else
                {
                    _parentDic[id] = temp;
                }
            }
        }
    }
}