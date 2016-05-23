using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int hp = 1; //Health Count

    public bool isEnemy = true; //Player or enemy

    public void Damage(int damageCount){ //Function that applies damage to the object
        hp -= damageCount;

        if (hp <= 0){ //Death Event
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider) //Activates for collision with a Trigger Object
    {
        pWeapon shot = otherCollider.gameObject.GetComponent<pWeapon>(); // Creates shot variable that grabs elements from the Projectile Script

        if (shot != null){ //Check for shot to be a real game object and not a ghost object
            if (shot.isEnemyWeapon != isEnemy){ //Checks for friendly fire. Only applies when enemies
                Damage(shot.damage);
                if (shot.weapon){
                    Destroy(shot.gameObject); //Destroys the projectile on impact
                }
            }
        }
    }
}
