using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird_Movement : MonoBehaviour
{
    /* public float Speed;
     Vector3 pos;*/
    public float jumpForce;
    Rigidbody2D rb;
    public Text StarText, Star;
    private int StarCount = 0;
    public GameObject Win;
    void Start()
    {
        /*pos= transform.position;*/
        rb = GetComponent<Rigidbody2D>();
        UpdateCoinText();
    }
    void Update()
    {
        /*pos.x += Speed * Time.deltaTime;
        transform.position = pos;*/
        if (Input.GetKeyDown(KeyCode.Mouse0))//Space
        {
            rb.linearVelocityY = jumpForce;
        }

       
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Star")
        {
            // Destroy coin
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);

            // Increment coin count
            StarCount++;
            UpdateCoinText();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Win.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    private void UpdateCoinText()
    {
        StarText.text =StarCount.ToString();//"Coins :  " +
        Star.text = "Stars :- " + StarCount.ToString();
    }
    public void OnRestartButtonClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Flappy Bird");
    }
}
