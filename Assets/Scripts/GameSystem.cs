using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;

    [Header("Data Play")]
    public bool GameActive;
    public int Target;
    public int DataLevel, DataScore, DataTime, DataBlood;



    [Header("Component UI")]
    public Text Text_Level;
    public Text Text_Time, Text_Score;
    public RectTransform UI_Blood;


    [Space]
    public bool systemRandom;

    [System.Serializable]
    public class DataGame
    {
        public string Name;
        public Sprite Picture;
    }

    [Header("Setting Standard")]
    public DataGame[] DataPlay;

    [Space]
    public Obj_PlaceDrop[] Drop_Place;
    public Obj_Drag[] Drag_Obj;



    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        RandomQuestion(); 
    }

    [HideInInspector]public List<int> _RandomQuestion = new List<int>();
    [HideInInspector]public List<int> _RandomPos = new List<int>();
    int rand;
    int rand2;

    public void RandomQuestion()
    {
        _RandomQuestion.Clear();
        _RandomPos.Clear();

        _RandomQuestion = new List<int>(new int[Drag_Obj.Length]);

        for(int i = 0; i < _RandomQuestion.Count; i++)
        {
            rand = Random.Range(1, DataPlay.Length);
            while(_RandomQuestion.Contains(rand))
            
                rand = Random.Range(1, DataPlay.Length);

                _RandomQuestion[i] = rand;

            Drag_Obj[i].ID = rand - 1;
            Drag_Obj[i].text.text = DataPlay[rand - 1].Name;
        }

        _RandomPos = new List<int>(new int[Drop_Place.Length]);

        for (int i = 0; i < _RandomPos.Count; i++)
        {
            rand2 = Random.Range(1,_RandomQuestion.Count+1);
            while(_RandomPos.Contains(rand2))

                rand2 = Random.Range(1, _RandomQuestion.Count + 1);

            _RandomPos[i] = rand2;

            Drop_Place[i].Drop.ID = _RandomQuestion[rand2 - 1] - 1;
            Drop_Place[i].Picture.sprite = DataPlay[Drop_Place[i].Drop.ID].Picture;
        }

    }

    float s;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            RandomQuestion();

        if(GameActive)
        {
            if(DataTime > 0)
            {
                s += Time.deltaTime;
                if(s >= 1)
                {
                    DataTime--;
                    s = 0;
                }
            }
        }

        SetInfoUI();    
    }

    public void SetInfoUI()
    {
        Text_Level.text = (DataLevel + 1).ToString();

        int Minute = Mathf.FloorToInt(DataTime / 60);
        int Seconds = Mathf.FloorToInt(DataTime % 60);
        Text_Time.text = Minute.ToString("00:") + Seconds.ToString("00");

        Text_Score.text = DataScore.ToString();

        UI_Blood.sizeDelta = new Vector2(183f * DataBlood, 166f);
    }
}
