
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
   
        [RequireComponent(typeof(Button))]
        public class TowerButton : MonoBehaviour
        {
        Button button;
        private void OnClick()
        {
            Debug.Log("Im a button");
        }
        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

    }
   
  
}