package net.middlemind.MmgGameApiJava.MmgBase;

import javax.sound.sampled.Clip;
import javax.sound.sampled.FloatControl;

/**
 * Class that wraps the underlying sound object. 
 * Created by Middlemind Games 06/01/2005
 *
 * @author Victor G. Brusca
 */
public class MmgSound {
    
    /**
     * Centralized, unique sound id.
     */
    private static int ID_SRC = 0;

    /**
     * Volume for all sounds.
     */
    public static float MMG_SOUND_GLOBAL_VOLUME = 0.65f;

    /**
     * Unique sound id, integer form.
     */
    private int id;

    /**
     * Unique sound id string form.
     */
    private String idStr;

    /**
     * The lower level sound object.
     */
    private Clip sound;

    /**
     * The volume set for this sound clip, based on the static class volume.
     */
    private float usedVolume;
    
    /**
     * A private class field to track the range of volume for the given sound clip.
     */
    private float range;
    
    /**
     * A private class field to track the gain or volume used to set the audio clip's volume.
     */
    private float gain;
    
    /**
     * A Java internal class that is used to adjust the volume of the given sound clip.
     */
    private FloatControl vol;
    
    /**
     * The current set volume for this MmgSound object.
     */
    private float currentVolume;
    
    /**
     * The current rate for this MmgSound object.
     */
    private float currentRate;
    
    /**
     * Constructor that sets the sound Clip value.
     *
     * @param se        The sound clip for this sounds object.
     * @see             Clip
     */
    public MmgSound(Clip se) {
        sound = se;        
        ApplyVolume();
        currentRate = 1.0f;        
        SetId();
    }

    /**
     * Constructor that sets the value of this class based on the attributes of
     * the given argument.
     *
     * @param obj    The sound object to use as a basis for a new sound object.
     */
    public MmgSound(MmgSound obj) {
        sound = obj.GetSound();
        ApplyVolume();
        currentRate = 1.0f;
        SetId();
    }

    /**
     * Applies the current static volume to this sound clip.
     */
    public void ApplyVolume() {
        usedVolume = MmgSound.MMG_SOUND_GLOBAL_VOLUME;        
        vol = (FloatControl) sound.getControl(FloatControl.Type.MASTER_GAIN);        
        range = vol.getMaximum() - vol.getMinimum();
        gain = (range * usedVolume) + vol.getMinimum();
        vol.setValue(gain);
        currentVolume = gain;
    }
    
    /**
     * Applies the given rate, 0.0 - 1.0, to the sound clip.
     * 
     * @param rate  The rate at which that sound clip is played, 0.0 - 1.0, where 1.0 is the maximum rate and 0 is no rate at all.
     */
    public void ApplyRate(float rate) {
        vol = (FloatControl) sound.getControl(FloatControl.Type.SAMPLE_RATE);        
        range = vol.getMaximum() - vol.getMinimum();
        gain = (range * rate) + vol.getMinimum();
        vol.setValue(gain);  
        currentRate = gain;
    }
    
    /**
     * Gets the current rate for this MmgSound object.
     * 
     * @return      The current rate for this MmgSound object. 
     */
    public float GetCurrentRate() {
        return currentRate;
    }
    
    /**
     * Gets the current volume for this MmgSound object.
     * 
     * @return      The current volume for this MmgSound object. 
     */
    public float GetCurrentVolume() {
        return currentVolume;
    }
        
    /**
     * Sets the volume of the sound system.
     *
     * @param f     The volume to set for all sounds.
     * @return      The current volume.
     */
    public static float SetVolume(float f) {
        MMG_SOUND_GLOBAL_VOLUME = f;
        if (MMG_SOUND_GLOBAL_VOLUME > 1.0f) {
            MMG_SOUND_GLOBAL_VOLUME = 1.0f;
        }

        if (MMG_SOUND_GLOBAL_VOLUME < 0.1f) {
            MMG_SOUND_GLOBAL_VOLUME = 0f;
        }
        return MMG_SOUND_GLOBAL_VOLUME;
    }

    /**
     * Gets a string version of the id.
     *
     * @return      A string version of the id.
     */
    public String GetIdStr() {
        return idStr;
    }

    /**
     * Gets an integer version of the id.
     *
     * @return      An integer version of the id.
     */
    public int GetId() {
        return id;
    }
    
    /**
     * Sets the unique sound id.
     */
    private void SetId() {
        id = MmgSound.ID_SRC;
        idStr = (id + "");
        MmgSound.ID_SRC++;
    }

    /**
     * Creates a basic clone of this class.
     *
     * @return      A clone of this object.
     */
    public MmgSound Clone() {
        return new MmgSound(sound);
    }

    /**
     * Gets the lower level Clip object.
     *
     * @return      The sound this class represents.
     * @see         Clip
     */
    public Clip GetSound() {
        return sound;
    }

    /**
     * Sets the lower level Clip object.
     * 
     * @param snd   The sound Clip wrapped by this class.
     */
    public void SetSound(Clip snd) {
        sound = snd;
        ApplyVolume();
    }
    
    /**
     * Starts playing this sound.
     */
    public void Play() {
        if(sound.isRunning()) {
            sound.stop();
        }

        if(usedVolume != MmgSound.MMG_SOUND_GLOBAL_VOLUME) {
            ApplyVolume();
        }        

        sound.setFramePosition(0);        
        sound.loop(0);
        sound.start();
    }

    /**
     * Starts playing this sound with the given loop and rate values.
     *
     * @param loop      The loop variable used when playing this sound.
     * @param rate      The rate variable used when playing this sound.
     */
    public void Play(int loop, float rate) {
        if(sound.isRunning()) {
            sound.stop();
        }
        
        if(usedVolume != MmgSound.MMG_SOUND_GLOBAL_VOLUME) {
            ApplyVolume();
        }
        
        if(rate >= 0f) {
            ApplyRate(rate);
        }
        
        sound.setFramePosition(0); 
        sound.loop(loop);
        sound.start();        
    }

    /**
     * Stops playing this sound.
     */
    public void Stop() {
        sound.stop();
        
        if(usedVolume != MmgSound.MMG_SOUND_GLOBAL_VOLUME) {
            ApplyVolume();
        }        
    }
    
    /**
     * Converts the MmgSound object into a string representation.
     * 
     * @return      The string representation of this class.
     */
    public String ApiToString() {
        return "MmgSound: " + idStr + " Clip Length MS: " + (sound.getMicrosecondLength() / 1000);
    }
    
    /**
     * A class method that tests for equality based on the contained sound clip and the sound clip of the
     * comparison object.
     * 
     * @param obj     The MmgSound object to compare.
     * @return      A boolean indicating if the object instance is equal to the argument object instance. 
     */
    public boolean ApiEquals(MmgSound obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
        
        boolean ret = false;
        if (
            ((obj.GetSound() == null && GetSound() == null) || (obj.GetSound() != null && GetSound() != null && obj.GetSound().equals(GetSound())))
        ) {
            ret = true;
        }
        return ret;
    }
}