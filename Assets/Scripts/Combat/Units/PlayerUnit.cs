using System;
using UnityEngine;

namespace Combat
{
    public class PlayerUnit : BattleUnit
    {
        public bool hasMadeTurn;

        public override void CreateUnit(UnitData data)
        {
            base.CreateUnit(data);
            animator.SetInteger(Animator.StringToHash("Direction"), 1);
        }
    }
}