using UnityEngine;
using UnityEngine.UIElements;

public class Movements : MonoBehaviour
{
    public float speed;
    public float start;
    public float end;

    public bool isVertical;
    public float top, bottom;

    GameObject star;
    void Start()
    {
        if(transform.childCount>2)
        star = transform.GetChild(2).gameObject;
    }
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if (transform.position.x <= end)
        {
            if (isVertical)
            {
                float y = Random.Range(top, bottom);
                transform.position = new Vector2(start, y);
            }
            else { 
                transform.position= new Vector2(start, transform.position.y);
            }

            if (star != null)
            {
                star.SetActive(Random.Range(0, 3) == 0);//4
            }

            if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    Application.Quit();
                }
            }
        }
    }
}
