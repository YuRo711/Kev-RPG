using System;
using Combat;
using Utils;

namespace Combat
{
    public class Mushroom : Enemy
    {
        #region Methods

        public override void MakeTurn()
        {
            var targetPos = position;
            var playersTried = 0;
            var totalPlayers = Manager.TotalPlayers();
            
            while (!Manager.TryAttackPlayer(this, targetPos) 
                   && playersTried < totalPlayers)
            {
                playersTried++;
                targetPos = (targetPos + 1) % totalPlayers;
            }
            
            if (playersTried < totalPlayers)
                PlayAttackAnimation();
        }

        #endregion

        #region MonoBehaviour Callbacks

        private void Start()
        {
            Manager = FindObjectOfType<EncounterManager>();
            Behaviour = new AttackCommand(Manager);
        }

        #endregion
    }
}