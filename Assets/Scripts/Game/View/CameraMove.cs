using DG.Tweening;
using UnityEngine;

namespace Game.View
{
    /// <summary>
    /// 控制相机移动的
    /// </summary>
    public class CameraMove : MonoBehaviour
    {
        public void move(Transform targetParent)
        {
            setParent(targetParent);
            float timeSpeed = 2;
            transform.DOKill();
            transform.DOLocalMove(Vector3.zero, timeSpeed);
            transform.DOLocalRotate(Vector3.zero, timeSpeed);
        }

        public void initCamera(Transform targetParent)
        {
            setParent(targetParent);
            transform.localPosition = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;
        }
        
        public void setParent(Transform targetParent)
        {
            transform.SetParent(targetParent);
        }
    }
}