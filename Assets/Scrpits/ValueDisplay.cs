
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace TowerDefense
{
    [RequireComponent(typeof(Text))]
    public class ValueDisplay : MonoBehaviour
    {
        private void Awake()
        {
            DisplayText=GetComponent<Text>();
            OnValueChanged.AddListener(ValueChanged);
        }

        public static UnityEvent<string,object> OnValueChanged= new UnityEvent<string,object>();

        [SerializeField] private string ValueName="";
        private Text DisplayText;
        void ValueChanged(string valueName,object value)
        {
           
            if(this.ValueName==valueName)
            {
                DisplayText.text=value.ToString();
            }
        }

    }
}