public enum ListenType
{
    ANY = 0,
    ON_PLAYER_DEATH,
    ON_ENEMY_DEATH,
    UPDATE_COUNT_TEXT,
    UPDATE_USER_INFO,
    UPDATE_AMMO
}

public enum UIType
{
    Unknow = 0,
    Screen = 1,
    Popup = 2,
    Notify = 3,
    Overlap = 4,
}

public enum AiStateID
{
    ChasePlayer,
    Death,
    Idle,
    Attack
}

public enum WeaponSlot
{
    Primary = 0,
    Secondary = 1,
    Submary = 2,
}
public enum WeaponType
{
    Laser = 0,
    Shotgun = 1,
    SMG = 2,
    Pistol = 3,
    Pistol1 = 4
}