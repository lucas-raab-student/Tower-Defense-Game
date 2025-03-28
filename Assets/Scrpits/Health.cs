using UnityEngine;
namespace TowerDefense
{

    public class Health : MonoBehaviour
    {
      
        public int health = 10;
        public void TakeDamage(int Damage)
        {
        
        
            health -= Damage;
            ValueDisplay.OnValueChanged.Invoke(  "PlayerHealth", health);
        
        }
        public static void  TryDamage(GameObject target, int Damage)
        {

            Health TargetHealth = target.GetComponent<Health>();
            if (TargetHealth)
            {
              
                TargetHealth.TakeDamage(Damage);
                

            }
       
        }

    }
}