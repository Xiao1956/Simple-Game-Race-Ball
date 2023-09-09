using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 15;
    public float turnSpeed = 4;
    private int score = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        SetScoreText();
        setTextState(false);

    }

    void OnTriggerEnter(Collider other)
   {
        if (other.gameObject.CompareTag("Rewards"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetScoreText();
        }
   }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        } else
        {
            float x = Input.GetAxis("Horizontal");
            transform.Translate(x * turnSpeed * Time.deltaTime, 0, speed * Time.deltaTime);
            var camera = Camera.main.transform;
            Quaternion curAngle = camera.rotation;
            Quaternion tarAngle = curAngle * Quaternion.Euler(0, 0, x * 1f);
            Camera.main.transform.rotation = Quaternion.Slerp(curAngle, tarAngle, 0.5f);

            if (transform.position.x < -4 || transform.position.x > 4)
            {
                transform.Translate(0, -10 * Time.deltaTime, 0);
            }
            if (transform.position.y < -20)
            {
                Time.timeScale = 0;
                setTextState(true);
            }
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void setTextState(bool state)
   {
        GameObject canvas = GameObject.Find("Canvas");
        canvas.transform.Find("WinPanel").gameObject.SetActive(false);
        canvas.transform.Find("LosePanel").gameObject.SetActive(state);
   }
}
