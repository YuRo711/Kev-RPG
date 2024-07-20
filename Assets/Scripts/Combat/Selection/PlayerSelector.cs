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
    }
}