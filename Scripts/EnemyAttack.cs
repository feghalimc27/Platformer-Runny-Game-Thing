using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public string player = "";
    public float attackDistance = 0;

    private bool proc = false;

    private GameObject procObject;

	// Use this for initialization
	void Start () {
        procObject = GameObject.Find(player);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (Mathf.Abs(procObject.transform.position.x - transform.position.x) <= attackDistance)
        {
            proc = true;
        }

        if (proc)
        {
            WeaponSpawn weapon = GetComponent<WeaponSpawn>();
            if (weapon != null)
            {
                weapon.Attack(true); // true because this is an enemy
                proc = false;
            }
        }
    }
}
