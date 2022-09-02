namespace Ex05.WindowsAppUI
{
    internal class UserInfoValidations
    {
        public static bool CheckIfValidName(string i_Name)
        {
            bool isValidFlag = true;
            for (int i = 0; i < i_Name.Length; i++)
            {
                if (!char.IsLetter(i_Name[i]))
                {
                    isValidFlag = false;
                    break;
                }
            }

            return i_Name != string.Empty && isValidFlag;
        }
    }
}
