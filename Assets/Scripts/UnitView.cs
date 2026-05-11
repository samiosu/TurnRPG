using UnityEngine;
using UnityEngine.UI;

public class UnitView : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Slider slider;
    
    public void UpdateUI(int maxHitPoint, int nowHitPoint)
    {
        text.text = nowHitPoint + " / " + maxHitPoint;
        slider.maxValue = maxHitPoint;
        slider.value = nowHitPoint;
    }
}