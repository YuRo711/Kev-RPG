namespace Combat
{
    public class PlayerSelector : CombatSelector
    {
        public void ResetTurns()
        {
            foreach (PlayerUnit unit in units)
            {
                unit.hasMadeTurn = false;
            }
        }

        public override void MoveSelection(int indexChange)
        {
            base.MoveSelection(indexChange);
            while (((PlayerUnit)currentUnit).hasMadeTurn)
            {
                MoveSelection(1);
            }
        }
        
        public override void Activate()
        {
            MoveSelection(1);
            base.Activate();
        }
    }
}