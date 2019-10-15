using System;
using System.Collections.Generic;
using System.Linq;
using Const;
using Manager;
using Model;
using UnityEngine;
using Utils;

namespace Controller
{
    public class ComicsController : MonoBehaviour
    {
        private readonly Dictionary<ComicsParentId, Transform> _parentDic = new Dictionary<ComicsParentId, Transform>();
        private readonly List<ComicsItem> _itemList = new List<ComicsItem>();
        private readonly Stack<ComicsItem> _rightStack = new Stack<ComicsItem>();
        private readonly Stack<ComicsItem> _leftStack = new Stack<ComicsItem>();
        private ComicsPage _comicsPage;

        private void Start()
        {
            initParent(); //初始化找到对应的父对象,以及他对应的子对象
            initBtns(); //找到button,并给button添加点击事件
            //还要创建一个prefab来做展示图片的物体对象
            spawnItem(); //找到图片,并把图片放到他对应的位置
            initPageNum();
        }

        /*private void initBgAudio()
        {
            var source = GetComponent<AudioSource>();
            source.Play();
        }*/
        
        //初始化page的显示
        private void initPageNum()
        {
            _comicsPage = transform.GetByName("Page").gameObject.AddComponent<ComicsPage>();
            print(_comicsPage);
        }

        private void spawnItem()
        {
            var sprites = getSprites(); //获取到当前关卡的所有comics图片,从resource文件夹里面加载
            spawnCurrentItem(sprites[0]);
            spawnRightItem(sprites);
        }

        private void spawnCurrentItem(Sprite sprite)
        {
            if (_parentDic[ComicsParentId.CurrentComics].childCount == 0)
            {
                instaniateItem(_parentDic[ComicsParentId.CurrentComics], sprite, 0);
            }
        }

        private void spawnRightItem(List<Sprite> sprites)
        {
            for (int i = sprites.Count - 1; i > 0; i--)
            {
                var item = instaniateItem(_parentDic[ComicsParentId.RightComics], sprites[i], i); //负责创建对象
                _rightStack.Push(item); //负责动画切换
            }
        }

        /**
         * 在resource文件夹下找到对应name的prefab并将其添加到对应的parent底下
         */
        private ComicsItem instaniateItem(Transform parent, Sprite sprite, int index)
        {
            var temp = LoadManager.single.loadAndInstaniate(Constant.COMICS_ITEM_PATH, parent);
            ComicsItem item = temp.AddComponent<ComicsItem>();
            item.init(sprite, index);
            return item;
        }

        private List<Sprite> getSprites()
        {
            //找到对应关卡下的所有图片
            var path = Constant.COMICS__PATH + ((int) LevelController.single.levelIndex).ToString("00");
            return LoadManager.single.loadAll<Sprite>(path).ToList();
        }

        //倒带直接跳转,把当前的图片放入最右边
        //左边的图片也房间最右边
        //当前的图片,放第一张图片
        private void backToFirstPage()
        {
            ComicsItem temp;
            temp = getCurrentItem();
            resetRightStack(temp);
            
            int count = _leftStack.Count;
            for (int i = 0; i < count; i++)
            {
                temp = _leftStack.Pop();
               resetRightStack(temp);
            }

            temp = _rightStack.Pop();
            temp.setParentAndPos(_parentDic[ComicsParentId.CurrentComics]);
            _comicsPage.showNumPage(temp.page);
        }

        private void resetRightStack(ComicsItem temp)
        {
            temp.setParentAndPos(_parentDic[ComicsParentId.RightComics]);
            _rightStack.Push(temp);
        }

        private void initBtns()
        {
            transform.AddBtnListener("Back", backToFirstPage);
            transform.AddBtnListener("Left", moveImageToRight);
            transform.AddBtnListener("Right", moveImageToLeft);
            transform.AddBtnListener("Done", () =>
            {
                var loadSceneController = FindObjectOfType<LoadSceneController>();
                loadSceneController.loadScene("03-Level_01");
                loadSceneController.allowSwitchScene();
            });
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

        //对ui暴露一个方法,当前通过点击事件帮当前显示的图片,向左向右移动
        //当前图片向左就是把右边的图片移动到中间,中间的图片移动到左边
        //移动就是改变物体的父物体,然后把物体的位置设置为000,其中父物体要占满整个屏幕
        private void moveImageToLeft()
        {
            if (_rightStack.Count == 0)
            {
                return;
            }

            //当前的图片运动到左边
            var comicsItem = moveStack(ComicsParentId.LeftComics);
            _comicsPage.showNumPage(comicsItem.page);
        }

        private void moveImageToRight()
        {
            if (_leftStack.Count == 0)
            {
                return;
            }

            //当前的图片运动到左边,这里播放切换动画的效果
            var comicsItem = moveStack(ComicsParentId.RightComics);
            _comicsPage.showNumPage(comicsItem.page);
        }

        private ComicsItem moveStack(ComicsParentId id)
        {
            ComicsItem currentItem = getCurrentItem();
            ComicsItem returnItem = null;
            switch (id)
            {
                case ComicsParentId.LeftComics:
                    _leftStack.Push(currentItem);
                    returnItem = _rightStack.Pop();
                    break;
                case ComicsParentId.RightComics:
                    _rightStack.Push(currentItem);
                    returnItem = _leftStack.Pop();
                    break;
            }

            currentItem.moveToParent(_parentDic[id]);
            returnItem.moveToParent(_parentDic[ComicsParentId.CurrentComics]);
            return returnItem;
        }

        private ComicsItem getCurrentItem()
        {
            return _parentDic[ComicsParentId.CurrentComics].GetChild(0).GetComponent<ComicsItem>();
        }
    }
}