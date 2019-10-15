using DG.Tweening;
using UnityEngine;
using Utils;

namespace Model
{
    public class ComicsItem : MonoBehaviour
    {
        public int page { get; private set; }

        public void init(Sprite sprite,int pageIndex)
        {
            transform.Image().sprite = sprite;
            page = pageIndex;
        }

        public void setParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public void setParentAndPos(Transform parent)
        {
            setParent(parent);
            transform.RectTransform().anchoredPosition = Vector3.zero;
        }

        public void moveToParent(Transform parent)
        {
            setParent(parent);
            transform.RectTransform().DOKill();
            transform.RectTransform().DOAnchorPos(Vector2.zero, 1).SetEase(Ease.Linear);
        }
    }
}