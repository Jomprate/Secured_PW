using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdviceDeletePassword : MonoBehaviour
{
    public static AdviceDeletePassword Instance;
    
    [SerializeField] private Button deleteBtn;
    [SerializeField] private Button returnBtn;

    private int mIndexNumber;
    private GameObject goToDelete;
    
    public void Initialize()
    {
        Instance = this;
        deleteBtn.onClick.AddListener(() => { DeletePw(); });
        returnBtn.onClick.AddListener(() => {GameManager.instance.ChangeGameStateE(Enums.AppStates.PasswordCont);});
    }

    public void SetPasswordInfo(int index, GameObject go)
    {
        mIndexNumber = index;
        goToDelete = go;
    }

    private void DeletePw()
    {
        DataSaveManager.instance.DeletePassword(mIndexNumber);
        Destroy(goToDelete);
        GameManager.instance.ChangeGameStateE(Enums.AppStates.PasswordCont);
    }
}
