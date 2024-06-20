using UnityEngine;

namespace Combat
{
    public abstract class BattleUnit : MonoBehaviour
    {
        #region Fields & Properties

        [SerializeField] private string unitName;
        [SerializeField] private int maxHp;
        [SerializeField] private int currentHp;
        [SerializeField] private int atk;
        [SerializeField] private float def;
        [SerializeField] private SpriteRenderer spriteRenderer;

        #endregion

        
        #region Public Methods

        public void CreateUnit(UnitData data)
        {
            unitName = data.UnitName;
            maxHp = data.MaxHp;
            currentHp = maxHp;
            atk = data.Atk;
            def = data.Def;
            spriteRenderer.sprite = data.UnitSprite;
        }

        public void Attack(BattleUnit target)
        {
            target.TakeDamage(atk);
        }

        public void TakeDamage(int damage)
        {
            var totalDamage = (int)(damage * (1 - def));
            currentHp -= totalDamage;
            
            if (currentHp <= 0)
                Die();
        }

        #endregion

        
        #region Protected Methods

        protected virtual void Die()
        {
            Debug.Log(unitName + " died");
        }

        #endregion
    }
}