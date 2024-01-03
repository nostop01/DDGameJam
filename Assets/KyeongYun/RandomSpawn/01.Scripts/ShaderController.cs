using UnityEngine;

public class ShaderController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial; // 오리지널 Material 저장
    private Material currentMaterial; // 현재 사용 중인 Material

    public float decreaseSpeed = 0.1f; // 감소 속도 조절 변수

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material; // 오리지널 Material을 저장
        currentMaterial = new Material(originalMaterial); // 오리지널 Material을 복사한 새로운 Material 인스턴스 생성
        spriteRenderer.material = currentMaterial; // 복사본을 현재 Material로 설정
    }

    public void ShaderOn()
    {
        float currentSplitValue = currentMaterial.GetFloat("_SplitValue");
        currentSplitValue -= decreaseSpeed * Time.deltaTime;

        currentMaterial.SetFloat("_SplitValue", currentSplitValue);

    }
}
