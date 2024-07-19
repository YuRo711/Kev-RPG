using System;
using Combat;
using Utils;

namespace Combat
{
    public class Mushroom : Enemy
    {
        private readonly EncounterManager _manager;

        #region Methods

        public override void MakeTurn()
        {
            var targetPos = position;
            var playersTried = 1;
            var totalPlayers = _manager.TotalPlayers();
            
            while (_manager.TryAttackPlayer(this, targetPos) 
                   && playersTried < totalPlayers)
            {
                playersTried++;
                targetPos = (targetPos + 1) % totalPlayers;
            }
        }

        #endregion

        #region MonoBehaviour Callbacks

        private void Start()
        {
            Behaviour = new AttackCommand(_manager);
        }

        #endregion
    }
}