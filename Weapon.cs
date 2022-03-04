
using System;

class Weapon
{
    private readonly int _damage;
    private int _bullets;
    private bool _canFire => _bullets > 0;

    public void Fire(Player player)
    {
        if (_canFire == false)
            throw new ArgumentOutOfRangeException(nameof(_bullets));

        player.TakeDamage(_damage);
        _bullets--;
    }
}

interface IDamageable
{
    void TakeDamage(int damage);
}

class Health : IDamageable
{
    public int Value { get; private set; }
    private bool _isAlive => Value > 0;
    public void TakeDamage(int damage)
    {
        if (_isAlive == false)
            throw new ArgumentOutOfRangeException(nameof(_isAlive));

        Value -= damage;
    }
}
class Player : IDamageable
{
    private Health _health;

    public Player(Health health)
    {
        _health = health;
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}

class Bot
{
    private readonly Weapon _weapon;

    public Bot(Weapon weapon)
    {
        _weapon = weapon;
    }
    public void OnSeePlayer(Player player)
    {
        if (player == null)
            throw new ArgumentNullException(nameof(player));
        if (_weapon == null)
            throw new ArgumentNullException(nameof(_weapon));

        _weapon.Fire(player);
    }
}