using UnityEngine;
using System.Collections;

public class pWeapon : MonoBehaviour {

    public int damage = 0; //Projectile damage

    public float despawnTime = 0f; //time for it to despawn

    public bool isEnemyWeapon = false; //checks for player or enemy origin

    public bool despawn = true; //check to see if this object should despawn after a certain time.

    public bool weapon = false; //checks to see if the object is a weapon or a character/trap. 

    void Start()
    {
        if (despawn){
            Destroy(gameObject, despawnTime);
        }
    }
}
