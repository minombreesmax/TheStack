using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject Block, Cube, screenButton, GameEnd, PauseMenu, pause;
    public Camera mainCamera;
    public Text score, yourScore, best;
    bool count = false;
    float time = 0;

    public void Start()
    {
        DataHolder.gameOver = false;
        var position = new Vector3(Block.transform.position.x, Block.transform.position.y + 1f, Block.transform.position.z);
        Instantiate(Cube, position, Quaternion.identity);
        screenButton.SetActive(true);
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        pause.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
        DataHolder.score = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        DataHolder.score = 0;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 1f;
    }

    public void CameraMove(float k)
    {
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y + Time.deltaTime / k, mainCamera.transform.position.z);
    }

    public void Count()
    {
        if (count == true)
        {
            time += Time.deltaTime;
        }

        if (time > DataHolder.instantiateTime)
        {
            count = false;
            time = 0;
            CameraMove(0.02f);
            Block.SetActive(true);
            var position = new Vector3(0, Block.transform.position.y + 1, 0);
            Instantiate(Cube, position, Quaternion.identity);
            DataHolder.score++;
        }
    }

    public void BlockOff()
    {
        Block.SetActive(false);
        count = true;
        Block.transform.position = new Vector3(Block.transform.position.x, Block.transform.position.y + 1, Block.transform.position.z);
    }

    public void GameOver()
    {
        if(DataHolder.gameOver)
        {
            screenButton.SetActive(false);
            GameEnd.SetActive(true);
            yourScore.text = $"Your score: {DataHolder.score}";
            DataHolder.best = PlayerPrefs.GetInt("Best");
            DataHolder.best = DataHolder.score > DataHolder.best ? DataHolder.score : DataHolder.best;
            PlayerPrefs.SetInt("Best", DataHolder.best);
            best.text = $"High Score: {PlayerPrefs.GetInt("Best")}";
        }
    }

    void FixedUpdate()
    {
        Count();
        score.text = $"{(int)DataHolder.score}";
        GameOver();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube(Clone)")
        {
            DataHolder.gameOver = true;
        }
    }

}
