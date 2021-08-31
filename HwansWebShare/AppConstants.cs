using System;

static class AppConstants
{
    public const string AppName = "HwansWebShare";

    public static readonly string AppDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + AppName;

    public static readonly string HtmlFolderPath = String.Concat(AppDataFolderPath, "\\Html");
}