using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SentenceManager : MonoBehaviour
{
    public static SentenceManager instance;
    public List<string> debut = new List<string>();
    public List<string> fin = new List<string>();

    public Text textSentence;
    public float timer = 0f;

    private void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        TextAsset CSV = Resources.Load<TextAsset>("Sentences");

        string[] line = CSV.text.Split(new char[] { '\n' });

        for(int i = 1; i < line.Length-1; i++)
        {
            string[] part = line[i].Split(new char[] { ';' });

            debut.Add(part[1]);
            fin.Add(part[2]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if( timer >= 5f)
        {
            ChangeSentence();
            timer = 0f;
        }
    }

    public void ChangeSentence()
    {
        string randomDebut = debut[Random.Range(0, debut.Count)];
        string randomFin = fin[Random.Range(0, fin.Count)];

        textSentence.text = randomDebut + " " + randomFin;
    }
}
