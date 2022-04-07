using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(BlinkRed))]
public class UserInfo : MonoBehaviour
{
    public static UserInfo instance;
    private BlinkRed _blinkRed;
    
    public bool UserAccepted { get; private set; }

    [SerializeField] private TMP_InputField userNameTMP;
    [SerializeField] private TMP_InputField passwordTMP;
    [SerializeField] private Button encryptBtn,usePwBtn;
    
    private Image _encryptImage, _usePasswordImage;
    
    Color redC = Color.red;
    Color greenC = Color.green;

    public User newUser;


    public void Initialize()
    {
        instance = this;
        _blinkRed = GetComponent<BlinkRed>();
        
        _encryptImage = encryptBtn.image;
        _usePasswordImage = usePwBtn.image;
        
        ResetConsole();
        
        
        encryptBtn.onClick.AddListener(() => { ChangeEncryptState();});
        usePwBtn.onClick.AddListener(() => { ChangeUsePasswordState();});
    }
    
    public void CheckNewUserData() {
        switch (USIN_CheckNewUserData.CheckData(newUser.UsePassword,userNameTMP,passwordTMP,_blinkRed))
        {
            case true: UserAccepted = true; SetUserInfo();
                break;
            case false: UserAccepted = false;
                break;
        }
    }
    
    
    public void ActiveOrUnActivePw() {
        passwordTMP.interactable = newUser.UsePassword;
        if (passwordTMP.interactable == false)
        {
            passwordTMP.text = string.Empty;
        }
    }

    private void ChangeEncryptState() {
        newUser.UseEncryption = !newUser.UseEncryption;
        _encryptImage.color = newUser.UseEncryption ? greenC : redC;
    }

    private void ChangeUsePasswordState() {
        newUser.UsePassword = !newUser.UsePassword;
        _usePasswordImage.color = newUser.UsePassword ? greenC : redC;
        
        ActiveOrUnActivePw();
    }

    private void SetUserInfo() {
        newUser.UserName = userNameTMP.text;
        newUser.UserPassword = passwordTMP.text;
    }
    
    public void ResetConsole()
    {
        newUser.UserId = 0;
        newUser.UserAccessPath = string.Empty;
        newUser.UserName = string.Empty;
        newUser.UserPassword = string.Empty;
        newUser.UseEncryption = false;
        newUser.UsePassword = false;

        passwordTMP.interactable = false;
        userNameTMP.text = string.Empty;
        passwordTMP.text = string.Empty;
        _encryptImage.color = redC;
        _usePasswordImage.color = redC;
    }
    
}
