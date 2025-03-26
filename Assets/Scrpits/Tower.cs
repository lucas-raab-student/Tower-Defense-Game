using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class Tower : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemiesInRange = new List<GameObject>();
    public Tower_SO towerType;

    private bool Firing = false;
    GameObject enemyTarget;
    Animator animator;
    public void Start()
    {
        animator = GetComponent<Animator>();

    }
    public void DamageTarget()
    {
        if (!enemyTarget) return;
        Health.TryDamage(enemyTarget, towerType.Damage);
    }

    private void RemvoeDestroyedEnemies()
    {
        int i = 0;
        while (i < enemiesInRange.Count)
        {
            if (enemiesInRange[i]) i++;
            else enemiesInRange.RemoveAt(i);
        }
    }
        IEnumerator DamagEnemyTarget()
        {
            Firing = true;
            while (enemiesInRange.Count > 0)
            {
                enemyTarget = enemiesInRange[0];
                if(enemiesInRange.Count>0) {
                    animator.SetTrigger("Fire");
                    yield return new WaitForSeconds(towerType.firerate);
                }
               

            }
            Firing = false;
        }
         private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy")) enemiesInRange.Add(other.gameObject);
            if (!Firing) StartCoroutine(DamagEnemyTarget());

        }
        private void OnTriggerExit(Collider other)
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }



    


    
