using UnityEngine;

namespace Combat
{
    public abstract class BattleUnit : MonoBehaviour, IBattleSelectable
    {
        #region Fields

        private string unitName;
        private int maxHp;
        private int currentHp;
        private int atk;
        private float def;
        private float critProbability;
        
        private bool _isChosen;
        
        private int animatorAttackHash;
        private int animatorHitHash;
        
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private UnitPointer pointer;
        [SerializeField] private HealthBar healthBar;
        [SerializeField] protected Animator animator;
        [SerializeField] private GameObject fadingText;

        #endregion

        
        #region Public Methods

        public virtual void CreateUnit(UnitData data)
        {
            unitName = data.UnitName;
            maxHp = data.MaxHp;
            currentHp = maxHp;
            atk = data.Atk;
            def = data.Def;
            critProbability = data.CritProbability;
            spriteRenderer.sprite = data.UnitSprite;
            animator.runtimeAnimatorController = data.animatorController;
            animatorAttackHash = Animator.StringToHash(data.animatorAttackName);
            animatorHitHash = Animator.StringToHash(data.animatorHitName);
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
            var randomFloat = Random.Range(0f, 1f);
            var damage = atk;
            
            if (randomFloat <= critProbability)
            {
                damage *= 2;
                Debug.Log("critical damage!");
            }
            
            target.TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            PlayHitAnimation();
            var totalDamage = (int)(damage * (1 - def));
            currentHp -= totalDamage;
            UpdateHealth();
            CreateFadingText(damage.ToString(), Color.red);
            
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

        protected void PlayHitAnimation()
        {
            animator.Play(animatorHitHash);
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

        protected void CreateFadingText(string text, Color textColor)
        {
            var fadingTextObject = Instantiate(fadingText, transform);
            fadingTextObject.GetComponent<FadingText>().SetText(text, textColor);
        }

        #endregion
    }
}