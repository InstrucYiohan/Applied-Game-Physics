using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace lagarde
{
    public class StarPanel : MonoBehaviour
    {
        [SerializeField] private TMP_InputField[] positionInputFields;
        [SerializeField] private TMP_InputField[] directionInputFields;
        [SerializeField] private TMP_InputField moveSpeedInputField;

        [SerializeField] private Star targetStar;

        private void Start()
        {
            DefaultsOnUI();
        }

        public void OnUpdateValues()
        {
            float posX = float.Parse(positionInputFields[0].text);
            float posY = float.Parse(positionInputFields[1].text);
            float posZ = float.Parse(positionInputFields[2].text);

            int dirX = int.Parse(directionInputFields[0].text);
            int dirY = int.Parse(directionInputFields[1].text);
            int dirZ = int.Parse(directionInputFields[2].text);

            float ms = float.Parse(moveSpeedInputField.text);

            Vector3 pos = new Vector3(posX, posY, posZ);
            Vector3 dir = new Vector3(dirX, dirY, dirZ);

            targetStar.UpdateValues(pos, dir, ms);
        }

        public void DefaultsOnUI()
        {
            positionInputFields[0].text = targetStar.transform.position.x.ToString();
            positionInputFields[1].text = targetStar.transform.position.y.ToString();
            positionInputFields[2].text = targetStar.transform.position.z.ToString();

            directionInputFields[0].text = targetStar.MoveDirection.x.ToString();
            directionInputFields[1].text = targetStar.MoveDirection.y.ToString();
            directionInputFields[2].text = targetStar.MoveDirection.z.ToString();

            moveSpeedInputField.text = targetStar.MoveSpeed.ToString();
        }
    }

}