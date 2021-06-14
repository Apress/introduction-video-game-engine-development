package net.middlemind.MmgGameApiJava.MmgBase;

import java.awt.Image;
import java.util.Hashtable;
import javax.sound.sampled.Clip;

/**
 * A local class that provides static access to a media tracker and image cache.
 * Created by Middlemind Games 07/29/2015
 * 
 * @author Victor G. Brusca
 */
@SuppressWarnings("UseOfObsoleteCollectionType")
public class MmgMediaTracker {
    
    /**
     * Hashtable used to track loading of image resources, in a central place.
     */
    public static Hashtable<String, Image> cacheBmp = new Hashtable<String, Image>();
    
    /**
     * Hashtable used to track loading of sound resources, in a central place.
     */
    public static Hashtable<String, Clip> cacheSound = new Hashtable<String, Clip>();
    
    /**
     * A static boolean indicating existing cached objects should be removed if they already exist and are being replaced.
     */
    public static boolean REMOVE_EXISTING = true;
        
    /**
     * Stores cached images by an unique id string and an image class.
     * 
     * @param key       The unique image id.
     * @param val       The image object to cache.
     */
    public static void CacheImage(String key, Image val) {
        if(MmgMediaTracker.HasBmpKey(key) == false) {
            MmgMediaTracker.cacheBmp.put(key, val);
        }else {
            if(MmgMediaTracker.REMOVE_EXISTING == true) {
                MmgMediaTracker.RemoveBmpByKey(key);
            }
            MmgMediaTracker.cacheBmp.put(key, val);
        }
    }
    
    /**
     * Stores cached sounds by an unique id string and an image class.
     * 
     * @param key       The unique sound id.
     * @param val       The sound object to cache.
     */
    public static void CacheSound(String key, Clip val) {
        if(MmgMediaTracker.HasSoundKey(key) == false) {
            MmgMediaTracker.cacheSound.put(key, val);
        }else {
            if(MmgMediaTracker.REMOVE_EXISTING == true) {
                MmgMediaTracker.RemoveSoundByKey(key);
            }
            MmgMediaTracker.cacheSound.put(key, val);
        }
    }    
    
    /**
     * Gets the size of the image, bitmap, object cache.
     * 
     * @return      The size of the image object cache.
     */
    public static int GetBmpCacheSize() {
        return cacheBmp.size();
    }
    
    /**
     * Gets the size of the sound object cache.
     * 
     * @return      The size of the sound object cache.
     */
    public static int GetSoundCacheSize() {
        return cacheSound.size();
    }    
    
    /**
     * Gets the value of the image cache entry for the given key.
     * 
     * @param key       The key under which the image was stored.
     * @return          An image object.
     */
    public static Image GetBmpValue(String key) {
        if(MmgMediaTracker.HasBmpKey(key) == true) {
            return MmgMediaTracker.cacheBmp.get(key);
        }else {
            return null;
        }
    }
    
    /**
     * Gets the value of the sound cache entry for the given key.
     * 
     * @param key       The key under which the sound was stored.
     * @return          A sound object.
     */
    public static Clip GetSoundValue(String key) {
        if(MmgMediaTracker.HasSoundKey(key) == true) {
            return MmgMediaTracker.cacheSound.get(key);
        }else {
            return null;
        }
    }
        
    /**
     * Returns true if the image cache hash table contains the given key.
     * 
     * @param key       The key to check existence for.
     * @return          True if the key exists in the image cache.
     */
    public static boolean HasBmpKey(String key) {
        if(MmgMediaTracker.cacheBmp.containsKey(key) == true) {
            return true;
        }else {
            return false;
        }
    }
    
    /**
     * Returns true if the sound cache hash table contains the given key.
     * 
     * @param key       The key to check existence for.
     * @return          True if the key exists in the image cache.
     */
    public static boolean HasSoundKey(String key) {
        if(MmgMediaTracker.cacheSound.containsKey(key) == true) {
            return true;
        }else {
            return false;
        }
    }    
    
    /**
     * Returns true if the image cache has the given value.
     * 
     * @param img       The image to check existence for.
     * @return          True if the image argument exists as a value in the image cache.
     */
    public static boolean HasBmpValue(Image img) {
        if(MmgMediaTracker.cacheBmp.containsValue(img) == true) {
            return true;
        }else {
            return false;
        }
    }
    
    /**
     * Returns true if the sound cache has the given value.
     * 
     * @param snd       The sound to check existence for.
     * @return          True if the sound argument exists as a value in the image cache.
     */
    public static boolean HasSoundValue(Clip snd) {
        if(MmgMediaTracker.cacheSound.containsValue(snd) == true) {
            return true;
        }else {
            return false;
        }
    }    
    
    /**
     * Removes an entry by key.
     * 
     * @param key       The key to use to remove a value for.
     * @return          Returns true if an entry was removed.
     */
    public static boolean RemoveBmpByKey(String key) {
        if(MmgMediaTracker.HasBmpKey(key) == true) {
            MmgMediaTracker.cacheBmp.remove(key);
            return true;
        }else {
            return false;
        }
    }
    
    /**
     * Removes an entry by key.
     * 
     * @param key       The key to use to remove a value for.
     * @return          Returns true if an entry was removed.
     */
    public static boolean RemoveSoundByKey(String key) {
        if(MmgMediaTracker.HasSoundKey(key) == true) {
            MmgMediaTracker.cacheSound.remove(key);
            return true;
        }else {
            return false;
        }
    }    
    
    /**
     * Removes an entry by key and value.
     * 
     * @param key       The key to use to remove an entry for.
     * @param img       The value to use to remove an entry for.
     * @return          Returns true if a key value pair was found and removed.
     */
    public static boolean RemoveBmpByKeyValue(String key, Image img) {
        if(MmgMediaTracker.HasBmpKey(key) == true) {
            MmgMediaTracker.cacheBmp.remove(key, img);
            return true;
        }else {
            return false;
        }
    }
    
    /**
     * Removes an entry by key and value.
     * 
     * @param key       The key to use to remove an entry for.
     * @param snd       The value to use to remove an entry for.
     * @return          Returns true if a key value pair was found and removed.
     */
    public static boolean RemoveSoundByKeyValue(String key, Clip snd) {
        if(MmgMediaTracker.HasSoundKey(key) == true) {
            MmgMediaTracker.cacheSound.remove(key, snd);
            return true;
        }else {
            return false;
        }
    }    
}