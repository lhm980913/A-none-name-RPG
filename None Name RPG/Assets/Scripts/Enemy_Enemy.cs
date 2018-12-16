using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IActor
{
    bool BeAttacked(float damage);
    bool Dead();
}

public class Enemy_Enemy : MonoBehaviour,IActor {
    
    public EnemyAsset enemyAsset;
    private float Health = 10;

    public bool BeAttacked(float damage)
    {
        if(Health - damage <= 0)
        {
            Dead();
        }
        else
        {
            Health -= damage;
        }
        return true;
    }

    public bool Dead()
    {
        Debug.Log("Dead");
        Destroy(this.gameObject);
        return true;
    }

}
