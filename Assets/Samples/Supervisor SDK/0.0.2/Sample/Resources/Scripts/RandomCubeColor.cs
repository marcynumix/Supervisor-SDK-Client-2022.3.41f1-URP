using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Numix.Supervisor
{
    public class RandomCubeColor : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ApplyRandomColor();
        }

        public void ApplyRandomColor()
        {
            // Color version
            Color randomColor = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );

            GetComponent<MeshRenderer>().material.color = randomColor;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ApplyRandomColor();
            }
        }
    }
}