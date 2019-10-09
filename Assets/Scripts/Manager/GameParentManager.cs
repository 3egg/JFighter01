using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    /// <summary>
    /// 场景内父物体管理类
    /// </summary>
    public class GameParentManager : MonoBehaviour
    {
        private Dictionary<string, Transform> parentDic;

        public void init()
        {
            parentDic = new Dictionary<string, Transform>();
            foreach (Transform trans in transform)
            {
                parentDic[trans.name] = trans;
            }
        }
        public Transform getParentTrans(ParentName parentName)
        {
            Transform parent = null;
            parentDic.TryGetValue(parentName.ToString(), out parent);
            return parent;
        }
        public Transform getParentTrans(string parentName)
        {
            Transform parent = null;
            parentDic.TryGetValue(parentName, out parent);
            return parent;
        }
    }

    public enum ParentName
    {
        PlayerRoot,
        CameraController,
    }
}