using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "skill Card", menuName = "new skill")]
public class skillObject : ScriptableObject
{

    public int hits;
    public int chance;
    public int damage;
    public int cost;

}