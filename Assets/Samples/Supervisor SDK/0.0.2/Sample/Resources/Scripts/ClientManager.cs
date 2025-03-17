using UnityEngine;

namespace Numix.Supervisor
{
    public class ClientManager : MonoBehaviour
    {
        public GameObject m_Cube;

        public GameObject m_ServerNodePrefab;

        public float m_CameraDistance = 5f;

        public int m_Size = 1;

        public int m_StartPort = 40000;

        private void Awake()
        {
            string[] args = System.Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-startPort")
                {
                    m_StartPort = int.Parse(args[i + 1]);
                }

                if (args[i] == "-renderTextures")
                {
                    m_Size = int.Parse(args[i + 1]);
                }
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            var points = PointSphereDistribution.PointsOnSphere(m_Size);

            for (int i = 0; i < m_Size; i++)
            {
                GameObject go = new GameObject();
                var camera = go.AddComponent<Camera>();

                camera.targetDisplay = i;

                go.transform.position = points[i] * m_CameraDistance;
                go.transform.LookAt(Vector3.zero);
                go.name = $"Camera_{i}";

                var serverNode = Instantiate(m_ServerNodePrefab);
                serverNode.name = $"ClientNode_{i}";

                var nm = serverNode.GetComponentInChildren<NetworkManagerClient>();
                nm.ServerSettings.ServerListenPort = m_StartPort + 2 * i;
                nm.ClientSettings.ClientListenPort = m_StartPort + 2 * i + 1;

                nm.OnReceivedStringDataEvent.AddListener(text =>
                {
                    m_Cube.GetComponent<RandomCubeColor>().ApplyRandomColor();
                });

                var encoder = serverNode.GetComponentInChildren<GameViewEncoder>();
                encoder.RenderCam = camera;

                camera.transform.SetParent(serverNode.transform, false);
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}