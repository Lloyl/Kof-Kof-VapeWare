using UnityEngine;

public static class Constants
{
    public const string MANAGEMENT_SCENE = "Management";
    public const string MENU_SCENE       = "Menu";

    public const int WIN_SCORE = 10;

    public static readonly Color WIN_COLOR  = new(0.43f, 0.83f, 0.3f, 1f);
    public static readonly Color LOSE_COLOR = new(0.83f, 0.3f, 0.3f, 1f);

    public const string TAG_BC_SAFEBOX = "BCSafeBox";
    public const string TAG_CLOPE      = "Clope";
}

public enum Audio
{
    // BabyClope
    BC_TIR,
    BC_WIN,
    BC_LOSE,

    // Saut de clope
    SC_AMBIANCE,
    SC_WIN,
    SC_LOSE,
}