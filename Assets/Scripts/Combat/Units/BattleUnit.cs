using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Combat
{
    public abstract class BattleUnit : MonoBehaviour, IBattleSelectable
    {
        #region Fields & Properties

        private string unitName;
        private int maxHp;
        private int currentHp;
        private int atk;
        private float def;
        
        private bool _isChosen;
        private int animatorAttackHash;
        
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private UnitPointer pointer;
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private Animator animator;
        [SerializeField] private string animatorAttackName;

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
            animatorAttackHash = Animator.StringToHash(animatorAttackName);
            pointer.SetVisibility(false);
        }

        public void Select()
        {
            pointer.SetVisibility(true);
        }

        public void Deselect()
        {
            pointer.SetVisibility(false);
        }

        public void Attack(BattleUnit target)
        {
            target.TakeDamage(atk);
        }

        public void TakeDamage(int damage)
        {
            var totalDamage = (int)(damage * (1 - def));
            currentHp -= totalDamage;
            UpdateHealth();
            Debug.Log(unitName + " took damage");
            
            if (currentHp <= 0)
                Die();
        }

        public bool IsAlive() => currentHp > 0;

        #endregion

        
        #region Protected Methods

        protected void PlayAttackAnimation()
        {
            animator.Play(animatorAttackHash);
        }
        
        protected virtual void Die()
        {
            Destroy(gameObject);
            Debug.Log(unitName + " died");
        }

        protected virtual void UpdateHealth()
        {
            healthBar.UpdateSlider((float)currentHp / maxHp);
        }

        #endregion
    }
}