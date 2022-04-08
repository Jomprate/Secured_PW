using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public interface IAdvice 
{
    
    InputManager InputManager { get; set; }
    TextMeshProUGUI Title { get; set; }
    TextMeshProUGUI Message { get; set; }
   
    Button ContinueBtn { get; set; }
    Button ReturnBtn { get; set; }

    void EnableScript(bool enable);
    void Continue();
    void Return();

}

public interface UsePW
{
    void CheckInsertedPassword();
    bool RequirePw { get; set; }
    TMP_InputField InputFieldPw { get; set; }
}
