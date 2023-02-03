using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollManager : MonoBehaviour
{
    public int Roll()
    {
        int i = Random.Range(1, 10);
        return i;
    }
}