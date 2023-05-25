using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickedButton : MonoBehaviour {
	public string buttonText;

	public QuestionManager QM;
	public void GetButtonText()
	{
        buttonText = GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponent<Button>().GetComponentInChildren<Text>().text;

		QM.clickedButton = buttonText;
		QM.SetAnswer();
		QM.click.Play();
	}
}
