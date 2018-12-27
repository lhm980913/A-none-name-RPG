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
    public float Health ;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        Health = enemyAsset.MaxHealth;
    }

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
        //animator.SetBool("IsDead", true);
        Destroy(this.gameObject);
        return true;
    }

}
