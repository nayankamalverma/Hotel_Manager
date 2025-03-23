using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UIService : MonoBehaviour
    {

        [Header("Game Play UI")]
        [SerializeField] private TextMeshProUGUI dollarText;

        private void Start()
        {
            UpdateDollarText();
        }

        private void Update()
        {
            UpdateDollarText();
        }

        private void UpdateDollarText()
        {
            dollarText.text = "$ " + PlayerPrefs.GetInt("dollar"); 
        }
    }
}