namespace Combat
{
    public class EnemySelector : CombatSelector
    {
        public void RemoveEnemy(Enemy enemy)
        {
            units.Remove(enemy);
            _maxIndex--;
        }
    }
}