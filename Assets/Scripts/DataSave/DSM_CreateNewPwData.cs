public static class DSM_CreateNewPwData {
    public static PasswordData CreateNewPasswordData(SaveDataObject saveDataObject) {
        var createNewPassword = CreateNewPassword.Instance;
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
