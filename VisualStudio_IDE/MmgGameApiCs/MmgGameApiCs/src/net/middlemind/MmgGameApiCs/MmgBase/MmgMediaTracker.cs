using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A local class that provides static access to a media tracker and image cache.
    /// Created by Middlemind Games 07/29/2015
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "<Pending>")]
    public class MmgMediaTracker
    {
        /// <summary>
        /// Hashtable used to track loading of image resources, in a central place.
        /// </summary>
        public static Dictionary<string, Texture2D> cacheBmp = new Dictionary<string, Texture2D>();

        /// <summary>
        /// Hashtable used to track loading of sound resources, in a central place.
        /// </summary>
        public static Dictionary<string, SoundEffect> cacheSound = new Dictionary<string, SoundEffect>();

        /// <summary>
        /// A static boolean indicating existing cached objects should be removed if they already exist and are being replaced.
        /// </summary>
        public static bool REMOVE_EXISTING = true;

        /// <summary>
        /// Stores cached images by an unique id string and an image class.
        /// </summary>
        /// <param name="key">The unique image id.</param>
        /// <param name="val">The image object to cache.</param>
        public static void CacheImage(string key, Texture2D val)
        {
            if (MmgMediaTracker.HasBmpKey(key) == false)
            {
                MmgMediaTracker.cacheBmp.Add(key, val);
            }
            else
            {
                if (MmgMediaTracker.REMOVE_EXISTING == true)
                {
                    MmgMediaTracker.RemoveBmpByKey(key);
                }
                MmgMediaTracker.cacheBmp.Add(key, val);
            }
        }

        /// <summary>
        /// Stores cached sounds by an unique id string and an image class.
        /// </summary>
        /// <param name="key">The unique sound id.</param>
        /// <param name="val">The sound object to cache.</param>
        public static void CacheSound(string key, SoundEffect val)
        {
            if (MmgMediaTracker.HasSoundKey(key) == false)
            {
                MmgMediaTracker.cacheSound.Add(key, val);
            }
            else
            {
                if (MmgMediaTracker.REMOVE_EXISTING == true)
                {
                    MmgMediaTracker.RemoveSoundByKey(key);
                }
                MmgMediaTracker.cacheSound.Add(key, val);
            }
        }

        /// <summary>
        /// Gets the size of the image, bitmap, object cache.
        /// </summary>
        /// <returns>The size of the image object cache.</returns>
        public static int GetBmpCacheSize()
        {
            return cacheBmp.Count;
        }

        /// <summary>
        /// Gets the size of the sound object cache.
        /// </summary>
        /// <returns>The size of the sound object cache.</returns>
        public static int GetSoundCacheSize()
        {
            return cacheSound.Count;
        }

        /// <summary>
        /// Gets the value of the image cache entry for the given key.
        /// </summary>
        /// <param name="key">The key under which the image was stored.</param>
        /// <returns>An image object.</returns>
        public static Texture2D GetBmpValue(string key)
        {
            if (MmgMediaTracker.HasBmpKey(key) == true)
            {
                return MmgMediaTracker.cacheBmp[key];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the value of the sound cache entry for the given key.
        /// </summary>
        /// <param name="key">The key under which the sound was stored.</param>
        /// <returns>A sound object.</returns>
        public static SoundEffect GetSoundValue(string key)
        {
            if (MmgMediaTracker.HasSoundKey(key) == true)
            {
                return MmgMediaTracker.cacheSound[key];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns true if the image cache hash table contains the given key.
        /// </summary>
        /// <param name="key">The key to check existence for.</param>
        /// <returns>True if the key exists in the image cache.</returns>
        public static bool HasBmpKey(string key)
        {
            if (MmgMediaTracker.cacheBmp.ContainsKey(key) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true if the sound cache hash table contains the given key.
        /// </summary>
        /// <param name="key">The key to check existence for.</param>
        /// <returns>True if the key exists in the image cache.</returns>
        public static bool HasSoundKey(string key)
        {
            if (MmgMediaTracker.cacheSound.ContainsKey(key) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true if the image cache has the given value.
        /// </summary>
        /// <param name="img">The image to check existence for.</param>
        /// <returns>True if the image argument exists as a value in the image cache.</returns>
        public static bool HasBmpValue(Texture2D img)
        {
            if (MmgMediaTracker.cacheBmp.ContainsValue(img) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true if the sound cache has the given value.
        /// </summary>
        /// <param name="snd">The sound to check existence for.</param>
        /// <returns>True if the sound argument exists as a value in the image cache.</returns>
        public static bool HasSoundValue(SoundEffect snd)
        {
            if (MmgMediaTracker.cacheSound.ContainsValue(snd) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes an entry by key.
        /// </summary>
        /// <param name="key">The key to use to remove a value for.</param>
        /// <returns>Returns true if an entry was removed.</returns>
        public static bool RemoveBmpByKey(String key)
        {
            if (MmgMediaTracker.HasBmpKey(key) == true)
            {
                MmgMediaTracker.cacheBmp.Remove(key);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes an entry by key.
        /// </summary>
        /// <param name="key">The key to use to remove a value for.</param>
        /// <returns>Returns true if an entry was removed.</returns>
        public static bool RemoveSoundByKey(String key)
        {
            if (MmgMediaTracker.HasSoundKey(key) == true)
            {
                MmgMediaTracker.cacheSound.Remove(key);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes an entry by key and value.
        /// </summary>
        /// <param name="key">The key to use to remove an entry for.</param>
        /// <param name="img">The value to use to remove an entry for.</param>
        /// <returns>Returns true if a key value pair was found and removed.</returns>
        public static bool RemoveBmpByKeyValue(String key, Texture2D img)
        {
            if (MmgMediaTracker.HasBmpKey(key) == true)
            {
                MmgMediaTracker.cacheBmp.Remove(key, out img);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes an entry by key and value.
        /// </summary>
        /// <param name="key">The key to use to remove an entry for.</param>
        /// <param name="snd">The value to use to remove an entry for.</param>
        /// <returns>Returns true if a key value pair was found and removed.</returns>
        public static bool RemoveSoundByKeyValue(String key, SoundEffect snd)
        {
            if (MmgMediaTracker.HasSoundKey(key) == true)
            {
                MmgMediaTracker.cacheSound.Remove(key, out snd);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}