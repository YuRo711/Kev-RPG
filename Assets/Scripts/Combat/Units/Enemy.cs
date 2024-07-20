using System;
using Utils;

namespace Combat
{
    public class Enemy : BattleUnit
    {
        protected EncounterManager Manager;
        public ICommand Behaviour;
        public int position;

        public virtual void MakeTurn() {}
        
        protected override void Die()
        {
            Manager.RemoveEnemy(this);
            base.Die();
        }
    }
}