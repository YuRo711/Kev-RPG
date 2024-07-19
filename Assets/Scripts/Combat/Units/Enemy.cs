using System;
using Utils;

namespace Combat
{
    public class Enemy : BattleUnit
    {
        public ICommand Behaviour;
        public int position;

        public virtual void MakeTurn() {}
    }
}