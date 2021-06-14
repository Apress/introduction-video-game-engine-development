package net.java.games.input.test;

import java.util.Hashtable;
import javax.swing.JFrame;
import net.java.games.input.Component;
import net.java.games.input.Controller;
import net.java.games.input.ControllerEnvironment;
import net.java.games.input.ControllerEvent;
import net.java.games.input.ControllerListener;

public class ControllerReadTest extends JFrame {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        new Thread(new Runnable() {
            public void run() {
                Controller[] ca = ControllerEnvironment.getDefaultEnvironment().getControllers();
                Hashtable<String, Float> currentData = new Hashtable<String, Float>();                    
                int z = 20;                    

                ControllerEnvironment.getDefaultEnvironment().addControllerListener(new ControllerListener() {
                    @Override
                    public void controllerRemoved(ControllerEvent ev) {
                        System.out.println("ControllerRemoved");
                    }

                    @Override
                    public void controllerAdded(ControllerEvent ev) {
                        System.out.println("ControllerAdded");
                    }
                });

                while(z > 0) {
                    for(int i = 0; i < ca.length; i++) {
                        if(ca[i].getType().toString().toLowerCase().equals("gamepad")) {
                            ca[i].poll();

                            /* Get the name of the controller */
                            //System.out.println("Count:" + z);
                            //System.out.println("");
                            //System.out.println(ca[i].getName());        
                            //System.out.println("Type: " + ca[i].getType().toString());

                            /* Get this controllers components (buttons and axis) */
                            Component[] components = ca[i].getComponents();
                            System.out.println("GamePad Index: " + i + " Component Count: " + components.length);
                            for(int j = 0; j < components.length; j++) {
                                if(currentData.containsKey(components[j].getName()) == false) {
                                    currentData.put(components[j].getName(), new Float(components[j].getPollData()));
                                    System.out.println("Component " + j + ": " + components[j].getName());
                                    System.out.println("\t\tIdentifier: " + components[j].getIdentifier().getName());
                                    System.out.println("\t\tIsAnalog: " + components[j].isAnalog());
                                    System.out.println("\t\tIsRelative: " + components[j].isRelative());
                                    System.out.println("\t\tData: " + components[j].getPollData());

                                } else {
                                    Float val = currentData.get(components[j].getName());
                                    if(val.floatValue() != components[j].getPollData()) {
                                        System.out.println("Component " + j + ": " + components[j].getName());
                                        System.out.println("\t\tIdentifier: " + components[j].getIdentifier().getName());
                                        System.out.println("\t\tIsAnalog: " + components[j].isAnalog());
                                        System.out.println("\t\tIsRelative: " + components[j].isRelative());
                                        System.out.println("\t\tData: " + components[j].getPollData());
                                    }

                                }

                            }
                        }
                    }

                    try {
                        Thread.sleep(1000);
                    }catch(Exception e) {

                    }

                    z--;
                }
            }
        }).start();
    }
}
