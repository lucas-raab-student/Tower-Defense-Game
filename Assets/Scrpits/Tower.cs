using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]private List<GameObject> enemiesInRange = new List<GameObject>();
    public Tower_SO towerType;

    private bool Firing=false;
    IEnumerator DamagEnemyTarget()
    {
        Firing = true;
        while(enemiesInRange.Count > 0)
        {
            if (!enemiesInRange[0]) enemiesInRange.RemoveAt(0);
            else Health.TryDamage(enemiesInRange[0], towerType.damage);
            yield return new WaitForSeconds(towerType.firerate);
            
        }
        Firing = false;
    }


    private void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.CompareTag("Enemy")) enemiesInRange.Add(other.gameObject);
        if (!Firing)  StartCoroutine(DamagEnemyTarget());

    }
    public void OnTriggerExit(Collider other)
    {
        enemiesInRange.Remove(other.gameObject);
    }

}
