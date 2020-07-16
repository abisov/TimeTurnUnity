public class CharacterStats
{
    private int type;
    private int range;
    private float health;
    private float damage;

    public int Type
    {
        get { return this.type; }
        set { this.type = value; }
    }

    public int Range
    {
        get { return this.range; }
        set { this.range = value; }

    }

    public float Health
    {
        get { return this.health; }
        set { this.health = value; }
    }

    public float Damage
    {
        get { return this.damage; }
        set { this.damage = value; }
    }
}
