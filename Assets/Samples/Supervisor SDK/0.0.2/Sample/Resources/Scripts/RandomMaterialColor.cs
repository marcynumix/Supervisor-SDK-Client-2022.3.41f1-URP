using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

namespace Numix.Supervisor
{
    public class RandomMaterialColor : MonoBehaviour
    {
        [SerializeField]
        private Material m_Material;

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

            foreach (var material in gameObject.GetComponent<Renderer>().materials)
            {
                if (material.name.Equals(m_Material.name + " (Instance)"))
                {
                    material.color = randomColor;
                }
            }
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