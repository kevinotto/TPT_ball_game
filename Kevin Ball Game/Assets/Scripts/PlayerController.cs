using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text ScoreText;
    public Text winText;
    public GameObject Gate1;
    private Rigidbody rb;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        Score = 0;
        SetScoreText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement*speed);

        //Restart level
        if(Input.GetKeyDown(KeyCode.R)) 
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        //Quit game
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            Score+= 100;
            SetScoreText();
            if(Score == 100) 
            {
                Gate1.gameObject.SetActive(false);
            }
        }

        if (other.gameObject.tag == "danger")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void SetScoreText()
    {
        ScoreText.text = "Score: " + Score.ToString();
        ScoreText.color = Color.yellow;
        if (Score >= 1000)
        {
            winText.text = "YOU WON!!!!!! YAY!!!!!!!! R to restart and ESC to quit";
        }
    }
}
