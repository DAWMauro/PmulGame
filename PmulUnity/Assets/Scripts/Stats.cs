using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField]
    private int damage = 0;
    [SerializeField]
    private float health = 0;
    [SerializeField]
    private float speed = 0.2f;
    [SerializeField]
    private int cost = 0;
    [SerializeField]
    private int reward = 0;

    GameObject canvas;
    [SerializeField]
    Sprite barra;

    private GameObject image;

    private float maxHealth;

    [SerializeField]
    AudioClip deathAudio;

    [SerializeField]
    AudioClip attackAudio;

    private AudioSource audio;

    [SerializeField]
    private bool tower;

    public bool last = false;

    void Start()
    {
        maxHealth = health;
        audio = GetComponent<AudioSource>();
        canvas = GameObject.Find("Canvas");


        //Creacion Imagen
        image = new GameObject();
        image.AddComponent<CanvasRenderer>();
        image.AddComponent<RectTransform>();
        image.AddComponent<Image>();

        //Le metemos cositas
        image.GetComponent<Image>().sprite = barra;
        image.GetComponent<Image>().type = Image.Type.Filled;
        image.GetComponent<Image>().fillMethod = Image.FillMethod.Horizontal;
        image.GetComponent<Image>().fillOrigin = 0;
        
        image.layer = 5;
        image.GetComponent<Image>().SetNativeSize();
        image.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 0.02f, 1);
        image.GetComponent<RectTransform>().sizeDelta = new Vector2(0.7f, 2.5f);

        image.transform.SetParent(canvas.transform);



        image.transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y);

    }

    void Update()
    {
        image.transform.position = new Vector3(transform.position.x, transform.position.y + 0.7f);
    }

    //¿El golpe lo mató? 
    //Si = true
    //No = False
    public bool GetAttack(int damage)
    {       
        health -= damage;
        image.GetComponent<Image>().fillAmount = (health / maxHealth);

        if (health <= 0)
        {
            audio.PlayOneShot(deathAudio);

            if (tower)
            {
                GameObject panel = GameObject.Find("Canvas");
                GameObject losePanel = panel.transform.Find("LosePanel").gameObject;

                losePanel.SetActive(true);
            }

            if (last)
            {
                last = false;
                GameObject panel = GameObject.Find("Canvas");
                GameObject winPanel = panel.transform.Find("WinPanel").gameObject;
                winPanel.SetActive(true);
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public int Attack()
    {
        audio.PlayOneShot(attackAudio);
        return damage;
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public int Cost
    {
        get
        {
            return cost;
        }

    }

    public int Reward
    {
        get
        {
            return reward;
        }

    }

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }
}
