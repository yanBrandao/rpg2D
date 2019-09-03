using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private Class.ClassType selectedClass;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void OpenGameScene(string type)
    {
        if (type == "Archer")
            selectedClass = Class.ClassType.Archer;
        else if (type == "Warrior")
            selectedClass = Class.ClassType.Warrior;
        else if (type == "Mage")
            selectedClass = Class.ClassType.Mage;

        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public Class.ClassType getClassType()
    {
        return selectedClass;
    }
}
