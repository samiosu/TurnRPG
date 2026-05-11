using UnityEngine;

public class UnitModel : MonoBehaviour
{
    [SerializeField] private string unitName = "unit";
    [SerializeField] private int maxHitPoint = 100;
    [SerializeField] private int nowHitPoint = 100;
    [SerializeField] private int attackPower = 100;
    [SerializeField] private int defensePower = 100;
    [SerializeField] private UnitView unitView;
    [SerializeField] private TextView textView;

    void Start()
    {
        unitView.UpdateUI(maxHitPoint, nowHitPoint);
    }
    public void DecreaseHitPoint(int damage, UnitModel attack)
    {
        nowHitPoint -= damage;
        if(nowHitPoint <= 0)
        {
            nowHitPoint = 0;
            textView.UpdateText($"{attack.unitName}は{unitName}に{damage}ダメージを与えた");
        }
        else
        {
            textView.UpdateText($"{attack.unitName}は{unitName}に{damage}ダメージを与えた");
        }
        unitView.UpdateUI(maxHitPoint, nowHitPoint);
        
    }
    
    public string getUnitName()
    {
        return unitName;
    }
    public int getMaxHitPoint()
    {
        return maxHitPoint;
    }
    public int getNowHitPoint()
    {
        return nowHitPoint;
    }
    public int getAttackPower()
    {
        return attackPower;
    }
    public int getDefensePower()
    {
        return defensePower;
    }
}
