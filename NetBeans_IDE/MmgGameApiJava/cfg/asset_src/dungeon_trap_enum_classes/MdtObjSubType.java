package game.jam.DungeonTrap;

/**
 * An enumeration that describes an object sub type.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 10/30/2020
 */
public enum MdtObjSubType {
    NONE,

    ITEM_BOMB,
    ITEM_CHEST,
    ITEM_COINS,
    ITEM_POTION,
    
    WEAPON_AXE,
    WEAPON_SPEAR,
    WEAPON_SWORD,

    MODIFIER_DOUBLE_POINTS,    
    MODIFIER_PLAYER_INVINCIBLE,
    MODIFIER_ONE_SHOT_KILLS,

    ENEMY_BANSHEE,
    ENEMY_DEMON,
    ENEMY_WARLOCK,
    
    PLAYER_1,
    PLAYER_2,

    OBJECT_BARREL,
    OBJECT_TABLE_1,
    OBJECT_TABLE_2,    
    OBJECT_TORCH,

    UI_HEALTH_BAR,
    UI_POINTS
}