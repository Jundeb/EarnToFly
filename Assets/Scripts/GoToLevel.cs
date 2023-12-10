using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
	public Button goToLevelButton;

	void Start () {
		Button btn = goToLevelButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		SceneManager.LoadScene("ForestLevel");
	}
}