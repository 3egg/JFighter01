using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.LogicService
{
    public class TrailComboManager : MonoBehaviour
    {
        private string _perfexName = "trail_";
        private Dictionary<int, Transform> _trailsDic;
        private Timer _trailTimer;
        private Transform _trailTemp;

        public void init()
        {
            _trailsDic = new Dictionary<int, Transform>();
            initTrailsDict();
            hideAllTrails();
        }

        public void showTrails(int code)
        {
            setActive(_trailsDic[code], true);
        }

        private void initTrailsDict()
        {
            foreach (Transform trans in transform)
            {
                _trailsDic[getSkillCode(trans.name)] = trans;
            }
        }

        private int getSkillCode(string codeName)
        {
            return PlayerInputSystem.single.getSkillCode(codeName, _perfexName, "");
        }

        public void hideAllTrails()
        {
            foreach (var pair in _trailsDic)
            {
                setActive(pair.Value, false);
            }
        }

        private void setActive(Transform obj, bool isActive)
        {
            if (_trailTemp != null)
            {
                _trailTemp.gameObject.SetActive(false);
            }
            
            _trailTemp = _trailsDic.Values.Where(t => t.Equals(obj)).ToList()[0];
            
            obj.gameObject.SetActive(isActive);
            
            _trailTimer = Timer.Register(0.5f, () => obj.gameObject.SetActive(false));
        }
    }
}