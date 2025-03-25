using UnityEngine;
namespace TowerDefense
{

    public class Health : MonoBehaviour
    {
        public int health = 3;
        public void TakeDamge(int DamageAmount)
        {
            health -= DamageAmount;
        }
        public static void  TryDamage(GameObject target, int damageAmount)
        {

            Health TargetHealth = target.GetComponent<Health>();
            if (target)
            {
                TargetHealth.TakeDamge(damageAmount);

            }
        }
    }
}