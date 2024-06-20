using UnityEngine;

namespace Combat
{
    public abstract class BattleUnit : MonoBehaviour
    {
        #region Fields & Properties

        private string unitName;
        private int maxHp;
        private int currentHp;
        private int atk;
        private float def;
        private EncounterManager _manager;
        [SerializeField] private SpriteRenderer spriteRenderer;

        #endregion

        
        #region Public Methods

        public void CreateUnit(UnitData data, EncounterManager manager)
        {
            unitName = data.UnitName;
            maxHp = data.MaxHp;
            currentHp = maxHp;
            atk = data.Atk;
            def = data.Def;
            spriteRenderer.sprite = data.UnitSprite;
            _manager = manager;
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