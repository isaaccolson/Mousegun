using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawnerTest : MonoBehaviour
{
    void Start()
    {
        //TextSpawnManager.Instance.SpawnText(transform.position, "Escape if you can little Mouse!");
        StartCoroutine(GetComponent<TextEffects>().FlashRed(Color.black,5,false));
   }

}
