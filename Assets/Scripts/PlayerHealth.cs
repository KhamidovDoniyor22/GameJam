using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    [SerializeField] private int health;

    private void Awake()
    {
        Instance = this;
    }
    public void HealthDeacrease(int amount)
    {
        health -= amount;
    }
    public bool CheckHealth()
    {
        if (health > 0) return true;
        else return false;
    }
}
