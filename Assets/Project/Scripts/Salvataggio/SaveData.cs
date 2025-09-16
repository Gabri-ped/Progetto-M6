using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public float[] position = new float[3];
    public float[] rotation = new float[4];
    public int coins;
    public int lifes;

    public SaveData() { } 

    public SaveData(float[] position, float[] rotation, int coins, int lifes)
    {
        this.position = position;
        this.rotation = rotation;
        this.coins = coins;
        this.lifes = lifes;
    }
}
