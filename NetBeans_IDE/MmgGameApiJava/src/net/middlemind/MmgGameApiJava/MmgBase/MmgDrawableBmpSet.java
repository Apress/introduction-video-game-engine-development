package net.middlemind.MmgGameApiJava.MmgBase;

import java.awt.Graphics2D;
import java.awt.image.BufferedImage;

/**
 * A class the hold the objects necessary to handle creation of a drawable bitmap.
 * Created by Middlemind Games 03/10/2020
 * 
 * @author Victor G. Brusca
 */
public class MmgDrawableBmpSet {
    
    /**
     * A lower level Java BufferedImage used for custom image creation and drawing.
     */
    public BufferedImage buffImg;
    
    /**
     * A lower level Java 2D graphics object that handles drawing basic shapes, objects to a BufferedImage.
     */
    public Graphics2D graphics;
    
    /**
     * An MmgApi level object that wraps the lower level Java graphics API and allows for drawing basic shapes and objects.
     */
    public MmgPen p;
    
    /**
     * An MmgApi level object that wraps Java graphics objects and can be used to display the drawn shapes and objects.
     */
    public MmgBmp img;
}