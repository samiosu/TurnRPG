using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    // インスタンスを置ける箱
    private InputSystem inputActions;
    // Modelの情報を取得してダメージの計算を行う
    [SerializeField] private UnitModel player;
    [SerializeField] private UnitModel enemy;
    [SerializeField] private TextView textView;
    private int state = 0;
    // inputActions使えるようにする
    void Start()
    {
        inputActions = new InputSystem();
        inputActions.Battle.Attack.started += OnAttack;
        inputActions.Enable();
    }
    // 終了するときの安全処理
    void OnDestroy()
    {
        inputActions.Disable();
        inputActions.Battle.Attack.started -= OnAttack;
        inputActions?.Dispose();
    }
    // 攻撃ボタンを押したときの処理
    void OnAttack(InputAction.CallbackContext context)
    {
        switch (state)
        {
            // playerの攻撃
            case 0:
                textView.UpdateText($"{player.getUnitName()}の攻撃");
                break;
            // playerはenemyに25ダメージを与えた
            case 1:
                DamageCalculation(player, enemy);
                break;
            // enemyの攻撃
            case 2:
                textView.UpdateText($"{enemy.getUnitName()}の攻撃");
                break;
            // enemyはplayerに25ダメージ与えた
            case 3:
                DamageCalculation(enemy, player);
                break;
        }
        state ++;
        state %= 4;
        
    }

    // ダメージ計算
    void DamageCalculation(UnitModel attack, UnitModel defence)
    {
        int damage = attack.getAttackPower() / 2 - defence.getDefensePower() / 4;
        defence.DecreaseHitPoint(damage, attack);
    }
}
