public static class DSM_CreateNewPwData {
    public static PasswordData CreateNewPasswordData(SaveDataObject saveDataObject) {
        var createNewPassword = CreateNewPassword.instance;
        PasswordData data = new PasswordData(
            createNewPassword.PasswordId,
            createNewPassword.Email,
            createNewPassword.UserName,
            createNewPassword.Password,
            createNewPassword.Description
        );
        return data;
    }
}
