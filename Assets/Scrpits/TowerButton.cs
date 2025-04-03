
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
   
        [RequireComponent(typeof(Button))]
        public class TowerButton : MonoBehaviour
        {
        Button button;
        Player player;
        public GameObject towerPrefab;
        private void OnClick()
        {
            Debug.Log("Im a button");
            player.towerPrefab = towerPrefab;
        }
        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
            player=FindAnyObjectByType<Player>();
        }

    }
   
  
}