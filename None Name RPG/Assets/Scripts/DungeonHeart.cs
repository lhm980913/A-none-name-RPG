using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonHeart : MonoBehaviour {

    public int MaxHealth;
    [SerializeField]
    private int health;

	// Use this for initialization
	void Start () {
        health = MaxHealth;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            health -= 1;
            if (health <= 0)
            {
                Debug.Log("Game Over");
            }
        }
    }

}
