using UnityEngine;
namespace TowerDefense
{

    public class Health : MonoBehaviour
    {
      
        public int health = 10;
        public void TakeDamage(int Damage,GameObject target)
        {
        
        
            health -= Damage;
            Player player=target.GetComponent<Player>();
            if (player)
            {
                ValueDisplay.OnValueChanged.Invoke("PlayerHealth", health);

            }
          
        
        }
        public static void  TryDamage(GameObject target, int Damage)
        {

            Health TargetHealth = target.GetComponent<Health>();
            if (TargetHealth)
            {
              
                TargetHealth.TakeDamage(Damage,target);
                

            }
       
        }

    }
}