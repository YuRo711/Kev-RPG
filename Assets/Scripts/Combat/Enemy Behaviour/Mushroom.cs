using System;
using Combat;
using Utils;

namespace Combat
{
    public class Mushroom : Enemy
    {
        private EncounterManager _manager;

        #region Methods

        public override void MakeTurn()
        {
            var targetPos = position;
            var playersTried = 0;
            var totalPlayers = _manager.TotalPlayers();
            
            while (!_manager.TryAttackPlayer(this, targetPos) 
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
            _manager = FindObjectOfType<EncounterManager>();
            Behaviour = new AttackCommand(_manager);
        }

        #endregion
    }
}