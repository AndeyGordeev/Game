using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameMaster.Gm.spawnPoint.position = FindObjectOfType<Play>().transform.position;
    }
}
