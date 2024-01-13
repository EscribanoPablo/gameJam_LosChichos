using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform m_LookAt;
    public float m_MinDistance = 4f;
    public float m_MaxDistance = 7f;
    public float m_RotationalYawSpeed;
    public float m_RotationalPitchSpeed;
    public float m_MinPitch;
    public float m_MaxPitch;
    public LayerMask m_AvoidObstaclesLayerMask;
    public float m_OffsetAvoidObstacle;

    private void LateUpdate()
    {

        transform.LookAt(m_LookAt.position);
        float l_Distance = Vector3.Distance(transform.position, m_LookAt.position);
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
        Vector3 l_DesiredPosition = m_LookAt.position - l_Forward * l_Distance;

        Ray l_Ray = new Ray(m_LookAt.position, -l_Forward);
        RaycastHit l_RaycastHit;
        if (Physics.Raycast(l_Ray, out l_RaycastHit, l_Distance, m_AvoidObstaclesLayerMask.value))
        {
            l_DesiredPosition = l_RaycastHit.point + l_Forward * m_OffsetAvoidObstacle;
        }

        transform.position = l_DesiredPosition;
        transform.LookAt(m_LookAt.position);

    }
}
