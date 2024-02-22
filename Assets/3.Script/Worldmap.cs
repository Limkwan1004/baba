using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Worldmap : MonoBehaviour
{
    [SerializeField] GameObject map1;
    [SerializeField] GameObject map2;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Map")
        {
            if (gameObject.transform.position == map1.transform.position) // Ŀ���� 1�� ���� ��
            {
                if (Input.GetKeyDown(KeyCode.RightArrow)) gameObject.transform.position = map2.transform.position;
                if (Input.GetKeyDown(KeyCode.Return)) SceneManager.LoadScene("Tutorial");
            }
            if (gameObject.transform.position == map2.transform.position) // Ŀ���� 2�� ���� ��
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow)) gameObject.transform.position = map1.transform.position;
                if (Input.GetKeyDown(KeyCode.Return)) SceneManager.LoadScene("Map1");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
