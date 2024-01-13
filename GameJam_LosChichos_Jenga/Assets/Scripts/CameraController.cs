using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform m_LookAt;
    public Vector3 m_WhereToLook;
    public float m_MinDistance = 4f;
    public float m_MaxDistance = 7f;
    public float m_RotationalYawSpeed;
    public float m_RotationalPitchSpeed;
    public float m_MinPitch;
    public float m_MaxPitch;
    public float m_OffsetY = 3f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        m_WhereToLook = new Vector3 (m_LookAt.position.x,m_LookAt.position.y+m_OffsetY,m_LookAt.position.z);
        transform.LookAt(m_WhereToLook);
        float l_Distance = Vector3.Distance(transform.position, m_WhereToLook);
        Vector3 l_EulerAngles = transform.rotation.eulerAngles;
        float l_Yaw = l_EulerAngles.y * Mathf.Deg2Rad;
        float l_Pitch = l_EulerAngles.x * Mathf.Deg2Rad;
        if (l_Pitch > Mathf.PI)
            l_Pitch -= 2f * Mathf.PI;

        float l_MouseX = Input.GetAxis("Mouse X");
        float l_MouseY = Input.GetAxis("Mouse Y");

        l_Yaw = l_Yaw + l_MouseX * (m_RotationalYawSpeed * Mathf.Deg2Rad) * Time.deltaTime;
        l_Pitch = l_Pitch + l_MouseY * (m_RotationalPitchSpeed * Mathf.Deg2Rad) * Time.deltaTime;
        l_Pitch = Mathf.Clamp(l_Pitch, m_MinPitch * Mathf.Deg2Rad, m_MaxPitch * Mathf.Deg2Rad);
        Vector3 l_Forward = new Vector3(Mathf.Sin(l_Yaw) * Mathf.Cos(-l_Pitch), Mathf.Sin(-l_Pitch), Mathf.Cos(l_Yaw) * Mathf.Cos(-l_Pitch));
        l_Distance = Mathf.Clamp(l_Distance, m_MinDistance, m_MaxDistance);
        Vector3 l_DesiredPosition = m_WhereToLook - l_Forward * l_Distance;

        transform.position = l_DesiredPosition;
        transform.LookAt(m_WhereToLook);

    }
}
