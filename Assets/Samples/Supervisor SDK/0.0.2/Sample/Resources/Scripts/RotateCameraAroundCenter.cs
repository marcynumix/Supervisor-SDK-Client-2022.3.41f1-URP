using UnityEngine;

namespace Numix.Supervisor
{
    public class RotateCameraAroundCenter : MonoBehaviour
    {
        [SerializeField]
        private float m_RotationSpeed = 0.1f;

        // Update is called once per frame
        void Update()
        {
            transform.RotateAround(Vector3.zero, Vector3.up, m_RotationSpeed * Time.deltaTime);
        }
    }
}