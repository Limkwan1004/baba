using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubjectWin : SubjectActive
{
    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(6))
        {
            SubjectMachine submachine = collision.gameObject.GetComponent<SubjectMachine>();
            if (submachine.subject_Type.Equals(Subject_Type.Win))
            {
                SceneManager.LoadScene("Map");
            }
        }
    }
}
