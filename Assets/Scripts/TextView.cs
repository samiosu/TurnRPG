using UnityEngine;
using UnityEngine.UI;

public class TextView : MonoBehaviour
{
    [SerializeField] private Text text;
    
    public void UpdateText(string log)
    {
        text.text = log;
    }
}
