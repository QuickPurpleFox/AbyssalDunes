using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private Animator _animator;
    private bool _isAlive;
    
    [SerializeField]
    private HealtObject health;
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

    private void Start()
    {
        _animator = gameObject.GetComponent<PlayerMovement>().animator;
    }

    private void Update()
    {
        if (health.healthPoints > numberOfHearts)
        { 
            health.healthPoints = numberOfHearts;
        }

        for(var i = 0; i < hearts.LongLength; i++)
        {
            if(i < health.healthPoints)
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

        if (health.healthPoints < 0)
        {
            StartCoroutine(PlayerDead());
            SceneManager.LoadScene("EndScene");
        }
    }

    public void TakeDamage(int damage)
    {
        if (System)
        {
            System.Play();
        }
        health.healthPoints = health.healthPoints - damage;
    }

    public void Heal(int amount)
    {
        health.healthPoints = health.healthPoints + amount;
    }

    private IEnumerator PlayerDead()
    {
        gameObject.GetComponent<PlayerMovement>().isAlive = false;
        yield return new WaitForSeconds(9);
    }
}
