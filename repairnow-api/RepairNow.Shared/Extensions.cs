namespace RepairNow.Shared;

public static class Extensions

{

    public static string ReplaceBlankByUndercores(this string str)

    {

        return str.Replace(" ", "_");

    }

}