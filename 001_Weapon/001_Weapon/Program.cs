
class Weapon
{
    private int _damage;
    private int _bullets;
    private bool _canFire => _bullets > 0;
    public void Fire(Player player)
    {
        if (_canFire == false)
            throw new ArgumentOutOfRangeException(nameof(_bullets));

        player.TakeDamage(_damage);
    }
}
 
class Player
{
    private int _health;
    private bool isAlive => _health > 0;

    public void TakeDamage(int damage)
    {
        if (isAlive == false)
            throw new ArgumentOutOfRangeException(nameof(isAlive));

        _health -= damage;
    }
}

class Bot
{
    private Weapon _weapon = new Weapon();

    public void OnSeePlayer(Player player)
    {
        if (player == null)
            throw new ArgumentNullException(nameof(player));

        _weapon.Fire(player);
    }
}