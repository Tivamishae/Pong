public class Cooldown
{
    private DateTime lastUsedTime;
    private TimeSpan cooldownDuration;

    public Cooldown(TimeSpan cooldownDuration)
    {
        this.cooldownDuration = cooldownDuration;
        lastUsedTime = DateTime.MinValue;
    }

    public bool CanUse()
    {
        return (DateTime.Now - lastUsedTime) >= cooldownDuration;
    }

    public void Use()
    {
        lastUsedTime = DateTime.Now;
    }
}