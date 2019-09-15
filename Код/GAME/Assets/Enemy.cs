using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthMax = 100;
    private int _healthCur = 100;
    public int healthCur
    {
        get { return _healthCur; }
        set { _healthCur = Mathf.Clamp(value, 0, healthMax);  }
    }

    private StatusIndicator statusIndicator;

    private void Start()
    {
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(healthCur, healthMax);
        }
    }

    public void DamageEnemy(int damage)
    {
        healthCur -= damage;
        if (healthCur <= 0)
        {
            GameMaster.KillEnemy(this);
        }

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(healthCur, healthMax);
        }
    }
}
