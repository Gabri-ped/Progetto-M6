using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Obj/Data")]
public class ScriptobleObjects : ScriptableObject
{
    public string ID;
    public GameObject PreFab;
    public int StartPool = 5;
}

