using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int level = 1;

    public int currentXP = 0;
    public int xpToNextLevel = 100;

    public int strength = 10;
    public int maxHealth = 100;

    public void GainXP(int amount)
    {
        currentXP += amount;

        Debug.Log("Gained XP: " + amount);

        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;

        currentXP = 0;
        xpToNextLevel += 50;

        strength += 2;
        maxHealth += 10;

        Debug.Log("LEVEL UP! Now level " + level);
    }
}