using UnityEngine;
using System.Collections;

public class pWeapon : MonoBehaviour {

    public int damage = 0; //Projectile damage

    public float despawnTime = 0f; //time for it to despawn

    public bool isEnemyWeapon = false; //checks for player or enemy origin

    void Start()
    {
        Destroy(gameObject, despawnTime);
    }
}
