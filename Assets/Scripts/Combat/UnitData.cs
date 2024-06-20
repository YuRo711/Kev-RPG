using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(menuName = "Unit data")]
    public class UnitData : ScriptableObject
    {
        public string UnitName => unitName;
        [SerializeField] private string unitName;

        public Sprite UnitSprite => unitSprite;
        [SerializeField] private Sprite unitSprite;

        public int MaxHp => maxHp;
        [SerializeField] private int maxHp;
        
        public int Atk => atk;
        [SerializeField] private int atk;
        
        public float Def => def;
        [SerializeField] private float def;
    }
}