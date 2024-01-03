using UnityEngine;

public class ShaderController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial; // �������� Material ����
    private Material currentMaterial; // ���� ��� ���� Material

    public float decreaseSpeed = 0.1f; // ���� �ӵ� ���� ����

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material; // �������� Material�� ����
        currentMaterial = new Material(originalMaterial); // �������� Material�� ������ ���ο� Material �ν��Ͻ� ����
        spriteRenderer.material = currentMaterial; // ���纻�� ���� Material�� ����
    }

    public void ShaderOn()
    {
        float currentSplitValue = currentMaterial.GetFloat("_SplitValue");
        currentSplitValue -= decreaseSpeed * Time.deltaTime;

        currentMaterial.SetFloat("_SplitValue", currentSplitValue);

    }
}
