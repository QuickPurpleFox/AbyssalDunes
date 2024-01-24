using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static Health Instance { get; private set; }
    
    private ParticleSystem _cachedSystem;
    ParticleSystem System
    {
        get
        {
            if (_cachedSystem == null)
                _cachedSystem = GetComponent<ParticleSystem>();
            return _cachedSystem;
        }
    }
    
    [SerializeField]
    private int health;
    [SerializeField]
    private int numberOfHearts;
    [SerializeField]
    private Image[] hearts;
    [SerializeField]
    private Sprite fullHeart;
    [SerializeField]
    private Sprite emptyHeart;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        if (System)
        {
            System.Stop();
        }
    }

    private void Update()
    {
        if (health > numberOfHearts)
        { 
            health = numberOfHearts;
        }

        for(var i = 0; i < hearts.LongLength; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (health < 0)
        {
            
        }
    }

    public void TakeDamage(int damage)
    {
        if (System)
        {
            System.Play();
        }
        health = health - damage;
    }

    public void Heal(int amount)
    {
        health = health + amount;
    }
}
