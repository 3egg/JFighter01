using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class SkillModel
    {
        public List<Skills> Skills;
    }

    [Serializable]
    public class Skills
    {
        public string Code;
        public int Level;
    }
}