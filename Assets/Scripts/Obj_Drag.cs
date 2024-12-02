using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Obj_Drag : MonoBehaviour
{
    [HideInInspector] public Vector2 SavePosition;
    [HideInInspector] public bool IsOnTopObj;

    Transform SaveObj;

    public int ID;
    public Text text;

    [Space]

    public UnityEvent OnDragRight;

    // Start is called before the first frame update
    void Start()
    {
        SavePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseUp()
    {
        if (IsOnTopObj)
        {
            int ID_PlaceDrop = SaveObj.GetComponent<Place_Drop>().ID;

            if (ID == ID_PlaceDrop)
            {
                transform.SetParent(SaveObj);
                transform.localPosition = Vector3.zero;
                transform.localScale = new Vector2(1f, 1f);

                SaveObj.GetComponent<SpriteRenderer>().enabled = false;
                SaveObj.GetComponent<Rigidbody2D>().simulated = false;
                SaveObj.GetComponent<BoxCollider2D>().enabled = false;

                gameObject.GetComponent<BoxCollider2D>().enabled = false;

                OnDragRight.Invoke();

            }
            else
            {
                transform.position = SavePosition;
            }
        }
    }

    private void OnMouseDrag()
    {
        Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Pos;
    }

    private void OnTriggerStay2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Drop"))
        {
            IsOnTopObj = true;
            SaveObj = trig.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Drop"))
        {
            IsOnTopObj = false;
        }
    }
}
