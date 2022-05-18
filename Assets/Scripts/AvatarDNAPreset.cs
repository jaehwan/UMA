using System.Collections;
using System.Collections.Generic;
using UMA;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "�ƹ�Ÿ/DNA������", order = 1)]

public class AvatarDNAPreset : ScriptableObject
{
    [System.Serializable]
    public class DnaValue
    {
        public string dnaName;
        public float dnaValue;
    };

    public Sprite thumbNail;
    public DnaValue [] dnaValues;
}
