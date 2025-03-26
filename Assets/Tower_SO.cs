using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{



    [CreateAssetMenu]
    public class Tower_SO : ScriptableObject
    {
        public float firerate = 1f;
        public int Damage = 1;
        public int cost = 1;
        public static int GetCost(GameObject gameObject)
        {
            Tower tower = gameObject.GetComponent<Tower>();
            if (tower == null) { return 1000; }
            return tower.towerType.cost;
        }
    }
}