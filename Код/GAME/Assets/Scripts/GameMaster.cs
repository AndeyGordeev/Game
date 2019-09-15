using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    
    public static void KillPlayer(Play player)
    {
        Destroy(player);
    }

}
