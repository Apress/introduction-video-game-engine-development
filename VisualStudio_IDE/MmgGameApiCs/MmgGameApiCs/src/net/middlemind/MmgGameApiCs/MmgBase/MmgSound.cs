using System;
using Microsoft.Xna.Framework.Audio;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that wraps the underlying sound object. 
    /// Created by Middlemind Games 06/01/2005
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgSound
    {
        /// <summary>
        /// Centralized, unique sound id.
        /// </summary>
        private static int ID_SRC = 0;

        /// <summary>
        /// Volume for all sounds.
        /// </summary>
        public static float MMG_SOUND_GLOBAL_VOLUME = 0.65f;

        /// <summary>
        /// Unique sound id, integer form.
        /// </summary>
        private int id;

        /// <summary>
        /// Unique sound id string form.
        /// </summary>
        private string idStr;

        /// <summary>
        /// The lower level sound object.
        /// </summary>
        private SoundEffect sound;

        /// <summary>
        /// The volume set for this sound clip, based on the static class volume.
        /// </summary>
        private float usedVolume;

        /// <summary>
        /// The current set volume for this MmgSound object. 
        /// </summary>
        private float currentVolume;

        /// <summary>
        /// The current rate for this MmgSound object. 
        /// </summary>
        private float currentRate;

        //NOTES: Required for Monogame sound support.
        /// <summary>
        /// Sound effect class for audio support.
        /// </summary>
        private SoundEffectInstance soundInst;

        /// <summary>
        /// Constructor that sets the sound Clip value.
        /// </summary>
        /// <param name="se">The sound clip for this sounds object.</param>
        public MmgSound(SoundEffect se)
        {
            sound = se;
            soundInst = sound.CreateInstance();
            ApplyVolume();
            currentRate = 1.0f;
            SetId();
        }

        /// <summary>
        /// Constructor that sets the value of this class based on the attributes of the given argument.
        /// </summary>
        /// <param name="obj">The sound object to use as a basis for a new sound object.</param>
        public MmgSound(MmgSound obj)
        {
            sound = obj.GetSound();
            soundInst = sound.CreateInstance();
            ApplyVolume();
            currentRate = 1.0f;
            SetId();
        }

        /// <summary>
        /// Applies the current static volume to this sound clip.
        /// </summary>
        public virtual void ApplyVolume()
        {
            usedVolume = MmgSound.MMG_SOUND_GLOBAL_VOLUME;
            //vol = (FloatControl)sound.getControl(FloatControl.Type.MASTER_GAIN);
            //range = vol.getMaximum() - vol.getMinimum();
            //gain = (range * usedVolume) + vol.getMinimum();
            //vol.setValue(gain);
            //currentRate = usedVolume;
            currentVolume = usedVolume;
        }

        /// <summary>
        /// Applies the given rate, 0.0 - 1.0, to the sound clip.
        /// </summary>
        /// <param name="rate">The rate at which that sound clip is played, 0.0 - 1.0, where 1.0 is the maximum rate and 0 is no rate at all.</param>
        public virtual void ApplyRate(float rate)
        {
            //vol = (FloatControl)sound.getControl(FloatControl.Type.SAMPLE_RATE);
            //range = vol.getMaximum() - vol.getMinimum();
            //gain = (range * rate) + vol.getMinimum();
            //vol.setValue(gain);
            //currentRate = gain;
            currentRate = rate;
        }

        /// <summary>
        /// Gets the current rate for this MmgSound object.
        /// </summary>
        /// <returns>The current rate for this MmgSound object.</returns>
        public virtual float GetCurrentRate()
        {
            return currentRate;
        }

        /// <summary>
        /// Gets the current volume for this MmgSound object.
        /// </summary>
        /// <returns>The current volume for this MmgSound object.</returns>
        public virtual float GetCurrentVolume()
        {
            return currentVolume;
        }

        /// <summary>
        /// Sets the volume of the sound system.
        /// </summary>
        /// <param name="f">The volume to set for all sounds.</param>
        /// <returns>The current volume.</returns>
        public static float SetVolume(float f)
        {
            MMG_SOUND_GLOBAL_VOLUME = f;
            if (MMG_SOUND_GLOBAL_VOLUME > 1.0f)
            {
                MMG_SOUND_GLOBAL_VOLUME = 1.0f;
            }

            if (MMG_SOUND_GLOBAL_VOLUME < 0.1f)
            {
                MMG_SOUND_GLOBAL_VOLUME = 0f;
            }
            return MMG_SOUND_GLOBAL_VOLUME;
        }

        /// <summary>
        /// Gets a string version of the id.
        /// </summary>
        /// <returns>A string version of the id.</returns>
        public virtual string GetIdStr()
        {
            return idStr;
        }

        /// <summary>
        /// Gets an integer version of the id.
        /// </summary>
        /// <returns>An integer version of the id.</returns>
        public virtual int GetId()
        {
            return id;
        }

        /// <summary>
        /// Sets the unique sound id.
        /// </summary>
        private void SetId()
        {
            id = MmgSound.ID_SRC;
            idStr = (id + "");
            MmgSound.ID_SRC++;
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this object.</returns>
        public virtual MmgSound Clone()
        {
            return new MmgSound(sound);
        }

        /// <summary>
        /// Gets the lower level Clip object.
        /// </summary>
        /// <returns>The sound this class represents.</returns>
        public virtual SoundEffect GetSound()
        {
            return sound;
        }

        /// <summary>
        /// Sets the lower level Clip object.
        /// </summary>
        /// <param name="snd">The sound Clip wrapped by this class.</param>
        public virtual void SetSound(SoundEffect snd)
        {
            sound = snd;
            soundInst = sound.CreateInstance();
            ApplyVolume();
        }

        /// <summary>
        /// Starts playing this sound.
        /// </summary>
        public virtual void Play()
        {
            if (soundInst.State == SoundState.Playing)
            {
                soundInst.Stop();
            }

            if (usedVolume != MmgSound.MMG_SOUND_GLOBAL_VOLUME)
            {
                ApplyVolume();
            }

            soundInst.IsLooped = false;
            soundInst.Volume = currentVolume;
            soundInst.Pitch = currentRate;
            soundInst.Play();
        }

        /// <summary>
        /// Starts playing this sound with the given loop and rate values.
        /// </summary>
        /// <param name="loop">The loop variable used when playing this sound.</param>
        /// <param name="rate">The rate variable used when playing this sound.</param>
        public virtual void Play(int loop, float rate)
        {
            if (soundInst.State == SoundState.Playing)
            {
                soundInst.Stop();
            }

            if (usedVolume != MmgSound.MMG_SOUND_GLOBAL_VOLUME)
            {
                ApplyVolume();
            }

            if (rate >= 0f)
            {
                ApplyRate(rate);
            }

            if (loop <= 0)
            {
                soundInst.IsLooped = false;
            }
            else
            {
                soundInst.IsLooped = true;
            }
            soundInst.Volume = currentVolume;
            soundInst.Pitch = currentRate;
            soundInst.Play();
        }

        /// <summary>
        /// Stops playing this sound.
        /// </summary>
        public virtual void Stop()
        {
            soundInst.Stop();

            if (usedVolume != MmgSound.MMG_SOUND_GLOBAL_VOLUME)
            {
                ApplyVolume();
            }
        }

        /// <summary>
        /// Converts the MmgSound object into a string representation.
        /// </summary>
        /// <returns>The string representation of this class.</returns>
        public virtual string ApiToString()
        {
            return "MmgSound: " + idStr + " Clip Length MS: " + (sound.Duration.TotalMilliseconds);
        }

        /// <summary>
        /// A class method that tests for equality based on the contained sound clip and the sound clip of the comparison object.
        /// </summary>
        /// <param name="obj">The MmgSound object to compare.</param>
        /// <returns>A boolean indicating if the object instance is equal to the argument object instance.</returns>
        public virtual bool ApiEquals(MmgSound obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            bool ret = false;
            if (
                ((obj.GetSound() == null && GetSound() == null) || (obj.GetSound() != null && GetSound() != null && obj.GetSound().Equals(GetSound())))
            )
            {
                ret = true;
            }
            return ret;
        }
    }
}
